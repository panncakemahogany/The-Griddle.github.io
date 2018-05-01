using GuildCarsMastery.BLL.Admin;
using GuildCarsMastery.Models.Domain.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace GuildCarsMastery.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        [System.Web.Http.Route("values/models/{makeId}")]
        [System.Web.Http.HttpGet]
        public IEnumerable<Nameplate> PopulateModelsDropdown (int makeId)
        {
            List<Nameplate> dropdown = new List<Nameplate>();

            VehicleManager mgr = new VehicleManager();

            dropdown = mgr.GetAllModels().Package.Where(n => n.ManufacturerId == makeId).ToList();

            return dropdown;
        }
    }
}