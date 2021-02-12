using Desafio.GitHub.Domain.Entities;
using Desafio.GitHub.Domain.ValueObjects;
using Desafio.GitHub.Domain.ValueObjects.Facades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Domain.Interfaces
{
    public interface IRepositorioService
    {
        ListarRepositoriosRetornoVo ListarRepositorios();
        ListarRepositorioFavoritadosRetornoVo ListarRepositoriosFavoritados();
        FavoritarRepositorioRetornoVo FavoritarRepositorio(long id);
        DesfavoritarRepositorioRetornoVo DesFavoritarRepositorio(long id);
    }
}
