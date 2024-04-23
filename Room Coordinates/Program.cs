
Coordinates a = new(0, -1);
Coordinates b = new(1, 0);
Coordinates c = new(3, 1);
Coordinates d = new(4, 7);

Console.WriteLine(Coordinates.IsAdjacent(a, b));
Console.WriteLine(Coordinates.IsAdjacent(a, c));
Console.WriteLine(Coordinates.IsAdjacent(b, c));
Console.WriteLine(Coordinates.IsAdjacent(c, d));


public struct Coordinates
{
    public readonly int X { get; }
    public readonly int Y { get; }

    public static bool IsAdjacent(Coordinates a, Coordinates b)
    {
        if (a.X == b.X + 1 || a.X == b.X - 1) return true;
        if (a.Y == b.Y + 1 || a.Y == b.Y - 1) return true;
        return false;
    }

    public Coordinates(int x, int y)
    {
        X = x; Y = y;
    }
}