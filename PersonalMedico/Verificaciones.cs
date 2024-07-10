using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalMedico
{
    public class Verificaciones
    {
        public static void VerificacionMaxMinCaracteres(string Objeto, string empleado,string NombrePropiedad, int max)
        {
            if (Objeto.Length < 1)
            {
                MessageBox.Show($"Ingrese {NombrePropiedad}, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (Objeto.Length > max)
            {
                MessageBox.Show($"Se ha excedido del numero máximo de caracteres[{max}] ({NombrePropiedad}).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                empleado = Objeto;
            }
        }
    }
}
