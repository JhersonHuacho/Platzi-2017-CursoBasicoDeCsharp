﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institucion.Models
{    
    public class Alumno : Persona
    {
        public EstadosAlumno Estado { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string ListaInasistencias()
        {
            return Inasistencias.ToString();
        }
        public Alumno(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public override string ConstruirResumen()
        {
            return $"{NombreCompleto}, {NickName}, {Telefono}";
        }
        // 2 formas de escribir el metodo NombreCompleto
        public override string NombreCompleto => base.NombreCompleto.ToUpper();
        //public override string NombreCompleto
        //{
        //    get
        //    {
        //        //return base.NombreCompleto;
        //        return "INFORMACIÓN BLOQUEADA";
        //    }
        //}
    }
}
