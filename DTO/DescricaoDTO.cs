using System;

namespace BibliotecaViva.DTO
{
    public class DescricaoDTO : BaseDTO, IDisposable
    {
        public DescricaoDTO()
        {
            Conteudo = string.Empty;
        }
        public int Registro { get; set; }
        public string Conteudo { get; set; }

        public void Dispose()
        {
            Conteudo = null;
        }
    }
}