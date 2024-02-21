using Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Datos
{
    public class AreaDAO
    { 
        public Boolean ActualizarOInsertarArea(int areaID, string areaNombre, string ubicacion)
        {
            if (ConexionDAO.Connect())
            {
                try
                {

                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "ActualizarOInsertarArea";
                    comando.Connection = ConexionDAO.conexion;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@p_AreaID", areaID);
                    comando.Parameters.AddWithValue("@p_AreaNombre", areaNombre);
                    comando.Parameters.AddWithValue("@p_Ubicacion", ubicacion);
                    comando.ExecuteNonQuery();
                }
                finally
                {
                    ConexionDAO.Disconnect();
                }
            }
            return true;
        }
        public List<Area> ObtenerAreas()
        {
            List<Area> ListaAreas = new List<Area>();

            if (ConexionDAO.Connect())
            {
                try
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "ObtenerAreas"; // Nombre de tu procedimiento almacenado
                    comando.Connection = ConexionDAO.conexion;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Area area = new Area(
                                Convert.ToInt32(reader["idArea"]),
                                reader["Nombre"].ToString(),
                                reader["Ubicacion"].ToString()
                            );
                            ListaAreas.Add(area);
                        }
                    }
                    return ListaAreas;
                }
                finally
                {
                    ConexionDAO.Disconnect();
                }
            }
            else
            {
                return null;
            }
        }
        public void EliminarArea(int areaId)
        {
            if (ConexionDAO.Connect())
            {
                try
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "EliminarArea";
                    comando.Connection = ConexionDAO.conexion;
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@p_AreaID", areaId);

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
