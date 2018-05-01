using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DVDModels.Models;
using DVDData;
using DVDModels.Interfaces;
using System.Runtime.Serialization.Json;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;

namespace DVDService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {
        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public Dvd GetById(int id)
        {
            IDvdRepository repo = DvdRepositoryFactory.Create();

            return repo.GetById(id);
        }

        [Route("dvds")]
        [HttpGet]
        public List<Dvd> GetAll()
        {
            IDvdRepository repo = DvdRepositoryFactory.Create();

            return repo.GetAll();
        }

        [Route("dvds/title/{title}")]
        [HttpGet]
        public List<Dvd> GetByTitle(string title)
        {
            IDvdRepository repo = DvdRepositoryFactory.Create();

            return repo.GetByTitle(title);
        }

        [Route("dvds/year/{realeaseYear}")]
        [HttpGet]
        public List<Dvd> GetByRealeaseYear(int realeaseYear)
        {
            IDvdRepository repo = DvdRepositoryFactory.Create();

            return repo.GetByYear(realeaseYear);
        }

        [Route("dvds/director/{directorName}")]
        [HttpGet]
        public List<Dvd> GetByDirector(string directorName)
        {
            IDvdRepository repo = DvdRepositoryFactory.Create();

            return repo.GetByDirector(directorName);

        }

        [Route("dvds/rating/{rating}")]
        [HttpGet]
        public List<Dvd> GetByRating(string rating)
        {
            IDvdRepository repo = DvdRepositoryFactory.Create();

            return repo.GetByRating(rating);
        }

        [Route("dvd")]
        [HttpPost]
        public void CreateDvd(AddDvdRequest request)
        {
            IDvdRepository repo = DvdRepositoryFactory.Create();

            Dvd dvd = new Dvd
            {
                Title = request.Title,
                RealeaseYear = request.RealeaseYear,
                Director = request.Director,
                Rating = request.Rating,
                Notes = request.Notes
            };

            repo.AddDvd(dvd);
        }

        [Route("dvd/{id}")]
        [HttpPut]
        public void UpdateDvd(int id, EditDvdRequest request)
        {
            IDvdRepository repo = DvdRepositoryFactory.Create();

            Dvd dvd = new Dvd
            {
                DvdId = request.DvdId,
                Title = request.Title,
                RealeaseYear = request.RealeaseYear,
                Director = request.Director,
                Rating = request.Rating,
                Notes = request.Notes
            };

            repo.EditDvd(dvd, id);
        }

        [Route("dvd/{id}")]
        [HttpDelete]
        public void DeleteDvd(int id)
        {
            IDvdRepository repo = DvdRepositoryFactory.Create();

            repo.DeleteDvd(id);
        }
    }
}
