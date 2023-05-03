using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpWinforms_Figueroa_Licla_Saavedra
{
    public partial class OrganizART : Form
    {
        public OrganizART()
        {
            InitializeComponent();
        }

        private void ListadoArtStripMenu_Click(object sender, EventArgs e)
        {
            ListadoDeArticulos FormList = new ListadoDeArticulos();
            FormList.ShowDialog();
        }

        private void CargaArticulosStripMenu_Click(object sender, EventArgs e)
        {
            CargaDeArticulos FormCarga = new CargaDeArticulos();
            FormCarga.ShowDialog();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarArticulo FormAgregar = new AgregarArticulo();
            FormAgregar.ShowDialog();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarArticulo FormModificar = new ModificarArticulo();
            FormModificar.ShowDialog();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarArticulo FormEliminar = new EliminarArticulo();
            FormEliminar.ShowDialog();
        }
    }
}
