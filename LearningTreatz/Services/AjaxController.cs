using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace LearningTreatz.Services
{
    public class AjaxController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get(string term)
        {
            RestaurantService db = new RestaurantService();
            return db.RestaurantNames(term);

        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}