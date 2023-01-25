using System;
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
        #region Propiedades
        CategoryDTO dto = new CategoryDTO();
        CategoryBLL bll = new CategoryBLL();
        CategoryDetailDTO detail = new CategoryDetailDTO();
        #endregion

        #region Eventos
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
            list = list.Where(x => x.CategoryName.Contains(txtCategoryName.Text)).ToList();
            //muestra en el dataGridView los resultados encontrados
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new CategoryDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.CategoryName = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
            {
                MessageBox.Show("Por favor selecciona una categoría de la tabla");
            }
            else
            {
                FrmCategory frm = new FrmCategory();
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                //se conecta a la capa de negocios
                bll = new CategoryBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Categories;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
            {
                MessageBox.Show("Por favor selecciona una categoría de la tabla");
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Esta seguro que desea borrarla?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("La categoría se borro exitosamente");
                        bll = new CategoryBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Categories;
                        txtCategoryName.Clear();
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
