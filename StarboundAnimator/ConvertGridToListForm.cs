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
	public partial class ConvertGridToListForm : Form
	{
		public bool bConvertDefaults
		{
			get
			{
				return cmbDefaults.SelectedIndex == 1;
			}
		}

		public bool bConvertNames
		{
			get
			{
				return cmbNames.SelectedIndex == 0;
			}
		}

		public ConvertGridToListForm()
		{
			InitializeComponent();

			cmbDefaults.SelectedIndex = 0;
			cmbNames.SelectedIndex = 0;
		}
	}
}
