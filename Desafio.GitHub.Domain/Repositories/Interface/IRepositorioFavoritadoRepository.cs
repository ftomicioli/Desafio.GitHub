using Desafio.GitHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Domain.Repositories.Interface
{
    public interface IRepositorioFavoritadoRepository
    {
        void FavoritarRepositorio(RepositorioFavoritado repositorio);
        bool DesFavoritarRepositorio(long id);
        List<RepositorioFavoritado> ListarRepositoriosFavoritados();
    }
}
