using System;
using BibliotecaViva.DTO.Interface;

namespace BibliotecaViva.DTO
{
    public class TipoExecucaoDTO : BaseDTO, IDisposable, INomeado
    {
        public TipoExecucaoDTO()
        {
            Nome = string.Empty;
        }
        public string Nome { get; set; }
        public bool Binario { get; set; }

        public void Dispose()
        {
            Nome = null;
        }
    }
}