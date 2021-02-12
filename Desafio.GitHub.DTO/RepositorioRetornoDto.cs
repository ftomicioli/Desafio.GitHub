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
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime Updated_At { get; set; }
        public string Dono { get; set; }

        public static explicit operator RepositorioRetornoDto(RepositoriosRetornoVo v)
        {
            if (v == null)
                return null;

            return new RepositorioRetornoDto
            {
                Id = v.Id,
                Name = v.Name,
                Description = v.Description,
                Language = v.Language,
                Updated_At = v.Updated_At,
                Dono = v.Dono
            };
        }
    }
}
