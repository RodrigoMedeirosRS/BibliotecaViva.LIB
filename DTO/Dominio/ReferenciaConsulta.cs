using System;

namespace BibliotecaViva.DTO.Dominio
{
    public class ReferenciaConsulta : IDisposable
    {
        public int Registro { get; set; }
        
        public void Dispose()
        {
        }
    }
}