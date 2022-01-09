using System;
using BibliotecaViva.DTO.Interface;

namespace BibliotecaViva.DTO
{
    public class TipoDTO : BaseDTO, IDisposable, INomeado
    {
        public TipoDTO()
        {
            Nome = string.Empty;
            Extensao = string.Empty;
        }
        public string Nome { get; set; }
        public string Extensao { get; set; }
        public bool Binario { get; set; }

        public void Dispose()
        {
            Nome = null;
            Extensao = null;
        }
    }
}