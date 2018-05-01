using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riley.Powerball.BLL.Validation
{
    public class Validate
    {
        public static bool ValidFirstFiveRange(int number)
        {
            if (number > 0 && number < 70)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidPowerballRange(int powerball)
        {
            if (powerball > 0 && powerball < 27)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsQuickPick(int quickpick)
        {
            if (quickpick > 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static bool NoFirstFiveOverlap(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[numbers.Count - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
