using System;
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
    public partial class FrmSalesList : Form
    {
        public FrmSalesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=General.isNumber(e);
        }

        private void txtSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSales frm = new FrmSales();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
