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

        #region Propiedades
        //para referenciar a la capa de negocio
        CategoryBLL bll = new CategoryBLL();
        //para cuando se actualiza una categoría
        public CategoryDetailDTO detail = new CategoryDetailDTO();
        public bool isUpdate = false;
        #endregion

        #region Eventos
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                txtCategoryName.Text = detail.CategoryName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Trim() == "")
                MessageBox.Show("El nombre de la categoría esta vacio");
            else
            {   //para añadir nuevo
                if (!isUpdate)
                {
                    CategoryDetailDTO category = new CategoryDetailDTO();
                    category.CategoryName = txtCategoryName.Text;
                    if (bll.Insert(category))
                    {
                        MessageBox.Show("La categoría se ha añadido correctamente");
                        txtCategoryName.Clear();
                    }
                }
                else if (isUpdate)
                {
                    //en caso de que no haga cambios en el texto
                    if (detail.CategoryName == txtCategoryName.Text.Trim())
                    {
                        MessageBox.Show("No se realizo ningún cambio");
                    }
                    //en caso de actualizar
                    else
                    {
                        detail.CategoryName = txtCategoryName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("La categoría fue actualizada");
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
