

RecentNumbers recentNumbers = new RecentNumbers();
Thread thread = new Thread(recentNumbers.RandomGen);
thread.Start();

while (true)
{
    Console.ReadKey(false);
    if (recentNumbers.Last == recentNumbers.SecondLast) Console.WriteLine("Correct");
    else Console.WriteLine("Wrong");
}


class RecentNumbers
{
    private readonly object _numberLock = new object();
    private int _last;
    private int _secondLast;

    public int Last
    {
        get
        {
            lock (_numberLock)
            {
                return _last;
            }
        }
    }

    public int SecondLast
    {
        get
        {
            lock (_numberLock)
            {
                return _secondLast;
            }
        }
    }

    public void Update(int newNum)
    {
        lock (_numberLock)
        {
            _secondLast = _last;
            _last = newNum;
        }
    }

    public void RandomGen()
    {
        while (true)
        {
            Random random = new Random();
            int num = random.Next(0, 10);
            Console.WriteLine(num);
            Update(num);
            Thread.Sleep(1000);

        }
    }
}