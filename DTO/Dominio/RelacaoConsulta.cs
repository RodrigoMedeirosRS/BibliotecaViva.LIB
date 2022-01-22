using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaViva.DTO.Dominio
{
    public class RelacaoConsulta : IDisposable
    {
        public int CodRegistro { get; set; }

        public void Dispose()
        {
            CodRegistro = 0;
        }
    }
}