using System.Collections.Generic;

namespace AppMove.Entities
{
    public class Product
    {
        public Product(string nome, decimal valor, int estoque)
        {
            Nome = nome;
            Valor = valor;
            Estoque = estoque;
            Reviews = new List<Compra>();
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public int Estoque { get; set; }
        public List<Compra> Reviews { get; private set; }
    }
}