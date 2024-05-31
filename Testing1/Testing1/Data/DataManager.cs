using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing1.Data
{
    internal class DataManager
    {
        //read from txt file
        public static List<DataPackage> Read()
        {
            List<DataPackage> result = new List<DataPackage>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                string line = reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    DataPackage package = new DataPackage(line);
                    result.Add(package);
                }
            }
            return result;
        }

        //write to txt file
        public static void Write(DataPackage dataPackage)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                string newLine = dataPackage.ToString();

                writer.WriteLine(newLine);
            }
        }

        //create text file to read and write to
        public static void PathDirectory()
        {
            string path = "C:\\Temp\\Bingo\\Bongo";
            if (Directory.Exists(path))
            {
                Console.WriteLine("The directory already exists");
            }
            else
            {
                DirectoryInfo directory = Directory.CreateDirectory(path);
                Console.WriteLine("A directory was created for data management");
            }
            if (File.Exists(filePath))
            {
                Console.WriteLine("The database file already exists");
            }
            else
            {
                File.Create(filePath);
                Console.WriteLine("A database file was created for this program's memory usage");
            }
            Console.WriteLine("Hit enter to continue");
            Console.ReadLine();
        }
        public static string filePath = "C:\\Temp\\Bingo\\Bongo\\test.txt";


    }
}
