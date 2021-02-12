using Desafio.GitHub.Domain.Entities;
using System.Collections.Generic;

namespace Desafio.GitHub.Domain.ValueObjects
{
    public class ListarRepositorioFavoritadosRetornoVo : BaseVo
    {
        public ListarRepositorioFavoritadosRetornoVo()
        {

        }

        public ListarRepositorioFavoritadosRetornoVo(bool erro, string mensagemErro)
        {
            Erro = erro;
            MensagemErro = mensagemErro;
        }

        public List<RepositorioFavoritado> RepositoriosFavoritados { get; set; }
    }
}
