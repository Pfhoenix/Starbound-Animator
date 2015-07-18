using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StarboundAnimator
{
	public partial class DefinitionLogParserForm : Form
	{
		public LuaSymbol ParsedSymbol;

		public DefinitionLogParserForm()
		{
			InitializeComponent();
		}

		private void tbLogLine_TextChanged(object sender, EventArgs e)
		{
			btnParse.Enabled = !string.IsNullOrWhiteSpace(tbLogLine.Text);
		}

		private void btnParse_Click(object sender, EventArgs e)
		{
			LuaTable lt = new LuaTable("");
			// first check to see if a name is being provided
			int i = tbLogLine.Text.IndexOf('{');
			if (i > 0)
			{
				string name = tbLogLine.Text.Substring(0, i).Trim();
				if (!string.IsNullOrWhiteSpace(name))
				{
					if (name.EndsWith("=")) lt.Text = name.Substring(0, name.Length - 1).Trim();
					else lt.Text = name;
				}
			}
			else if (i < 0)
			{
				Close();
				return;
			}

			string toprocess = tbLogLine.Text.Substring(i + 1, tbLogLine.Text.LastIndexOf('}') - i - 1);
			i = 0;
			while (i > -1)
			{
				if (i == 0) i = -1;
				int se = toprocess.IndexOf(',', i + 1);
				string segment = se > -1 ? toprocess.Substring(i + 1, se - i - 1) : toprocess.Substring(i + 1);

				// do stuff
				int eq = segment.IndexOf('=');
				string name = segment.Substring(0, eq);
				string val = segment.Substring(eq + 1);
				if (val.StartsWith("function:")) lt.Functions.Add(new LuaFunction(name));
				else lt.Variables.Add(new LuaSymbol(name, SymbolType.Variable));

				i = se;
			}

			ParsedSymbol = lt;
			Close();
		}
	}
}
