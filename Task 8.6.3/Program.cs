using System;
using System.IO;

namespace Task_8._6._3
{
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите путь к файлам");
                string Path = Console.ReadLine();

                int file = 0;

                DirectoryInfo dirInfo = new DirectoryInfo(Path);
                if (dirInfo.Exists)
                {
                    var asd = FolderSize(Path);

                    Console.WriteLine("Исходный рамер папки: {0} байт", asd);

                    foreach (var item in dirInfo.GetFiles())
                    {
                        item.Delete();
                        file++;
                    }
                    foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                    {

                        dir.Delete(true);

                    }
                    
                    Console.WriteLine("Колличество удаленных файлов: {0}", file);
                    Console.WriteLine("Освобождено {0} байт", asd);
                    var qwe = FolderSize(Path);
                    Console.WriteLine("Текущий размер папки: {0} байт", qwe);
                }
                else
                {
                    Console.WriteLine("Путь указан не верно");
                }

               
                static long FolderSize(string Path)
                {
                    long i = 0;
                    DirectoryInfo DrInfo = new DirectoryInfo(Path);
                    DirectoryInfo[] folder = DrInfo.GetDirectories();
                    FileInfo[] Fi = DrInfo.GetFiles();

                    foreach (FileInfo fl in Fi)
                    {
                        i += fl.Length;
                    }

                    for (int j = 0; j < folder.Length; j++)
                    {
                        i += FolderSize(Path + "\\" + folder[j].Name);
                    }

                    return i;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);

            }

            
        }
    }
}

