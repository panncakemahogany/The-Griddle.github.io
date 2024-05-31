using System.Numerics;
using Testing1.Data;

namespace Testing1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            //TestClass test = new TestClass();
            //Console.WriteLine("Hello, World!");
            //TestClass.StaticString();
            //TestClass.InputString(test.attributeString);
            //TestClass.InputInteger(test.attributeInteger);
            //TestClass.InteractMethod();
            //TestClass.SortString();
            //test.GoldenRatioUI();
            Run();
        }

        static void Run()
        {
            DataManager.PathDirectory();
            for (int i = 0; i <= 3; i++)
            {
                Console.Clear();
                Console.WriteLine("Console program operational! Hello World!");
                Console.WriteLine();
                Console.WriteLine("To select an option, type it out.");
                Console.WriteLine();
                Console.WriteLine("Start");
                Console.WriteLine();
                Console.WriteLine("Exit");
                Console.WriteLine();
                if (i == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID INPUT");
                    Console.ResetColor();
                }
                string userInput = Console.ReadLine();
                if (userInput != null && userInput != string.Empty)
                {
                    if (userInput.ToLower() == "start")
                    {
                        MainMenu();
                        i = 0;
                    }
                    else if (userInput.ToLower() == "exit")
                    {
                        i = 3; break;
                    }
                    else
                    {
                        i = 1;
                    }
                }
                else
                {
                    i = 1;
                }
            }
        }

        static void MainMenu()
        {
            for (int i = 0; i <= 3; i++)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("          MAIN   MENU          ");
                Console.WriteLine("                               ");
                Console.WriteLine("                               ");
                Console.WriteLine("                               ");
                Console.ResetColor();
                Console.WriteLine("             START             ");
                Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("         SELECT   TEST         ");
                Console.ResetColor();
                Console.WriteLine("            OPTIONS            ");
                Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("          EXIT PROGRAM         ");
                Console.ResetColor();
                Console.WriteLine("                               ");
                Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("   TYPE TO SELECT MENU OPTION  ");
                Console.ResetColor();
                Console.ReadLine();
            }
        }
    }
}

public class TestClass
{
    public int attributeInteger = 451;
    public string attributeString = "This is TestClass's attributeString, I am static and unchanging. You can call me a field.";
    private Dictionary<BigInteger, BigInteger> _cache = new Dictionary<BigInteger, BigInteger>()
    {
        [0] = 0,
        [1] = 1
    };
    public static void StaticString()
    {
        Console.WriteLine("TestClass.staticString() says 'Hello, World!'");
    }

    public static void InputString(string str)
    {
        Console.WriteLine(str);
    }

    public static void InputInteger(int i)
    {
        Console.WriteLine($"The integer attribute of this TestClass is {i}");
    }

    public static void InteractMethod()
    {
        Console.WriteLine("Please submit a text string for further testing.");
        string str = Console.ReadLine();
        Console.WriteLine($"Thank you, what are said was: {str}");
    }

    public static void SortString()
    {
        Console.WriteLine("Please submit a series of words that I will proceed to arrange in alphabetical and word length order");
        string userInput = Console.ReadLine();
        if (userInput != null && userInput.Replace(" ", string.Empty) != string.Empty)
        {
            string[] words = userInput.Split(" ");
            string[] alphabetizedWords = words.OrderBy(x => x).ToArray();
            string alphabetizedString = "";
            for (int i = 0; i < alphabetizedWords.Length; i++)
            {
                alphabetizedString += alphabetizedWords[i] + " ";
            }
            Console.WriteLine(alphabetizedString);
            string lengthSortedString = "";
            Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));
            for (int i = 0; i < words.Length; i++)
            {
                lengthSortedString += words[i] + " ";
            }
            Console.WriteLine(lengthSortedString);
        }
        else 
        {
            Console.WriteLine("Invalid Input, test aborted.");
            return; 
        }
    }

    public BigInteger CalculateFibonacciSequence(int number)
    {
        if (_cache.ContainsKey(number))
            return _cache[number];

        _cache[number] = CalculateFibonacciSequence(number - 1) + CalculateFibonacciSequence(number - 2);
        return _cache[number];
    }

    public void GoldenRatioUI()
    {
        Console.WriteLine("Give me a number and I will return that number's iteration in the Fibonacci sequence.");
        string userInput = Console.ReadLine();
        int number;
        if (int.TryParse(userInput, out number))
        {
            if (number <= 3000)
            {
                Console.WriteLine($"{CalculateFibonacciSequence(number)}");
            }
            else
            {
                Console.WriteLine("I refuse to let you cause a stack overflow. The 3000th iteration is enough, anymore than that is just obscene. Test aborted.");
            }
        }
        else
        {
            Console.WriteLine("Error input not able to be parsed");
        }
    }

    public void SaveRecallDataUI()
    {
        Console.WriteLine("ENTER TEXT");
        string userInputString = Console.ReadLine();
        Console.WriteLine("ENTER NUMBER");
        List<string> strings = new List<string>();
        
    }
}