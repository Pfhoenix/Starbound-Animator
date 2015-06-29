using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StarboundAnimator
{
	public enum SymbolType { None = 0, Symbol, CommentSingle, CommentBlockStart, CommentBlockEnd, Keyword, LiteralNumber, LiteralString, Variable, Function, Table }

	public class LuaSymbol
	{
		public string Text;
		public SymbolType Type;

		public LuaSymbol(string text, SymbolType type)
		{
			Text = text;
			Type = type;
		}
	}

	public class LuaFunction : LuaSymbol
	{
		public List<string> Parameters = new List<string>();

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

		public LuaTable(string text) : base(text, SymbolType.Table)
		{
		}
	}

	public class LuaScript
	{
		public List<LuaSymbol> Symbols = new List<LuaSymbol>();
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
			new LuaSymbol("--", SymbolType.CommentSingle)
		};

		static LuaSymbol GetLuaKeywordFor(string text)
		{
			return Keywords.Find(kw => kw.Text == text);
		}

		static LuaSymbol GetLuaSymbolFor(string text)
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

		//static List<LuaSymbol> Globals = new List<LuaSymbol>();
		public static List<string> Globals = new List<string>()
		{
			"string",
			"table",
			"math",
			"self",
			"world",
			"entity",
			"tech",
			"mcontroller"
		};

		public LuaScript ParseFile(string filepath)
		{
			if (!File.Exists(filepath)) return null;
			string[] lines = File.ReadAllLines(filepath);
			return ParseSourceLines(lines);
		}

		public LuaScript ParseText(string source)
		{
			string ns = source.Replace("\r", "");
			string[] lines = source.Split(new char[] { '\n' });
			return ParseSourceLines(lines);
		}

		public LuaScript ParseSourceLines(string[] sourcelines)
		{
			return null;
		}
	}
}
