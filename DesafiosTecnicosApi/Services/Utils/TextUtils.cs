namespace DesafiosTecnicosApi.Services.Utils
{
    public static class TextUtils
    {
        public static string RemoverEspacosEConverterParaMinusculo(string texto)
        {
            string textoTratado = "";

            foreach (char letra in texto)
            {
                if (letra != ' ')
                {
                    textoTratado += char.ToLower(letra);
                }
            }

            return textoTratado;
        }

        public static string NormalizarTextoGritado(string texto)
        {
            string resultado = "";

            int indice = 0;

            while (indice < texto.Length)
            {
                char caractereAtual = texto[indice];

                if (caractereAtual == '?' || caractereAtual == '!')
                {
                    bool temInterrogacao = false;
                    bool temExclamacao = false;

                    while (
                        indice < texto.Length &&
                        (texto[indice] == '?' || texto[indice] == '!')
                    )
                    {
                        if (texto[indice] == '?')
                        {
                            temInterrogacao = true;
                        }

                        if (texto[indice] == '!')
                        {
                            temExclamacao = true;
                        }

                        indice++;
                    }

                    if (temInterrogacao)
                    {
                        resultado += "?";
                    }

                    if (temExclamacao)
                    {
                        resultado += "!";
                    }
                }
                else
                {
                    resultado += caractereAtual;
                    indice++;
                }
            }

            return resultado;
        }
    }
}
