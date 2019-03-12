using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtividadeMVC_Calculadora.Models
{
    public class CalculadoraModel
    {
        public double? numero1 { get; set; }
        public double? numero2 { get; set; }
        public string operacao { get; set; }
        public double? resultado { get; set; }

        public void Calcula(double? numero1, double? numero2, string operacao)
        {
            if (operacao == "+")
            {
                resultado = numero1 + numero2;
            }
            else if (operacao == "-")
            {
                resultado = numero1 - numero2;
            }
            else if (operacao == "*")
            {
                resultado = numero1 * numero2;
            }
            else if (operacao == "/" && (numero1 > 0 && numero2 > 0))
            {
                resultado = numero1 / numero2;
            }
        }

    }
}