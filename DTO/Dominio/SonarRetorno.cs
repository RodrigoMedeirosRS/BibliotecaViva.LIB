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
            Pessoas = new List<PessoaDTO>();
        }
        public List<RegistroDTO> Registros { get; set; }
        public List<PessoaDTO> Pessoas { get; set; }

        public void Dispose()
        {
            Desalocador.DesalocarLista<RegistroDTO>(Registros);
            Desalocador.DesalocarLista<PessoaDTO>(Pessoas);
        }
    }
}