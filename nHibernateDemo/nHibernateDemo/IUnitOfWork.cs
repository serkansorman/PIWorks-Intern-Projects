using System;
using System.Collections.Generic;
using System.Text;

namespace nHibernateDemo
{
    interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
