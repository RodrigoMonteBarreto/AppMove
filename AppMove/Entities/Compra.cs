using System;

namespace AppMove.Entities
{
    public class Compra
    {
        public int ID { get; set; }
        public Product produto { get; set; }
        public DateTime DataCompra { get; set; }
        public int Quantidade { get; set; }
        public Cartao Cartao { get; set; }
    }

    public class Cartao
    {

        public int ID { get; set; }
        public string Titular { get; set; }
        public int Numero { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string Bandeira { get; set; }
        public int CCV { get; set; }
    }
}