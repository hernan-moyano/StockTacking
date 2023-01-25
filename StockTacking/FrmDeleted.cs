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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace StockTacking
{
    public partial class FrmDeleted : Form
    {
        public FrmDeleted()
        {
            InitializeComponent();
        }

        #region Propiedades
        SalesDTO dto = new SalesDTO();
        SalesBLL bll = new SalesBLL();
        CategoryDetailDTO categoryDetail = new CategoryDetailDTO();
        ProductDetailDTO productDetail = new ProductDetailDTO();
        CustomerDetailDTO customerDetail = new CustomerDetailDTO();
        SalesDetailDTO salesDetail = new SalesDetailDTO();
        CategoryBLL categoryBLL = new CategoryBLL();
        ProductBLL productBLL = new ProductBLL();
        CustomerBLL customerBLL = new CustomerBLL();
        SalesBLL salesBLL = new SalesBLL();
        #endregion

        #region Eventos
        private void FrmDeleted_Load(object sender, EventArgs e)
        {
            cmbDeletedData.Items.Add("Categorias");
            cmbDeletedData.Items.Add("Productos");
            cmbDeletedData.Items.Add("Clientes");
            cmbDeletedData.Items.Add("Ventas");
            dto = bll.Select(true);
        }

        private void cmbDeletedData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0)
            {
                //carga de los datos del DGV de categorias
                dataGridView1.DataSource = dto.Categories;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Nombre de Categoría";
            }
            if (cmbDeletedData.SelectedIndex == 1)
            {
                //carga de los datos del DGV de productos
                dataGridView1.DataSource = dto.Products;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Producto";
                dataGridView1.Columns[3].HeaderText = "Categoría";
                dataGridView1.Columns[4].HeaderText = "Stock";
                dataGridView1.Columns[5].HeaderText = "Precio";
                dataGridView1.Columns[6].Visible = false;
            }
            if (cmbDeletedData.SelectedIndex == 2)
            {
                //carga de los datos del DGV de clientes
                dataGridView1.DataSource = dto.Customers;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Nombre del cliente";
            }
            if (cmbDeletedData.SelectedIndex == 3)
            {
                //carga de los datos del DGV de ventas
                dataGridView1.DataSource = dto.Sales;
                dataGridView1.Columns[0].HeaderText = "Cliente";
                dataGridView1.Columns[1].HeaderText = "Producto";
                dataGridView1.Columns[2].HeaderText = "Categoría";
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].HeaderText = "Cantidad vendida";
                dataGridView1.Columns[7].HeaderText = "Precio";
                dataGridView1.Columns[8].HeaderText = "Fecha de venta";
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0)
            {
                categoryDetail = new CategoryDetailDTO();
                categoryDetail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                categoryDetail.CategoryName = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                productDetail = new ProductDetailDTO();
                productDetail.ProductID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                productDetail.CategoryID = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                productDetail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                productDetail.Price = (decimal)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                productDetail.isCategoryDeleted = (bool)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                customerDetail = new CustomerDetailDTO();
                customerDetail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                customerDetail.CustomerName = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            }
            else if (cmbDeletedData.SelectedIndex == 3)
            {
                try
                {
                    salesDetail = new SalesDetailDTO();
                    salesDetail.CustomerName = (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                    salesDetail.ProductName = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                    salesDetail.ProductID = (int)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                    salesDetail.SalesAmount = (int)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
                    salesDetail.Price = (decimal)dataGridView1.Rows[e.RowIndex].Cells[7].Value;
                    salesDetail.SalesID = (int)dataGridView1.Rows[e.RowIndex].Cells[10].Value;
                    salesDetail.isCategoryDeleted = (bool)dataGridView1.Rows[e.RowIndex].Cells[11].Value;
                    salesDetail.isCustomerDeleted = (bool)dataGridView1.Rows[e.RowIndex].Cells[12].Value;
                    salesDetail.isProductDeleted = (bool)dataGridView1.Rows[e.RowIndex].Cells[13].Value;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Nota", MessageBoxButtons.OK);

                }
            }
        }

        private void btnGetBack_Click(object sender, EventArgs e)
        {
            if (cmbDeletedData.SelectedIndex == 0)
            {
                if (categoryBLL.GetBack(categoryDetail))
                {
                    MessageBox.Show("La categoría se restauro exitosamente");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Categories;
                }
            }
            else if (cmbDeletedData.SelectedIndex == 1)
            {
                if (productDetail.isCategoryDeleted)
                {
                    MessageBox.Show("Categría del producto borrada, debe restaurarla antes");
                }
                else if (productBLL.GetBack(productDetail))
                {
                    MessageBox.Show("El producto se restauro exitosamente");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Products;
                }
            }
            else if (cmbDeletedData.SelectedIndex == 2)
            {
                if (customerBLL.GetBack(customerDetail))
                {
                    MessageBox.Show("El cliente se restauro exitosamente");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Customers;
                }
            }
            else if (cmbDeletedData.SelectedIndex == 3)
            {
                if (salesDetail.isCategoryDeleted || salesDetail.isCustomerDeleted || salesDetail.isProductDeleted)
                {
                    if (salesDetail.isCategoryDeleted)
                    {
                        MessageBox.Show("Categría de la venta borrada, debe restaurarla antes");
                    }
                    else if (salesDetail.isCustomerDeleted)
                    {
                        MessageBox.Show("Cliente de la venta borrado, debe restaurarlo antes");
                    }
                    else if (salesDetail.isProductDeleted)
                    {
                        MessageBox.Show("Producto de la venta borrado, debe restaurarlo antes");
                    }
                }
                else if (salesBLL.GetBack(salesDetail))
                {
                    MessageBox.Show("La venta se restauro exitosamente");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Sales;
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
