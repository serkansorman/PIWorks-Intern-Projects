using System;
using System.Collections.Generic;
using System.Linq;

namespace nHibernateDemo
{
    class PersonRepository : IRepository<Person>
    {
        public void Add(Person person)
        {
            UnitOfWork unitOfWork = new UnitOfWork();

            using (var session = unitOfWork.Session)
            {
                session.Save(person);
                session.Flush();

                Console.WriteLine("Added Record: " + person.ToString());
            }
        }

        public void Edit(Person person)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            //var person = session.Query<Person>().FirstOrDefault(w => w.Id == entity.Id);
            using (var session = unitOfWork.Session)
            {

                session.SaveOrUpdate(person);
                session.Flush();

                Console.WriteLine("Updated Record: " + person.ToString());
            }


        }

        public void Delete(Person person)
        {
            UnitOfWork unitOfWork = new UnitOfWork();

            using (var session = unitOfWork.Session)
            {

                session.Delete(person);
                session.Flush();

                Console.WriteLine("Deleted Record: " + person.ToString());
            }
        }

        public Person GetById(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            using (var session = unitOfWork.Session)
            {
                return session.Get<Person>(id);
            }

            
        }

        public IEnumerable<Person> List()
        {
            UnitOfWork unitOfWork = new UnitOfWork();

            using (var session = unitOfWork.Session) {

                return session.Query<Person>().ToList();

            }
        }
    }
}
