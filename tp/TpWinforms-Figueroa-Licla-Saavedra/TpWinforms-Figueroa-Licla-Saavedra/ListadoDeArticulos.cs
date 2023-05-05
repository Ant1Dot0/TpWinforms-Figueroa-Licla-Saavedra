using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conexiones;
using Clases;

namespace TpWinforms_Figueroa_Licla_Saavedra
{
    public partial class ListadoDeArticulos : Form
    {
        public ListadoDeArticulos()
        {
            InitializeComponent();
        }

        private void ListadoDeArticulos_Load(object sender, EventArgs e)
        {
            DgvArticulos.DataSource = new ArticuloNegocio().Listar();
        }

        private void DgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Articulo Seleccionado = new Articulo();
            Seleccionado = (Articulo)DgvArticulos.CurrentRow.DataBoundItem;
            AgregarArticulo Modificar = new AgregarArticulo(Seleccionado);
            Modificar.ShowDialog();
            
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminarFisico_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                //validacion de confirmacion de eliminar articulo
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar el articulo seleccionado?","Eliminando",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)DgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.ID);

                }
                
                //falta cargar la lista nuevamente

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
