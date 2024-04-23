
Point point1 = new Point(2, 3);
Point point2 = new Point(-4, 0);
Point point3 = new Point();

Console.WriteLine($"({point1.X}, {point1.Y}) ({point2.X}, {point2.Y}) ({point3.X}, {point3.Y}) ");

class Point
{
    public float X { get; private set; }
    public float Y { get; private set; }

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }

    public Point()
    {
        X = 0; Y = 0;
    }
}
