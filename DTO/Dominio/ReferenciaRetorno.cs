using System;
using System.Collections.Generic;

using BibliotecaViva.DTO;

namespace BibliotecaViva.DTO.Dominio
{
    public class ReferenciaRetorno
    {
        public ReferenciaRetorno()
        {
            Registros = new List<RegistroDTO>();
            Pessoas = new List<PessoaDTO>();
        }
        public List <RegistroDTO> Registros { get; set; }
        public List <PessoaDTO> Pessoas { get; set; }

        public void Dispose()
        {
            foreach(var registro in Registros)
                registro.Dispose();
            Registros.Clear();
            Registros = null;

            foreach(var pessoa in Pessoas)
                pessoa.Dispose();
            Pessoas.Clear();
            Pessoas = null;
        }
    }
}