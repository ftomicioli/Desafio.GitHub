using Desafio.GitHub.Data.LiteDb;
using Desafio.GitHub.Data.LiteDb.Interfaces;
using Desafio.GitHub.Domain.Entities;
using Desafio.GitHub.Domain.Infrastructure.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Domain.Infrastructure
{
    public class DesafioUnitOfWork : IDesafioUnitOfWork, IDisposable
    {
        private ILiteDatabase _db;
        private bool _disposed;

        public DesafioUnitOfWork()
        {
            _db ??= new LiteDatabase(@"C:\\ftomicioli.db"); // whole remarked block above, can be replaced by this one, it's a C# 8 convension
        }

        IBaseRepository<RepositorioFavoritado> _repositorioFavoritado;
        public IBaseRepository<RepositorioFavoritado> RepositorioFavoritado
        {
            get
            {
                if (_repositorioFavoritado == null)
                    _repositorioFavoritado = new Repository<RepositorioFavoritado>(_db);

                return _repositorioFavoritado;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_db != null)
                        _db.Dispose();
                }
                _disposed = true;
            }
        }

        ~DesafioUnitOfWork()
        {
            Dispose(false);
        }
    }
}
