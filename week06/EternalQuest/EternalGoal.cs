using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {

    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {ShortName} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{ShortName}|{Description}|{Points}";
    }
}