using DVDModels.Interfaces;
using DVDModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDData
{
    public class DvdRepositoryEF : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            DvdLibraryEFEntities db = new DvdLibraryEFEntities();

            //IEnumerable<DbEntityValidationResult> validation = db.GetValidationErrors();

            bool valid = (dvd.Title != null
                        && dvd.RealeaseYear > 0
                        && dvd.Director != null
                        && dvd.Rating != null);
            
            //foreach (var v in validation)
            //{
            //    valid = v.IsValid;
            //}

            if (valid)
            {
                db.Dvds.AddOrUpdate(dvd);
                db.SaveChanges();
            }
        }

        public void DeleteDvd(int id)
        {
            DvdLibraryEFEntities db = new DvdLibraryEFEntities();

            var target = db.Dvds.Find(id);

            if (target != null)
                db.Dvds.Remove(target);

            db.SaveChanges();
        }

        public void EditDvd(Dvd dvd, int id)
        {
            DvdLibraryEFEntities db = new DvdLibraryEFEntities();

            dvd.DvdId = id;

            db.Dvds.AddOrUpdate(d => d.DvdId, dvd);

            db.SaveChanges();
        }

        public List<Dvd> GetAll()
        {
            DvdLibraryEFEntities db = new DvdLibraryEFEntities();

            return db.Dvds.ToList();
        }

        public List<Dvd> GetByDirector(string director)
        {
            DvdLibraryEFEntities db = new DvdLibraryEFEntities();

            return db.Dvds.Where(d => d.Director == director).ToList();
        }

        public Dvd GetById(int id)
        {
            DvdLibraryEFEntities db = new DvdLibraryEFEntities();

            return db.Dvds.FirstOrDefault(d => d.DvdId == id);
        }

        public List<Dvd> GetByRating(string rating)
        {
            DvdLibraryEFEntities db = new DvdLibraryEFEntities();

            return db.Dvds.Where(d => d.Rating == rating).Select(d => d).ToList();
        }

        public List<Dvd> GetByTitle(string title)
        {
            DvdLibraryEFEntities db = new DvdLibraryEFEntities();

            return db.Dvds.Where(d => d.Title == title).Select(d => d).ToList();
        }

        public List<Dvd> GetByYear(int year)
        {
            DvdLibraryEFEntities db = new DvdLibraryEFEntities();

            return db.Dvds.Where(d => d.RealeaseYear == year).Select(d => d).ToList();
        }
    }
}
