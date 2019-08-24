using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institucion.Models
{
    struct CursoStruct
    {
        const string NOMBRE_DEF_CURSO = "NO ASIGNADO";
        public string Curso { get; set; }
        public readonly short max_capacidad;

        public CursoStruct(short max_cap)
        {
            max_capacidad = max_cap;
            Curso = NOMBRE_DEF_CURSO;
        }
    }
}
