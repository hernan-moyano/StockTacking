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
using StockTacking.DAL;
using StockTacking.DAL.DAO;
using StockTacking.DAL.DTO;

namespace StockTacking
{
    public partial class FrmSales : Form
    {
        public FrmSales()
        {
            InitializeComponent();
        }

        private void textProductSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SalesBLL bll = new SalesBLL();
        public SalesDTO dto = new SalesDTO();
        public SalesDetailDTO detail = new SalesDetailDTO();
        
        bool comboFull = false;
        public bool isUpdate = false;

        private void FrmSales_Load(object sender, EventArgs e)
        {
            //carga del combo de categorias en cmb
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            if (!isUpdate)
            {
                //carga de los datos de productos en el DGV
                gridProduct.DataSource = dto.Products;
                gridProduct.Columns[0].Visible = false;
                gridProduct.Columns[1].Visible = false;
                gridProduct.Columns[2].HeaderText = "Producto";
                gridProduct.Columns[3].HeaderText = "Categoría";
                gridProduct.Columns[4].HeaderText = "Stock";
                gridProduct.Columns[5].HeaderText = "Precio";
                //para obtener todos los clientes            
                gridCustomer.DataSource = dto.Customers;
                gridCustomer.Columns[0].Visible = false;
                gridCustomer.Columns[1].HeaderText = "Nombre del cliente";
                if (dto.Categories.Count > 0)
                {
                    comboFull = true;
                }
            }
            else
            {
                panel1.Hide();
                txtCustomerName.Text = detail.CustomerName;
                txtProductName.Text = detail.ProductName;
                txtPrice.Text = detail.Price.ToString();
                txtProductSalesAmount.Text = detail.SalesAmount.ToString();

                txtStock.Text = detail.StockAmount.ToString();
            }
        }


        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //para el filtrado por categoría
            if (comboFull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                gridProduct.DataSource = list;
                if (list.Count == 0)
                {
                    txtProductName.Clear();
                    txtStock.Clear();
                    txtPrice.Clear();
                }

            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            //Para el filtrado por cliente
            List<CustomerDetailDTO> list = dto.Customers;
            list = list.Where(x => x.CustomerName.Contains(txtCustomerSearch.Text)).ToList();
            gridCustomer.DataSource = list;
            if (list.Count == 0)
            {
                txtCustomerName.Clear();
            }
        }


        private void gridProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {   //se obtienen los valores de la tabla            
            detail.ProductID = (int)gridProduct.Rows[e.RowIndex].Cells[0].Value;
            detail.CategoryID = (int)gridProduct.Rows[e.RowIndex].Cells[1].Value;
            detail.ProductName = (string)gridProduct.Rows[e.RowIndex].Cells[2].Value;
            detail.StockAmount = (int)gridProduct.Rows[e.RowIndex].Cells[4].Value;
            detail.Price = (decimal)gridProduct.Rows[e.RowIndex].Cells[5].Value;
            //se cargan los valores en los txtbox
            txtProductName.Text = detail.ProductName;
            txtStock.Text = detail.StockAmount.ToString();
            txtPrice.Text = detail.Price.ToString();


        }

        private void gridCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.CustomerID = (int)gridCustomer.Rows[e.RowIndex].Cells[0].Value;
            detail.CustomerName = (string)gridCustomer.Rows[e.RowIndex].Cells[1].Value;
            txtCustomerName.Text = detail.CustomerName;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductSalesAmount.Text.Trim() == "")
            {
                MessageBox.Show("Por favor complete el área de cantidad de ventas");
            }
            else
            {   //Agregar
                if (!isUpdate)
                {
                    if (detail.ProductID == 0)
                    {
                        MessageBox.Show("Por favor, selecciona un producto de la tabla");
                    }
                    else if (detail.CustomerID == 0)
                    {
                        MessageBox.Show("Por favor, selecciona un cliente de la tabla");
                    }
                    else if (detail.StockAmount < Convert.ToInt32(txtProductSalesAmount.Text))
                    {
                        MessageBox.Show("No se posee la cantidad de stock requerida");
                    }
                    else
                    {
                        detail.SalesAmount = Convert.ToInt32(txtProductSalesAmount.Text);
                        detail.SalesDate = DateTime.Today;
                        if (bll.Insert(detail))
                        {
                            MessageBox.Show("Se ha realizado la venta exitosamente");
                            bll = new SalesBLL();
                            dto = bll.Select();
                            gridProduct.DataSource = dto.Products;
                            dto.Customers = dto.Customers;
                            comboFull = false;
                            cmbCategory.DataSource = dto.Categories;
                            if (dto.Products.Count > 0)
                            {
                                comboFull = true;
                            }
                            txtProductSalesAmount.Clear();
                        }
                    }

                }
                //Actualizar
                else
                {
                    if (detail.SalesAmount == Convert.ToInt32(txtProductSalesAmount.Text))
                    {
                        MessageBox.Show("No se realizo ningún cambio");
                    }
                    else
                    {
                        int temp = detail.StockAmount + detail.SalesAmount;
                        if (temp < Convert.ToInt32(txtProductSalesAmount.Text))
                        {
                            MessageBox.Show("No tiene suficiente producto para la venta");
                        }
                        else
                        {
                            detail.SalesAmount = Convert.ToInt32(txtProductSalesAmount.Text);
                            detail.StockAmount = temp - detail.SalesAmount;
                            if (bll.Update(detail))
                            {
                                MessageBox.Show("Se actualizó la venta");
                                this.Close();
                            }
                        }
                    }

                }
            }
        }
    }
}
