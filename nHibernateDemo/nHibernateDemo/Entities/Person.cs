using System;

namespace nHibernateDemo
{
    public class Person : EntityBase
    {

        public virtual int Id { get; set; }
        public virtual String LastName { get; set; }
        public virtual String FirstName { get; set; }
        public virtual String Email { get; set; }


        public override string ToString()
        {
            return "Id: " + Id + " || FirstName: " + FirstName + " || LastName: " + LastName + " || Email: " + Email;
        }


    }
}