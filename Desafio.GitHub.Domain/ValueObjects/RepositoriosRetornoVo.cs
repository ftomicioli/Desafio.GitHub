using Desafio.GitHub.Domain.ValueObjects.Facades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Domain.ValueObjects
{
    public class RepositoriosRetornoVo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime Updated_At { get; set; }
        public string Dono { get; set; }

        public static explicit operator RepositoriosRetornoVo(RepoFacadeRetornoVo v)
        {
            if (v == null)
                return null;

            return new RepositoriosRetornoVo
            {
                Id = v.id,
                Name = v.name,
                Description = v.description,
                Language = v.language,
                Updated_At = v.updated_at,
                Dono = v.owner != null ? v.owner.login: null
            };
        }
    }
}
