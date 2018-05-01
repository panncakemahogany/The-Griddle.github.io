using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            return aSmile == bSmile;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            return !(isWeekday) || isVacation;
        }

        public int SumDouble(int a, int b)
        {
            if (a == b)
            {
                return 2 * (a + b);
            }
            else
            {
                return a + b;
            }
        }

        public int Diff21(int n)
        {
            if (n > 21)
            {
                return 2 * (n - 21);
            }
            else if (n < 21)
            {
                return 21 - n;
            }
            else
            {
                return 0; //return n - 21;
            }
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == true && hour < 7 || hour > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10)
            {
                return true;
            }
            else if (a + b == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NearHundred(int n)
        {
            if (n <= 100)
            {
                if (100 - n <= 10)
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
                if (n - 100 <= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if (negative == true)
            {
                return true;
            }
            else if (a < 0 && b > 0 || a > 0 && b < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string NotString(string s)
        {
            string a = "not ";
            if (s.Contains("not"))
            {
                return s;
            }
            else
            {
                return a + s;
            }
        }

        public string MissingChar(string str, int n)
        {
            return str.Remove(n, 1);
        }

        public string FrontBack(string str)
        {
            int input = str.Length;
            string output = str.Substring(input - 1) + str + str.Substring(0, 1);
            output = output.Remove(1, 1);
            output = output.Remove(input - 1, 1);
            return output;
        }

        public string Front3(string str)
        {
            int law = str.Length;
            if (law < 3)
            {
                return (str + str + str);
            }
            else
            {
                string ing = str.Remove(3, law - 3);
                return (ing + ing + ing);
            }
        }

        public string BackAround(string str)
        {
            string last = str.Substring(str.Length - 1);
            return (last + str + last);
        }

        public bool Multiple3or5(int number)
        {
            return number % 3 == 0 || number % 5 == 0;
        }

        public bool StartHi(string str)
        {
            int shield = str.Length;
            if (shield < 2)
            {
                return false;
            }
            else if (shield == 2)
            {
                return str.Contains("hi");
            }
            else if (str.Contains("hi ") || str.Contains("hi,"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IcyHot(int temp1, int temp2)
        {
            if ((temp1 < 0 && temp2 > 100) || (temp1 > 100 && temp2 < 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Between10and20(int a, int b)
        {
            if (a > 10 && a < 20)
            {
                return true;
            }
            else if (b > 10 && b < 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasTeen(int a, int b, int c)
        {
            if (a > 12 && a < 20)
            {
                return true;
            }
            else if (b > 12 && b < 20)
            {
                return true;
            }
            else if (c > 12 && c < 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SoAlone(int a, int b)
        {
            if (a > 12 && a < 20)
            {
                if (b > 12 && b < 20)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (b > 12 && b < 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RemoveDel(string str)
        {
            if (str.Contains("del"))
            {
                string noDel = str.Replace("del", "");
                return noDel;
            }
            else
            {
                return str;
            }
        }

        public bool IxStart(string str)
        {
            int del = str.Length - 3;
            string preIx = str.Remove(0, 1);
            string ix = preIx.Remove(2, del);
            return ix.Contains("ix");
        }

        public string StartOz(string str)
        {
            if (str.Length < 2)
            {
                string wrong = "";
                return wrong;
            }
            int rest = str.Length - 2;
            string oz = str.Remove(2, rest);
            if (oz.Contains("oz"))
            {
                return oz;
            }
            else if (oz.Contains("o"))
            {
                string o = oz.Remove(1, 1);
                if (o.Contains("o"))
                {
                    return o;
                }
            }
            else if (oz.Contains("z"))
            {
                string z = oz.Remove(0, 1);
                if (z.Contains("z"))
                {
                    return z;
                }
            }
            throw new NotImplementedException();
        }

        public int Max(int a, int b, int c)
        {
            if (a > b)
            {
                if (a > c)
                {
                    return a;
                }
                else
                {
                    return c;
                }
            }
            else if (b > c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }

        public int Closer(int a, int b)
        {
            int aClose = Math.Abs(10 - a);
            int bClose = Math.Abs(10 - b);
            if (aClose == bClose)
            {
                return 0;
            }
            else if (aClose < bClose)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public bool GotE(string str)
        {
            int[] getm = new int[str.Length];
            for (int x = 0; x <= str.Length - 1; x++)
            {
                string gotm = str.Substring(x, 1);
                if (gotm.Contains("e"))
                {
                    getm[x] = 1;
                }
            }
            int getGot = 0;
            for (int x = 0; x <= getm.Length - 1; x++)
            {
                if (getm[x] == 1)
                {
                    getGot++;
                }
            }
            if (getGot > 0 && getGot < 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string EndUp(string str)
        {
            int end = str.Length - 3;
            if (str.Length < 3)
            {
                return str.ToUpper();
            }
            else
            {
                string upp = str.Substring(end, 3);
                upp = upp.ToUpper();
                str = str.Remove(end);
                str = str + upp;
                return str;
            }
        }

        public string EveryNth(string str, int n)
        {
            if (n == 1)
            {
                return str;
            }
            else
            {
                string result = str.Substring(0, 1);
                for (int i = 1; i < str.Length; i++)
                {
                    result += str.Substring(n * i, 1);
                    if (result.Length == (str.Length - 1) - n)
                    {
                        break;
                    }
                }
                return result;
            }
        }
    }
}
