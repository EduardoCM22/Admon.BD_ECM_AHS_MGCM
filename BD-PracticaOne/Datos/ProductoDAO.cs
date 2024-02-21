using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
namespace Datos
{
    public class ProductoDAO
    {

        public List<Producto> ObtenerProductosInventario()
        {
            List<Producto> productos = new List<Producto>();
            if (ConexionDAO.Connect())
            {
                try
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "ObtenerProductosInventario";
                    comando.Connection = ConexionDAO.conexion;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto
                            {
                                ProductoID = Convert.ToInt32(reader["idInventario"]),
                                ProductoNombre = Convert.ToString(reader["nombreCorto"]),
                                ProductoDescripcion = Convert.ToString(reader["Descripcion"]),
                                ProductoSerie = Convert.ToString(reader["Serie"]),
                                ProductoColor = Convert.ToString(reader["Color"]),
                                ProductoFechaAd = Convert.ToDateTime(reader["FechaAdquisicion"]),
                                ProductoTipoAd = Convert.ToString(reader["TipoAdquisicion"]),
                                ProductoObservaciones = Convert.ToString(reader["Observaciones"]),
                                ProductoArea = Convert.ToString(reader["areasId"]),
                            };
                            productos.Add(producto);
                        }
                    }
                }
                finally
                {
                    ConexionDAO.Disconnect();
                }
            }
            return productos;
        }
        public Boolean ActualizarOInsertarProducto(int productoID, string nombreCorto, string descripcion, string serie, string color, DateTime fechaAdquisicion, string tipoAdquisicion, string observaciones, int areasId)
        {
            if (ConexionDAO.Connect())
            {
                try
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "ActualizarOInsertarProducto";
                    comando.Connection = ConexionDAO.conexion;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@p_ProductoID", productoID);
                    comando.Parameters.AddWithValue("@p_NombreCorto", nombreCorto);
                    comando.Parameters.AddWithValue("@p_Descripcion", descripcion);
                    comando.Parameters.AddWithValue("@p_Serie", serie);
                    comando.Parameters.AddWithValue("@p_Color", color);
                    comando.Parameters.AddWithValue("@p_FechaAdquisicion", fechaAdquisicion);
                    comando.Parameters.AddWithValue("@p_TipoAdquisicion", tipoAdquisicion);
                    comando.Parameters.AddWithValue("@p_Observaciones", observaciones);
                    comando.Parameters.AddWithValue("@p_AreasId", areasId);
                    comando.ExecuteNonQuery();
                }
                finally
                {
                    ConexionDAO.Disconnect();
                }
            }
            return true;
        }
        public void EliminarProducto(int productoID)
        {
            if (ConexionDAO.Connect())
            {
                try
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "EliminarProducto";
                    comando.Connection = ConexionDAO.conexion;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@p_ProductoID", productoID);

                    comando.ExecuteNonQuery();
                }
                finally
                {
                    ConexionDAO.Disconnect();
                    
                }
            }
        }


    }
}
