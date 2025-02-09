using System;
using System.Collections.Generic;

namespace CommunityApp
{
    // Clase base
    public class MiembroDeLaComunidad
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }

        public MiembroDeLaComunidad(string nombre, string identificacion)
        {
            Nombre = nombre;
            Identificacion = identificacion;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}, Identificación: {Identificacion}");
        }
    }

    public class Empleado : MiembroDeLaComunidad
    {
        public string Departamento { get; set; }

        public Empleado(string nombre, string identificacion, string departamento)
            : base(nombre, identificacion)
        {
            Departamento = departamento;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Departamento: {Departamento}");
        }
    }

    public class Estudiante : MiembroDeLaComunidad
    {
        public string Carrera { get; set; }

        public Estudiante(string nombre, string identificacion, string carrera)
            : base(nombre, identificacion)
        {
            Carrera = carrera;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Carrera: {Carrera}");
        }
    }

    public class ExAlumno : MiembroDeLaComunidad
    {
        public int AnioGraduacion { get; set; }

        public ExAlumno(string nombre, string identificacion, int anioGraduacion)
            : base(nombre, identificacion)
        {
            AnioGraduacion = anioGraduacion;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Año de Graduación: {AnioGraduacion}");
        }
    }

    public class Docente : Empleado
    {
        public Docente(string nombre, string identificacion, string departamento)
            : base(nombre, identificacion, departamento) { }
    }

    public class Administrativo : Empleado
    {
        public Administrativo(string nombre, string identificacion, string departamento)
            : base(nombre, identificacion, departamento) { }
    }

    public class Maestro : Docente
    {
        public string Especialidad { get; set; }

        public Maestro(string nombre, string identificacion, string departamento, string especialidad)
            : base(nombre, identificacion, departamento)
        {
            Especialidad = especialidad;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Especialidad: {Especialidad}");
        }
    }

    public class Administrador : Docente
    {
        public Administrador(string nombre, string identificacion, string departamento)
            : base(nombre, identificacion, departamento) { }

        public void GestionarRecursos()
        {
            Console.WriteLine("Gestionando recursos de la comunidad educativa.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<MiembroDeLaComunidad> miembros = new List<MiembroDeLaComunidad>
            {
                new Estudiante("Juan Perez", "E001", "Ingeniería de Software"),
                new ExAlumno("Ana Martínez", "X002", 2015),
                new Maestro("Carlos López", "M003", "Matemáticas", "Algebra"),
                new Administrativo("Marta Ruiz", "A004", "Recursos Humanos"),
                new Administrador("Luis Gómez", "AD005", "Administración General")
            };

            foreach (var miembro in miembros)
            {
                miembro.MostrarInformacion();
                Console.WriteLine();
            }
        }
    }
}
