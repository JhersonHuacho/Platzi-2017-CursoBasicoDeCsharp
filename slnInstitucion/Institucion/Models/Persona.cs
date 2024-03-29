﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institucion.Models
{
    public abstract class Persona : IEnteInstituto
    {
        public static int ContadorPersonas = 0;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public short Edad { get; set; }
        public string Telefono { get; set; }
        protected int Inasistencias { get; set; }
        public virtual string NombreCompleto
        {
            get { return $"{Nombre} {Apellido}"; } // string literal
        }

        public string CodigoInterno { get; set; }

        // si lo dejamos como publico, este constructor se ejecuta cada vez que cree un objeto Persona,
        // no solo la primera vez.
        public Persona()
        {
            ContadorPersonas++; // este me devuelve primero el valor y luego lo incrementa
            //++ContadorPersonas; // este primero incrementa y luego me devuelve el valor.
        }

        // este constructor seria llamado una sola vez cuando se cree el primer objeto persona
        //static Persona()
        //{

        //}

        public abstract string ConstruirResumen();

        public string ConstruirLlaveSecreta(string nombreEnte)
        {
            var rnd = new Random();           

            return rnd.Next(1, 9998945).ToString();
        }
    }
}
