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
    public class ListModel : PageModel
    {

        private static IRepositorioPaciente _repoPaciente= new RepositorioPaciente(new Persistencia.AppContext());
        [BindProperty]
        public Paciente Paciente{get;set;}
        public IEnumerable<SignoVital> SignosPaciente{get;set;}

        public void OnGet(int? pacienteId)
        { 
            pacienteId = 1;
            Console.WriteLine("paciente ver signos:"+ pacienteId);
            if(pacienteId.HasValue)
            {
                Paciente = _repoPaciente.GetPaciente(pacienteId.Value);
            }

            if(Paciente != null)
            {
                SignosPaciente = _repoPaciente.GetSignosPaciente(pacienteId.Value);
            }


        }
    }
}
