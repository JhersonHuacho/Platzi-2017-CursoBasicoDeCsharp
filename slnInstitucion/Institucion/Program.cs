using Institucion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Institucion
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("GESTION DE INSTITUCION");

            Alumno alumno1 = new Alumno("Juan Carlos", "Ruiz")
            {
                Id = 1,                
                Edad = 36,
                Telefono = "944954119",
                Email = "juank@platzi.com"
            };

            Profesor profesor1 = new Profesor()
            {
                Id = 2,
                Nombre = "Freddy",
                Apellido = "Vega",
                Edad = 86,
                Telefono = "944954119",
                Catedra = "Programación"
            };

            WriteLine(Persona.ContadorPersonas);

            ReadLine();
        }
    }
}
