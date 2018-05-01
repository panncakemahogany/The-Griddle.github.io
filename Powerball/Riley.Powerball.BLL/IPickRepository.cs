using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riley.Powerball.BLL
{
    interface IPickRepository
    {
        Pick Create(Pick pick); // The return value is a Pick with a valid identifier.
        Pick FindById(int identifier); // Returns the Pick with the given identifier 
                                       // or null if not found.
        IEnumerable<Pick> FindBestMatches(Pick draw); // A powerball draw is supplied as a Pick. 
                                                      // Returns the Picks that best matches the draw.
    }
}
