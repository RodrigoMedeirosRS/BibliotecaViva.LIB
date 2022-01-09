using System;
using BibliotecaViva.DTO.Interface;

namespace BibliotecaViva.DTO
{
    public class TipoRelacaoDTO : BaseDTO, IDisposable, INomeado
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