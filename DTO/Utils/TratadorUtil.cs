namespace BibliotecaViva.DTO.Utils
{
    public static class TratadorUtil
    {
        public static bool VerificarBinario(TipoExecucao tipoExecucao)
        {
            return (tipoExecucao != TipoExecucao.Texto && tipoExecucao != TipoExecucao.URL);
        }
    }
}