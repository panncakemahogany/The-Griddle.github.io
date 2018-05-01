using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Riley.Powerball.BLL.PowerIO
{
    public class PickRepository : IPickRepository
    {
        public Pick Create(Pick pick)
        {
            List<Pick> repo = FromFile();
            int validID = int.MinValue;

            int[] existingIDs = new int[repo.Count];
            int index = 0;

            foreach (Pick p in repo)
            {
                existingIDs[index] = p.Identifier;
                index++;
            }

            for (int x = 1; x < 100000; x++)
            {
                if (existingIDs.Contains(x))
                {
                    continue;
                }
                else
                {
                    validID = x;
                    break;
                }
            }

            pick.Identifier = validID;

            return pick;
        }

        public IEnumerable<Pick> FindBestMatches(Pick draw)
        {
            List<Pick> winners = new List<Pick>();
            List<Pick> contestants = FromFile();
            
            foreach (Pick p in contestants)
            {
                if (draw.FirstBall == p.FirstBall)
                {
                    p.WinningBallCount++;
                }
                if (draw.SecondBall == p.SecondBall)
                {
                    p.WinningBallCount++;
                }
                if (draw.ThirdBall == p.ThirdBall)
                {
                    p.WinningBallCount++;
                }
                if (draw.FourthBall == p.FourthBall)
                {
                    p.WinningBallCount++;
                }
                if (draw.FifthBall == p.FifthBall)
                {
                    p.WinningBallCount++;
                }
                if (draw.PowerBall == p.PowerBall)
                {
                    p.WinningBallCount++;
                    p.WinningPowerball = true;
                }
            }

            foreach (Pick p in contestants)
            {
                if (p.WinningBallCount == contestants.Max(c => c.WinningBallCount))
                {

                }
                else
                {
                    continue;
                }
            }

            foreach (Pick p in contestants)
            {
                if (p.WinningPowerball && !winners.Contains(p))
                {
                    winners.Add(p);
                }
                else
                {
                    continue;
                }
            }

            return winners;
        }

        public Pick FindById(int identifier)
        {
            List<Pick> allPicks = FromFile();
            Pick selectedPick = new Pick();

            foreach (Pick p in allPicks)
            {
                if (p.Identifier == identifier)
                {
                    selectedPick = p;
                }
            }

            return selectedPick;
        }

        public List<Pick> FindByName(string name)
        {
            List<Pick> allPicks = FromFile();
            List<Pick> selectedPicks = new List<Pick>();

            foreach (Pick p in allPicks)
            {
                if (p.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    selectedPicks.Add(p);
                }
                else
                {
                    continue;
                }
            }

            return selectedPicks;
        }

        public static List<Pick> FromFile()
        {
            List<Pick> picks = new List<Pick>();

            using (StreamReader reader = new StreamReader(Settings.FilePath))
            {
                reader.ReadLine();
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] knowsPick = line.Split(',');

                    Pick pick = new Pick();

                    pick.Identifier = int.Parse(knowsPick[0]);
                    pick.Name = knowsPick[1];
                    pick.FirstBall = int.Parse(knowsPick[2]);
                    pick.SecondBall = int.Parse(knowsPick[3]);
                    pick.ThirdBall = int.Parse(knowsPick[4]);
                    pick.FourthBall = int.Parse(knowsPick[5]);
                    pick.FifthBall = int.Parse(knowsPick[6]);
                    pick.PowerBall = int.Parse(knowsPick[7]);

                    picks.Add(pick);
                }
            }

            return picks;
        }

        public void ToFile(Pick pick)
        {
            using (StreamWriter writer = new StreamWriter(Settings.FilePath, true))
            {
                string newLine = pick.ToString();

                writer.WriteLine(newLine);
            }
        }
    }
}
