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
    public partial class ModificarArticulo : Form
    {
        public ModificarArticulo()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articulo.Codigo = txtCodArticulo.Text;
            articulo = new ArticuloNegocio().BuscarArticuloid(articulo);

            if(articulo.ID != 0)
            {
                txtCodArticulo.Text = articulo.Codigo;
                txtDescripcion.Text = articulo.Descripcion;
                txtNombre.Text = articulo.Nombre;
                TxtPrecio.Text = ""+ (articulo.Precio);
                
            }
            
        }
    }
}
