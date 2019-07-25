using System;
using System.Collections.Generic;
using System.Text;

namespace nHibernateDemo
{
    class Employee
    {
        public virtual int Id { get; set; }
        public virtual String LastName { get; set; }
        public virtual String FirstName { get; set; }
        public virtual String Email { get; set; }
        public virtual Department Department { get; set; }


        public override string ToString()
        {
            return "Id: " + Id + " || FirstName: " + FirstName + " || LastName: " + LastName + " || Email: " + Email + " || Department: "+ Department.Name;
        }
    }
}
