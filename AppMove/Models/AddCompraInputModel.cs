using System;

namespace AppMove.Models
{
    public class AddCompraInputModel
    {
        public int IdProduto { get; set; }
        public int qtdComprada { get; set; }
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