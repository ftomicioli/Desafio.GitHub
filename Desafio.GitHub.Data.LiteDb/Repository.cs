using Desafio.GitHub.Data.LiteDb.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.GitHub.Data.LiteDb
{
    public class Repository<T> : IBaseRepository<T>
    {
        private ILiteDatabase DB { get; }
        private ILiteCollection<T> Collection { get; }

        public Repository(ILiteDatabase db)
        {
            DB = db;
            Collection = db.GetCollection<T>();
        }

        public virtual T Create(T entity)
        {
            var newId = Collection.Insert(entity);
            return Collection.FindById(newId.AsInt32);
        }

        public virtual IEnumerable<T> All()
        {
            return Collection.FindAll();
        }

        public virtual T FindById(int id)
        {
            return Collection.FindById(id);
        }

        public virtual void Update(T entity)
        {
            Collection.Upsert(entity);
        }

        public virtual bool Delete(int id)
        {
            return Collection.Delete(id);
        }
    }
}
