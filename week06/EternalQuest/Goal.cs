using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetDetailsString();

    public abstract string GetStringRepresentation();

}