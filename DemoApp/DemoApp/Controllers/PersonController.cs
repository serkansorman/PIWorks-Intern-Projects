using DataAccessLayer;
using log4net;
using System.Web.Mvc;

namespace DataAccessLayer
{
    public class PersonController : Controller
    {

        private readonly IRepository<Person> personRepository;
        private readonly ILog log;

        public PersonController()
        {

        }

        public PersonController(IRepository<Person> personRepository,ILog log)
        {
            this.personRepository = personRepository;
            this.log = log;
        }
 
        public ActionResult PersonList()
        {
            var personList = personRepository.List();
            log.Info( "Person list GET succesfully");
            return View(personList);
        }


        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            System.Diagnostics.Debug.WriteLine("Person Email:" + person.Email);


            personRepository.Add(person);
            log.Info(person.Email + " is added successfully");
            return new HttpStatusCodeResult(200);

        }

        [HttpPost]
        public ActionResult DeletePerson(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);


            personRepository.Delete(id);
            log.Info("ID: "+ id + " is deleted successfully");
            return new HttpStatusCodeResult(200);

        }


        [HttpPost]
        public ActionResult EditPerson(Person person)
        {
            System.Diagnostics.Debug.WriteLine(person.Email);
            


            personRepository.Edit(person);
            log.Info(person.Email + " is edited successfully");
            return new HttpStatusCodeResult(200);

        }

        [HttpPost]
        public ActionResult GetById(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);


            personRepository.GetById(id);
            log.Info("ID: " + id + " GET successfully");
            return View("TestView");

        }



        public ActionResult TestView()
        {
            return View("TestView");
        }

    }
}