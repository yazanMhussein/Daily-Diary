namespace Daily_Diary_Manager;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "mydiary.txt";
        DailyDiary diary = new DailyDiary(filePath);

        while (true)
        {
            Console.WriteLine("Daily Diary Manager");
            Console.WriteLine("1. Read Diary");
            Console.WriteLine("2. Add Entry");
            Console.WriteLine("3. Delete Entry");
            Console.WriteLine("4. Count Entries");
            Console.WriteLine("5. Search Entries");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    diary.ReadDiary();
                    break;
                case "2":
                    Console.Write("Enter the date (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    {
                        Console.Write("Enter the content: ");
                        string content = Console.ReadLine();
                        Entry entry = new Entry(date, content);
                        diary.AddEntry(entry);
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                    }
                    break;
                case "3":
                    Console.Write("Enter the date (YYYY-MM-DD) of the entry to delete: ");
                    if (DateTime.TryParse(Console.ReadLine(), out date))
                    {
                        diary.DeleteEntry(date);
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                    }
                    break;
                case "4":
                    int count = diary.CountEntries();
                    Console.WriteLine($"Total entries: {count}");
                    break;
                case "5":
                    Console.Write("Enter the date (YYYY-MM-DD) to search for: ");
                    if (DateTime.TryParse(Console.ReadLine(), out date))
                    {
                        diary.SearchEntries(date);
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format.");
                    }
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}

