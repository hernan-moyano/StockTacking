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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        #region Propiedades
        //para acceder a la capa de negocio
        CustomerBLL bll = new CustomerBLL();
        public CustomerDetailDTO detail = new CustomerDetailDTO();
        public bool isUpdate = false;
        #endregion

        #region Eventos
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                txtCustomerName.Text = detail.CustomerName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim() == "")
                MessageBox.Show("El nombre del cliente esta vacio");
            else
            {
                if (!isUpdate)
                {
                    CustomerDetailDTO customer = new CustomerDetailDTO();
                    customer.CustomerName = txtCustomerName.Text;
                    if (bll.Insert(customer))
                    {
                        MessageBox.Show("El cliente se ha añadido correctamente");
                        txtCustomerName.Clear();
                    }
                }
                else
                {
                    if (detail.CustomerName == txtCustomerName.Text)
                    {
                        MessageBox.Show("No hubo cambios en el nombre");
                    }
                    else
                    {
                        detail.CustomerName = txtCustomerName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("El cliente se ha actualizado correctamente");
                            this.Close();
                        }
                    }
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
