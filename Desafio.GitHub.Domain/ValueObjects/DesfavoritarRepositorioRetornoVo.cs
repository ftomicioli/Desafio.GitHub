using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Domain.ValueObjects
{
    public class DesfavoritarRepositorioRetornoVo : BaseVo
    {
        public bool RepositorioDesfavoritadoComSucesso { get; set; }

        public DesfavoritarRepositorioRetornoVo(bool erro, string mensagemErro)
        {
            Erro = erro;
            MensagemErro = mensagemErro;
        }

        public DesfavoritarRepositorioRetornoVo(bool repositorioDesfavoritadoComSucesso)
        {
            RepositorioDesfavoritadoComSucesso = repositorioDesfavoritadoComSucesso;
        }
    }
}
