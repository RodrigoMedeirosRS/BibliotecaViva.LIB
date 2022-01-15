using System;
namespace BibliotecaViva.DTO.Dominio
{
    public class PessoaConsulta : IDisposable
    {
        public PessoaConsulta()
        {
            Nome = string.Empty;
            Sobrenome = string.Empty;
            Apelido = string.Empty;
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Apelido { get; set; }
        
        public void Dispose()
        {
            Nome = null;
            Sobrenome = null;
            Apelido = null;
        }
    }
}