//I added some functions to let the user know if they typed invalid input. I also added stars to show when congratulating the user for compliting the checklist goal.
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding  = Encoding.UTF8;

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}