using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Domain.ValueObjects.Facades
{
    public class RepoFacadeRetornoVo 
    {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public DateTime updated_at { get; set; }

        public OwnerFacadeRetornoVo owner { get; set; }
    }
}
