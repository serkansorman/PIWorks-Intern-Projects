using DataAccessLayer;
using DemoApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;

namespace WebAPI.controllers
{
    public class PersonController : ApiController
	{
       
        private readonly IRepository<Person> personRepository = new PersonRepository();


        [HttpGet]
        public IHttpActionResult Get()
		{

            return Ok(personRepository.List());
      
		}

        [HttpPost]
        public IHttpActionResult Post([FromBody] Person person)
        {
            personRepository.Add(person);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] Person person)
        {
            personRepository.Edit(person);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            personRepository.Delete(id);
            return Ok();
        }


    }
}
