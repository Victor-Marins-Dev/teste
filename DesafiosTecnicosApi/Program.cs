using DesafiosTecnicosApi.Dtos.Request;
using DesafiosTecnicosApi.Services;
using DesafiosTecnicosApi.Services.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<OrcamentoService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

var desafio = app.MapGroup("/api/desafio");

desafio.MapGet("/palindromo", (string texto) =>
{
    if (string.IsNullOrWhiteSpace(texto))
    {
        return Results.BadRequest(new
        {
            mensagem = "O parâmetro 'texto' é obrigatório."
        });
    }

    bool ehPalindromo = PalindromoService.EhPalindromo(texto);

    return Results.Ok(new
    {
        texto,
        ehPalindromo
    });
});

desafio.MapGet("/fibonacci", (int quantidade) =>
{
    if (quantidade <= 0)
    {
        return Results.BadRequest(new
        {
            mensagem = "A quantidade deve ser maior que zero."
        });
    }

    if (quantidade > 47)
    {
        return Results.BadRequest(new
        {
            mensagem = "O maior número inteiro aceito por essa função é 46, pois a implementação foi feita com " +
            "um tipo int e F(48) resultaria em um número negativo"
        });
    }

    var sequencia = FibonacciService.GerarSequenciaFibonnaci(quantidade);

    return Results.Ok(new
    {
        quantidade,
        sequencia
    });
});

desafio.MapGet("/normalizar-texto-gritado", (string texto) =>
{
    if (string.IsNullOrWhiteSpace(texto))
    {
        return Results.BadRequest(new
        {
            mensagem = "O parâmetro 'texto' é obrigatório."
        });
    }

    var textoNormalizado =
        TextUtils.NormalizarTextoGritado(texto);

    return Results.Ok(new
    {
        textoOriginal = texto,
        textoNormalizado
    });
});

desafio.MapPost("/orcamentos", (CriarOrcamentoRequestDto request, OrcamentoService service) =>
{
    var result = service.Criar(request);

    if (!result.IsSuccess)
    {
        return Results.BadRequest(new
        {
            mensagem = result.Error
        });
    }

    var response = result.Data;

    if(response == null)
    {
        return Results.BadRequest(new
        {
            mensagem = "Falha ao gerar orçamento."
        });
    }

    return Results.Created($"/api/orcamentos/{response.Id}", new
    {
        mensagem = "Orçamento cadastrado com sucesso. Como não existe persistência os ids estão zerados.",
        data = response
    });
});

app.Run();

