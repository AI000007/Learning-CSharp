

using System.Xml;

Colour custom = new Colour(123, 034, 255);
Colour red = Colour.Red;

Console.WriteLine($"({custom._red}, {custom._green}, {custom._blue}) ({red._red}, {red._green}, {red._blue})");

class Colour
{
    public int _red { get; private set; }
    public int _green { get; private set; }
    public int _blue { get; private set; }

    public Colour(int red, int green, int blue)
    {
        _red = red;
        _green = green;
        _blue = blue;
    }

    public static Colour White => new Colour(255, 255, 255);
    public static Colour Black => new Colour(0, 0, 0);
    public static Colour Red => new Colour(255, 0, 0);
    public static Colour Orange => new Colour(255, 165, 0);
    public static Colour Yellow => new Colour(255, 255, 0);
    public static Colour Green => new Colour(0, 128, 0);
    public static Colour Blue => new Colour(0, 0, 255);
    public static Colour Purple => new Colour(128, 0, 128);
}
