using System;
/*I added functions to show if there are no entries when request to display entries. Also it shows that the user typed an invalid input and it promts them to select a number from 1 to 5.*/
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        Console.WriteLine("\nWelcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"{prompt}");
                Console.Write("");
                string response = Console.ReadLine();

                Entry entry = new Entry(prompt, response);
                journal.AddEntry(entry);
                Console.WriteLine("Entry recorded.\n");
            }
            else if (input == "2")
            {
                journal.DisplayAll();
            }
            else if (input == "3")
            {
                Console.Write("Enter filename to save: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (input == "4")
            {
                Console.Write("Enter filename to load: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (input == "5")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            }
        }
    }
}
