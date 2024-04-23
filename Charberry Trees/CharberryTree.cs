
public class CharberryTree
{
    DateTime _time = DateTime.Now;
    private Random _random = new Random();
    public bool Ripe {  get; set; }

    public event Action? Ripened;

    public void MaybeGrow()
    {
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
            TimeSpan timePast = DateTime.Now - _time;
            Console.WriteLine($"H:{timePast.Hours} M:{timePast.Minutes} S:{timePast.Seconds}");
        }
    }
}
