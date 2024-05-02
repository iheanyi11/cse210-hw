using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToCsv(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            // Write header row
            writer.WriteLine("Date,PromptText,EntryText");

            foreach (Entry entry in _entries)
            {
                // Write each entry in CSV format
                writer.WriteLine($"{entry.Date},{entry.PromptText},{entry.EntryText}");
            }
        }
    }

    public void LoadFromCsv(string file)
    {
        _entries.Clear(); // Clear existing entries before loading new ones

        using (StreamReader reader = new StreamReader(file))
        {
            // Skip header row
            reader.ReadLine();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    _entries.Add(entry);
                }
            }
        }
    }
}
