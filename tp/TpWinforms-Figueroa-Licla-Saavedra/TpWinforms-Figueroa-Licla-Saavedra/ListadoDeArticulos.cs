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
            try
            {
                ActualizarGrid();
                ListadoCat listadoCat = new ListadoCat();
                ListadoMarcas listadoMarcas = new ListadoMarcas();

                CbmCat.DataSource = listadoCat.Listar();
                CbmCat.ValueMember = "Id";
                CbmCat.DisplayMember = "Categoria";
                CbmMarca.DataSource = listadoMarcas.Listar();
                CbmMarca.ValueMember = "Id";
                CbmMarca.DisplayMember = "Marca";
                CbmOrdenar.Items.Add("Menor precio");
                CbmOrdenar.Items.Add("Mayor precio");
                CbmOrdenar.Items.Add("A - Z");
                CbmOrdenar.Items.Add("Z - A");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            


        }


        private void BorrarCB()
        {
            CbmCat.SelectedIndex = -1;
            CbmMarca.SelectedIndex = -1;
            CbmOrdenar.SelectedIndex = -1;
            
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Articulo Seleccionado = new Articulo();
            Seleccionado = (Articulo)DgvArticulos.CurrentRow.DataBoundItem;
            AgregarArticulo Modificar = new AgregarArticulo(Seleccionado);
            Modificar.ShowDialog();
            ActualizarGrid();

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            AgregarArticulo agregar = new AgregarArticulo();
            agregar.ShowDialog();
            ActualizarGrid();
        }

        private void BtnEliminarFisico_Click(object sender, EventArgs e)
        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                //validacion de confirmacion de eliminar articulo
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar el articulo seleccionado?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)DgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.ID);

                }

                ActualizarGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private List<Articulo> Aux;

        private void ActualizarGrid()
        {
            try
            {
                ArticuloNegocio articulo = new ArticuloNegocio();

                Aux = articulo.Listar();
                DgvArticulos.DataSource = Aux;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
          


        }

        private void button4_Click(object sender, EventArgs e)
        {
            BorrarCB();
        }


        //Filtro Rapido por medio de Nombre o Id
        private void txbCodigoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<Articulo> listafiltrada;
            string filtro = txbCodigoNombre.Text;

            if (filtro != "")
            {
                listafiltrada = Aux.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()) ) ;
            }
            else
            {
                listafiltrada = Aux;
            }
            

            DgvArticulos.DataSource = null;
            DgvArticulos.DataSource = listafiltrada;
                
        }
    }

}
