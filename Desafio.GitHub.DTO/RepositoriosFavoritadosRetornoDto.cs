using Desafio.GitHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.DTO
{
    public class RepositoriosFavoritadosRetornoDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static explicit operator RepositoriosFavoritadosRetornoDto(RepositorioFavoritado v)
        {
            if (v == null)
                return null;

            return new RepositoriosFavoritadosRetornoDto
            {
                Id = v.Id,
                Name = v.Name
            };
        }
    }
}
