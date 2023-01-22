using StockTacking.BLL;
using StockTacking.DAL.DAO;
using StockTacking.DAL.DTO;
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
using StockTacking.DAL;

namespace StockTacking
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!General.isDecimal(e.KeyChar, txtPrice.Text))
                e.Handled = true;
        }

        public ProductBLL bll = new ProductBLL();
        public ProductDTO dto = new ProductDTO();
        public ProductDetailDTO detail = new ProductDetailDTO();
        public bool isUpdate = false;

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            if (isUpdate)
            {
                cmbCategory.SelectedValue = detail.CategoryID;
                txtProductName.Text = detail.ProductName;
                txtPrice.Text = detail.Price.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("El nombre del producto esta vacio");
            else if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una categoría");
            }
            else if (txtPrice.Text.Trim() == "")
            {
                MessageBox.Show("Debe completar el precio");
            }  
            else
            {
                //para agregar
                if (!isUpdate)
                {
                    ProductDetailDTO product = new ProductDetailDTO();
                    product.ProductName = txtProductName.Text;
                    product.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                    product.Price = Convert.ToDecimal(txtPrice.Text);

                    if (bll.Insert(product))
                    {
                        MessageBox.Show("El producto se ha añadido correctamente");
                        txtProductName.Clear();
                        cmbCategory.SelectedValue = -1;
                        txtPrice.Clear();
                    }
                }//para actualizar
                else
                {
                    if (detail.ProductName == txtProductName.Text && 
                        detail.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue) &&
                        detail.Price == Convert.ToDecimal(txtPrice.Text))
                    {
                        MessageBox.Show("No se realizo ningún cambio");
                    }
                    else
                    {
                        detail.ProductName = txtProductName.Text;
                        detail.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                        detail.Price = Convert.ToDecimal(txtPrice.Text);
                    {

                            if (bll.Update(detail))
                        {
                            MessageBox.Show("El producto fue actualizado");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
}
