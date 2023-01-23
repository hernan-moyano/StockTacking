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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace StockTacking
{
    public partial class FrmProductList : Form
    {
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();

        public FrmProductList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = General.isNumber(e);
            if (!General.isDecimal(e.KeyChar, txtPrice.Text))
                e.Handled = true;
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            //para refrescar despues de haber añadido uno nuevo
            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;
            //se limpian los filtros de busqueda
            CleanFilters();
        }


        private void FrmProductList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            //carga de los datos del DGV
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Producto";
            dataGridView1.Columns[3].HeaderText = "Categoría";
            dataGridView1.Columns[4].HeaderText = "Stock";
            dataGridView1.Columns[5].HeaderText = "Precio";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //se crea una lista temporal
            List<ProductDetailDTO> list = dto.Products;
            if (txtProductName.Text.Trim() != null)
            {
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
            }
            if (cmbCategory.SelectedIndex != -1)
            {
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            }
            if (txtPrice.Text.Trim() != "")
            {
                if (rbPriceEquals.Checked)
                    list = list.Where(x => x.Price == Convert.ToDecimal(txtPrice.Text)).ToList();
                else if (rbPriceMore.Checked)
                    list = list.Where(x => x.Price > Convert.ToDecimal(txtPrice.Text)).ToList();
                else if (rbPriceLess.Checked)
                    list = list.Where(x => x.Price < Convert.ToDecimal(txtPrice.Text)).ToList();
                else
                    MessageBox.Show("Por favor, selecciona un criterio para filtrar el precio");
            }
            if (txtStock.Text.Trim() != "")
            {
                if (rbStockEquals.Checked)
                    list = list.Where(x => x.StockAmount == Convert.ToInt32(txtStock.Text)).ToList();
                else if (rbStockMore.Checked)
                    list = list.Where(x => x.StockAmount > Convert.ToInt32(txtStock.Text)).ToList();
                else if (rbStockLess.Checked)
                    list = list.Where(x => x.StockAmount < Convert.ToInt32(txtStock.Text)).ToList();
                else
                    MessageBox.Show("Por favor, selecciona un criterio para filtrar el stock");
            }
            dataGridView1.DataSource = list;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtProductName.Clear();
            cmbCategory.SelectedIndex = -1;
            txtPrice.Clear();
            rbPriceEquals.Checked = false;
            rbPriceMore.Checked = false;
            rbPriceLess.Checked = false;
            txtStock.Clear();
            rbStockEquals.Checked = false;
            rbStockMore.Checked = false;
            rbStockLess.Checked = false;
            dataGridView1.DataSource = dto.Products;
        }

        public ProductDetailDTO detail = new ProductDetailDTO();

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new ProductDetailDTO();
            detail.ProductID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            detail.CategoryID = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //detail.CategoryName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //detail.StockAmount = (int)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
            detail.Price = (decimal)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
            {
                MessageBox.Show("Por favor selecciona un producto de la tabla");
            }
            else
            {
                FrmProduct frm = new FrmProduct();
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                //se conecta a la capa de negocios
                bll = new ProductBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Products;
                CleanFilters();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ProductID==0)
            {
                MessageBox.Show("Por favor selecciona un producto de la tabla");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Esta seguro que desea borrarlo?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("El producto se borro exitosamente");
                        bll = new ProductBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Products;
                        cmbCategory.DataSource = dto.Categories;
                        CleanFilters();
                    }
                }
            }
        }
    }
}
