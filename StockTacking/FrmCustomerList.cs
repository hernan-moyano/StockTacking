﻿using System;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        CustomerBLL bll = new CustomerBLL();
        CustomerDTO dto = new CustomerDTO();

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            //para obtener todos los clientes
            dto = bll.Select();
            dataGridView1.DataSource= dto.Cutomers;
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
    }
}
