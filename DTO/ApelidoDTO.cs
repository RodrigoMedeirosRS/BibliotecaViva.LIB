using System;

namespace BibliotecaViva.DTO
{
    public class ApelidoDTO : BaseDTO, IDisposable
    {
        public ApelidoDTO()
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