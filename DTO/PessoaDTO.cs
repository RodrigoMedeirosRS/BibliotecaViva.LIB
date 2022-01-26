using System;
using System.Collections.Generic;

using BibliotecaViva.DTO.Interface;
using BibliotecaViva.DTO.Utils;

namespace BibliotecaViva.DTO
{
    public class PessoaDTO : BaseDTO, IDisposable, INomeado
    {
        public PessoaDTO()
        {
            Nome = string.Empty;
            Sobrenome = string.Empty;
            Genero = string.Empty;
            Apelido = string.Empty;
            Relacoes = new List<RelacaoDTO>();
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Genero { get; set; }
        public string Apelido { get; set; }
        public List<RelacaoDTO> Relacoes { get; set; }

        public void Dispose()
        {
            Nome = null;
            Genero = null;
            Apelido = null;
            Desalocador.DesalocarLista<RelacaoDTO>(Relacoes);
        }
    }
}