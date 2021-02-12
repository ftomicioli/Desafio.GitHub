using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Domain.ValueObjects
{
    public class FavoritarRepositorioRetornoVo : BaseVo
    {
        public readonly bool RepositorioFavoritadoComSucesso;

        public FavoritarRepositorioRetornoVo(bool erro, string mensagemErro)
        {
            Erro = erro;
            MensagemErro = mensagemErro;
        }

        public FavoritarRepositorioRetornoVo(bool repositorioFavoritadoComSucesso)
        {
            RepositorioFavoritadoComSucesso = repositorioFavoritadoComSucesso;
        }
    }
}
