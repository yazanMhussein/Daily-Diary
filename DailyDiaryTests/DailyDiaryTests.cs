using System;
using Xunit;

public class DailyDiaryTests
{
    [Fact]
    public void TestReadDiary()
    {
        string filePath = "mydiary.txt";
        DailyDiary diary = new DailyDiary(filePath);

        // Add a sample entry
        diary.AddEntry(new Entry(DateTime.Now, "Test content"));

        // Redirect console output
        var output = new StringWriter();
        Console.SetOut(output);

        diary.ReadDiary();

        Assert.Contains("Test content", output.ToString());
    }

    [Fact]
    public void TestAddEntry()
    {
        string filePath = "mydiary.txt";
        DailyDiary diary = new DailyDiary(filePath);

        int initialCount = diary.CountEntries();
        diary.AddEntry(new Entry(DateTime.Now, "Another test content"));

        int newCount = diary.CountEntries();
        Assert.Equal(initialCount + 1, newCount);
    }
}
