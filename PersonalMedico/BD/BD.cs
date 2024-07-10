using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalMedico.BD
{
    public static class BD
    {

        public static SqlConnection Conection()//Hacemos una funcion que retorne un SqlConnection
        {
            SqlConnection conexion = new SqlConnection("Server=DESKTOP-3MSS1LQ\\JAIFY3; Database=PersonalMedico; Trusted_Connection=true; Integrated Security=SSPI;Persist Security Info=False;");//Trusted_Connection utiliza al usuario que inicio sesion en windows
            conexion.Open();

            return conexion;
        }
    }
}
