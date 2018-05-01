using DvdLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibraryWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(DvdRepository.GetAll());
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int dvdId)
        {
            DVD found = DvdRepository.Get(dvdId);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        [Route("dvds/add")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(DVD dvd)
        {
            DvdRepository.Add(dvd);

            return Created($"dvd/{dvd.DvdId}", dvd);
        }

        [Route("dvds/edit")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(DVD dvd)
        {
            DvdRepository.Edit(dvd);

            return Created($"dvd/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int dvdId)
        {
            DvdRepository.Delete(dvdId);
        }
    }
}