using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Domain.ValueObjects

{
    public class BaseVo
    {
        public bool Erro { get; set; }
        public string MensagemErro { get; set; }
    }
}
