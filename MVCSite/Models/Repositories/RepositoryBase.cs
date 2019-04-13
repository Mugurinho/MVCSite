using MVCSite.Models.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace MVCSite.Models.Repositories
{
    //T = a generic type of class and inherits from class i.e. integer, string, etc.
    public class RepositoryBase<T> where T : class
    {
        //ctor
        public RepositoryBase(MVCSiteDataContext entities)
        {
            _entities = entities;
        }
        protected MVCSiteDataContext _entities;

        //creating virtual methods
        public virtual void Add(T entity)//generic method with a T parameter 
        {
            _entities.GetTable<T>().InsertOnSubmit(entity);
        }

        public virtual void AddAll(IEnumerable<T> entity)//where more elements/list of entitities to alter > use list as type IEnumerable
        {
            _entities.GetTable<T>().InsertAllOnSubmit(entity);
        }

        public virtual long Count()
        {
            return _entities.GetTable<T>().Count();
        }

        public virtual void Delete(T entity)
        {
            _entities.GetTable<T>().DeleteOnSubmit(entity);
        }

        public virtual void DeleteAll(IEnumerable<T> entity)
        {
            _entities.GetTable<T>().DeleteAllOnSubmit(entity);
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return _entities.GetTable<T>().Where(where);
        }

        public virtual IQueryable<T> GetAll()
        {
            return GetAll(x => true);
        }

        public virtual void SubmitChanges()
        {
            _entities.SubmitChanges();
        }

        public virtual void Truncate(string SQLTableName)
        {
            _entities.ExecuteCommand("Select * From {0}", SQLTableName);
        }
    }
}