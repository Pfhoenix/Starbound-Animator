using System;
using System.Collections.Generic;
using System.Text;

namespace StarboundAnimator
{
	public enum TextSymbolType { Empty, Symbol, Keyword, Variable, Function, Table }

	public class TextSymbol
	{
		public int Position;
		public string Text;
		public TextSymbolType Type;
		public TextLine Line;

		public virtual bool HasValidContext()
		{
			return true;
		}

		public virtual void Clear()
		{
			Line = null;
		}
	}

	public class LuaFunction : TextSymbol
	{
		public List<string> Parameters = new List<string>();

		public LuaFunction()
		{
			Type = TextSymbolType.Function;
		}


	}

	public class LuaTable : TextSymbol
	{
		public List<TextSymbol> Variables = new List<TextSymbol>();
		public List<TextSymbol> Functions = new List<TextSymbol>();

		public LuaTable()
		{
			Type = TextSymbolType.Table;
		}
	}

	public class TextLine
	{
		public int LineNumber;
		public List<TextSymbol> Symbols = new List<TextSymbol>();

		public TextSymbol GetSymbolAtPosition(int p)
		{
			foreach (TextSymbol ts in Symbols)
			{
				if (p < ts.Text.Length) return ts;
				p -= ts.Text.Length;
			}

			return null;
		}

		public void ReplaceSymbol(TextSymbol old, List<TextSymbol> repl)
		{
			int i = Symbols.IndexOf(old);
			if (i < 0) return;
			Symbols.RemoveAt(i);
			int pos = old.Position;
			old.Clear();
			foreach (TextSymbol ts in repl)
			{
				ts.Line = this;
				ts.Position = pos;
				pos += ts.Text.Length;
			}
			Symbols.InsertRange(i, repl);
			for (int j = i + repl.Count; j < Symbols.Count; j++)
			{
				Symbols[j].Position = pos;
				pos += Symbols[j].Text.Length;
			}
		}
	}

	public class LuaScript
	{
		public List<TextLine> Lines = new List<TextLine>();

		public TextLine GetPrevLine(TextLine tl)
		{
			int i = Lines.IndexOf(tl);
			if (i <= 0) return null;
			else return Lines[i - 1];
		}

		public TextLine GetNextLine(TextLine tl)
		{
			int i = Lines.IndexOf(tl);
			if (i < 0) return null;
			if (i == (Lines.Count - 1)) return null;
			else return Lines[i + 1];
		}
	}

	public class Lua
	{

		public static List<string> Keywords = new List<string>()
		{
			"and",
			"break",
			"do",
			"else",
			"elseif",
			"end",
			"false",
			"for",
			"function",
			"if",
			"in",
			"local",
			"nil",
			"not",
			"or",
			"repeat",
			"return",
			"then",
			"true",
			"until",
			"while"
		};

		public static List<string> Symbols = new List<string>()
		{
			"+",
			"-",
			"*",
			"/",
			"%",
			"^",
			"#",
			"==",
			"<=",
			">=",
			"<",
			">",
			"=",
			"(",
			")",
			"{",
			"}",
			"[",
			"]",
			";",
			":",
			",",
			".",
			"..",
			"..."
		};

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
	}
}
