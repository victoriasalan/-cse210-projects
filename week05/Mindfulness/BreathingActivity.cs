using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;
        bool breatheIn = true;

        while (elapsed < _duration)
        {
            Console.WriteLine(breatheIn ? "\nBreathe in..." : "Now breathe out...");
            ShowCountDown(4);
            elapsed += 4;
            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}