using System;

namespace BibliotecaViva.DTO.Dominio
{
    public class SonarConsulta : IDisposable
    {
        public SonarConsulta()
        {
            CoordenadaInicio = new double[2];
            CoordenadaFim = new double[2];
        }
        public double[] CoordenadaInicio { get; set; }
        public double[] CoordenadaFim { get; set; }

        public void Dispose()
        {
            CoordenadaInicio = null;
            CoordenadaFim = null;
        }    
    }
}