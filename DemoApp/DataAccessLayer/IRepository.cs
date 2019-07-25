using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        void Add(T entity);
        void Delete(int id);
        void Edit(T entity);
    }

    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }
}
