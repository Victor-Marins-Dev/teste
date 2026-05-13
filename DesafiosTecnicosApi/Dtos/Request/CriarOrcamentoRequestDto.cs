namespace DesafiosTecnicosApi.Dtos.Request
{
    public class CriarOrcamentoRequestDto
    {
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public List<CriarOrcamentoItemRequestDto> Itens { get; set; } = new();
    }
}
