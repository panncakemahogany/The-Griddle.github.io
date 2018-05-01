using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6)
            {
                return true;
            }
            else if (numbers[numbers.Length - 1] == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length >= 1)
            {
                if (numbers[0] == numbers[numbers.Length - 1])
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
        public int[] MakePi(int n)
        {
            int[] piPan = new int[n];
            int[] crust = new int[12] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };
            for (int x = 0; x <= n -1; x++)
            {
                piPan[x] = crust[x];
            }
            return piPan;
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            int aLong = a.Length - 1;
            int bLong = b.Length - 1;
            if (a[0] == b[0] || a[aLong] == b[bLong])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int Sum(int[] numbers)
        {
            int sum = 0;
            for (int x = 0; x <= numbers.Length - 1; x++)
            {
                sum += numbers[x];
            }
            return sum;
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] result = new int[numbers.Length];
            result[0] = numbers[1];
            result[1] = numbers[2];
            result[2] = numbers[0];
            return result;
        }
        
        public int[] Reverse(int[] numbers)
        {
            int[] result = new int[numbers.Length];
            int y = numbers.Length - 1;
            for (int x = 0; x <= numbers.Length - 1; x++)
            {
                result[x] = numbers[y];
                y = y - 1;
            }
            return result;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int end = numbers.Length - 1;
            if (numbers[0] > numbers[end])
            {
                int[] result = new int[numbers.Length];
                for (int x = 0; x <= end; x++)
                {
                    result[x] = numbers[0];
                }
                return result;
            }
            else
            {
                int[] result = new int[numbers.Length];
                for (int x = 0; x <= end; x++)
                {
                    result[x] = numbers[end];
                }
                return result;
            }
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] result = new int[2];
            result[0] = a[1];
            result[1] = b[1];
            return result;
        }
        
        public bool HasEven(int[] numbers)
        {
            for (int x = 0; x <= numbers.Length - 1; x++)
            {
                if (numbers[x] % 2 == 0)
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
        
        public int[] KeepLast(int[] numbers)
        {
            int[] result = new int[numbers.Length * 2];
            int end = result.Length - 1;
            for (int x = 0; x <= end; x++)
            {
                if (x == end)
                {
                    result[x] = numbers[numbers.Length - 1];
                    break;
                }
                result[x] = 0;
            }
            return result;
        }
        
        public bool Double23(int[] numbers)
        {
            int[] law = new int[6];
            for (int x = 0; x <= numbers.Length - 1; x++)
            {
                if (numbers[x] == 2)
                {
                    if (law[1] == 2)
                    {
                        law[2] = 2;
                    }
                    else if (law[0] == 2)
                    {
                        law[1] = 2;
                    }
                    else
                    {
                        law[0] = 2;
                    }
                }
                else if (numbers[x] == 3)
                {
                    if (law[4] == 3)
                    {
                        law[5] = 3;
                    }
                    else if (law[3] == 3)
                    {
                        law[4] = 3;
                    }
                    else
                    {
                        law[3] = 3;
                    }
                }
                else
                {
                    continue;
                }
            }
            if (law[2] == 2 || law[5] == 3)
            {
                return false;
            }
            if (law[0] == 2 && law[1] == 2 || law[3] == 3 && law[4] == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int[] Fix23(int[] numbers)
        {
            int[] result = new int[3];
            if (numbers[0] == 2 && numbers[1] == 3)
            {
                result[0] = numbers[0];
                result[1] = 0;
                result[2] = numbers[2];
            }
            else if (numbers[1] == 2 && numbers[2] == 3)
            {
                result[0] = numbers[0];
                result[1] = numbers[1];
                result[2] = 0;
            }
            else
            {
                result[0] = numbers[0];
                result[1] = numbers[1];
                result[2] = numbers[2];
            }
            return result;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            for (int x = 0; x <= numbers.Length - 2; x++)
            {
                int y = x + 1;
                if (numbers[x] == 1 && numbers [y] == 3)
                {
                    if (x < 2 || x > numbers.Length - 2)
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
                    continue;
                }
            }
            return false;
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] result = new int[2];
            if (a.Length > 0 && b.Length > 0)
            {
                if (a.Length == 1)
                {
                    result[0] = a[0];
                    result[1] = b[0];
                }
                else
                {
                    result[0] = a[0];
                    result[1] = a[1];
                }
            }
            else if (a.Length == 0)
            {
                result[0] = b[0];
                result[1] = b[1];
            }
            else
            {
                result[0] = a[0];
                result[1] = a[1];
            }
            return result;
        }

    }
}
