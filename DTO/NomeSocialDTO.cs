using System;

namespace BibliotecaViva.DTO
{
    public class NomeSocialDTO : BaseDTO, IDisposable
    {
        public NomeSocialDTO()
        {
            Nome = string.Empty;
        }
        public int Pessoa { get; set; }
        public string Nome { get; set; }

        public void Dispose()
        {
            Nome = null;
        }
    }
}