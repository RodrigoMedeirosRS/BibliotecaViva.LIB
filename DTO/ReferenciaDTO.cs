using System;
namespace BibliotecaViva.DTO
{
    public class ReferenciaDTO : BaseDTO, IDisposable
    {
        public int Registro { get; set; }
        public int Referencia { get; set; }
        
        public void Dispose()
        {

        }
    }
}