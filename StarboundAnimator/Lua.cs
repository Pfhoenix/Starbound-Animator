using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace StarboundAnimator
{
	public enum SymbolType { None = 0, Symbol, CommentSingle, CommentBlockStart, CommentText, BlockEnd, Keyword, LiteralNumber, LiteralString, LiteralStringText, Variable, Function, Table }

	public class LuaSymbol
	{
		public string Text;
		public SymbolType Type;

		public LuaSymbol() { }

		public LuaSymbol(string text, SymbolType type)
		{
			Text = text;
			Type = type;
		}
	}

	public class LuaFunction : LuaSymbol
	{
		public List<string> Parameters = new List<string>();

		public LuaFunction() { }

		public LuaFunction(string text) : base(text, SymbolType.Function)
		{
		}

		/*public override void ValidateContext()
		{
		}*/
	}

	public class LuaTable : LuaSymbol
	{
		public List<LuaSymbol> Variables = new List<LuaSymbol>();
		public List<LuaFunction> Functions = new List<LuaFunction>();

		public LuaTable() { }

		public LuaTable(string text) : base(text, SymbolType.Table)
		{
		}
	}

	public class LuaScriptAsset : Asset
	{
		[NonSerialized]
		public new const string FileExtension = ".lua";

		public LuaScript Script;

		public LuaScriptAsset(Asset a)
		{
			Source = a.Source;
			Filename = a.Filename;
			FilePath = a.FilePath;
			Script = LuaScript.FromText(Source);
		}

		public new static LuaScriptAsset LoadFromFile(string path)
		{
			LuaScriptAsset lsa = new LuaScriptAsset(Asset.LoadFromFile(path));

			return lsa;
		}
	}

	public class LuaScript
	{
		[NonSerialized]
		public LuaTable Self = new LuaTable("self");
		public List<List<LuaSymbol>> Symbols = new List<List<LuaSymbol>>();

		public LuaScript() { }

		public static LuaScript FromFile(string filepath)
		{
			if (!File.Exists(filepath)) return null;
			string[] lines = File.ReadAllLines(filepath);
			return FromSourceLines(lines);
		}

		public static LuaScript FromText(string source)
		{
			string ns = source.Replace("\r", "");
			string[] lines = source.Split(new char[] { '\n' });
			return FromSourceLines(lines);
		}

		static LuaSymbol ProcessWord(string w)
		{
			// this is where we would sort out exactly what word is, i.e. keyword, global table, table, variable, function, whatever
			LuaSymbol ls = Lua.GetLuaKeywordFor(w);
			if (ls == null) ls = new LuaSymbol(w, SymbolType.Variable);

			return ls;
		}

		public static LuaScript FromSourceLines(string[] lines)
		{
			LuaScript script = new LuaScript();

			LuaSymbol currentsymbol = null;
			bool literalstring = false;
			bool commenting = false;
			foreach (string line in lines)
			{
				List<LuaSymbol> symline = new List<LuaSymbol>();
				string cur = "";
				for (int i = 0; i < line.Length; i++)
				{
					char c = line[i];

					if (literalstring || commenting)
					{
						int j = line.IndexOf("]]", i);
						if (j > -1)
						{
							symline.Add(new LuaSymbol(line.Substring(i, j - i), literalstring ? SymbolType.LiteralStringText : SymbolType.CommentText));
							symline.Add(Lua.GetLuaSymbolFor("]]"));
							i = j;
							literalstring = commenting = false;
							continue;
						}
						else
						{
							symline.Add(new LuaSymbol(line, literalstring ? SymbolType.LiteralStringText : SymbolType.CommentText));
							break;
						}
					}
					else if (currentsymbol != null)
					{
						cur += c;
						LuaSymbol ls = Lua.GetLuaSymbolFor(cur);
						if (ls != null)
						{
							currentsymbol = ls;
							continue;
						}

						if (currentsymbol.Type == SymbolType.CommentSingle)
						{
							symline.Add(new LuaSymbol(currentsymbol.Text, SymbolType.CommentSingle));
							symline.Add(new LuaSymbol(line.Substring(i), SymbolType.CommentText));
							currentsymbol = null;
							break;
						}
						else if (currentsymbol.Type == SymbolType.CommentBlockStart)
						{
							symline.Add(currentsymbol);
							currentsymbol = null;
							int j = line.IndexOf("]]", i);
							if (j > -1)
							{
								symline.Add(new LuaSymbol(line.Substring(i, j - i), SymbolType.CommentText));
								symline.Add(Lua.GetLuaSymbolFor("]]"));
								i = j + 1;
								cur = "";
								continue;
							}
							else
							{
								symline.Add(new LuaSymbol(line.Substring(i), SymbolType.CommentText));
								commenting = true;
								break;
							}
						}
						else if (currentsymbol.Type == SymbolType.LiteralString)
						{
							symline.Add(currentsymbol);
							if (currentsymbol.Text == "[[")
							{
								currentsymbol = null;
								cur = "";
								int j = line.IndexOf("]]", i);
								if (j > -1)
								{
									symline.Add(new LuaSymbol(line.Substring(i, j - i), SymbolType.LiteralStringText));
									symline.Add(Lua.GetLuaSymbolFor("]]"));
									i = j + 1;
									continue;
								}
								else
								{
									symline.Add(new LuaSymbol(line.Substring(i), SymbolType.LiteralStringText));
									literalstring = true;
									break;
								}
							}
							else
							{
								int j = line.IndexOf(currentsymbol.Text, i);
								symline.Add(new LuaSymbol(j > -1 ? line.Substring(i, j - i) : line.Substring(i), SymbolType.LiteralStringText));
								symline.Add(currentsymbol);
								currentsymbol = null;
								cur = "";
								if (i < j)
								{
									i = j;
									continue;
								}
								else break;
							}
						}
						else if (currentsymbol.Type == SymbolType.Symbol)
						{
							symline.Add(currentsymbol);
							currentsymbol = null;
							cur = "";
							i--;
							continue;
						}
					}
					else if (Lua.IsNumber(c))
					{
						int j = i + 1;
						if ((j < line.Length) && (line[j] == 'x')) j++;
						for (; j < line.Length; j++)
						{
							if (!Lua.IsNumber(line[j]) && (line[j] != '.'))
							{
								symline.Add(new LuaSymbol(line.Substring(i, j - i), SymbolType.LiteralNumber));
								i = j - 1;
								break;
							}
						}
						if (i == j - 1) continue;
						symline.Add(new LuaSymbol(line.Substring(i), SymbolType.LiteralNumber));
						break;
					}
					else if (Lua.IsSpacer(c))
					{
						int j = i + 1;
						for (; j < line.Length; j++)
						{
							if (!Lua.IsSpacer(line[j]))
							{
								symline.Add(new LuaSymbol(line.Substring(i, j - i), SymbolType.None));
								i = j - 1;
								break;
							}
						}
						if (i == j - 1) continue;
						symline.Add(new LuaSymbol(line.Substring(i), SymbolType.None));
						continue;
					}
					else
					{
						cur = c.ToString();
						currentsymbol = Lua.GetLuaSymbolFor(cur);
						if (currentsymbol != null) continue;
						bool done = false;
						for (int j = i + 1; j < line.Length; j++)
						{
							if (!Lua.IsSpacer(line[j]) && !Lua.IsNumber(line[j]))
							{
								currentsymbol = Lua.GetLuaSymbolFor(line[j].ToString());
								if (currentsymbol == null) continue;
								else cur = line[j].ToString();
							}

							symline.Add(ProcessWord(line.Substring(i, j - i)));
							if (currentsymbol != null) i = j;
							else i = j - 1;
							done = true;
							break;
						}

						if (!done)
						{
							symline.Add(ProcessWord(line.Substring(i)));
							break;
						}
					}
				}

				if (currentsymbol != null)
				{
					symline.Add(currentsymbol);
					currentsymbol = null;
				}

				script.Symbols.Add(symline);
			}

			return script;
		}
	}

	public class LuaGlobalDefinition
	{
		public string Name = "";
		public List<LuaTable> Tables = new List<LuaTable>();

		public LuaGlobalDefinition() { }

		public static LuaGlobalDefinition Load(string defname)
		{
			try
			{
				XmlSerializer xml = new XmlSerializer(typeof(LuaGlobalDefinition));
				FileStream fs = File.OpenRead(Path.Combine(Path.Combine(Globals.AppPath, LuaGlobalDefinitionEditor.DefinitionsPath), defname));
				LuaGlobalDefinition lgd = xml.Deserialize(fs) as LuaGlobalDefinition;
				fs.Close();
				return lgd;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public void Save()
		{
			try
			{
				XmlSerializer xml = new XmlSerializer(typeof(LuaGlobalDefinition));
				string dp = Path.Combine(Globals.AppPath, LuaGlobalDefinitionEditor.DefinitionsPath);
				Directory.CreateDirectory(dp);
				FileStream fs = File.OpenWrite(Path.Combine(dp, Name + ".xml"));
				xml.Serialize(fs, this);
				fs.Flush();
				fs.Close();
			}
			catch (Exception e) { }
		}
	}

	public class Lua
	{
		static List<LuaSymbol> Keywords = new List<LuaSymbol>()
		{
			new LuaSymbol("and", SymbolType.Keyword),
			new LuaSymbol("break", SymbolType.Keyword),
			new LuaSymbol("do", SymbolType.Keyword),
			new LuaSymbol("else", SymbolType.Keyword),
			new LuaSymbol("elseif", SymbolType.Keyword),
			new LuaSymbol("end", SymbolType.Keyword),
			new LuaSymbol("false", SymbolType.Keyword),
			new LuaSymbol("for", SymbolType.Keyword),
			new LuaSymbol("function", SymbolType.Keyword),
			new LuaSymbol("if", SymbolType.Keyword),
			new LuaSymbol("in", SymbolType.Keyword),
			new LuaSymbol("local", SymbolType.Keyword),
			new LuaSymbol("nil", SymbolType.Keyword),
			new LuaSymbol("not", SymbolType.Keyword),
			new LuaSymbol("or", SymbolType.Keyword),
			new LuaSymbol("repeat", SymbolType.Keyword),
			new LuaSymbol("return", SymbolType.Keyword),
			new LuaSymbol("then", SymbolType.Keyword),
			new LuaSymbol("true", SymbolType.Keyword),
			new LuaSymbol("until", SymbolType.Keyword),
			new LuaSymbol("while", SymbolType.Keyword)
		};

		static List<LuaSymbol> Symbols = new List<LuaSymbol>()
		{
			new LuaSymbol("+", SymbolType.Symbol),
			new LuaSymbol("-", SymbolType.Symbol),
			new LuaSymbol("*", SymbolType.Symbol),
			new LuaSymbol("/", SymbolType.Symbol),
			new LuaSymbol("%", SymbolType.Symbol),
			new LuaSymbol("^", SymbolType.Symbol),
			new LuaSymbol("#", SymbolType.Symbol),
			new LuaSymbol("==", SymbolType.Symbol),
			new LuaSymbol("<=", SymbolType.Symbol),
			new LuaSymbol(">=", SymbolType.Symbol),
			new LuaSymbol("<", SymbolType.Symbol),
			new LuaSymbol(">", SymbolType.Symbol),
			new LuaSymbol("=", SymbolType.Symbol),
			new LuaSymbol("(", SymbolType.Symbol),
			new LuaSymbol(")", SymbolType.Symbol),
			new LuaSymbol("{", SymbolType.Symbol),
			new LuaSymbol("}", SymbolType.Symbol),
			new LuaSymbol("[", SymbolType.Symbol),
			new LuaSymbol("]", SymbolType.Symbol),
			new LuaSymbol(";", SymbolType.Symbol),
			new LuaSymbol(":", SymbolType.Symbol),
			new LuaSymbol(",", SymbolType.Symbol),
			new LuaSymbol(".", SymbolType.Symbol),
			new LuaSymbol("..", SymbolType.Symbol),
			new LuaSymbol("...", SymbolType.Symbol),
			new LuaSymbol("--", SymbolType.CommentSingle),
			new LuaSymbol("--[[", SymbolType.CommentBlockStart),
			new LuaSymbol("\"", SymbolType.LiteralString),
			new LuaSymbol("'", SymbolType.LiteralString),
			new LuaSymbol("[[", SymbolType.LiteralString),
			new LuaSymbol("]]", SymbolType.BlockEnd)
		};

		public static bool IsLetter(char c)
		{
			if ((c >= 'A') && (c <= 'Z')) return true;
			if ((c >= 'a') && (c <= 'z')) return true;

			return false;
		}

		public static bool IsNumber(char c)
		{
			return (c >= '0') && (c <= '9');
		}

		public static bool IsSpacer(char c)
		{
			return (c == ' ') || (c == '\t');
		}

		public static LuaSymbol GetLuaKeywordFor(string text)
		{
			return Keywords.Find(kw => kw.Text == text);
		}

		public static LuaSymbol GetLuaSymbolFor(string text)
		{
			return Symbols.Find(s => s.Text == text);
		}

		public static LuaSymbol GetSymbolForText(string text, SymbolType type)
		{
			switch (type)
			{
				case SymbolType.Symbol:
					return GetLuaSymbolFor(text);

				case SymbolType.Keyword:
					return GetLuaKeywordFor(text);

				case SymbolType.None:
					LuaSymbol ls = GetLuaSymbolFor(text);
					if (ls != null) return ls;
					ls = GetLuaKeywordFor(text);
					if (ls != null) return ls;
					break;
			}

			return null;
		}

		public static LuaGlobalDefinition Globals = new LuaGlobalDefinition();

		public static void SetGlobalsDefinition(string filename)
		{
			Globals = LuaGlobalDefinition.Load(filename);
		}
	}
}
