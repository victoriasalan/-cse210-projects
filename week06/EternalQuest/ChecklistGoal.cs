using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted = 0;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted += 1;

        if (IsComplete())
        {
            return Points + _bonus;
        }

        return Points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {ShortName} ({Description}) -- Currently Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName}|{Description}|{Points}|{_amountCompleted}|{_target}|{_bonus}";
    }

    public void SetAmountCompletedForLoad(int amount)
    {
        _amountCompleted = amount;
        if (_amountCompleted < 0) _amountCompleted = 0;
        if (_amountCompleted > _target) _amountCompleted = _target;
    }

}