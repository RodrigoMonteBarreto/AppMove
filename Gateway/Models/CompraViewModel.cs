namespace Gateway.Models
{
    public class CompraViewModel
    {
        public CompraViewModel(decimal vl, string estado)
        {
            Valor = vl;
            Estado = estado;
        }
        public decimal Valor { get; set; }
        public string Estado { get; set; }
    }
}