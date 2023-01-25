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
    public partial class FrmCustomerList : Form
    {
        public FrmCustomerList()
        {
            InitializeComponent();
        }

        #region Propiedades
        CustomerBLL bll = new CustomerBLL();
        CustomerDTO dto = new CustomerDTO();
        CustomerDetailDTO detail = new CustomerDetailDTO();
        #endregion

        #region Eventos
        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            //para obtener todos los clientes
            dto = bll.Select();
            dataGridView1.DataSource = dto.Cutomers;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre del cliente";
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            //lista temporal
            List<CustomerDetailDTO> list = dto.Cutomers;
            //filtrado segun lo ingresado
            list = list.Where(x => x.CustomerName.Contains(txtCustomerName.Text)).ToList();
            //el datagrid se rellena con la lista creada
            dataGridView1.DataSource = list;

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new CustomerDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.CustomerName = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCustomer frm = new FrmCustomer();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            //se actualiza la lista
            dto = bll.Select();
            dataGridView1.DataSource = dto.Cutomers;
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
            {
                MessageBox.Show("Por favor selecciona un cliente de la tabla");
            }
            else
            {
                FrmCustomer frm = new FrmCustomer();
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                //se conecta a la capa de negocios
                bll = new CustomerBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Cutomers;
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
            {
                MessageBox.Show("Por favor selecciona un cliente de la tabla");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Esta seguro que desea borrarlo?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("El cliente se borro exitosamente");
                        bll = new CustomerBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Cutomers;
                        txtCustomerName.Clear();
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
