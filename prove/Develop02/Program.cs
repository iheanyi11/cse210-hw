using System;
using System.Collections.Generic;

// To exceed requirements, I improved the process of saving and loading to save as a .csv file that can be opened in excel
class Program

{
    static void Main(string[] args)
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        PromptGenerator promptGenerator = new PromptGenerator(prompts);
        Journal journal = new Journal();

        int choice;

        do
        {
            Console.WriteLine("Welcome to the Journal program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        WriteEntry(journal, promptGenerator);
                        break;
                    case 2:
                        journal.DisplayAll();
                        break;
                    case 3:
                        LoadJournal(journal);
                        break;
                    case 4:
                        SaveJournal(journal);
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (choice != 5);
        static void WriteEntry(Journal journal, PromptGenerator promptGenerator)
        {
            string randomPrompt = promptGenerator.GetRandomPrompt();
            Console.WriteLine(randomPrompt);
            Console.Write("Your response: ");
            string entryText = Console.ReadLine();

            Entry newEntry = new Entry(DateTime.Now.ToString(), randomPrompt, entryText);
            journal.AddEntry(newEntry);
            Console.WriteLine("Entry added!\n");
        }

        static void LoadJournal(Journal journal)
        {
            Console.Write("Enter the file name to load from: ");
            string fileName = Console.ReadLine();
            journal.LoadFromCsv(fileName);
            Console.WriteLine("Journal loaded!\n");
        }

        static void SaveJournal(Journal journal)
        {
            Console.Write("Enter the file name to save to: ");
            string fileName = Console.ReadLine();
            journal.SaveToCsv(fileName);
            Console.WriteLine("Journal saved!\n");
        }
    }
}