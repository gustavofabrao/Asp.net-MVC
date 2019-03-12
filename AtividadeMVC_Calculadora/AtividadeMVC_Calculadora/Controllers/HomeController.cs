using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtividadeMVC_Calculadora.Models;

namespace AtividadeMVC_Calculadora.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calculadora()
        {
            ViewBag.Message = "Calculadora";
            return View(new CalculadoraModel());
        }

        [HttpPost]
        public ActionResult Calculadora(CalculadoraModel calculadora)
        {
            List<CalculadoraModel> calc = new List<CalculadoraModel>();          

            if ((calculadora.numero1 == 0 || calculadora.numero2 == 0) && calculadora.operacao == "/")
            {
                ViewBag.Resultado = "Para operações de divisão, insira valores maiores que zero";
            }
            else if((calculadora.numero1 == null || calculadora.numero2 == null))
            {
                ViewBag.Resultado = "Os campos não podem ser nulos";
            }
            else{
                calculadora.Calcula(calculadora.numero1, calculadora.numero2, calculadora.operacao);
                if(Session["ListaSessao"] != null)
                    calc = (List<CalculadoraModel>)Session["ListaSessao"];
                calc.Add(calculadora);

                Session["ListaSessao"] = calc;
                ViewBag.ListaResult = Session["ListaSessao"];

                ViewBag.Resultado = "Resultado de  " + calculadora.numero1 + " " + calculadora.operacao + " " + calculadora.numero2 + " = " + calculadora.resultado;
            }
            return View();

        }
    }
}