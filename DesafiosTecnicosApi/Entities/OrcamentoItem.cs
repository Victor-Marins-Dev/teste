namespace DesafiosTecnicosApi.Entities
{
    public class OrcamentoItem
    {
        public int Id { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public int Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get; set; }
    }
}
