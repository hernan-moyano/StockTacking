using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTacking.BLL;
using StockTacking.DAL.DTO;

namespace StockTacking
{
    public partial class FrmStockAlert : Form
    {
        public FrmStockAlert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain();
            this.Hide();
            frm.ShowDialog();
        }

        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        int stockCritico = 10;
        private void FrmStockAlert_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dto.Products = dto.Products.Where(x => x.StockAmount <= stockCritico).ToList();
            //se cargan los datos en el DGV
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Producto";
            dataGridView1.Columns[3].HeaderText = "Categoría";
            dataGridView1.Columns[4].HeaderText = "Stock";
            dataGridView1.Columns[5].HeaderText = "Precio";
            //si no hay productos con stock critico se va a la pantalla principal
            if (dto.Products.Count==0)
            {
                FrmMain frm = new FrmMain();
                this.Hide();
                frm.ShowDialog();
            }
        }
    }
}
