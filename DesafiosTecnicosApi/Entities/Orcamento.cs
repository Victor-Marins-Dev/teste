namespace DesafiosTecnicosApi.Entities
{
    public class Orcamento
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int VeiculoId { get; set; }

        public decimal ValorTotal { get; set; }

        public DateTimeOffset DataCriacao { get; set; }

        public List<OrcamentoItem> Itens { get; set; } = new();
    }
}
