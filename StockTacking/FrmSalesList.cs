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
            if (detail.SalesID == 0)
            {
                MessageBox.Show("Por favor selecciona una venta de la tabla");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Esta seguro que desea borrarla?","Advertencia",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("La venta se borro exitosamente");
                        bll = new SalesBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource= dto.Sales;
                        CleanFilters();
                    }
                }
            }
        }


        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!General.isDecimal(e.KeyChar, txtPrice.Text))
                e.Handled = true;
        }

        private void txtSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSales frm = new FrmSales();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            //para actualizar y limpiar filtros
            dto = bll.Select();
            dataGridView1.DataSource = dto.Sales;
            CleanFilters();
        }

        SalesBLL bll = new SalesBLL();
        SalesDTO dto = new SalesDTO();
        SalesDetailDTO detail = new SalesDetailDTO();


        private void FrmSalesList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;

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

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalesDetailDTO> list = dto.Sales;
            if (txtProductName.Text.Trim() != null)
            {
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
            }
            if (txtCustomerName.Text.Trim() != null)
            {
                list = list.Where(x => x.CustomerName.Contains(txtCustomerName.Text)).ToList();
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
            if (txtSalesAmount.Text.Trim() != "")
            {
                if (rbSaleEquals.Checked)
                    list = list.Where(x => x.SalesAmount == Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else if (rbSaleMore.Checked)
                    list = list.Where(x => x.SalesAmount > Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else if (rbSaleLess.Checked)
                    list = list.Where(x => x.SalesAmount < Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else
                {
                    MessageBox.Show("Por favor, selecciona un criterio para filtrar el stock vendido");
                }
            }
            if (chDate.Checked)
            {
                list = list.Where(x => x.SalesDate >= dpStart.Value &&
                x.SalesDate <= dpEnd.Value
                ).ToList();
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
            txtCustomerName.Clear();
            cmbCategory.SelectedIndex = -1;
            txtPrice.Clear();
            txtSalesAmount.Clear();
            rbPriceEquals.Checked = false;
            rbPriceMore.Checked = false;
            rbPriceLess.Checked = false;
            rbSaleEquals.Checked = false;
            rbSaleMore.Checked = false;
            rbSaleLess.Checked = false;
            chDate.Checked = false;
            dpStart.Value = DateTime.Today;
            dpEnd.Value = DateTime.Today;
            dataGridView1.DataSource = dto.Sales;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                detail = new SalesDetailDTO();
                detail.CustomerName = (string)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                detail.ProductName = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                detail.ProductID = (int)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                detail.SalesAmount = (int)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
                detail.Price = (decimal)dataGridView1.Rows[e.RowIndex].Cells[7].Value;
                detail.SalesID = (int)dataGridView1.Rows[e.RowIndex].Cells[10].Value;
                //todo: si se elimina la categoria del producto o el producto no puede seleccionarse el id
                ProductDetailDTO product = dto.Products.First(x => x.ProductID == detail.ProductID);
                detail.StockAmount = product.StockAmount;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.SalesID ==0)
            {
                MessageBox.Show("Por favor selecciona una venta de la tabla");
            }
            else
            {
                FrmSales frm = new FrmSales();
                frm.detail = detail;
                frm.isUpdate = true;
                //se le pasa el dto que tiene la clase, necesario para la expresion lambda
                frm.dto = dto;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                //se conecta a la capa de negocios
                bll = new SalesBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Sales;
                CleanFilters();
            }
        }
    }
}
