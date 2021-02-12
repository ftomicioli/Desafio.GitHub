using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Domain.ValueObjects.Facades
{
    public class ListarRepositoriosRetornoVo : BaseVo
    {
        public ListarRepositoriosRetornoVo() 
        { 
        
        }

        public ListarRepositoriosRetornoVo(bool erro, string mensagemErro)
        {
            Erro = erro;
            MensagemErro = mensagemErro;
        }

        public List<RepositoriosRetornoVo> repositorios { get; set; }
    }
}
