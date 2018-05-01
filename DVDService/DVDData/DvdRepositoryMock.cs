using DVDModels.Interfaces;
using DVDModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDData
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> DvdLibrary = new List<Dvd>
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

        public void AddDvd(Dvd dvd)
        {
            if (DvdLibrary.Count == 0)
                dvd.DvdId = 1;
            else
                dvd.DvdId = DvdLibrary.Max(d => d.DvdId) + 1;

            if (dvd.Title != null
                || dvd.RealeaseYear > 0
                || dvd.Director != null
                || dvd.Rating != null)
            {
                DvdLibrary.Add(dvd);
            }
        }

        public void DeleteDvd(int id)
        {
            DvdLibrary.Remove(DvdLibrary.FirstOrDefault(d => d.DvdId == id));
        }

        public void EditDvd(Dvd dvd, int id)
        {
            foreach (Dvd d in DvdLibrary)
            {
                if (d.DvdId == id)
                {
                    d.Title = dvd.Title;
                    d.Rating = dvd.Rating;
                    d.Notes = dvd.Notes;
                    d.RealeaseYear = dvd.RealeaseYear;
                    d.Director = dvd.Director;
                }
                else continue;
            }
        }

        public List<Dvd> GetAll()
        {
            return DvdLibrary;
        }

        public List<Dvd> GetByDirector(string director)
        {
            List<Dvd> result = DvdLibrary.Where(d => d.Director == director).Select(d => d).ToList();

            return result;
        }

        public Dvd GetById(int id)
        {
            Dvd result = DvdLibrary.FirstOrDefault(d => d.DvdId == id);

            return result;
        }

        public List<Dvd> GetByRating(string rating)
        {
            List<Dvd> result = DvdLibrary.Where(d => d.Rating == rating).Select(d => d).ToList();

            return result;
        }

        public List<Dvd> GetByTitle(string title)
        {
            List<Dvd> result = DvdLibrary.Where(d => d.Title == title).Select(d => d).ToList();

            return result;
        }

        public List<Dvd> GetByYear(int year)
        {
            List<Dvd> result = DvdLibrary.Where(d => d.RealeaseYear == year).Select(d => d).ToList();

            return result;
        }
    }
}
