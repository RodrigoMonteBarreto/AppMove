using System;

namespace Gateway.Models
{
    public class Compra
    {
       public decimal Valor { get; set; }
        public Cartao Cartao { get; set; }
    }

    public class Cartao
    {

        public string Titular { get; set; }
        public int Numero { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string Bandeira { get; set; }
        public int CCV { get; set; }
    }
}