using DesafiosTecnicosApi.Commons;
using DesafiosTecnicosApi.Dtos.Request;
using DesafiosTecnicosApi.Entities;

namespace DesafiosTecnicosApi.Services
{
    public class OrcamentoService
    {
        public Result<Orcamento> Criar(CriarOrcamentoRequestDto request)
        {
            var resultadoValidacao = ValidarRequest(request);

            if (!resultadoValidacao.IsSuccess)
                return resultadoValidacao;

            var itens = request.Itens.Select(item => new OrcamentoItem
            {
                Descricao = item.Descricao,
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario,
                ValorTotal = item.Quantidade * item.ValorUnitario
            }).ToList();

            var orcamento = new Orcamento
            {
                ClienteId = request.ClienteId,
                VeiculoId = request.VeiculoId,
                DataCriacao = DateTimeOffset.Now,
                Itens = itens,
                ValorTotal = itens.Sum(x => x.ValorTotal)
            };

            //Aqui eu persistiria

            //Aqui o correto seria mapear para um DTO de resposta, mas vou simplificar

            return Result<Orcamento>.Success(orcamento);
        }

        private Result<Orcamento> ValidarRequest(CriarOrcamentoRequestDto request)
        {
            var erros = new List<string>();

            if (request.ClienteId <= 0)
                return Result<Orcamento>.Failure("clienteId é obrigatório.");

            if (request.VeiculoId <= 0)
                return Result<Orcamento>.Failure("veiculoId é obrigatório.");

            if (request.Itens == null || !request.Itens.Any())
                return Result<Orcamento>.Failure("O orçamento deve possuir pelo menos 1 item.");

            if (request.Itens != null)
            {
                for (int i = 0; i < request.Itens.Count; i++)
                {
                    var item = request.Itens[i];

                    if (string.IsNullOrWhiteSpace(item.Descricao))
                        return Result<Orcamento>.Failure($"Item {i + 1}: descrição é obrigatória.");

                    if (item.Quantidade <= 0)
                        return Result<Orcamento>.Failure($"Item {i + 1}: quantidade deve ser maior que zero.");

                    if (item.ValorUnitario <= 0)
                        return Result<Orcamento>.Failure($"Item {i + 1}: valor unitário deve ser maior que zero.");
                }
            }

            return Result<Orcamento>.Success(new Orcamento());
        }

    }
}
