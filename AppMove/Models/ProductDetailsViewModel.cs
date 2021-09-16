namespace AppMove.Models
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(int id, string nome, decimal valor, int estoque)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Estoque = estoque;
            //Vendas = vendas;

        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public int Estoque { get; private set; }
    }
}