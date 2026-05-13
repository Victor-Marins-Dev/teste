using System.ComponentModel.DataAnnotations;

namespace DesafiosTecnicosApi.Dtos.Request
{
    public class CriarOrcamentoItemRequestDto
    {
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
