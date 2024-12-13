using System;
using System.Collections.Generic;

abstract class Activity
{
    private string _date;
    protected int _durationMinutes; // Changed to protected to allow access in derived classes

    protected Activity(string date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public abstract double CalculateDistance();
    public abstract double CalculateSpeed();
    public abstract double CalculatePace();

    public string GetSummary()
    {
        double distance = CalculateDistance();
        double speed = CalculateSpeed();
        double pace = CalculatePace();
        return $"{_date}: {GetType().Name} ({_durationMinutes} min): Distance {distance:F2} km, Speed {speed:F2} kph, Pace {pace:F2} min per km";
    }
}

class Running : Activity
{
    private double _distanceKm;

    public Running(string date, int durationMinutes, double distanceKm) : base(date, durationMinutes)
    {
        _distanceKm = distanceKm;
    }

    public override double CalculateDistance()
    {
        return _distanceKm;
    }

    public override double CalculateSpeed()
    {
        return (_distanceKm / _durationMinutes) * 60;
    }

    public override double CalculatePace()
    {
        return _durationMinutes / _distanceKm;
    }
}

class Cycling : Activity
{
    private double _speedKph;

    public Cycling(string date, int durationMinutes, double speedKph) : base(date, durationMinutes)
    {
        _speedKph = speedKph;
    }

    public override double CalculateDistance()
    {
        return (_speedKph * _durationMinutes) / 60;
    }

    public override double CalculateSpeed()
    {
        return _speedKph;
    }

    public override double CalculatePace()
    {
        return 60 / _speedKph;
    }
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double CalculateDistance()
    {
        return (_laps * 50) / 1000.0;
    }

    public override double CalculateSpeed()
    {
        double distanceKm = CalculateDistance();
        return (distanceKm / _durationMinutes) * 60;
    }

    public override double CalculatePace()
    {
        double distanceKm = CalculateDistance();
        return _durationMinutes / distanceKm;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 4.8),
            new Cycling("04 Nov 2022", 45, 20),
            new Swimming("05 Nov 2022", 60, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
