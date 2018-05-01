using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        public string MakeTags(string tag, string content)
        {
            return "<" + tag + ">" + content + "</" + tag + ">";
        }

        public string InsertWord(string container, string word)
        {
            return container.Substring(0, 2) + word + container.Substring(2, 2);
        }

        public string MultipleEndings(string str)
        {
            return str.Substring(str.Length - 2, 2) + str.Substring(str.Length - 2, 2) + str.Substring(str.Length - 2, 2);
        }

        public string FirstHalf(string str)
        {
            return str.Remove(str.Length - str.Length / 2);
        }

        public string TrimOne(string str)
        {
            string result = str.Remove(0, 1);
            return result.Remove(result.Length - 1, 1);
        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return b + a + b;
            }
            else
            {
                return a + b + a;
            }
        }

        public string RotateLeft2(string str)
        {
            return str.Substring(2) + str.Substring(0, 2);
        }

        public string RotateRight2(string str)
        {
            return str.Substring(str.Length - 2, 2) + str.Substring(0, str.Length - 2);
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                return str.Substring(0, 1);
            }
            else
            {
                return str.Substring(str.Length - 1, 1);
            }
        }

        public string MiddleTwo(string str)
        {
            int middleBegin = (str.Length / 2) - 1;
            return str.Substring(middleBegin, 2);
        }

        public bool EndsWithLy(string str)
        {
            return str.Contains("ly");
        }

        public string FrontAndBack(string str, int n)
        {
            return str.Substring(0, n) + str.Substring(str.Length - n, n);
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n > str.Length - 2)
            {
                return str.Substring(0, 2);
            }
            else
            {
                return str.Substring(n, 2);
            }
        }

        public bool HasBad(string str)
        {
            if (str.Length < 3)
            {
                return false;
            }
            string test1 = str.Substring(0, 3);
            string test2 = str.Substring(1, 3);
            if (test1.Contains("bad") || test2.Contains("bad"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string AtFirst(string str)
        {
            if (str.Length == 0)
            {
                return "@@";
            }
            else if (str.Length == 1)
            {
                return str.Substring(0, 1) + "@";
            }
            else
            {
                return str.Substring(0, 2);
            }
        }

        public string LastChars(string a, string b)
        {
            if (a.Length == 0 && b.Length == 0)
            {
                return "@@";
            }
            else if (a.Length == 0)
            {
                return "@" + b.Substring(b.Length - 1, 1);
            }
            else if (b.Length == 0)
            {
                return a.Substring(0, 1) + "@";
            }
            else
            {
                return a.Substring(0, 1) + b.Substring(b.Length - 1, 1);
            }
        }

        public string ConCat(string a, string b)
        {
            if (a.Length == 0 || b.Length == 0)
            {
                return a + b;
            }
            else
            {
                if (a.Substring(a.Length - 1, 1) == b.Substring(0, 1))
                {
                    return a.Remove(a.Length - 1) + b;
                }
                else
                {
                    return a + b;
                }
            }
        }

        public string SwapLast(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }
            else
            {
                return str.Remove(str.Length - 2) + str.Substring(str.Length - 1, 1) + str.Substring(str.Length - 2, 1);
            }
        }

        public bool FrontAgain(string str)
        {
            return (str.Substring(0, 2) == str.Substring(str.Length - 2, 2));
        }

        public string MinCat(string a, string b)
        {
            if (a.Length == b.Length)
            {
                return a + b;
            }
            else if (a.Length > b.Length)
            {
                return a.Substring(a.Length - b.Length) + b;
            }
            else
            {
                return a + b.Substring(b.Length - a.Length);
            }
        }

        public string TweakFront(string str)
        {
            if (str.Length == 0)
            {
                return str;
            }
            else if (str.Length == 1)
            {
                if (str.Contains("a"))
                {
                    return str;
                }
                else
                {
                    return "";
                }
            }
            else if (str.Substring(0, 1) == "a" && str.Substring(1, 1) == "b")
            {
                return str;
            }
            else if (str.Substring(1, 1) == "b")
            {
                return str.Remove(0, 1);
            }
            else if (str.Substring(0, 1) == "a")
            {
                return str.Remove(1, 1);
            }
            else
            {
                return str.Remove(0, 2);
            }
        }

        public string StripX(string str)
        {
            if (str.Length == 0)
            {
                return str;
            }
            else if (str.Length == 1)
            {
                if (str.Contains("x"))
                {
                    return "";
                }
                else
                {
                    return str;
                }
            }
            else
            {
                if (str.Substring(0, 1) == "x" && str.Substring(str.Length - 1, 1) == "x")
                {
                    return str.Substring(1, str.Length - 2);
                }
                else if (str.Substring(0, 1) == "x")
                {
                    return str.Substring(1, str.Length - 1);
                }
                else if (str.Substring(str.Length - 1, 1) == "x")
                {
                    return str.Substring(0, str.Length - 1);
                }
                else
                {
                    return str;
                }
            }
        }
    }
}
