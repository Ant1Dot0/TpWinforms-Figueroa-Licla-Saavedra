using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using Conexiones;

namespace TpWinforms_Figueroa_Licla_Saavedra
{
    public partial class AgregarArticulo : Form
    {

        private Articulo AuxArticulo = null;
        
        public AgregarArticulo()
        {
            InitializeComponent();
          
        }

        public AgregarArticulo(Articulo ArticuloModif)
        {
            InitializeComponent();
            this.AuxArticulo = ArticuloModif;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio datos = new ArticuloNegocio();
           
            try
            {
                if (AuxArticulo == null)
                {
                    AuxArticulo = new Articulo();
                }
                AuxArticulo.Codigo = txtCodArticulo.Text;
                AuxArticulo.Descripcion = txtDescripcion.Text;
                AuxArticulo.Nombre = txtNombre.Text;
                AuxArticulo.Marcas = (Marcas)cmbMarca.SelectedItem;
                AuxArticulo.Categorias = (Categorias)cmxCategoria.SelectedItem;
                AuxArticulo.Precio = decimal.Parse(TxtPrecio.Text);


                if (AuxArticulo.ID != 0)
                {
                    MessageBox.Show(AuxArticulo.ID.ToString());
                    ///datos.update(AuxArticulo);
                    MessageBox.Show("ARTICULO MODIFICADO");
                    Close();
                }
                else
                {
                    datos.Insertar(AuxArticulo);
                    MessageBox.Show("ARTICULO CARGADO");
                    Close();
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void AgregarArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                if(AuxArticulo != null)
                {
                    txtCodArticulo.Text = AuxArticulo.Codigo;
                    txtDescripcion.Text = AuxArticulo.Descripcion;
                    txtNombre.Text = AuxArticulo.Nombre;
                    TxtPrecio.Text = AuxArticulo.Precio.ToString();
                    cmbMarca.SelectedValue = AuxArticulo.Marcas.ID;
                    cmxCategoria.SelectedValue = AuxArticulo.Categorias.ID;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
