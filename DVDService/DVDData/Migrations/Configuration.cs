namespace DVDData.Migrations
{
    using DVDModels.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDData.DvdLibraryEFEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDData.DvdLibraryEFEntities context)
        {
            if (context.Database.Exists())
            {
                context.Database.Delete();
            }

            context.Database.Create();

            Dvd[] dvdLibrary = new Dvd[10]
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

            context.Dvds.AddOrUpdate(dvdLibrary);
        }
    }
}
