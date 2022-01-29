namespace BibliotecaViva.SAL.Interface
{
    public interface IRequisicao
    {
        S ExecutarPost<T, S>(string url, T Corpo, bool remoteAccess = false);
        string ExecutarGet(string requisicao);
        
        void Dispose();
    }
}