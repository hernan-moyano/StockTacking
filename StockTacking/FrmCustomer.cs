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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //para acceder a la capa de negocio
        CustomerBLL bll = new CustomerBLL();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim() == "")
                MessageBox.Show("El nombre del cliente esta vacio");
            else
            {
                CustomerDetailDTO customer = new CustomerDetailDTO();
                customer.CustomerName = txtCustomerName.Text;
                if (bll.Insert(customer))
                {
                    MessageBox.Show("El cliente se ha añadido correctamente");
                    txtCustomerName.Clear();
                }
            }
        }
    }
}
