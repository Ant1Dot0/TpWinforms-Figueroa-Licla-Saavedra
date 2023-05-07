using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Conexiones
{
    public class ListadoCat
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Categorias> Listar()
        {
            List<Categorias> lista = new List<Categorias>();

            try
            {
                datos.setearConsulta("Select Id, Descripcion as 'Categoria' from CATEGORIAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();

                    aux.ID = (int)datos.Lector["Id"];
                    aux.Categoria = (string)datos.Lector["Categoria"];

                    lista.Add(aux);
                }

                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
