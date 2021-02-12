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

        public static explicit operator RepositoriosRetornoVo(ListarRepositoriosFacadeRetornoVo v)
        {
            if (v == null)
                return null;

            return new RepositoriosRetornoVo
            {
                Id = v.Id,
                Name = v.Name
            };
        }
    }
}
