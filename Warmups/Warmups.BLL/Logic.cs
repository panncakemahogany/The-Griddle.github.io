using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (cigars >= 40)
            {
                if (isWeekend)
                {
                    return true;
                }
                else if (cigars <= 60)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle >= 8 || dateStyle >= 8)
            {
                if (yourStyle <= 2 || dateStyle <= 2)
                {
                    return 0;
                }
                else
                {
                    return 2;
                }
            }
            else if (yourStyle <= 2 || dateStyle <= 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (temp >= 60)
            {
                if (isSummer)
                {
                    if (temp <= 100)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (temp <= 90)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (isBirthday)
            {
                if (speed <= 65)
                {
                    return 0;
                }
                else if (speed >= 66 && speed <= 85)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                if (speed <= 60)
                {
                    return 0;
                }
                else if (speed >= 61 && speed <= 80)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }
        
        public int SkipSum(int a, int b)
        {
            int c = a + b;
            if (c >= 10 && c <= 19)
            {
                return 20;
            }
            else
            {
                return c;
            }
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            if (vacation)
            {
                if (day == 0 || day == 6)
                {
                    return "off";
                }
                else
                {
                    return "10:00";
                }
            }
            else
            {
                if (day == 0 || day == 6)
                {
                    return "10:00";
                }
                else
                {
                    return "7:00";
                }
            }
        }
        
        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6)
            {
                return true;
            }
            else if (a + b == 6 || a - b == 6 || b - a == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode)
            {
                if (n <= 1 || n>= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (n >= 1 && n <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0 || n % 11 == 1 || n % 11 == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Mod20(int n)
        {
            if (n % 20 == 1 || n % 20 == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Mod35(int n)
        {
            if (n % 3 == 0 && n % 5 == 0)
            {
                return false;
            }
            else if (n % 3 == 0 || n % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep)
            {
                return false;
            }
            else if (isMorning)
            {
                if (isMom)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            return (a + b == c || a + c == b || b + c == a);
            return false;
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (bOk)
            {
                return (c > b);
            }
            else
            {
                return (c > b && b > a);
            }
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (equalOk)
            {
                return (c >= b && b >= a);
            }
            else
            {
                return (c > b && b > a);
            }
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            return (a % 10 == b % 10 || b % 10 == c % 10 || a % 10 == c % 10);
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            if (noDoubles)
            {
                if (die1 == die2)
                {
                    die1++;
                    if (die1 == 7)
                    {
                        die1 = 1;
                        return die1 + die2;
                    }
                    else
                    {
                        return die1 + die2;
                    }
                }
                else
                {
                    return die1 + die2;
                }
            }
            else
            {
                return die1 + die2;
            }
        }

    }
}
