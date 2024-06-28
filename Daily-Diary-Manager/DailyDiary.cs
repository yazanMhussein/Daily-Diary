using Daily_Diary_Manager;
using System;
using System.Collections.Generic;
using System.IO;

public class DailyDiary
{
    private string _filePath;

    public DailyDiary(string filePath)
    {
        _filePath = filePath;
    }

    public void ReadDiary()
    {
        if (File.Exists(_filePath))
        {
            string[] lines = File.ReadAllLines(_filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("Diary file not found.");
        }
    }

    public void AddEntry(Entry entry)
    {
        using (StreamWriter sw = new StreamWriter(_filePath, true))
        {
            sw.WriteLine(entry.ToString() + Environment.NewLine);
        }
    }

    public void DeleteEntry(DateTime date)
    {
        if (File.Exists(_filePath))
        {
            List<string> lines = new List<string>(File.ReadAllLines(_filePath));
            lines.RemoveAll(line => line.StartsWith(date.ToString("yyyy-MM-dd")));
            File.WriteAllLines(_filePath, lines);
        }
        else
        {
            Console.WriteLine("Diary file not found.");
        }
    }

    public int CountEntries()
    {
        if (File.Exists(_filePath))
        {
            string[] lines = File.ReadAllLines(_filePath);
            return lines.Length;
        }
        else
        {
            Console.WriteLine("Diary file not found.");
            return 0;
        }
    }

    public void SearchEntries(DateTime date)
    {
        if (File.Exists(_filePath))
        {
            string[] lines = File.ReadAllLines(_filePath);
            foreach (string line in lines)
            {
                if (line.StartsWith(date.ToString("yyyy-MM-dd")))
                {
                    Console.WriteLine(line);
                }
            }
        }
        else
        {
            Console.WriteLine("Diary file not found.");
        }
    }
}
 