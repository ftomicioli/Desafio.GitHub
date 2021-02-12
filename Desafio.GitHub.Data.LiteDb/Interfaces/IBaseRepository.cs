using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Data.LiteDb.Interfaces
{
    public interface IBaseRepository<T>
    {
        T Create(T data);
        IEnumerable<T> All();
        T FindById(int id);
        void Update(T entity);
        bool Delete(int id);
    }
}
