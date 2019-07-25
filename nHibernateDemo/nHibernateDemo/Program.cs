
using System;

namespace nHibernateDemo
{
    class Program
    {

        static void Main(string[] args)
        {

             PersonRepository personRepository = new PersonRepository();

             var person = new Person()
             {
                 LastName = "addTest3",
                 FirstName = "addTest3",
                 Email = "addTest3@piworks.net"
             };

            //personRepository.Add(entity);

            /*foreach (Person person in personRepository.List())
                Console.WriteLine(person);*/



            //Console.WriteLine(personRepository.GetById(10));

            //personRepository.Delete(entity);

            //personRepository.Edit(entity);


            var employee = new Employee()
            {
                LastName = "addTest11",
                FirstName = "addTest11",
                Email = "addTest11@piworks.net",
                Department = new Department()
                {
                    Id = 1,
                    Name = "R&D",
                    NumOfEmployee = 15

                }
        };


            UnitOfWork unitOfWork = new UnitOfWork();

            using (var session = unitOfWork.Session)
            {
                using(var transaction = session.BeginTransaction())
                {
                    session.Save(employee);
                    session.Flush();

                    transaction.Commit();

                    Console.WriteLine("Added Record: " + employee.ToString());
                }
               
            }
            
            Console.ReadLine();


        }
    }
}
