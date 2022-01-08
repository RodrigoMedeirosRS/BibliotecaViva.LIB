using System;
namespace BibliotecaViva.DTO.Dominio
{
    public class PessoaConsulta : IDisposable
    {
        public PessoaConsulta()
        {
            Nome = string.Empty;
            Sobrenome = string.Empty;
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        
        public void Dispose()
        {
            Nome = null;
            Sobrenome = null;
        }
    }
}