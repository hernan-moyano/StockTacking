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
    public partial class FrmAddStock : Form
    {
        public FrmAddStock()
        {
            InitializeComponent();
        }

        #region Propiedades
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        bool comboFull = false;
        ProductDetailDTO detail = new ProductDetailDTO();
        #endregion

        #region Eventos
        private void FrmAddStock_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;

            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Producto";
            dataGridView1.Columns[3].HeaderText = "Categoría";
            dataGridView1.Columns[4].HeaderText = "Stock";
            dataGridView1.Columns[5].HeaderText = "Precio";
            dataGridView1.Columns[6].Visible = false;

            if (dto.Categories.Count > 0)
            {
                comboFull = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                dataGridView1.DataSource = list;
                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtStock.Clear();
                }

            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            txtProductName.Text = detail.ProductName;
            detail.Price = (decimal)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
            txtPrice.Text = detail.Price.ToString();
            detail.StockAmount = (int)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
            txtStock.Text = detail.StockAmount.ToString();
            detail.ProductID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, seleccione un producto de la tabla");
            }
            else if (txtStock.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, introduce una cantidad");
            }
            else
            {
                int sumStock = detail.StockAmount;
                sumStock += Convert.ToInt32(txtStock.Text);
                detail.StockAmount = sumStock;
                if (bll.Update(detail))
                {
                    MessageBox.Show("El stock ha sido actualizado");
                    bll = new ProductBLL();
                    dto = bll.Select();
                    dataGridView1.DataSource = dto.Products;
                    txtStock.Clear();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion   
    }
}
