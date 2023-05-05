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
        AccesoDatos datos = new AccesoDatos();
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            
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
        public void Insertar(Articulo Agregar)
        {


            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) Values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @PP)");
                datos.SetearPARAMETROS("@Codigo", Agregar.Codigo);
                datos.SetearPARAMETROS("@Nombre", Agregar.Nombre);
                datos.SetearPARAMETROS("@Descripcion", Agregar.Descripcion);
                datos.SetearPARAMETROS("@IdMarca", Agregar.Marcas.ID);
                datos.SetearPARAMETROS("IdCategoria", Agregar.Categorias.ID);
                datos.SetearPARAMETROS("@PP", Agregar.Precio);

                datos.ejecutarEscritura();

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Articulo BuscarArticuloid(Articulo articulo)
        {
            try
            {
                datos.setearConsulta("SELECT Id, CODIGO, NOMBRE, Descripcion, IdMarca, IdCategoria, PRECIO FROM ARTICULOS WHERE CODIGO = " + articulo.Codigo);
                datos.ejecutarLectura();
                if(datos.Lector.Read())
                { 
                    articulo.ID = (int)datos.Lector["ART"];
                    articulo.Codigo = (string)datos.Lector["CODIGO"];
                    articulo.Nombre = (string)datos.Lector["NOMBRE"];
                    articulo.Descripcion = (string)datos.Lector["DESCRIP"];
                    articulo.Marcas = new Marcas();
                    articulo.Marcas.Marca = (string)datos.Lector["MARDE"];
                    articulo.Marcas.ID = (int)datos.Lector["MAR"];
                    articulo.Categorias = new Categorias();
                    articulo.Categorias.Categoria = (string)datos.Lector["CATEDE"];
                    articulo.Categorias.ID = (int)datos.Lector["CATE"];
                    articulo.Precio = (decimal)datos.Lector["PRECIO"];
                }
                else
                {
                    articulo.ID = 0;
                }
                return articulo;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificar(Articulo articulo)
         {
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, Precio = @precio where Id " + articulo.ID);
                datos.SetearPARAMETROS("@codigo", articulo.Codigo);
                datos.SetearPARAMETROS("@nombre", articulo.Nombre);
                datos.SetearPARAMETROS("@descripcion", articulo.Descripcion);
                datos.SetearPARAMETROS("@idmarca", articulo.Marcas);
                datos.SetearPARAMETROS("@idcategoria", articulo.Categorias);
                datos.SetearPARAMETROS("@precio", articulo.Precio);

                datos.ejecutarEscritura();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        

     }

    
}
