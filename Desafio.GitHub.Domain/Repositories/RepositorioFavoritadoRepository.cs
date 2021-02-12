using Desafio.GitHub.Domain.Entities;
using Desafio.GitHub.Domain.Infrastructure.Interfaces;
using Desafio.GitHub.Domain.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.GitHub.Domain.Repositories
{
    public class RepositorioFavoritadoRepository : IRepositorioFavoritadoRepository
    {
        IDesafioUnitOfWork _desafioUnitOfWork;

        public RepositorioFavoritadoRepository(IDesafioUnitOfWork desafioUnitOfWork)
        {
            _desafioUnitOfWork = desafioUnitOfWork;
        }

        public void FavoritarRepositorio(RepositorioFavoritado repositorio)
        {
            _desafioUnitOfWork.RepositorioFavoritado.Create(repositorio);
        }

        public bool DesFavoritarRepositorio(long id)
        {
            return _desafioUnitOfWork.RepositorioFavoritado.Delete((int)id);
        }

        public List<RepositorioFavoritado> ListarRepositoriosFavoritados()
        {
            return _desafioUnitOfWork.RepositorioFavoritado.All().ToList();
        }
    }
}
