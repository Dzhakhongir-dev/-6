using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(
            "Введите 1 — Что бы вывести данные на экран.\n" +
            "Введите 2 — Что бы заполнить данные и добавить новую запись.\n" +
            "Введите 3 - Что бы убрать символы '#' из записи.\n" +
            "Введите 4 - Что бы удалить запись.");


            string inputAction = Console.ReadLine();

            switch (inputAction)
            {
                case "1":
                    ReadMethod();
                    break;

                case "2":
                    WriteMethod();
                    break;

                case "3":
                    SplitMethod();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Вы уверены?\n" +
                        "Нажмите 1 если хотите удалить\n" +
                        "Нажмите 2 если не хотите удалять");

                    string choose = Console.ReadLine();

                    switch (choose)
                    {
                        case "1":
                            DeleteMethod();
                            Console.WriteLine("Файл Удален!");
                            break;

                            case "2":
                            ReadMethod();
                            break;

                        default:
                            Console.WriteLine("Такой операции не существует!");
                            break;
                    }
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Такой операции не существует!");
                    break;
            }
        }
    }

    public static void DeleteMethod()
    {
        string pathToFile = @"D:\SkillBoxExample.txt";

        if (File.Exists(pathToFile))
        {
            File.Delete(pathToFile);
        }
        else
        {
            Console.WriteLine("Файл и так отсутвует!");
            Console.ReadLine();
        }
    }

    public static void SplitMethod()
    {
        Console.Clear();
        string pathToFile = File.ReadAllText(@"D:\SkillBoxExample.txt");

        string[] textInFile = pathToFile.Split('#');

        foreach (var item in textInFile)
        {
            Console.Write(item);
        }

        for (int i = 0; i < textInFile.Length; i++)
        {
            Console.Write(textInFile[i]);
        }
        Console.ReadKey();
    }
    
    public static void ReadMethod()
    {
        string pathToFile = @"D:\SkillBoxExample.txt";

        Console.Clear();

        if (!File.Exists(pathToFile))
        {
            
            Console.WriteLine("Файлa не существует!\nСейчас создам!");

            FileStream fileStream = new FileStream(pathToFile, FileMode.Append);

            StreamWriter streamWriter = new StreamWriter(fileStream);

            streamWriter.Close();
            Console.ReadKey();
        }

        else
        {
            string[] textInFile = File.ReadAllLines(pathToFile);

            File.WriteAllLines(pathToFile, textInFile);

            for (int i = 0; i < textInFile.Length; i++)
            {
                Console.WriteLine(textInFile[i]);
            }
            Console.ReadKey();
        }
    }

    public static void WriteMethod()
    {
        string pathToFile = @"D:\SkillBoxExample.txt";

        FileStream fileStream = new FileStream(pathToFile, FileMode.Append);

        StreamWriter streamWriter = new StreamWriter(fileStream);

        FileInfo fileInfo = new FileInfo(pathToFile);

        Console.Clear();

        Console.Write("Введите Ваше ID - ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите Имя - ");
        string firstName = Console.ReadLine();
        
        Console.Write("Введите Фамилию - ");
        string lastName = Console.ReadLine();

        Console.Write("Введите Отчество - ");
        string midName = Console.ReadLine();

        Console.Write("Введите Возраст - ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите Рост - ");
        int height = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите Дату Рождения - ");
        int dateOfBirth = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите Место Рождения - ");
        string placeOfBirth = Console.ReadLine();

        streamWriter.Write(
        $"ID - #{id}#\n" +
        $"Дата и Время Добавления Записи - #{fileInfo.LastWriteTime}#\n" +
        $"Имя - #{firstName}#\n" +
        $"Фамилия - #{midName}#\n" +
        $"Отчество - #{lastName}#\n" +
        $"Возраст - #{age}#\n" +
        $"Рост - #{height}#\n" +
        $"Дата Рождения - #{dateOfBirth}#\n" +
        $"Место Рождения - #{placeOfBirth}#");

        Console.ReadKey();

        streamWriter.Close();
        fileStream.Close();
        
    }
}