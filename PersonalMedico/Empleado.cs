using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalMedico
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Provincia {  get; set; }
        public string Domicilio { get; set; }
        public string Localidad {  get; set; }
        public string Especialidad {  get; set; }
        public string DiasDeAtencion { get; set; }
        public string DiasDeGuardia { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal Sueldo {  get; set; }

        public Empleado() { }

        public Empleado(int Id, string Nombre, string Apellido, string Provincia, string Domicilio, string Localidad, string Especialidad, string DiasDeAtencion, string DiasDeGuardia
            , DateTime FechaIngreso, decimal Sueldo)
        {
            this.Id = Id;
            this.Nombre = Nombre; 
            this.Apellido = Apellido;
            this.Provincia = Provincia;
            this.DiasDeGuardia = DiasDeGuardia;
            this.Sueldo = Sueldo;
            this.Domicilio = Domicilio;
            this.Localidad = Localidad;
            this.Especialidad = Especialidad;
            this.DiasDeAtencion = DiasDeAtencion;
            this.FechaIngreso = FechaIngreso;
        }
    }
}
