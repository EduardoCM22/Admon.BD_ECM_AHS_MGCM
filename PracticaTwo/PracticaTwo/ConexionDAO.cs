using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PracticaTwo
{
    public class ConexionDAO
    {
        // String conexionGeneral = "Data Source=EDWARDCM;Initial Catalog=BIBLIOTECA;User ID=sa;Password=root;";
        // String conexionGeneral = "Data Source=20.106.175.61;Initial Catalog=BIBLIOTECA;User ID=sa;Password=Password1234;";
        String conexionGeneral = "Data Source=WindowsServer;Initial Catalog=BIBLIOTECA;User ID=sa;Password=Password1234;";

        public void Insert(Book book)
        {
            // Establecer la cadena de conexión
            string connectionString =
                "Data Source=EDWARDCM;Initial Catalog=BIBLIOTECA;User ID=sa;Password=root;";

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(conexionGeneral))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear una consulta SQL de inserción
                    string query =
                    "INSERT INTO LIBROS (id, ISBN, titulo, numeroEdicion, anioPublicacion,autores, paisPublicacion, sinopsis, carrera, materia)" +
                    " VALUES (@id, @ISBN, @titulo,@numeroEdicion, @anioPublicacion,@autores, @paisPublicacion, @sinopsis, @carrera, @materia)";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Añadir parámetros a la consulta SQL
                    command.Parameters.AddWithValue("@id", book.id);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@titulo", book.title);
                    command.Parameters.AddWithValue("@numeroEdicion", book.editionNumber);
                    command.Parameters.AddWithValue("@anioPublicacion", book.yearOfPublication);
                    command.Parameters.AddWithValue("@autores", book.authors);
                    command.Parameters.AddWithValue("@paisPublicacion", book.countryOfPublication);
                    command.Parameters.AddWithValue("@sinopsis",book.synopsis);
                    command.Parameters.AddWithValue("@carrera", book.career);
                    command.Parameters.AddWithValue("@materia", book.subject);

                    // Ejecutar la consulta SQL
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si se ha insertado alguna fila
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Se ha insertado una fila en la tabla ALUMNOS");
                    }
                    else
                    {
                        Console.WriteLine("No se ha insertado ninguna fila en la tabla ALUMNOS");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public List<Book> Select()
        {
            List<Book> list = new List<Book>();
            // Establecer la cadena de conexión
            string connectionString =
                "Data Source=ELITEBOOK-G2;Initial Catalog=BIBLIOTECA;User ID=sa;Password=root;";

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(conexionGeneral))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear una consulta SQL de inserción
                    string query =
                    "select * from LIBROS";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar la consulta SQL
                    //int rowsAffected = command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Book book = new Book();
                        book.id = Convert.ToInt32(reader["ID"]);
                        book.ISBN = reader["ISBN"].ToString();
                        book.title = reader["Titulo"].ToString();
                        book.editionNumber = Convert.ToInt32(reader["NumeroEdicion"]);
                        book.yearOfPublication = Convert.ToInt32(reader["AnioPublicacion"]);
                        book.authors = reader["Autores"].ToString();
                        book.countryOfPublication = reader["PaisPublicacion"].ToString();
                        book.synopsis = reader["Sinopsis"].ToString();
                        book.career = reader["Carrera"].ToString();
                        book.subject = reader["Materia"].ToString();
                        list.Add(book);
                    }
                    /*
                      ID INT PRIMARY KEY,
                        ISBN VARCHAR(20) NOT NULL,
                        Titulo NVARCHAR(100) NOT NULL,
                        NumeroEdicion INT,
                        AnioPublicacion INT,
                        Autores NVARCHAR(100) NOT NULL,
                        PaisPublicacion NVARCHAR(50),
                        Sinopsis NVARCHAR(MAX),
                        Carrera NVARCHAR(100),
                        Materia NVARCHAR(100)
                     */
                    return list;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return list;
            }
        }
    }
}