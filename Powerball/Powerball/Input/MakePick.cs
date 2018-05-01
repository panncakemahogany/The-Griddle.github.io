using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riley.Powerball.BLL.PowerIO;
using Riley.Powerball.BLL;
using Powerball.Input;

namespace Powerball.Input
{
    class MakePick
    {
        public void Create()
        {
            PickRepository repo = new PickRepository();
            Pick pick = PickBalls.Create();
            pick = repo.Create(pick);
            repo.ToFile(pick);
        }
    }
}
