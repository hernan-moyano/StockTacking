﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTacking.DAL.DTO;
using StockTacking.BLL;

namespace StockTacking
{
    public partial class FrmCategoryList : Form
    {
        public FrmCategoryList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            //despues de añadir se actualiza la lista
            dto = bll.Select();
            dataGridView1.DataSource = dto.Categories;

        }

        CategoryDTO dto = new CategoryDTO();
        CategoryBLL bll = new CategoryBLL();

        private void FrmCategoryList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Categories;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre de Categoría";
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            List<CategoryDetailDTO> list = dto.Categories;
            //filtra segun lo escrito en la caja de texto (SENSIBLE A MAYUSCULAS Y MINUSCULAS)
            list = list.Where(x=>x.CategoryName.Contains(txtCategoryName.Text)).ToList();
            //muestra en el dataGridView los resultados encontrados
            dataGridView1.DataSource = list;
        }
    }
}
