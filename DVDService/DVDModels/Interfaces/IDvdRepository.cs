using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDModels.Models;

namespace DVDModels.Interfaces
{
    public interface IDvdRepository
    {
        List<Dvd> GetAll();
        List<Dvd> GetByTitle(string title);
        List<Dvd> GetByYear(int year);
        List<Dvd> GetByDirector(string director);
        List<Dvd> GetByRating(string rating);
        Dvd GetById(int id);
        void AddDvd(Dvd dvd);
        void EditDvd(Dvd dvd, int id);
        void DeleteDvd(int id);
    }
}
