using System.Diagnostics;

namespace BibliotecaViva.Utils
{
    public static class ProcessoUtil
    {
        public static Process InstanciarNovoProcesso(string argumento, string caminhoExe)
        {
            var processo = new Process();
            processo.StartInfo = Parametrizar(argumento, caminhoExe);
            return processo;
        }
        public static string ExecutarProcesso(Process processo)
        {
            processo.Start();
            var leitura = ObterRetorno(processo);
            processo.WaitForExit();
            processo.Dispose();
            return leitura;
        }
        public static string ExecutarProcesso(string argumento, string caminhoExe)
        {
            using (var processo = new Process())
            {
                processo.StartInfo = Parametrizar(argumento, caminhoExe);
                processo.Start();
                var leitura = ObterRetorno(processo);
                processo.WaitForExit();
                return leitura;
            }
        }
        private static string ObterRetorno(Process processoDeCaptura)
        {
            var retorno = string.Empty;
            while (!processoDeCaptura.StandardOutput.EndOfStream)
                retorno = processoDeCaptura.StandardOutput.ReadLine();
            return retorno;
        }
        private static ProcessStartInfo Parametrizar(string argumentos, string caminhoExe)
        {
            var parametros = new ProcessStartInfo();
            parametros.FileName = System.IO.Path.GetFullPath(caminhoExe);
            parametros.Arguments = argumentos;
            parametros.UseShellExecute = false;
            parametros.RedirectStandardOutput = true;
            parametros.CreateNoWindow = true;
            parametros.StandardOutputEncoding = System.Text.Encoding.UTF8;
            return parametros;
        }
    }
}