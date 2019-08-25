using Institucion.Miscelanea;
using Institucion.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            var listaProfes = new List<Profesor>();
            string[] lineas = File.ReadAllLines("./Files/Profesores.txt");

            int localId = 0;
            foreach (var linea in lineas)
            {
                listaProfes.Add(new Profesor() { Nombre = linea, Id = localId++ });
            }
            foreach (var profesor in listaProfes)
            {
                WriteLine(profesor.Nombre);
            }

            // crear un archivo binario
            FileStream archivo = File.Open("prefesBinarios.bin", FileMode.OpenOrCreate);
            var binFile = new BinaryWriter(archivo);

            foreach (var profesor in listaProfes)
            {
                //var bytesNombre = Encoding.UTF8.GetBytes(profesor.Nombre);
                //archivo.Write(bytesNombre, 0, bytesNombre.Length);
                binFile.Write(profesor.Nombre);
                binFile.Write(profesor.Id);
            }
            binFile.Close();
            archivo.Close();

            ReadLine();
        }
        public static void Rutina6()
        {
            var profesor = new Profesor()
            {
                Id = 12,
                Nombre = "Mateo",
                Apellido = "Pereira",
                CodigoInterno = "PROFE_SMART"
            };
            var transmitter = new TransmisorDeDatos();
            transmitter.InformacionEnviada += Transmitter_InformacionEnviada;
            transmitter.InformacionEnviada += (obj, evtarg) =>
            {
                Console.WriteLine("WAAAAAAOOOOOOOOO");
            };
            transmitter.FormatearYEnviar(profesor, formatter, "ALEXTROI");
            transmitter.FormatearYEnviar(profesor, ReverseFormatter, "ALEXTROI");

            transmitter.InformacionEnviada -= Transmitter_InformacionEnviada;
            // usando expresiones Lambda
            transmitter.FormatearYEnviar(profesor, (input) => {
                return new string(input.Reverse().ToArray<char>());
            }, "ALEXTROI");
        }
        private static void Transmitter_InformacionEnviada(object sender, EventArgs e)
        {
            Console.WriteLine("TRANSMISION DE INFORMACION"); ;
        }

        private static string ReverseFormatter(string input)
        {
            var reversedString = new string(input.Reverse().ToArray<char>());
            return reversedString;
        }
        private static string formatter(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        public static void Rutina5()
        {
            // Listas
            ArrayList listaPersonas = new ArrayList();

            listaPersonas.Add(new Alumno("Francisco", "Huacho") { NickName = "pancho" });
            listaPersonas.Add(new Profesor() { Nombre = "Alberto", Apellido = "X" });
            listaPersonas.Add(new Alumno("Fernando", "Pedroza"));
            listaPersonas.Add(new Profesor() { Nombre = "Mag", Apellido = "X" });
            listaPersonas.Add(new Alumno("Neto", "Orbe"));

            foreach (var persona in listaPersonas)
            {
                if (persona is Alumno)
                {
                    var al = (Alumno)persona;
                    Console.WriteLine(al.NickName != null ? al.NickName : al.NombreCompleto);
                }
                else
                {
                    var per = persona as Persona;

                    if (per != null)
                        WriteLine(per.NombreCompleto);
                }
            }

            // Listas Genericas
            List<Persona> listaDePersonas = new List<Persona>();
            listaDePersonas.Add(new Alumno("Francisco", "Huacho") { NickName = "pancho" });
            listaDePersonas.Add(new Profesor() { Nombre = "Alberto", Apellido = "X" });
            listaDePersonas.Add(new Alumno("Fernando", "Pedroza"));
            listaDePersonas.Add(new Profesor() { Nombre = "Mag", Apellido = "X" });
            listaDePersonas.Add(new Alumno("Neto", "Orbe"));
        }
        private static void Rutina4()
        {
            Persona[] arregloPersona = new Persona[5];

            var tam = arregloPersona.Length;

            arregloPersona[0] = new Alumno("Francisco", "Huacho") { NickName = "pancho" };
            arregloPersona[1] = new Profesor() { Nombre = "Alberto", Apellido = "X" };
            arregloPersona[2] = new Alumno("Fernando", "Pedroza");
            arregloPersona[3] = new Profesor() { Nombre = "Mag", Apellido = "X" };
            arregloPersona[4] = new Alumno("Neto", "Orbe");
            //arregloPersona[5] = new Profesor() { Nombre = "Juan", Apellido = "X" };

            for (int i = 0; i < arregloPersona.Length; i++)
            {
                if (arregloPersona[i] is Alumno)
                {
                    var al = (Alumno)arregloPersona[i];
                    Console.WriteLine(al.NickName != null ? al.NickName : al.NombreCompleto);
                }
                else
                {
                    WriteLine(arregloPersona[i].NombreCompleto);
                }
            }
        }
        private static void Rutina3()
        {
            var alumno = new Alumno("Victor", "Perez");
            var profesor = new Profesor();
            Persona persona = profesor;

            alumno = (Alumno)persona;
            if (persona is Profesor)
            {
                var profe = (Profesor)persona;
                ///...
            }

            var tmpProfe = persona as Profesor;
            if (tmpProfe != null)
            {
                //...
            }
        }

        [Flags]
        enum Banderas
        {
            NOMBRE_COMPLETO = 1,
            CURSO_COMPLETO = 2,
            TODO_COMPLETO = 3,
            HABILITA_RESUMEN = 4
        }
        public void Rutina1()
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

                IEnteInstituto ente = persona;
                ente.ConstruirLlaveSecreta("Hola");
            }

            Console.WriteLine("S T R U C T S");
            CursoStruct c = new CursoStruct(70);
            c.Curso = "101-B";

            CursoStruct newC = new CursoStruct();
            newC.Curso = "564-A";

            var cursoFreak = c;
            cursoFreak.Curso = "666-G";

            Console.WriteLine($"Curso c = {c.Curso}");
            Console.WriteLine($"Curso Freak = {cursoFreak.Curso}");
            Console.WriteLine("");

            Console.WriteLine("C L A S E S");
            CursoClass c_class = new CursoClass(70);
            c_class.Curso = "101-B";

            //CursoClass newC_class = new CursoClass();
            //newC_class.Curso = "564-A";

            var cursoFreak_class = c_class;
            cursoFreak_class.Curso = "666-G";

            Console.WriteLine($"Curso c = {c_class.Curso}");
            Console.WriteLine($"Curso Freak = {cursoFreak_class.Curso}");

            Console.WriteLine("");
            Console.WriteLine("E N U M E R A C I O N E S");

            var alumnoEstado = new Alumno("Freddy", "Vega")
            {
                Id = 22,
                Edad = 86,
                Telefono = "944954119",
                Estado = EstadosAlumno.Activo
            };
            Persona personax = alumnoEstado;
            IEnteInstituto iei = alumnoEstado;

            Console.WriteLine("Estado de Alumno" + alumnoEstado.Estado);
            Console.WriteLine($"Tipo: {typeof(EstadosAlumno)}");
            Console.WriteLine($"Tipo: {typeof(Alumno)}");
            Console.WriteLine($"Tipo: {iei.GetType()}");
            Console.WriteLine($"Tipo: {alumnoEstado.GetType()}");
            Console.WriteLine($"Tipo: {personax.GetType()}");
            Console.WriteLine($"Nombre: {nameof(Alumno)}");
            Console.WriteLine($"Tamaño: {sizeof(int)}");
        }

        private static void Rutina2()
        {
            short s = 32000;
            int i = 33000;
            float f = 2.35f;
            double dou = 0.0004d;
            decimal d = 0.000000000023m;

            WriteLine(i);
            s = (short)i;
            WriteLine(s);
            WriteLine(f);
            i = (int)f;
            WriteLine(i);
        }
    }
}
