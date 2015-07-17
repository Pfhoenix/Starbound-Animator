using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace StarboundAnimator
{
	public class TextSymbol
	{
		public TextLine Line;
		public LuaSymbol Symbol;

		string _text = "";
		public string Text
		{
			get
			{
				if (Symbol != null) return Symbol.Text;
				else return _text;
			}
		}

		// length of this symbol in characters
		public int Length
		{
			get
			{
				if (Symbol != null) return Symbol.Text.Length;
				else
				{
					string t = _text.Replace("\t", LuaScriptBox.TabSpaces);
					return t.Length;
				}
			}
		}

		public SymbolType Type
		{
			get
			{
				if (Symbol != null) return Symbol.Type;
				else return SymbolType.None;
			}
		}

		public TextSymbol(LuaSymbol ls)
		{
			Symbol = ls;
		}

		//public bool InvalidContext;

		/*public virtual void ValidateContext()
		{
			InvalidContext = false;
		}*/

		public virtual void Clear()
		{
			Line = null;
		}
	}

	public class TextLine
	{
		public int LineNumber;
		public List<TextSymbol> Symbols = new List<TextSymbol>();

		public TextLine(int ln)
		{
			LineNumber = ln;
		}

		public void AddSymbol(TextSymbol ts)
		{
			ts.Line = this;
			Symbols.Add(ts);
		}

		public void RemoveSymbol(TextSymbol ts)
		{
			Symbols.Remove(ts);
			ts.Line = null;
		}

		public TextSymbol GetSymbolAtPosition(int p)
		{
			foreach (TextSymbol ts in Symbols)
			{
				if (p < ts.Length) return ts;
				p -= ts.Length;
			}

			return null;
		}

		public int GetPositionOfSymbol(TextSymbol sym)
		{
			int pos = 0;
			foreach (TextSymbol ts in Symbols)
			{
				if (ts == sym) return pos;
				else pos += ts.Length;
			}

			return -1;
		}

		public void ReplaceSymbol(TextSymbol old, List<TextSymbol> repl)
		{
			int pos = 0;
			int index;
			for (index = 0; index < Symbols.Count; index++)
			{
				if (Symbols[index] == old) break;
				else pos += Symbols[index].Length;
			}

			// old wasn't found in this line; this shouldn't be happening
			if (index == Symbols.Count) return;

			Symbols.RemoveAt(index);
			old.Clear();
			foreach (TextSymbol ts in repl)
			{
				ts.Line = this;
			}
			Symbols.InsertRange(index, repl);
		}
	}

	public class SyntaxHighlightColors
	{
		public string TextColorString;
		public string SymbolColorString;
		public string CommentColorString;
		public string KeywordColorString;
		public string NumberColorString;
		public string StringColorString;
		public string GlobalColorString;
	
		[XmlIgnore]
		public Color Text;
		[XmlIgnore]
		public Color Symbol;
		[XmlIgnore]
		public Color Comment;
		[XmlIgnore]
		public Color Keyword;
		[XmlIgnore]
		public Color Number;
		[XmlIgnore]
		public Color String;
		[XmlIgnore]
		public Color Global;

		public void PostLoad()
		{
			Text = ColorTranslator.FromHtml(TextColorString);
			Symbol = ColorTranslator.FromHtml(SymbolColorString);
			Comment = ColorTranslator.FromHtml(CommentColorString);
			Keyword = ColorTranslator.FromHtml(KeywordColorString);
			Number = ColorTranslator.FromHtml(NumberColorString);
			String = ColorTranslator.FromHtml(StringColorString);
			Global = ColorTranslator.FromHtml(GlobalColorString);
		}

		public void PreSave()
		{
			TextColorString = ColorTranslator.ToHtml(Text);
			SymbolColorString = ColorTranslator.ToHtml(Symbol);
			CommentColorString = ColorTranslator.ToHtml(Comment);
			KeywordColorString = ColorTranslator.ToHtml(Keyword);
			NumberColorString = ColorTranslator.ToHtml(Number);
			StringColorString = ColorTranslator.ToHtml(String);
			GlobalColorString = ColorTranslator.ToHtml(Global);
		}

		public static SyntaxHighlightColors GetDefault()
		{
			SyntaxHighlightColors shc = new SyntaxHighlightColors();
			shc.Text = Color.LightGray;
			shc.Symbol = Color.Red;
			shc.Comment = Color.DarkGreen;
			shc.Keyword = Color.Lime;
			shc.Number = Color.Yellow;
			shc.String = Color.Cyan;
			shc.Global = Color.Teal;

			return shc;
		}

		public static SyntaxHighlightColors Load()
		{
			try
			{
				XmlSerializer xml = new XmlSerializer(typeof(SyntaxHighlightColors));
				SyntaxHighlightColors shc = xml.Deserialize(File.OpenRead(Path.Combine(Globals.AppPath, "luasyntax.colors"))) as SyntaxHighlightColors;
				if (shc != null) shc.PostLoad();
				return shc;
			}
			catch (Exception e)
			{
				MessageBox.Show("Error : " + e.Message, "Syntax highlighting loading error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}
		}

		public void Save()
		{
			try
			{
				XmlSerializer xml = new XmlSerializer(typeof(SyntaxHighlightColors));
				FileStream fs = File.OpenWrite(Path.Combine(Globals.AppPath, "luasyntax.colors"));
				PreSave();
				xml.Serialize(fs, this);
				fs.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show("Error : " + e.Message, "Syntax highlighting saving error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}

	public partial class LuaScriptBox : RichTextBox
	{
		public SyntaxHighlightColors SHC;
		LuaScript CurrentScript;
		public static int CharWidth;
		public static int TabSize;
		public static string TabSpaces;
		public List<Color> TextColors = new List<Color>();
		//public List<Color> TextBackgrounds = new List<Color>();

		public List<TextLine> TextLines = new List<TextLine>();

		public void Init()
		{
			Size s = TextRenderer.MeasureText("X", Font);
			CharWidth = s.Width;
			SetTabSpaces(4);
			SHC = SyntaxHighlightColors.Load();
			if (SHC == null)
			{
				SHC = SyntaxHighlightColors.GetDefault();
				SHC.Save();
			}
			UpdateColors();
		}

		public void SetTabSpaces(int tabsize)
		{
			TabSize = tabsize;
			TabSpaces = "";
			for (int i = 0; i < tabsize; i++)
				TabSpaces += " ";
		}

		public void UpdateColors()
		{
			TextColors.Clear();
			// SymbolType.None
			TextColors.Add(SHC.Text);
			// SymbolType.Symbol
			TextColors.Add(SHC.Symbol);
			// SymbolType.CommentSingle
			TextColors.Add(SHC.Comment);
			// SymbolType.CommentBlockStart
			TextColors.Add(SHC.Comment);
			// SymbolType.CommentText
			TextColors.Add(SHC.Comment);
			// SymbolType.BlockEnd
			TextColors.Add(Color.Black);
			// SymbolType.Keyword
			TextColors.Add(SHC.Keyword);
			// SymbolType.LiteralNumber
			TextColors.Add(SHC.Number);
			// SymbolType.LiteralString
			TextColors.Add(SHC.String);
			// SymbolType.LiteralStringText
			TextColors.Add(SHC.String);
			// SymbolType.Variable
			TextColors.Add(SHC.Text);
			// SymbolType.Function
			TextColors.Add(SHC.Text);
			// SymbolType.Table
			TextColors.Add(SHC.Text);
		}

		public TextLine GetPrevLine(TextLine tl)
		{
			int i = TextLines.IndexOf(tl);
			if (i <= 0) return null;
			else return TextLines[i - 1];
		}

		public TextLine GetNextLine(TextLine tl)
		{
			int i = TextLines.IndexOf(tl);
			if (i < 0) return null;
			if (i == (TextLines.Count - 1)) return null;
			else return TextLines[i + 1];
		}

		public TextSymbol GetSymbolAtPosition(int line, int pos)
		{
			if ((line < 0) || (line >= TextLines.Count)) return null;
			else return TextLines[line].GetSymbolAtPosition(pos);
		}

		public void AppendText(string text, Color fore)//, Color back)
		{
			SelectionStart = TextLength;
			SelectionLength = 0;

			SelectionColor = fore;
			AppendText(text);
			SelectionColor = ForeColor;
		}

		public void SetScript(LuaScript script)
		{
			CurrentScript = null;
			Clear();
			TextLines.Clear();
			CurrentScript = script;

			for (int i = 0; i < script.Symbols.Count; i++)
			{
				List<LuaSymbol> symline = script.Symbols[i];
				TextLine tline = new TextLine(i);

				for (int j = 0; j < symline.Count; j++)
				{
					TextSymbol ts = new TextSymbol(symline[j]);
					tline.AddSymbol(ts);
					AppendText(ts.Text, TextColors[(int)ts.Type]);
				}

				TextLines.Add(tline);
				AppendText(Environment.NewLine);
			}
		}
	}
}
