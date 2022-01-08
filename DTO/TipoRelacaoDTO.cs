using System;

namespace BibliotecaViva.DTO
{
    public class TipoRelacaoDTO : BaseDTO, IDisposable
    {
        public TipoRelacaoDTO()
        {
            Nome = string.Empty;
        }
        public string Nome { get; set; }

        public void Dispose()
        {
            Nome = null;
        }
    }
}