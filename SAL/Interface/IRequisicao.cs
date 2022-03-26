namespace BibliotecaViva.SAL.Interface
{
    public interface IRequisicao
    {
        S ExecutarPost<T, S>(string url, T Corpo, string usuario = "", string senha = "",  bool remoteAccess = false);
        string ExecutarGet(string requisicao);
        
        void Dispose();
    }
}