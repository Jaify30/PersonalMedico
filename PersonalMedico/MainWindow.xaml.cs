using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using PersonalMedico.BD;
using System.Data.Common;
using System.Data.SqlTypes;


namespace PersonalMedico
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IdG.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado();

            //Verificación nombre
            
                if (NombreG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese un Nombre, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                }
                if (NombreG.Text.Length>50)
                {
                    MessageBox.Show("Se ha excedido del numero maximo de caracteres[50] (Nombre).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Nombre = NombreG.Text;
                }

                //Verificación Apellido

                if (ApellidoG.Text.Length<1)
                {
                    MessageBox.Show("Ingrese un Apellido, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (ApellidoG.Text.Length > 50) 
                {
                    MessageBox.Show("Se ha excedido del numero maximo de caracteres[50] (Apellido).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Apellido = ApellidoG.Text;
                }

                //Verificación Provincia

                if (ProvinciaG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese una Provincia, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (ProvinciaG.Text.Length > 50)
                {
                    MessageBox.Show("Se ha excedido del numero máximo de caracteres[50] (Provincia).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Provincia = ProvinciaG.Text;
                }

                //Verificación Domicilio
                if (DomicilioG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese un Domicilio, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (DomicilioG.Text.Length > 50)
                {
                    MessageBox.Show("Se ha excedido del numero máximo de caracteres[50] (Domicilio).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Domicilio = DomicilioG.Text;
                }


                //Verificacion Localidad
                if (LocalidadG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese una Localidad, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (LocalidadG.Text.Length > 40)
                {
                    MessageBox.Show("Se ha excedido del numero máximo de caracteres[40] (Localidad).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Localidad = LocalidadG.Text;
                }

                //Verificacion Especialidad
                if (EspecialidadG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese una Especialidad, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (EspecialidadG.Text.Length > 30)
                {
                    MessageBox.Show("Se ha excedido del numero máximo de caracteres[30] (Especialidad).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Especialidad = EspecialidadG.Text;
                }

                //Verificacion Dias de Atencion
                string DiasDeAtencionAux = "";

                if (AtencionLunes.IsChecked == true)
                {
                    DiasDeAtencionAux += "Lunes ";
                }
                if (AtencionMartes.IsChecked == true)
                {
                    DiasDeAtencionAux += "Martes ";
                }
                if (AtencionMiercoles.IsChecked == true)
                {
                    DiasDeAtencionAux += "Miercoles ";
                }
                if (AtencionJueves.IsChecked == true)
                {
                    DiasDeAtencionAux += "Jueves ";
                }
                if (AtencionViernes.IsChecked == true)
                {
                    DiasDeAtencionAux += "Viernes ";
                }
                if (AtencionSabados.IsChecked == true)
                {
                    DiasDeAtencionAux += "Sabado ";
                }
                if (AtencionDomingos.IsChecked == true)
                {
                    DiasDeAtencionAux += "Domingo ";
                }

                if (string.IsNullOrWhiteSpace(DiasDeAtencionAux))
                {
                    MessageBox.Show("Por favor, seleccione al menos una opción.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    DiasDeAtencionAux = DiasDeAtencionAux.TrimEnd();
                    empleado.DiasDeAtencion = DiasDeAtencionAux;
                    AtencionLunes.IsChecked = false;
                    AtencionMiercoles.IsChecked = false;
                    AtencionMartes.IsChecked = false;
                    AtencionJueves.IsChecked = false;
                    AtencionViernes.IsChecked=false;
                    AtencionSabados.IsChecked = false;
                    AtencionDomingos.IsChecked=false;
                }

                //Verificacion Dias de guardia
                string DiasDeGuardiaAux = "";
                if (GuardiaLunes.IsChecked==true)
                {
                    DiasDeGuardiaAux += "Lunes ";
                }
                if (GuardianMartes.IsChecked==true)
                {
                    DiasDeGuardiaAux += "Martes ";
                }
                if (GuardiaMiercoles.IsChecked==true)
                {
                    DiasDeGuardiaAux += "Miercoles ";
                }
                if (GuardiaJueves.IsChecked == true)
                {
                    DiasDeGuardiaAux += "Jueves ";
                }
                if (GuardiaViernes.IsChecked==true)
                {
                    DiasDeGuardiaAux += "Viernes"; 
                }
                if (GuardiaSabados.IsChecked==true)
                {
                    DiasDeGuardiaAux += "Sabados ";
                }
                if (GuardiaDomingos.IsChecked==true)
                {
                    DiasDeGuardiaAux += "Domingos ";
                }

                if (string.IsNullOrWhiteSpace(DiasDeGuardiaAux))
                {
                    MessageBox.Show("Por favor, seleccione al menos una opción.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    DiasDeAtencionAux = DiasDeGuardiaAux.TrimEnd();
                    empleado.DiasDeGuardia = DiasDeGuardiaAux;
                    GuardiaLunes.IsChecked = false;
                    GuardianMartes.IsChecked = false;
                    GuardiaMiercoles.IsChecked = false;
                    GuardiaJueves.IsChecked = false;
                    GuardiaViernes.IsChecked=false;
                    GuardiaSabados.IsChecked = false;
                    GuardiaDomingos.IsChecked=false;
                }

                //Ingresa la fecha de ingreso
                if (DateTime.TryParse(FechaIngresoG.Text, out DateTime fechaIngreso))
                {
                    if (fechaIngreso >= SqlDateTime.MinValue.Value && fechaIngreso <= SqlDateTime.MaxValue.Value)
                    {
                        empleado.FechaIngreso = fechaIngreso;

                    }
                    else
                    {
                        MessageBox.Show("La fecha de ingreso está fuera del rango permitido.");
                    }
                }
                else
                {
                    MessageBox.Show("Fecha de ingreso inválida.");
                }

                //sueldo
                decimal sueldo;
                if (decimal.TryParse(SueldoG.Text, out sueldo))
                {
                    // Asigna el sueldo solo si la conversión fue exitosa
                    empleado.Sueldo = sueldo;
                }
                else
                {
                    // Manejo del error en caso de que el usuario ingrese un valor no válido
                    MessageBox.Show("El valor ingresado no es un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                int Agregar=EmpleadoSet.AgregarPersona(empleado);

                if (Agregar > 0)
                {
                    MessageBox.Show("Empleado agregado correctamente!");
                    IdG.Text = "";
                    NombreG.Text = "";
                    ApellidoG.Text = "";
                    ProvinciaG.Text = "";
                    DomicilioG.Text = "";
                    LocalidadG.Text = "";
                    EspecialidadG.Text = "";
                    FechaIngresoG.SelectedDate = null;
                    SueldoG.Text = "";
                    GuardiaLunes.IsChecked = false;
                    GuardianMartes.IsChecked = false;
                    GuardiaMiercoles.IsChecked = false;
                    GuardiaJueves.IsChecked = false;
                    GuardiaViernes.IsChecked = false;
                    GuardiaSabados.IsChecked = false;
                    GuardiaDomingos.IsChecked = false;
                    GuardiaLunes.IsChecked = false;
                    GuardianMartes.IsChecked = false;
                    GuardiaMiercoles.IsChecked = false;
                    GuardiaJueves.IsChecked = false;
                    GuardiaViernes.IsChecked = false;
                    GuardiaSabados.IsChecked = false;
                    GuardiaDomingos.IsChecked = false;
            }
                else
                {
                    MessageBox.Show("No se ha podido Guardar los datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            Refresh_Pantalla();
        }

        private void Ver_Click(object sender, RoutedEventArgs e)
        {
            Refresh_Pantalla();
            IdG.IsEnabled = false;
        }

        private void Refresh_Pantalla()
        {
            ViewData.ItemsSource = EmpleadoSet.Registros();
        }

        private void Modificar_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado();
            try
            {

            
                empleado.Id=int.Parse(IdG.Text);

                if (NombreG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese un Nombre, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (NombreG.Text.Length > 50)
                {
                    MessageBox.Show("Se ha excedido del numero maximo de caracteres[50] (Nombre).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Nombre = NombreG.Text;
                }

                //Verificación Apellido

                if (ApellidoG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese un Apellido, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (ApellidoG.Text.Length > 50)
                {
                    MessageBox.Show("Se ha excedido del numero maximo de caracteres[50] (Apellido).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Apellido = ApellidoG.Text;
                }

                //Verificación Provincia

                if (ProvinciaG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese una Provincia, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (ProvinciaG.Text.Length > 50)
                {
                    MessageBox.Show("Se ha excedido del numero máximo de caracteres[50] (Provincia).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Provincia = ProvinciaG.Text;
                }

                //Verificación Domicilio
                if (DomicilioG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese un Domicilio, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (DomicilioG.Text.Length > 50)
                {
                    MessageBox.Show("Se ha excedido del numero máximo de caracteres[50] (Domicilio).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Domicilio = DomicilioG.Text;
                }


                //Verificacion Localidad
                if (LocalidadG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese una Localidad, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (LocalidadG.Text.Length > 40)
                {
                    MessageBox.Show("Se ha excedido del numero máximo de caracteres[40] (Localidad).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Localidad = LocalidadG.Text;
                }

                //Verificacion Especialidad
                if (EspecialidadG.Text.Length < 1)
                {
                    MessageBox.Show("Ingrese una Especialidad, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (EspecialidadG.Text.Length > 30)
                {
                    MessageBox.Show("Se ha excedido del numero máximo de caracteres[30] (Especialidad).", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    empleado.Especialidad = EspecialidadG.Text;
                }

                //Verificacion Dias de Atencion
                string DiasDeAtencionAux = "";

                if (AtencionLunes.IsChecked == true)
                {
                    DiasDeAtencionAux += "Lunes ";
                }
                if (AtencionMartes.IsChecked == true)
                {
                    DiasDeAtencionAux += "Martes ";
                }
                if (AtencionMiercoles.IsChecked == true)
                {
                    DiasDeAtencionAux += "Miercoles ";
                }
                if (AtencionJueves.IsChecked == true)
                {
                    DiasDeAtencionAux += "Jueves ";
                }
                if (AtencionViernes.IsChecked == true)
                {
                    DiasDeAtencionAux += "Viernes ";
                }
                if (AtencionSabados.IsChecked == true)
                {
                    DiasDeAtencionAux += "Sabado ";
                }
                if (AtencionDomingos.IsChecked == true)
                {
                    DiasDeAtencionAux += "Domingo ";
                }

                if (string.IsNullOrWhiteSpace(DiasDeAtencionAux))
                {
                    MessageBox.Show("Por favor, seleccione al menos una opción.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    DiasDeAtencionAux = DiasDeAtencionAux.TrimEnd();
                    empleado.DiasDeAtencion = DiasDeAtencionAux;
                    AtencionLunes.IsChecked = false;
                    AtencionMiercoles.IsChecked = false;
                    AtencionMartes.IsChecked = false;
                    AtencionJueves.IsChecked = false;
                    AtencionViernes.IsChecked = false;
                    AtencionSabados.IsChecked = false;
                    AtencionDomingos.IsChecked = false;
                }

                //Verificacion Dias de guardia
                string DiasDeGuardiaAux = "";
                if (GuardiaLunes.IsChecked == true)
                {
                    DiasDeGuardiaAux += "Lunes ";
                }
                if (GuardianMartes.IsChecked == true)
                {
                    DiasDeGuardiaAux += "Martes ";
                }
                if (GuardiaMiercoles.IsChecked == true)
                {
                    DiasDeGuardiaAux += "Miercoles ";
                }
                if (GuardiaJueves.IsChecked == true)
                {
                    DiasDeGuardiaAux += "Jueves ";
                }
                if (GuardiaViernes.IsChecked == true)
                {
                    DiasDeGuardiaAux += "Viernes";
                }
                if (GuardiaSabados.IsChecked == true)
                {
                    DiasDeGuardiaAux += "Sabados ";
                }
                if (GuardiaDomingos.IsChecked == true)
                {
                    DiasDeGuardiaAux += "Domingos ";
                }

                if (string.IsNullOrWhiteSpace(DiasDeGuardiaAux))
                {
                    MessageBox.Show("Por favor, seleccione al menos una opción.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    DiasDeAtencionAux = DiasDeGuardiaAux.TrimEnd();
                    empleado.DiasDeGuardia = DiasDeGuardiaAux;
                    GuardiaLunes.IsChecked = false;
                    GuardianMartes.IsChecked = false;
                    GuardiaMiercoles.IsChecked = false;
                    GuardiaJueves.IsChecked = false;
                    GuardiaViernes.IsChecked = false;
                    GuardiaSabados.IsChecked = false;
                    GuardiaDomingos.IsChecked = false;
                }

                //Ingresa la fecha de ingreso
                if (DateTime.TryParse(FechaIngresoG.Text, out DateTime fechaIngreso))
                {
                    if (fechaIngreso >= SqlDateTime.MinValue.Value && fechaIngreso <= SqlDateTime.MaxValue.Value)
                    {
                        empleado.FechaIngreso = fechaIngreso;

                    }
                    else
                    {
                        MessageBox.Show("La fecha de ingreso está fuera del rango permitido.");
                    }
                }
                else
                {
                    MessageBox.Show("Fecha de ingreso inválida.");
                }

                //sueldo
                decimal sueldo;
                if (decimal.TryParse(SueldoG.Text, out sueldo))
                {
                    // Asigna el sueldo solo si la conversión fue exitosa
                    empleado.Sueldo = sueldo;
                }
                else
                {
                    // Manejo del error en caso de que el usuario ingrese un valor no válido
                    MessageBox.Show("El valor ingresado no es un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                int Modificar = EmpleadoSet.Modificar(empleado);

                if (Modificar > 0)
                {
                    MessageBox.Show("Empleado Modificado correctamente!");
                    IdG.Text = "";
                    NombreG.Text = "";
                    ApellidoG.Text = "";
                    ProvinciaG.Text = "";
                    DomicilioG.Text = "";
                    LocalidadG.Text = "";
                    EspecialidadG.Text = "";
                    FechaIngresoG.SelectedDate = null;
                    SueldoG.Text = "";
                    GuardiaLunes.IsChecked = false;
                    GuardianMartes.IsChecked = false;
                    GuardiaMiercoles.IsChecked = false;
                    GuardiaJueves.IsChecked = false;
                    GuardiaViernes.IsChecked = false;
                    GuardiaSabados.IsChecked = false;
                    GuardiaDomingos.IsChecked = false;
                    GuardiaLunes.IsChecked = false;
                    GuardianMartes.IsChecked = false;
                    GuardiaMiercoles.IsChecked = false;
                    GuardiaJueves.IsChecked = false;
                    GuardiaViernes.IsChecked = false;
                    GuardiaSabados.IsChecked = false;
                    GuardiaDomingos.IsChecked = false;
                }
                else
                {
                    MessageBox.Show("No se ha podido Modificar los datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Seleccione un empleado a modificar por favor.");
            }
            Refresh_Pantalla();
        }

        private void ViewData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewData.SelectedItem is Empleado selectedItem)
            {
                IdG.Text= selectedItem.Id.ToString();
                NombreG.Text = selectedItem.Nombre;
                ApellidoG.Text = selectedItem.Apellido;
                ProvinciaG.Text = selectedItem.Provincia;
                DomicilioG.Text = selectedItem.Domicilio;
                LocalidadG.Text = selectedItem.Localidad;
                EspecialidadG.Text = selectedItem.Especialidad;
                FechaIngresoG.SelectedDate = selectedItem.FechaIngreso;
                SueldoG.Text = selectedItem.Sueldo.ToString();

                // Actualizar los CheckBoxes de Dias de Atención
                AtencionLunes.IsChecked = selectedItem.DiasDeAtencion.Contains("Lunes");
                AtencionMartes.IsChecked = selectedItem.DiasDeAtencion.Contains("Martes");
                AtencionMiercoles.IsChecked = selectedItem.DiasDeAtencion.Contains("Miercoles");
                AtencionJueves.IsChecked = selectedItem.DiasDeAtencion.Contains("Jueves");
                AtencionViernes.IsChecked = selectedItem.DiasDeAtencion.Contains("Viernes");
                AtencionSabados.IsChecked = selectedItem.DiasDeAtencion.Contains("Sabado");
                AtencionDomingos.IsChecked = selectedItem.DiasDeAtencion.Contains("Domingo");

                // Actualizar los CheckBoxes de Dias de Guardia
                GuardiaLunes.IsChecked = selectedItem.DiasDeGuardia.Contains("Lunes");
                GuardianMartes.IsChecked = selectedItem.DiasDeGuardia.Contains("Martes");
                GuardiaMiercoles.IsChecked = selectedItem.DiasDeGuardia.Contains("Miercoles");
                GuardiaJueves.IsChecked = selectedItem.DiasDeGuardia.Contains("Jueves");
                GuardiaViernes.IsChecked = selectedItem.DiasDeGuardia.Contains("Viernes");
                GuardiaSabados.IsChecked = selectedItem.DiasDeGuardia.Contains("Sabado");
                GuardiaDomingos.IsChecked = selectedItem.DiasDeGuardia.Contains("Domingo");
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                MessageBoxResult resultado = MessageBox.Show("¿Estás seguro de querer realizar esta acción?",
                                                      "Confirmación",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);

                if (resultado == MessageBoxResult.Yes)
                {
                    Empleado empleado = new Empleado();

                    empleado.Id = int.Parse(IdG.Text);

                    int Eliminar = EmpleadoSet.Eliminar(empleado);

                    if (Eliminar > 0)
                    {
                        MessageBox.Show("El empleado se ha eliminado");
                        IdG.Text = "";
                        NombreG.Text = "";
                        ApellidoG.Text = "";
                        ProvinciaG.Text = "";
                        DomicilioG.Text = "";
                        LocalidadG.Text = "";
                        EspecialidadG.Text = "";
                        FechaIngresoG.SelectedDate = null;
                        SueldoG.Text = "";
                        GuardiaLunes.IsChecked = false;
                        GuardianMartes.IsChecked = false;
                        GuardiaMiercoles.IsChecked = false;
                        GuardiaJueves.IsChecked = false;
                        GuardiaViernes.IsChecked = false;
                        GuardiaSabados.IsChecked = false;
                        GuardiaDomingos.IsChecked = false;
                        GuardiaLunes.IsChecked = false;
                        GuardianMartes.IsChecked = false;
                        GuardiaMiercoles.IsChecked = false;
                        GuardiaJueves.IsChecked = false;
                        GuardiaViernes.IsChecked = false;
                        GuardiaSabados.IsChecked = false;
                        GuardiaDomingos.IsChecked = false;
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el empleado", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un empleado, por favor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Refresh_Pantalla();
        }
    }
}
