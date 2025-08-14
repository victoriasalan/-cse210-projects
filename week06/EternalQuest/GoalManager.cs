using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine($"You have {_score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please choose 1–6.");
                    break;
            }

            if (running)
            {
                Console.WriteLine();
            }
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one goal!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points = ReadInt("What is the amount of points associated with this goal? ");

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid type. No goal created.");
        }

    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first.");
            return;
        }

        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }

        Console.Write("Enter number: ");

        if (int.TryParse(Console.ReadLine(), out int index))
        {
            index -= 1;
            if (index >= 0 && index < _goals.Count)
            {
                int earned = _goals[index].RecordEvent();
                _score += earned;

                if (earned > 0)
                {
                    if (_goals[index] is ChecklistGoal checklist && checklist.IsComplete())
                    {
                        Console.WriteLine($"🎉 Congratulations! You completed the checklist goal '{_goals[index].ShortName}'!");
                        Console.WriteLine($"You earned {earned} points (including bonus!)");
                        Console.WriteLine("⭐⭐⭐⭐⭐ Great job! ⭐⭐⭐⭐⭐");
                    }
                    else
                    {
                        Console.WriteLine($"Congratulations! You have earned {earned} points!");
                    }
                }
                else
                {
                    Console.WriteLine("This goal is already complete. No points earned.");
                }       
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }

    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine("File Saved");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);
        _goals.Clear();
        _score = 0;

        if (lines.Length == 0) return;

        int.TryParse(lines[0], out _score);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] typeAndData = lines[i].Split(':');
            if (typeAndData.Length != 2) continue;

            string type = typeAndData[0];
            string data = typeAndData[1];
            Goal g = GoalFactory(type, data);
            if (g != null) _goals.Add(g);
        }

        Console.WriteLine("File loaded.");
    }


    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string raw = Console.ReadLine();
            if (int.TryParse(raw, out int value)) return value;
            Console.WriteLine("Please enter a whole number.");
        }
    }

    private Goal GoalFactory(string type, string data)
    {
        string[] p = data.Split('|');

        try
        {
            if (type == "SimpleGoal" && p.Length == 4)
            {
                var g = new SimpleGoal(p[0], p[1], int.Parse(p[2]));
                if (bool.Parse(p[3])) g.ForceCompleteForLoad();
                return g;
            }
            if (type == "EternalGoal" && p.Length == 3)
            {
                return new EternalGoal(p[0], p[1], int.Parse(p[2]));
            }
            if (type == "ChecklistGoal" && p.Length == 6)
            {
                var g = new ChecklistGoal(p[0], p[1], int.Parse(p[2]), int.Parse(p[4]), int.Parse(p[5]));
                g.SetAmountCompletedForLoad(int.Parse(p[3]));
                return g;
            }
        }
        catch { }

        return null;
    }
}