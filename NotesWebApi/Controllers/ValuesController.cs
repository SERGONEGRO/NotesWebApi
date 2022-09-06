using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NotesWebApi.Data.Interfaces;
using NotesWebApi.Data.Repository;
using NotesWebApi.Models;

namespace NotesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// список клиентов
        /// </summary>
        private IAllPerson _personRep;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="personRep"></param>
        /// <param name="shopCart"></param>
        public ValuesController(IAllPerson personRep)
        {
            _personRep = personRep;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<IPerson> Get()
        {
            return _personRep.GetPersons;
        }


        // GET api/values/5
        public IPerson GetPersonById(int id)
        {
            return _personRep.GetPersonById(id);
        }

        [HttpGet]
        [Route("GetRange/{pos}/count/{count}")]
        public IEnumerable<IPerson> Get(int pos, int count, int agrs = 0)
        {
            return _personRep.GetPersonsRange(pos,count);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Person value)
        {
            _personRep.AddPerson(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody] Person value)
        {
            _personRep.UpdatePerson(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _personRep.DeletePerson(id);
        }
    }
}
