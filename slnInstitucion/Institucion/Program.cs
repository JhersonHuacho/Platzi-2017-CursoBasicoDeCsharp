﻿using Institucion.Models;
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

            //Persona obj = new Persona();

            Persona[] lista = new Persona[3];

            lista[0] = new Alumno("Juan Carlos", "Ruiz")
            {
                Id = 1,                
                Edad = 36,
                Telefono = "944954119",
                Email = "juank@platzi.com"
            };

            lista[1] = new Profesor()
            {
                Id = 2,
                Nombre = "Freddy",
                Apellido = "Vega",
                Edad = 86,
                Telefono = "944954119",
                Catedra = "Programación"
            };

            lista[2] = new Profesor()
            {
                Id = 3,
                Nombre = "William",
                Apellido = "Torvalds",
                Edad = 86,
                Telefono = "944954119",
                Catedra = "Algebra"
            };

            WriteLine(Persona.ContadorPersonas);
            Console.WriteLine("Resumenes");

            foreach (Persona persona in lista)
            {
                Console.WriteLine($"Tipo: {persona.GetType()}");
                Console.WriteLine(persona.ConstruirResumen());
            }

            ReadLine();
        }
    }
}
