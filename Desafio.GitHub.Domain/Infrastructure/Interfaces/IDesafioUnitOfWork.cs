using Desafio.GitHub.Data.LiteDb.Interfaces;
using Desafio.GitHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Domain.Infrastructure.Interfaces
{
    public interface IDesafioUnitOfWork
    {
        IBaseRepository<RepositorioFavoritado> RepositorioFavoritado { get; }
    }
}
