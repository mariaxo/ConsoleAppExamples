using System;
using System.IO;
using System.Linq;

namespace DisposingAndGarbageCollection
{
    //Directory , Path , File

    //getting all directories in a path
    //getting all files in a path
    //getting info about a file
    //creating a new directory
    //copy files
    //move files

    class Program
    {
        static void Main(string[] args)
        {
            #region Directory
            string rootPath = @"C:\Users\mabrahamyan\Desktop";

            //read all the directories (folders) in this path
            string[] directories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

            foreach (string directory in directories)
            {
                Console.WriteLine(directory);
            }

            Console.WriteLine();

            //files in the directory
            var files = Directory.GetFiles(rootPath, "*", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                //Console.WriteLine(file);
                //Console.WriteLine(Path.GetFileName(file));
                //Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                //Console.WriteLine(Path.GetFullPath(file));
                Console.WriteLine(Path.GetDirectoryName(file));
            }

            //creating a directory
            string newPath = @"C:\Users\mabrahamyan\Desktop\NewFolder\NewSubFolder";
            Directory.CreateDirectory(newPath);



            #endregion

            int a = 5;
            int a1 = int.Parse(Convert.ToString(a, 2));
            Console.WriteLine(a1*7);


            #region File - reading from a file
            //debug to see
            string text = System.IO.File.ReadAllText(@"C:\Users\mabrahamyan\Desktop\FilesDemoDirectory\DemoTextToReadWrite.txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\mabrahamyan\Desktop\FilesDemoDirectory\DemoTextToReadWrite.txt");

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            #endregion
           
            #region File - writing to a file
            //using File class
                string textToWriteIntoTheFile = "This is now the new information";
            File.WriteAllText(@"C:\Users\mabrahamyan\Desktop\FilesDemoDirectory\DemoTextToReadWrite.txt", textToWriteIntoTheFile);

            string[] linesToWrite = new[] { "Line 1", "line 2" };
            File.WriteAllLines(@"C:\Users\mabrahamyan\Desktop\FilesDemoDirectory\DemoTextToReadWrite.txt", linesToWrite);


            //using StreamWriter to write to a file

            string[] linesToWriteToFile1 = { "line 1 to write", "line2 to write", "line 3 to write" };
            //using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\Users\mabrahamyan\Desktop\FilesDemoDirectory\DemoTextToReadWrite.txt"))
            //{
            //    foreach (var line in linesToWriteToFile1)
            //    {
            //        writer.WriteLine(line);
            //    }
            //}
            System.IO.StreamWriter writer = null;
            try
            {
                writer = new System.IO.StreamWriter(@"C:\Users\mabrahamyan\Desktop\FilesDemoDirectory\DemoTextToReadWrite.txt");
                foreach (var line in linesToWriteToFile1)
                {
                    writer.WriteLine(line);
                }
            }
            //using doesn't have the catch clause
            catch (IOException ex)
            {
                Console.WriteLine("An IO exception occured" + ex.Message);
            }
            finally
            {
                writer?.Dispose();
            }
            #endregion

            #region Streams (System.IO) - write to a file with a StreamWriter
            string[] linesToWriteToFile2 = { "line 1 to write", "line2 to write", "line 3 to write" };

            //ctor takes a path here
                using (StreamWriter writerr = new StreamWriter(@"C:\Users\mabrahamyan\Desktop\FilesDemoDirectory\DemoTextToReadWrite.txt"))
                { 
                    foreach (var line in linesToWriteToFile2)
                    {
                         writerr.WriteLine(line);
                    }
                }

            #endregion

            FileStream xmlFromFilevv = File.OpenRead("path/to/the/file");
                 

            #region StreamReader
            Stream xmlFromFile = File.Open("Sample.xml", FileMode.Open);
            // ctor takes a stream here
            StreamReader reader = new StreamReader(xmlFromFile);
            string xmlData = reader.ReadToEnd();
            #endregion


            #region StreamReader reads from a stream , which in this case is just a file
            Stream s = File.Open("TextFile1.txt", FileMode.Open);
            StreamReader readerr = new StreamReader(s);
            string fileLine1 = readerr.ReadLine();
            string fileLine2 = readerr.ReadLine();

            Console.WriteLine(fileLine1);
            Console.WriteLine(fileLine2);
            #endregion
        }
    }
}
