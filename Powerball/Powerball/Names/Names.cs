using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riley.Powerball.BLL;

namespace Powerball.Names
{
    public class Name
    {
        public static string GetName()
        {
            int number = QuickPick.RandomBall();

            switch (number)
            {
                case 1:
                    return "Michael Porter";
                case 2:
                    return "Krystine Hughes";
                case 3:
                    return "Derek Petricka";
                case 4:
                    return "Derek Lysne";
                case 5:
                    return "Edward Chavie";
                case 6:
                    return "Caleb Geary";
                case 7:
                    return "Cayden Elmore";
                case 8:
                    return "Josh Beese";
                case 9:
                    return "Zach Beese";
                case 10:
                    return "Max Gartner";
                case 11:
                    return "Ian Gartner";
                case 12:
                    return "Patricia Gartner";
                case 13:
                    return "Christopher Gartner";
                case 14:
                    return "Christopher Remke";
                case 15:
                    return "Ian Gunderson";
                case 16:
                    return "Kendra Born";
                case 17:
                    return "Teejay Barnett";
                case 18:
                    return "Jacobi Larscheid";
                case 19:
                    return "Tyler King";
                case 20:
                    return "Pete Anderson";
                case 21:
                    return "Tyler Anderson";
                case 22:
                    return "Jake Anderson";
                case 23:
                    return "Drew Anderson";
                case 24:
                    return "Catherine Anderson";
                case 25:
                    return "Marie Anderson";
                case 26:
                    return "Brandon Thompson";
                case 27:
                    return "Jackson Schultz";
                case 28:
                    return "Preston Osterhus";
                case 29:
                    return "Alisha Grobner";
                case 30:
                    return "Michael Parsons";
                case 31:
                    return "Janzen Staska";
                case 32:
                    return "Arden Anderson";
                case 33:
                    return "Kevin House";
                case 34:
                    return "Calvin Heidi";
                case 35:
                    return "Heather Heeman";
                case 36:
                    return "Ashley Williams";
                case 37:
                    return "Jack Shepherd";
                case 38:
                    return "Dexter Holland";
                case 39:
                    return "Victor Von Frankenstein";
                case 40:
                    return "Gaius Julius Caesar";
                case 41:
                    return "John Johnson";
                case 42:
                    return "Jack Jackson";
                case 43:
                    return "Robert Robertson";
                case 44:
                    return "Bill Williamson";
                case 45:
                    return "Dick Richardson";
                case 46:
                    return "Thomas Thompson";
                case 47:
                    return "Gunther Gunderson";
                case 48:
                    return "Andrew Anderson";
                case 49:
                    return "Erik Erikson";
                case 50:
                    return "Mike Michaelson";
                case 51:
                    return "Hot Gravy Platter";
                case 52:
                    return "A Bucket of Rotting Fish";
                case 53:
                    return "Carpet Stain";
                case 54:
                    return "Chuck Testa";
                case 55:
                    return "Snot Soup";
                case 56:
                    return "Can't Think of New Name";
                case 57:
                    return "Brad Pitt";
                case 58:
                    return "Plastic Bag";
                case 59:
                    return "Rubber Band";
                case 60:
                    return "Stray Hamster";
                case 61:
                    return "An Angry Turtle";
                case 62:
                    return "Please Make";
                case 63:
                    return "This Name Generation";
                case 64:
                    return "Stop Thank You";
                default:
                    return "Riley Gartner";
            }
        }
    }
}
