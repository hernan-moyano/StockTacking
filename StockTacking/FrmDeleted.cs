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
    public partial class FrmDeleted : Form
    {
        public FrmDeleted()
        {
            InitializeComponent();
        }

        private void FrmDeleted_Load(object sender, EventArgs e)
        {
            cmbDeletedData.Items.Add("Categorias");
            cmbDeletedData.Items.Add("Productos");
            cmbDeletedData.Items.Add("Clientes");
            cmbDeletedData.Items.Add("Ventas");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
