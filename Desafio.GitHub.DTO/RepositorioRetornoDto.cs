using Desafio.GitHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.DTO
{
    public class RepositorioRetornoDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static explicit operator RepositorioRetornoDto(RepositoriosRetornoVo v)
        {
            if (v == null)
                return null;

            return new RepositorioRetornoDto
            {
                Id = v.Id,
                Name = v.Name
            };
        }
    }
}
