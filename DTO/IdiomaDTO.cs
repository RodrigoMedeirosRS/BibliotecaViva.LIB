using System;

namespace BibliotecaViva.DTO
{
    public class IdiomaDTO : BaseDTO, IDisposable
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