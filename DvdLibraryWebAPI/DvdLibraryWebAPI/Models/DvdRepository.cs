using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryWebAPI.Models
{
    public class DvdRepository
    {
        private static List<DVD> dvds;

        static DvdRepository()
        {
            dvds = new List<DVD>()
            {
                new DVD { DvdId = 0, Title = "Die Hard", ReleaseYear = 1988, Director = "John McTiernan", Rating = "R", Notes = "The single greatest Christmas movie." },
                new DVD { DvdId = 1, Title = "City of God", ReleaseYear = 2003, Director = "Fernando Mierelles", Rating = "R", Notes = "A down right intense social commentary." },
                new DVD { DvdId = 2, Title = "Star Wars IV: A New Hope", ReleaseYear = 1977, Director = "George Lucas", Rating = "PG", Notes = "Mark Hamill had never seen Star Wars before making Episode IV."}
            };
        }

        public static List<DVD> GetAll()
        {
            return dvds;
        }

        public static DVD Get(int dvdId)
        {
            return dvds.FirstOrDefault(d => d.DvdId == dvdId);
        }

        public static void Add(DVD dvd)
        {
            dvd.DvdId = dvds.Max(d => d.DvdId) + 1;
            dvds.Add(dvd);
        }

        public static void Edit(DVD dvd)
        {
            dvds.RemoveAll(d => d.DvdId == dvd.DvdId);
            dvds.Add(dvd);
        }

        public static void Delete(int dvdId)
        {
            dvds.RemoveAll(d => d.DvdId == dvdId);
        }
    }
}