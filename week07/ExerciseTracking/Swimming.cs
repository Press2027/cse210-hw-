public class Swimming : Activity
{
    private int _laps; // 50 meters each

    public Swimming(string date, int minutes, int laps) 
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // meters → kilometers → miles
        double km = (_laps * 50) / 1000.0;
        double miles = km * 0.62;
        return miles;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
