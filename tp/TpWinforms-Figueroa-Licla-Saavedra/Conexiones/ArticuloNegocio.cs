using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Conexiones
{
     public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                    datos.setearConsulta("SELECT A.id as ART, CODIGO, NOMBRE, A.Descripcion as DESCRIP, M.ID as MAR, M.Descripcion as MARDE, C.Id as CATE, C.Descripcion as CATEDE, PRECIO FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE A.IdMarca = M.id and A.idCategoria = C.id");
                    datos.ejecutarLectura();
                    while (datos.Lector.Read())
                    {
                        Articulo aux = new Articulo();
                        aux.ID = (int)datos.Lector["ART"];
                        aux.Codigo = (string)datos.Lector["CODIGO"];
                        aux.Nombre = (string)datos.Lector["NOMBRE"];
                        aux.Descripcion = (string)datos.Lector["DESCRIP"];
                        aux.Marcas = new Marcas();
                        aux.Marcas.Marca = (string)datos.Lector["MARDE"];
                        aux.Marcas.ID = (int)datos.Lector["MAR"];
                        aux.Categorias = new Categorias();
                        aux.Categorias.Categoria = (string)datos.Lector["CATEDE"];
                        aux.Categorias.ID = (int)datos.Lector["CATE"];
                        aux.Precio = (decimal)datos.Lector["PRECIO"];
                        lista.Add(aux);
                    }

                    datos.cerrarConexion();
                    return lista;
                }
            catch(Exception ex)
            {
                    throw ex;              
            }

        }
    }
}
