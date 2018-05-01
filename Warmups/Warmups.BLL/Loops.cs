using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string result = "";
            for (int x = 1; x <= n; x++)
            {
                result += str;
            }
            return result;
        }

        public string FrontTimes(string str, int n)
        {
            string result = "";
            for (int x = 1; x <= n; x++)
            {
                result += str.Substring(0, 3);
            }
            return result;
        }

        public int CountXX(string str)
        {
            int result = 0;
            for (int x = 0; x <= str.Length - 2; x++)
            {
                string test = str.Substring(x, 2);
                if (test.Contains("xx"))
                {
                    result++;
                }
            }
            return result;
        }

        public bool DoubleX(string str)
        {
            if (str.Length <= 2)
            {
                return str.Contains("xx");
            }
            int index = str.IndexOf("x");
            for (int x = 0; x <= index; x++)
            {
                string test = str.Substring(x, 2);
                if (test.Contains("xx"))
                {
                    return test.Contains("xx");
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        public string EveryOther(string str)
        {
            string result = "";
            for (int x = 0; x <= str.Length - 1; x++)
            {
                if (x == 0 || x % 2 == 0)
                {
                    result += str.Substring(x, 1);
                }
                else
                {
                    continue;
                }
            }
            return result;
        }

        public string StringSplosion(string str)
        {
            string result = "";
            for (int x = 1; x <= str.Length; x++)
            {
                result += str.Substring(0, x);
            }
            return result;
        }

        public int CountLast2(string str)
        {
            int result = 0;
            string control = str.Substring(str.Length - 2, 2);
            string tester = str.Remove(str.Length - 2);
            for (int x = 0; x <= tester.Length - 2; x++)
            {
                string test = tester.Substring(x, 2);
                if (test.Contains(control))
                {
                    result++;
                }
                continue;
            }
            return result;
        }

        public int Count9(int[] numbers)
        {
            int result = 0;
            for (int x = 0; x <= numbers.Length - 1; x++)
            {
                if (numbers[x] == 9)
                {
                    result++;
                }
                continue;
            }
            return result;
        }

        public bool ArrayFront9(int[] numbers)
        {
            if (numbers.Length < 4)
            {
                for (int x = 0; x <= numbers.Length; x++)
                {
                    if (numbers[x] == 9)
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
                return false;
            }
            else
            {
                for (int x = 0; x <= 3; x++)
                {
                    if (numbers[x] == 9)
                    {
                        return true;
                    }
                    else
                    {
                        continue;
                    }
                }
                return false;
            }
        }

        public bool Array123(int[] numbers)
        {
            for (int x = 0; x <= numbers.Length - 3; x++)
            {
                int a = numbers[x];
                int b = numbers[x + 1];
                int c = numbers[x + 2];
                if (a == 1 && b == 2 && c == 3)
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            int result = 0;
            if (a.Length > b.Length)
            {
                for (int x = 0; x <= b.Length - 2; x++)
                {
                    if (a.Substring(x, 2) == b.Substring(x, 2))
                    {
                        result++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                for (int x = 0; x <= a.Length - 2; x++)
                {
                    if (a.Substring(x, 2) == b.Substring(x, 2))
                    {
                        result++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return result;
        }

        public string StringX(string str)
        {
            string result = str.Substring(0, 1);
            for (int x = 1; x < str.Length - 1; x++)
            {
                string test = str.Substring(x, 1);
                if (test.Contains("x"))
                {
                    continue;
                }
                else
                {
                    result += test;
                }
            }
            result += str.Substring(str.Length - 1, 1);
            return result;
        }

        public string AltPairs(string str)
        {
            string result = "";
            if (str.Length % 2 == 0)
            {
                for (int x = 0; x <= str.Length - 2; x += 4)
                {
                    result += str.Substring(x, 2);
                }
            }
            else
            {
                for (int x = 0; x <= str.Length - 1; x += 4)
                {
                    if (x == str.Length - 1)
                    {
                        result += str.Substring(x, 1);
                        break;
                    }
                    else
                    {
                        result += str.Substring(x, 2);
                        continue;
                    }
                }
            }
            return result;
        }

        public string DoNotYak(string str)
        {
            string result = "";
            for (int x = 0; x <= str.Length - 3; x++)
            {
                string test1 = str.Substring(x, 1);
                string test2 = str.Substring(x + 2, 1);
                if (test1.Contains("y") && test2.Contains("k"))
                {
                    result += str.Remove(x, 3);
                    break;
                }
                else
                {
                    continue;
                }
            }
            return result;
        }

        public int Array667(int[] numbers)
        {
            int result = 0;
            for (int x = 0; x <= numbers.Length - 2; x++)
            {
                if (numbers[x] == 6 && numbers[x + 1] == 6 || numbers[x + 1] == 7)
                {
                    result++;
                }
                else
                {
                    continue;
                }
            }
            return result;
        }

        public bool NoTriples(int[] numbers)
        {
            for (int x = 0; x <= numbers.Length - 3; x++)
            {
                if (numbers[x] == numbers[x + 1] && numbers[x] == numbers [x + 2])
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            for (int x = 0; x <= numbers.Length - 3; x++)
            {
                int test = numbers[x];
                if (test + 5 == numbers[x + 1] && test - 1 == numbers[x + 2])
                {
                    return true;
                }
            }
            return false;
        }

    }
}
