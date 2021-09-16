namespace AppMove.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(string nome, decimal valor, int estoque)
        {

            Nome = nome;
            Valor = valor;
            Estoque = estoque;
        }


        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public int Estoque { get; set; }
    }
}