using PersonalMedico.BD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalMedico
{
    public class EmpleadoSet
    {
        public static int AgregarPersona(Empleado empleado)
        {
            int retorna = 0;

            using (SqlConnection conexion= BD.BD.Conection())
            {
                string query = "INSERT INTO Empleados (Nombre, Apellido, Provincia, Domicilio, Localidad, Especialidad, DiasDeAtencion, DiasDeGuardia, FechaDeIngreso, Sueldo) " +
                       "VALUES (@Nombre, @Apellido, @Provincia, @Domicilio, @Localidad, @Especialidad, @DiasDeAtencion, @DiasDeGuardia, @FechaDeIngreso, @Sueldo)";
                SqlCommand command = new SqlCommand(query, conexion);

                command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                command.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                command.Parameters.AddWithValue("@Provincia", empleado.Provincia);
                command.Parameters.AddWithValue("@Domicilio", empleado.Domicilio); // Asegúrate de que esté presente y correctamente asignado
                command.Parameters.AddWithValue("@Localidad", empleado.Localidad);
                command.Parameters.AddWithValue("@Especialidad", empleado.Especialidad);
                command.Parameters.AddWithValue("@DiasDeAtencion", empleado.DiasDeAtencion);
                command.Parameters.AddWithValue("@DiasDeGuardia", empleado.DiasDeGuardia);
                command.Parameters.AddWithValue("@FechaDeIngreso", empleado.FechaIngreso);
                command.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);

                try
                {
                    retorna = command.ExecuteNonQuery();
                    if (retorna>0)
                    {
                        MessageBox.Show("El empleado Fue insertado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el empleado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                    }
                }
                catch(Exception e) 
                {
                    MessageBox.Show($"Ocurrió un error: {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                }
                
            }
            return retorna;
        }//Bien!

        public static List<Empleado> Registros()
        {
            List<Empleado> lista = new List<Empleado>();

            using (SqlConnection conexion = BD.BD.Conection())
            {
                string query = "SELECT * FROM Empleados";

                SqlCommand command = new SqlCommand(query, conexion);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Empleado empleado = new Empleado();

                    empleado.Id = reader.GetInt32(0);
                    empleado.Nombre = reader.GetString(1);
                    empleado.Apellido = reader.GetString(2);
                    empleado.Provincia = reader.GetString(3);
                    empleado.Domicilio = reader.GetString(4);
                    empleado.Localidad = reader.GetString(5);
                    empleado.Especialidad = reader.GetString(6);
                    empleado.DiasDeAtencion = reader.GetString(7);
                    empleado.DiasDeGuardia = reader.GetString(8);
                    empleado.FechaIngreso = reader.GetDateTime(9);
                    empleado.Sueldo = reader.GetDecimal(10);
                    lista.Add(empleado);
                }
                conexion.Close();
                return lista;
            }
        }//Bien!

        public static int Modificar(Empleado empleado)
        {
            int retorno = 0;

            using (SqlConnection conexion = BD.BD.Conection())
            {
                string query = "UPDATE Empleados SET Nombre=@Nombre, Apellido=@Apellido, Provincia=@Provincia, " +
                               "Localidad=@Localidad, Especialidad=@Especialidad, DiasDeAtencion=@DiasDeAtencion, " +
                               "DiasDeGuardia=@DiasDeGuardia, FechaDeIngreso=@FechaDeIngreso, Sueldo=@Sueldo " +
                               "WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                cmd.Parameters.AddWithValue("@Provincia", empleado.Provincia);
                cmd.Parameters.AddWithValue("@Localidad", empleado.Localidad);
                cmd.Parameters.AddWithValue("@Especialidad", empleado.Especialidad);
                cmd.Parameters.AddWithValue("@DiasDeAtencion", empleado.DiasDeAtencion);
                cmd.Parameters.AddWithValue("@DiasDeGuardia", empleado.DiasDeGuardia);
                cmd.Parameters.AddWithValue("@FechaDeIngreso", empleado.FechaIngreso);
                cmd.Parameters.AddWithValue("@Sueldo", empleado.Sueldo);
                cmd.Parameters.AddWithValue("@Id", empleado.Id);

                try
                {
                    retorno = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Manejo de excepciones (log, mostrar mensaje, etc.)
                    MessageBox.Show("Error al modificar empleado: " + ex.Message);
                }


                return retorno;
            }
        }//Bien!

        public static int Eliminar(Empleado empleado)
        {
            int retorno = 0;

            using (SqlConnection conexion = BD.BD.Conection())
            {
                string query = "DELETE FROM Empleados WHERE Id=@Id";

                SqlCommand comando= new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Id", empleado.Id);

                retorno = comando.ExecuteNonQuery();

                return retorno;
            }
        }//Bien!

    }

}
