using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diseño
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }
        private bool Modify { get; set; } = false;
        Category category = new Category();
        CategoryServices categoryServices = new CategoryServices();

        private void SearchCategory()
        {
            category = categoryServices.select(Convert.ToInt32(txtID.Text));
            if (category is null)
            {
                MessageBox.Show("No se encontro ninguna categoria con este codigo");
            }
            else
            {
                txtID.Text = category.id.ToString();
                txtName.Text = category.name;
                if (category.status)
                    cbStatus.Text = "Activo";
                else
                    cbStatus.Text = "Inactivo";
            }
        }
        private void AddCategory()
        {
            category = new Category();
            category.name = txtName.Text;
            if (cbStatus.Text == "Activo")
                category.status = true;
            else
                category.status = false;

            if (!Modify)
            {
                category.id = CategoryRepository.Instancia.Categories.Count + 1;
                if (categoryServices.Add(category))
                {
                    MessageBox.Show("Categoria agregada correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la categoria");
                }
            }
            else
            {
                if(categoryServices.Edit(Convert.ToInt32(txtID.Text), category))
                {
                    MessageBox.Show("Categoria modificada correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo editar la categoria");
                }
            }
        }
        private void DeleteCategory()
        {
            if (categoryServices.Delete(Convert.ToInt32(txtID.Text)))
            {
                MessageBox.Show("Categoria eliminada correctamente");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar la categoria");
            }
        }
        private void Clear()
        {
            txtID.Clear();
            txtName.Clear();
            cbStatus.Text = "";
            Modify = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "") 
            { 
                SearchCategory();
                Modify = true;
            }
            else
                MessageBox.Show("Debe ingresar el ID");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && cbStatus.Text != "")
            {
                AddCategory();
                Clear();
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtName.Text != "" && cbStatus.Text != "")
            {
                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("Seguro que desea eliminar esta categoria?", "Atencion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteCategory();
                    Clear();
                }
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }
    }
}
