using System;

namespace BibliotecaViva.DTO.Dominio
{
    public class SonarConsulta : IDisposable
    {
        public SonarConsulta()
        {
            CoordenadaInicio = new string[2];
            CoordenadaFim = new string[2];
        }
        public string[] CoordenadaInicio { get; set; }
        public string[] CoordenadaFim { get; set; }

        public void Dispose()
        {
            CoordenadaInicio = null;
            CoordenadaFim = null;
        }    
    }
}