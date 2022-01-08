using System;
using System.Collections.Generic;

using BibliotecaViva.DTO.Uteis;

namespace BibliotecaViva.DTO
{
    public class RegistroDTO : BaseDTO, IDisposable
    {
        public RegistroDTO()
        {
            Nome = string.Empty;
            Apelido = string.Empty;
            Idioma = string.Empty;
            Tipo = string.Empty;
            Conteudo = string.Empty;
            Descricao = string.Empty;
            DataInsercao = DateTime.Now;
            Referencias = new List<ReferenciaDTO>();
        }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Idioma { get; set; }
        public string Tipo { get; set; }
        public string Conteudo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInsercao { get; set; }
        public long? Latitude { get; set; }
        public long? Longitude { get; set; } 
        public List<ReferenciaDTO> Referencias { get; set; }

        public void Dispose()
        {
            Nome = null;
            Apelido = null;
            Idioma = null;
            Tipo = null;
            Conteudo = null;
            Descricao = null;
            Latitude = null;
            Longitude = null;
            Desalocador.DesalocarLista<ReferenciaDTO>(Referencias);
        }
    }
}