
using System.Collections.Generic;


namespace nHibernateDemo
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }

    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }
}
