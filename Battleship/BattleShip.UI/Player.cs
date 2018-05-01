using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;

namespace BattleShip.UI
{
    public class Player
    {
        public string Name { get; set; }
        public string[,] Display { get; set; }
        public bool OnTurn { get; set; }
        public bool IsWinner { get; set; }
        public ConsoleColor Color { get; set; }

        public Player()
        {
            
        }

        public void SetBoard()
        {

        }

        public void ShowDisplay()
        {
            Console.WriteLine(Name);
            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 23; y++)
                {
                    if (Display[x, y].Contains("M"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Display[x, y]);
                        Console.ForegroundColor = Color;
                    }
                    else if (Display[x, y].Contains("H") && x != 8 && y != 2)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Display[x, y]);
                        Console.ForegroundColor = Color;
                    }
                    else
                    {
                    Console.Write(Display[x, y]);
                    }
                }
                Console.WriteLine();
            }
        }

        public void ShipPlacementDisplay(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(Name);
            for (int x = 0; x < 12; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    Console.Write(Display[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
