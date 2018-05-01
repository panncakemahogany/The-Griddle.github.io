using Dapper;
using DVDModels.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDData.Tests
{
    [TestFixture]
    class ADORepoTests
    {
        [SetUp]
        public void ResetData()
        {
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager
                    .ConnectionStrings["DvdLibraryADO"]
                    .ConnectionString;

                cn.Execute(
                    "ResetData",
                    commandType: CommandType.StoredProcedure);

                cn.Close();
            }
        }

        [TestCase(true)]
        public void CanGetAll(bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();

            var allDvds = repo.GetAll();

            bool actual = allDvds != null;

            while (actual)
            {
                actual = allDvds[0].DvdId == 1;
                actual = allDvds[0].Title == "Mad Max: Fury Road";
                actual = allDvds[0].RealeaseYear == 2015;
                actual = allDvds[0].Director == "George Miller";
                actual = allDvds[0].Rating == "R";
                actual = allDvds[0].Notes == "Some critics say \"Thirty-six viewings in a row is the only reasonable way to watch this film.\"";
                actual = allDvds[9].DvdId == 10;
                actual = allDvds[9].Title == "Boyz N The Hood";
                actual = allDvds[9].RealeaseYear == 1992;
                actual = allDvds[9].Director == "John Singleton";
                actual = allDvds[9].Rating == "R";
                actual = allDvds[9].Notes == "";
                break;
            }

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(int.MinValue, false)]
        [TestCase(1, true)]
        public void CanGetById(int id, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();

            Dvd result = repo.GetById(id);

            bool actual;

            if (result == null)
            {
                actual = false;
            }
            else
            {
                actual = (result.DvdId == id);
            }

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase("A Wrong Name", false)]
        [TestCase("pi", true)]
        public void CanGetByTitle(string title, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();

            List<Dvd> result = repo.GetByTitle(title);

            bool actual;

            if (result.Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = result.All(d => d.Title == title);
            }

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(1000, false)]
        [TestCase(1992, true)]
        public void CanGetByYear(int year, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();

            List<Dvd> result = repo.GetByYear(year);

            bool actual;

            if (result.Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = result.All(d => d.RealeaseYear == year);
            }

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase("A Wrong Name", false)]
        [TestCase("John Carpenter", true)]
        public void CanGetByDirector(string director, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();

            List<Dvd> result = repo.GetByDirector(director);

            bool actual;

            if (result.Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = result.All(d => d.Director == director);
            }

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase("A Wrong Rating", false)]
        [TestCase("R", true)]
        public void CanGetByRating(string rating, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();

            List<Dvd> result = repo.GetByRating(rating);

            bool actual;

            if (result.Count == 0)
            {
                actual = false;
            }
            else
            {
                actual = result.All(d => d.Rating == rating);
            }

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(null, int.MinValue, null, null, null, false)]
        [TestCase("test", 2018, "test", "NR", "test", true)]
        public void CanAddDvd(string title, int year, string director, string rating, string notes, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();

            Dvd dvd = new Dvd() { Title = title, Director = director, RealeaseYear = year, Rating = rating, Notes = notes };

            repo.AddDvd(dvd);

            var fromRepo = repo.GetById(dvd.DvdId);

            bool actual = (fromRepo != null 
                        && dvd.Title == fromRepo.Title
                        && dvd.RealeaseYear == fromRepo.RealeaseYear
                        && dvd.Director == fromRepo.Director
                        && dvd.Rating == fromRepo.Rating
                        && dvd.Notes == fromRepo.Notes);

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(300, null, int.MinValue, null, null, null, false)]
        [TestCase(1, "test", 2018, "test", "NR", "test", true)]
        public void CanEditDvd(int id, string title, int year, string director, string rating, string notes, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();

            Dvd edit = new Dvd() { DvdId = id, Title = title, Director = director, RealeaseYear = year, Rating = rating, Notes = notes };

            repo.EditDvd(edit, id);

            Dvd dvd = repo.GetById(id);

            bool actual;

            if (dvd == null)
            {
                actual = false;
            }
            else
            {
                actual = (dvd.DvdId == id
                       && dvd.Title == title
                       && dvd.RealeaseYear == year
                       && dvd.Director == director
                       && dvd.Rating == rating
                       && dvd.Notes == notes);
            }

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(0, false)]
        [TestCase(1, true)]
        public void CanDeleteDvd(int id, bool expected)
        {
            DvdRepositoryADO repo = new DvdRepositoryADO();

            bool actual = repo.GetAll().Any(d => d.DvdId == id);

            if (actual)
            {
                repo.DeleteDvd(id);

                actual = !(repo.GetAll().Any(d => d.DvdId == id));
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
