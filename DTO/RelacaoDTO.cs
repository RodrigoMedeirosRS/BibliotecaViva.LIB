using System; 

namespace BibliotecaViva.DTO
{
    public class RelacaoDTO : BaseDTO, IDisposable
    {
        public RelacaoDTO()
        {
            TipoRelacao = string.Empty;
        }
        public int? RegistroPessoaID { get; set; }
        public int? RelacaoID { get; set; }
        public string TipoRelacao { get; set; }

        public void Dispose()
        {
            RegistroPessoaID = null;
            RelacaoID = null;
            TipoRelacao = null;
        }
    }
}