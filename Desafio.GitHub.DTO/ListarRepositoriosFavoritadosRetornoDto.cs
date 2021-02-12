using Desafio.GitHub.Domain.Entities;
using Desafio.GitHub.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Desafio.GitHub.DTO
{
    public class ListarRepositoriosFavoritadosRetornoDto : BaseDto
    {
        public List<RepositoriosFavoritadosRetornoDto> RepositoriosFavoritados { get; set; }
    }
}
