using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Conexiones
{
    public class ListadoMarcas
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Marcas> Listar()
        {
            List<Marcas> lista = new List<Marcas>();

            try
            {
                datos.setearConsulta("Select Id, Descripcion as 'Marca' from MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();

                    aux.ID = (int)datos.Lector["Id"];
                    aux.Marca = (string)datos.Lector["Marca"];

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
