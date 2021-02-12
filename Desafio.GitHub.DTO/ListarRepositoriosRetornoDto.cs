using Desafio.GitHub.Domain.Entities;
using Desafio.GitHub.Domain.ValueObjects.Facades;
using System;
using System.Collections.Generic;

namespace Desafio.GitHub.DTO
{
    public class ListarRepositoriosRetornoDto : BaseDto
    {
        //public long Id { get; set; }
        //public string Name { get; set; }

        public List<RepositorioRetornoDto> repositorios { get; set; }

        public static explicit operator ListarRepositoriosRetornoDto(ListarRepositoriosRetornoVo vo)
        {
            if (vo == null)
                return null;

            return new ListarRepositoriosRetornoDto
            {
                //Id = vo.id,
                //Name = vo.name
            };
        }

        public static explicit operator ListarRepositoriosRetornoDto(RepositorioFavoritado v)
        {
            if (v == null)
                return null;

            return new ListarRepositoriosRetornoDto
            {
                //Id = v.Id,
                //Name = v.Name
            };
        }
    }
}
