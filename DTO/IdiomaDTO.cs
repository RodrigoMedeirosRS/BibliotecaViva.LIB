using System;
using BibliotecaViva.DTO.Interface;

namespace BibliotecaViva.DTO
{
    public class IdiomaDTO : BaseDTO, IDisposable, INomeado
    {
        public IdiomaDTO()
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