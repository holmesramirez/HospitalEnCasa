using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class ListPersonasModel : PageModel
    {

        private static IRepositorioPaciente _repoPaciente= new RepositorioPaciente(new Persistencia.AppContext());

        public List<Paciente> ListaPersonas{get;set;}

        public void OnGet()
        {
            ListaPersonas = _repoPaciente.GetPacientesCorazon().ToList();
            //ListarPacientesCorazon();
        }

        //private  void ListarPacientesCorazon()
        //{
         //   var pacientesC = _repoPaciente.GetPacientesCorazon();
            
         //   foreach (Paciente p in pacientesC)
         //   {
         //       Console.WriteLine(p.Nombre + " " + p.Apellidos);
         //   }
             
       // }
    }
}
