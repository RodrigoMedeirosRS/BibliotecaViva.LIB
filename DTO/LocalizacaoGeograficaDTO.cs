using System;

namespace BibliotecaViva.DTO
{
    public class LocalizacaoGeograficaDTO : BaseDTO, IDisposable
    {
        public long Latitude { get; set; }
        public long Longitude { get; set; }

        public void Dispose()
        {

        }
    }
}