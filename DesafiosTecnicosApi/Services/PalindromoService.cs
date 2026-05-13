using DesafiosTecnicosApi.Services.Utils;

namespace DesafiosTecnicosApi.Services
{
    public static class PalindromoService
    {
        public static bool EhPalindromo(string texto)
        {
            var textoTratado = TextUtils.RemoverEspacosEConverterParaMinusculo(texto);

            int inicio = 0;
            int fim = textoTratado.Length - 1;

            while (inicio < fim)
            {
                if (textoTratado[inicio] != textoTratado[fim])
                {
                    return false;
                }

                inicio++;
                fim--;
            }

            return true;
        }
    }
}
