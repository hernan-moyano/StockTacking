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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //para referenciar a la capa de negocio
        CategoryBLL bll = new CategoryBLL();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Trim() == "")
                MessageBox.Show("El nombre de la categoría esta vacio");
            else
            {
                CategoryDetailDTO category = new CategoryDetailDTO();
                category.CategoryName = txtCategoryName.Text;
                if(bll.Insert(category))
                {
                    MessageBox.Show("La categoría se ha añadido correctamente");
                    txtCategoryName.Clear();
                }
            }
        }
    }
}
