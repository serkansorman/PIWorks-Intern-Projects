using System;
using System.Collections.Generic;
using System.Text;

namespace nHibernateDemo
{
    class Department
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int NumOfEmployee { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
