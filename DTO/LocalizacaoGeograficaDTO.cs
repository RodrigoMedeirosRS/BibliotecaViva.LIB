using System;

namespace BibliotecaViva.DTO
{
    public class LocalizacaoGeograficaDTO : BaseDTO, IDisposable
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public void Dispose()
        {

        }
    }
}