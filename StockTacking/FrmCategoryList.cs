﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTacking
{
    public partial class FrmCategoryList : Form
    {
        public FrmCategoryList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
