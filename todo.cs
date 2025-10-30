Console.Clear();
string appFolder = AppDomain.CurrentDomain.BaseDirectory;
string fileList = Path.Combine(appFolder, "tasks.txt");


void Menu()
{
    Console.WriteLine("\na - Add new\nd - Delete task\nx - Exit");

    string rk = Console.ReadLine().ToLower();
    if (rk == "a") AddNew();
    else if (rk == "d") Delete();
    else if (rk == "x") System.Environment.Exit(0);
    else Show();
}


void Show()
{
    Console.Clear();
    try
    {
        string[] tasks = File.ReadAllLines(fileList);
        if (tasks[0] != null)
            for (int id = 0; id < tasks.Length; id++)
                Console.WriteLine(id + 1 + "\t" + tasks[id]);
    }
    catch
    {
        Console.WriteLine("Nothing");
    }
    Menu();
}


void AddNew()
{
    Console.Write("\nEnter task: ");
    string name = Console.ReadLine();
    Console.Write("Enter time: ");
    string time = Console.ReadLine();
    using (StreamWriter sw = new(fileList, true))
        sw.WriteLine($"{name}\t{time}");
    Show();
}


void Delete()
{
    Console.Write("What to delete? (0 - Back) ");
    List<string> list = [.. File.ReadAllLines(fileList)];
    try
    {
        int complite = int.Parse(Console.ReadLine());
        if (complite > 0 && complite <= list.Count)
        {
            list.RemoveAt(--complite);
            File.WriteAllLines(fileList, list);
            Show();
        }
        else Show();
    }
    catch
    {
        Console.WriteLine("erorr: no number found");
        Delete();
    }
}


Show();
