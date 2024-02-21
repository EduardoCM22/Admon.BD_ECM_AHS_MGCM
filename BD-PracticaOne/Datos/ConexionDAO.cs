using MySql.Data.MySqlClient;
using System;

namespace Datos
{
    public class ConexionDAO
    {

        public static MySqlConnection conexion;

        public static bool Connect()
        {
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open) return true;

                conexion = new MySqlConnection();
                //Conexion local
                //conexion.ConnectionString = "server=localhost;uid=root;pwd=root;database=PracticaOne";
                // Esta es la AHS conexion.ConnectionString = "server=localhost;uid=root;pwd=root;database=PracticaOne";
                conexion.ConnectionString = "server=4.246.140.42;uid=GerenteApp;pwd=Qwerty12345;database=PracticaOne";
                //conexion.ConnectionString = "server=localhost;uid=root;pwd=root;database=northwind";
                //Conexion a azure
                //conexion.ConnectionString = "server=proyecto.mysql.database.azure.com;uid=Cliente;pwd=TBD_Proyecto;database=Login";
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public static void Disconnect()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
            conexion.Dispose();

        }
    }
}
