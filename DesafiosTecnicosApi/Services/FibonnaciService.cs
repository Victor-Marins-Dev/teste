namespace DesafiosTecnicosApi.Services
{
    public static class FibonacciService
    {
        public static List<int> GerarSequenciaFibonnaci(int quantidadeElementos)
        {
            List<int> sequencia = new List<int>();

            if (quantidadeElementos <= 0)
            {
                return sequencia;
            }

            sequencia.Add(0);

            if (quantidadeElementos == 1)
            {
                return sequencia;
            }

            sequencia.Add(1);

            while (sequencia.Count < quantidadeElementos)
            {
                int ultimoNumero = sequencia[sequencia.Count - 1];
                int penultimoNumero = sequencia[sequencia.Count - 2];

                int proximoNumero = ultimoNumero + penultimoNumero;

                sequencia.Add(proximoNumero);
            }

            return sequencia;
        }
    }
}
