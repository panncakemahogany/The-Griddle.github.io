using DVDModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDData
{
    public class DvdLibraryEFEntities : DbContext
    {
        public DvdLibraryEFEntities() : base("DvdLibraryEF")
        {

        }

        public DbSet<Dvd> Dvds { get; set; }
    }
}
