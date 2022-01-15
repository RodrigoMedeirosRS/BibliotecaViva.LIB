using System;

namespace BibliotecaViva.DTO.Dominio
{
    public class RegistroConsulta : IDisposable
    {
        public RegistroConsulta()
        {
            Nome = string.Empty;
            Idioma = string.Empty;
            Apelido = string.Empty;
        }
        public string Nome { get; set; }
        public string Idioma { get; set; }
        public string Apelido { get; set; }
        
        public void Dispose()
        {
            Nome = null;
            Idioma = null;
            Apelido = null;
        }
    }
}