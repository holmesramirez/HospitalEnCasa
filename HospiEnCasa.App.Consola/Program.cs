using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;
using System.Collections.Generic;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        
        private static IRepositorioPaciente _repoPaciente= new RepositorioPaciente(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World EF!");
            AddPacienteConSignosVitales();
            AddPaciente();
            BuscarPaciente(2);
            //AsignarMedico();
            AddSignosPaciente(1);
            ListarPacientesMasculinos();
            ListarPacientesCorazon();

        }

        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Pedro",
                Apellidos = "Julio",
                NumeroTelefono = "jfg",
                Genero = Genero.Masculino,
                Direccion = "Calle 4 Njkjhkhko 7-4",
                Longitud = 5.98062F,
                Latitud = -75.52290F,
                Ciudad = "Cali",
                FechaNacimiento = new DateTime(1989, 04, 12)
            };
            _repoPaciente.AddPaciente(paciente);
          
        }

        private static void AddPacienteConSignosVitales()
        {
            var paciente = new Paciente
            {
                Nombre = "Juan",
                Apellidos = "Sosa",
                NumeroTelefono = "65755",
                Genero = Genero.Masculino,
                Direccion = "Calle 4 Njkjhkhko 7-4",
                Longitud = 5.98062F,
                Latitud = -75.52290F,
                Ciudad = "Meedellin",
                FechaNacimiento = new DateTime(1989, 04, 12),
                SignosVitales = new List<SignoVital> {
                    new SignoVital{FechaHora=new DateTime(2021,09,11,18,50,0), Valor=20, Signo=TipoSigno.TemperaturaCorporal},
                    new SignoVital{FechaHora=new DateTime(2021,09,11,18,50,0), Valor=30, Signo=TipoSigno.SaturacionOxigeno},
                    new SignoVital{FechaHora=new DateTime(2021,09,11,18,50,0), Valor=50, Signo=TipoSigno.FrecuenciaCardica},
                }

            };
            _repoPaciente.AddPaciente(paciente);
          
        }

        private static void AddSignosPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            if(paciente!=null)
            {
                if(paciente.SignosVitales!=null)
                {
                    paciente.SignosVitales.Add(new SignoVital{FechaHora=new DateTime(2021,09,11,18,50,0), Valor=50, Signo=TipoSigno.FrecuenciaCardica});
                }
                else
                {
                    paciente.SignosVitales = new List<SignoVital> {
                         new SignoVital{FechaHora=new DateTime(2021,09,11,18,50,0), Valor=86, Signo=TipoSigno.FrecuenciaCardica}
                    };
                }

                _repoPaciente.UpdatePaciente(paciente);
            }
        }

        private static void BuscarPaciente(int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            Console.WriteLine(paciente.Nombre+" "+paciente.Apellidos);
        }

        private static void AsignarMedico()
        {
            var medico = _repoPaciente.AsignarMedico(1,2);
            Console.WriteLine(medico.Nombre+" "+medico.Apellidos);
        }

        private static void ListarPacientesMasculinos()
        {
            
            var pacientesM = _repoPaciente.GetPacientesMasculinos();
            foreach (Paciente p in pacientesM)
            {
                Console.WriteLine(p.Nombre + " " + p.Apellidos);
            }
        }

        private static void ListarPacientesCorazon()
        {
            var pacientesC = _repoPaciente.GetPacientesCorazon();
            foreach (Paciente p in pacientesC)
            {
                Console.WriteLine(p.Nombre + " " + p.Apellidos);
            }
        }
    }
}
