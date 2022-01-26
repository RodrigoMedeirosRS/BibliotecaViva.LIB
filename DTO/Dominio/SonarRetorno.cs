using System;
using System.Collections.Generic;

using BibliotecaViva.DTO.Utils;

namespace BibliotecaViva.DTO.Dominio
{
    public class SonarRetorno : IDisposable
    {
        public SonarRetorno()
        {
            Registros = new List<RegistroDTO>();
        }
        public List<RegistroDTO> Registros { get; set; }

        public void Dispose()
        {
            Desalocador.DesalocarLista<RegistroDTO>(Registros);
        }
    }
}