using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

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

	public partial class LuaScriptBox : RichTextBox
	{
		public static int CharWidth;
		public static int TabSize;
		public static string TabSpaces;
		public List<Color> TextColors = new List<Color>();
		public List<Color> TextBackgrounds = new List<Color>();

		public List<TextLine> TextLines = new List<TextLine>();

		public LuaScriptBox()
		{
			InitializeComponent();
			Size s = TextRenderer.MeasureText("X", Font);
			CharWidth = s.Width;
			SetTabSpaces(4);
			ResetColorsToDefault();
		}

		public void SetTabSpaces(int tabsize)
		{
			TabSize = tabsize;
			TabSpaces = "";
			for (int i = 0; i < tabsize; i++)
				TabSpaces += " ";
		}

		public void ResetColorsToDefault()
		{
			TextColors.Clear();
			// SymbolType.None
			TextColors.Add(Color.LightGray);
			// SymbolType.Symbol
			TextColors.Add(Color.Red);
			// SymbolType.CommentSingle
			TextColors.Add(Color.DarkGreen);
			// SymbolType.CommentBlockStart
			TextColors.Add(Color.DarkGreen);
			// SymbolType.CommentBlockEnd
			TextColors.Add(Color.DarkGreen);
			// SymbolType.Keyword
			TextColors.Add(Color.Lime);
			// SymbolType.LiteralNumber
			TextColors.Add(Color.Yellow);
			// SymbolType.LiteralString
			TextColors.Add(Color.Cyan);
			// SymbolType.Variable
			TextColors.Add(Color.LightGray);
			// SymbolType.Function
			TextColors.Add(Color.LightGray);
			// SymbolType.Table
			TextColors.Add(Color.LightGray);

			TextBackgrounds.Clear();
			for (int i = 0; i < TextColors.Count; i++)
				TextBackgrounds.Add(Color.Black);
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
	}
}
