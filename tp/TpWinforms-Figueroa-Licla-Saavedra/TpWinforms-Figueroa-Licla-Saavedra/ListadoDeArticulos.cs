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
    }
}
