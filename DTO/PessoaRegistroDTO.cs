using System; 

namespace BibliotecaViva.DTO
{
    public class PessoaRegistroDTO : BaseDTO, IDisposable
    {
        public PessoaRegistroDTO()
        {
            TipoRelacao = string.Empty;
        }
        public int? Pessoa { get; set; }
        public int? Registro { get; set; }
        public string TipoRelacao { get; set; }

        public void Dispose()
        {
            Pessoa = null;
            Registro = null;
            TipoRelacao = null;
        }
    }
}