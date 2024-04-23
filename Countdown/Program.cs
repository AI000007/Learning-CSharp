int CountFrom(int x)
{
    Console.WriteLine(x);
    if (x == 1) return x;

    return CountFrom(x - 1);
}

CountFrom(100);