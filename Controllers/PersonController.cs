using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Domain.Entities.Base;
using ContosoUniversity.Infrastructure.Repositories;

namespace ContosoUniversity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        protected CrudRepository<Person> _repository;

        public PersonController()
        {
            _repository = new CrudRepository<Person>();
        }

        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_repository.GetById(id));
        }

        [Route("findBy")]
        [HttpGet]
        public IActionResult Get([FromQuery] Person person)
        {
            Func<Person, bool> filter = x => x.Address.Contains(person.Address);
            return Ok(_repository.FindBy(filter));
        }
    }
}