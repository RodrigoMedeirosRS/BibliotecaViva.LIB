using System;

namespace BibliotecaViva.DTO.Dominio
{
    public class SonarConsulta : IDisposable
    {
        public SonarConsulta()
        {
            Latitude = "0";
            Longitude = "0";
            Alcance = "0";
        }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Alcance { get; set; }

        public void Dispose()
        {
            Latitude = null;
            Longitude = null;
            Alcance = null;
        }    
    }
}