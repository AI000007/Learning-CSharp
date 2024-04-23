
ColouredItem<Sword> blueSword = new(new Sword(), ConsoleColor.Blue);
ColouredItem<Bow> redBow = new(new Bow(), ConsoleColor.Red);
ColouredItem<Axe> greenAxe = new(new Axe(), ConsoleColor.Green);

blueSword.Diplay();
redBow.Diplay();
greenAxe.Diplay();

public class Sword { }
public class Bow { }
public class Axe { }

public class ColouredItem<T>
{
    public ConsoleColor Colour { get; }
    public T Item { get; }

    public ColouredItem(T item, ConsoleColor colour)
    {
        Colour = colour;
        Item = item;
    }
    public void Diplay()
    {
        Console.ForegroundColor = Colour;
        Console.WriteLine(Item);
    }

}
