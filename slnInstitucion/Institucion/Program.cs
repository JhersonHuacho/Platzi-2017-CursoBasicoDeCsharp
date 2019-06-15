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

            Alumno alumno1 = new Alumno()
            {
                Id = 1,
                Nombre = "Juan Carlos",
                Apellido = "Ruiz",
                Edad = 36,
                Telefono = "944954119",
                Email = "juank@platzi.com"
            };

            Persona persona1 = new Persona()
            {
                Id = 2,
                Nombre = "Freddy",
                Apellido = "Vega",
                Edad = 86,
                Telefono = "944954119"                
            };

            persona1 = alumno1;           

            ReadLine();
        }
    }
}
