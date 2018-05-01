using DVDModels.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDData.Tests
{
    [TestFixture]
    class MockRepoTests
    {
        [SetUp]
        public void ResetData()
        {
            DvdRepositoryMock repo = new DvdRepositoryMock();
            List<Dvd> dvds = repo.GetAll().ToList();

            foreach (var d in dvds)
            {
                repo.DeleteDvd(d.DvdId);
            }

            List<Dvd> dvdLibrary = new List<Dvd>()
                {
                    new Dvd { DvdId = 1, Title = "Mad Max: Fury Road", RealeaseYear = 2015, Director = "George Miller", Rating = "R", Notes = "Some critics say \"Thirty-six viewings in a row is the only reasonable way to watch this film.\""},
                    new Dvd { DvdId = 2, Title = "They Live!", RealeaseYear = 1988, Director = "John Carpenter", Rating = "R", Notes = "A great documentary detailing the inner workings of current government."},
                    new Dvd { DvdId = 3, Title = "Death Proof", RealeaseYear = 2007, Director = "Quentin Tarantino", Rating = "R", Notes = "Kurt Russell plays a lady's man who valiance makes women swoon."},
                    new Dvd { DvdId = 4, Title = "Army of Darkness", RealeaseYear = 1992, Director = "Sam Raimi", Rating = "R", Notes = "\"If you don't like this movie, we could never be friends.\" - Riley Gartner, whilst coding this program."},
                    new Dvd { DvdId = 5, Title = "The Thing", RealeaseYear = 1982, Director = "John Carpenter", Rating = "R", Notes = "The only horror movie. Every other horror movie is just an over-dramatic thiller"},
                    new Dvd { DvdId = 6, Title = "pi", RealeaseYear = 1997, Director = "Darren Aronofsky", Rating = "R", Notes = Math.PI.ToString()},
                    new Dvd { DvdId = 7, Title = "Big Trouble in Little China", RealeaseYear = 1995, Director = "John Carpenter", Rating = "PG-13", Notes = "Rated top choice by several Women's lifestyles publications as the perfect film to watch with your love interest."},
                    new Dvd { DvdId = 8, Title = "Enter The Dragon", RealeaseYear = 1973, Director = "Robert Clouse", Rating = "R", Notes = "The film that ended the argument of whether Chuck Norris or Bruce Lee would win in a fight."},
                    new Dvd { DvdId = 9, Title = "Labyrinth", RealeaseYear = 1999, Director = "Jim Henson", Rating = "PG", Notes = "If you didn't watch this film between ages 1-12, your parents deprived you of a childhood. Also, emulating David Bowie's magic dance is guaranteed to land you a date."},
                    new Dvd { DvdId = 10, Title = "Boyz N The Hood", RealeaseYear = 1992, Director = "John Singleton", Rating = "R", Notes = ""}
                };

            foreach (var d in dvdLibrary)
            {
                repo.AddDvd(d);
            }
        }

        [Test]
        [TestCase(true)]
        public void CanGetAll(bool expected)
        {
            DvdRepositoryMock repo = new DvdRepositoryMock();

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

        [Test]
        [TestCase(int.MinValue, false)]
        [TestCase(1, true)]
        public void CanGetById(int id, bool expected)
        {
            DvdRepositoryMock repo = new DvdRepositoryMock();

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

        [Test]
        [TestCase("A Wrong Name", false)]
        [TestCase("pi", true)]
        public void CanGetByTitle(string title, bool expected)
        {
            DvdRepositoryMock repo = new DvdRepositoryMock();

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

        [Test]
        [TestCase(1000, false)]
        [TestCase(1992, true)]
        public void CanGetByYear(int year, bool expected)
        {
            DvdRepositoryMock repo = new DvdRepositoryMock();

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

        [Test]
        [TestCase("A Wrong Name", false)]
        [TestCase("John Carpenter", true)]
        public void CanGetByDirector(string director, bool expected)
        {
            DvdRepositoryMock repo = new DvdRepositoryMock();

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

        [Test]
        [TestCase("A Wrong Rating", false)]
        [TestCase("R", true)]
        public void CanGetByRating(string rating, bool expected)
        {
            DvdRepositoryMock repo = new DvdRepositoryMock();

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

        [Test]
        [TestCase(null, int.MinValue, null, null, null, false)]
        [TestCase("test", 2018, "test", "NR", "test", true)]
        public void CanAddDvd(string title, int year, string director, string rating, string notes, bool expected)
        {
            DvdRepositoryMock repo = new DvdRepositoryMock();

            Dvd dvd = new Dvd() { Title = title, Director = director, RealeaseYear = year, Rating = rating, Notes = notes };

            repo.AddDvd(dvd);

            var check = repo.GetById(dvd.DvdId);

            bool actual = check != null &&
                            check.Title == title &&
                            check.RealeaseYear == year &&
                            check.Director == director &&
                            check.Rating == rating &&
                            check.Notes == notes;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(300, null, int.MinValue, null, null, null, false)]
        [TestCase(1, "test", 2018, "test", "NR", "test", true)]
        public void CanEditDvd(int id, string title, int year, string director, string rating, string notes, bool expected)
        {
            DvdRepositoryMock repo = new DvdRepositoryMock();

            Dvd edit = new Dvd() { Title = title, Director = director, RealeaseYear = year, Rating = rating, Notes = notes };

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

        [Test]
        [TestCase(0, false)]
        [TestCase(1, true)]
        public void CanDeleteDvd(int id, bool expected)
        {
            DvdRepositoryMock repo = new DvdRepositoryMock();

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
