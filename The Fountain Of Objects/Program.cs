

using System.Data;
using System.Data.Common;
using System.Security.Claims;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous threats in search of the Fountain of Objects.");
Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
Console.WriteLine("You must navigate the Caverns with your other senses.");
Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.");
Console.WriteLine("Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns. You will be able to hear their growling and groaning in nearby rooms.");
Console.WriteLine("Amaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.");
Console.WriteLine("You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply.");
Console.WriteLine("You can enter \"help\" for a list of commands.");
Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.\n");

Console.ForegroundColor = ConsoleColor.White;
int size = AskForNumberInRange("What size cavern would you like? \n1 - Small \n2 - Medium \n3 - Large", 1, 3) switch
{
    1 => 4,
    2 => 6,
    3 => 8,
};

Console.Clear();

Cavern cavern = new(size);
new FountainOfObjectsGame().Run(cavern);



int AskForNumber(string text)
{
    Console.WriteLine(text);
    return Convert.ToInt32(Console.ReadLine());
}

int AskForNumberInRange(string text, int min, int max)
{
    int num;
    do
    {
        num = AskForNumber(text);

    }
    while (num > max || num < min);
    return num;
}



public class FountainOfObjectsGame
{
    public void Run(Cavern cavern)
    {
        Player player = new(cavern);
        DateTime startTime = DateTime.Now;
        
        while(cavern.Layout[player.Row, player.Column] != RoomType.Exit && player.IsDead == false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            cavern.Display(player);
            Console.WriteLine($"You are currently in the room at (Row={player.Row}, Column={player.Column}). \nYou have {player.Arrow} arrows left.");
            player.Sense(cavern);
            Console.ForegroundColor = ConsoleColor.White;
            ICommand? command = player.GetCommand();
            Console.Clear();
            command?.Execute(player, cavern);
            player.ClampPosition(cavern);
            player.IsDead = player.CheckForDeath(cavern);
            player.ClampPosition(cavern);


        }

        DateTime endTime = DateTime.Now;
        if (player.IsDead == true) Console.WriteLine("You lose!");
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life! \nYou Win!");
        }

        TimeSpan timeSpent = endTime - startTime;
        Console.WriteLine($"You spent {timeSpent.Minutes} minutes and {timeSpent.Seconds} seconds in the Caverns");
    }
}

public class Cavern
{
    public RoomType[,] Layout { get; }
    public int Size { get; }

    public Cavern(int size)
    {
        Size = size;
        switch (size)
        {
            case 4: 
                Layout = new RoomType[4,4];
                Layout[0, 2] = RoomType.FountainOff;
                Layout[0, 1] = RoomType.Pit;
                Layout[1, 2] = RoomType.Amarok;
                
                break;

            case 6:
                Layout = new RoomType[6,6];
                Layout[4, 2] = RoomType.FountainOff;
                Layout[2, 1] = RoomType.Pit;
                Layout[4, 4] = RoomType.Pit;
                Layout[1, 2] = RoomType.Maelstrom;
                Layout[1, 3] = RoomType.Amarok;
                Layout[5, 2] = RoomType.Amarok;
                break;

            case 8:
                Layout = new RoomType[8,8];
                Layout[7, 7] = RoomType.FountainOff;
                Layout[7, 6] = RoomType.Pit;
                Layout[3, 5] = RoomType.Pit;
                Layout[2, 6] = RoomType.Pit;
                Layout[6, 3] = RoomType.Pit;
                Layout[4, 4] = RoomType.Maelstrom;
                Layout[5, 5] = RoomType.Maelstrom;
                Layout[1, 2] = RoomType.Amarok;
                Layout[2, 4] = RoomType.Amarok;
                Layout[5, 1] = RoomType.Amarok;
                break;
        }

        Layout[0, 0] = RoomType.Entrance;
        
    }

    public int[]? SearchForRoom(RoomType room)
    {
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                if (Layout[row, column] == room) return new int[2]{ row, column };
            }

        }
        return null;
                        
    }

    public void Display(Player player)
    {
        for (int j = 0; j < Size; j++)
        {
            Console.Write("+---");
        }

        Console.Write("+");
        Console.WriteLine();

        for (int  i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (i == player.Row && j == player.Column) Console.Write("| O ");
                else Console.Write("|   ");
            }

            Console.Write("|");
            Console.WriteLine();

            for (int j = 0; j < Size; j++)
            {
                Console.Write("+---");
            }

            Console.Write("+");
            Console.WriteLine();
        }
    }

}


public class Player
{
    public int Row { get; set; } = 0;
    public int Column { get; set; } = 0;
    public bool IsDead { get; set; } = false;

    public int Arrow { get; set; } = 5;

    public Player(Cavern cavern)
    {
        int[]? roomIndex = cavern.SearchForRoom(RoomType.Entrance);
        if (roomIndex != null)
        {
            Row = roomIndex[0];
            Column = roomIndex[1];
        }

    }

    public void Sense(Cavern cavern)
    {

        if (cavern.Layout[Row, Column] == RoomType.Entrance) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("You see light coming from the cavern entrance"); }
        if (cavern.Layout[Row, Column] == RoomType.FountainOff) { Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!"); }
        if (cavern.Layout[Row, Column] == RoomType.FountainOn) { Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("You hear rushing waters from the Fountain of Objects. It has been reactivated!"); }
        if (CheckAdjacentRooms(cavern, RoomType.Pit)) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("You feel a draft. There is a pit in a nearby room."); }
        if (CheckAdjacentRooms(cavern, RoomType.Maelstrom)) { Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("You hear the growling and groaning of a maelstrom nearby."); }
        if (CheckAdjacentRooms(cavern, RoomType.Amarok)) { Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine("You smell the stench of something rotting. There is an amarok close by."); }
    }

    private bool CheckAdjacentRooms(Cavern cavern, RoomType room)
    {
        if (Row + 1 != cavern.Size) { if (cavern.Layout[Row + 1, Column] == room) return true; }
        if (Row - 1 != -1) { if (cavern.Layout[Row - 1, Column] == room) return true; }
        if (Column + 1 != cavern.Size) { if (cavern.Layout[Row, Column + 1] == room) return true; }
        if (Column - 1 != -1) { if (cavern.Layout[Row, Column - 1] == room) return true; }
        if (Row + 1 != cavern.Size && Column + 1 != cavern.Size ) { if (cavern.Layout[Row + 1, Column + 1] == room) return true; }
        if (Row - 1 != -1 && Column - 1 != -1) { if (cavern.Layout[Row - 1, Column - 1] == room) return true; }
        if (Row - 1 != -1 && Column + 1 != cavern.Size) { if (cavern.Layout[Row - 1, Column + 1] == room) return true; }
        if (Row + 1 != cavern.Size && Column - 1 != -1) { if (cavern.Layout[Row + 1, Column - 1] == room) return true; }
        return false;
    }

    //Checks for death but also deals with maelstrom interaction
    public bool CheckForDeath(Cavern cavern)
    {
        
        Random rand = new Random();

        if (cavern.Layout[Row, Column] == RoomType.Maelstrom)
        {
            bool isFree = false;
            cavern.Layout[Row, Column] = RoomType.Empty;
            while (!isFree)
            {
                int row = rand.Next(cavern.Size);
                int column = rand.Next(cavern.Size);
                if (cavern.Layout[row, column] == RoomType.Empty) { cavern.Layout[row, column] = RoomType.Maelstrom; isFree = true; }
            }
            
            Row = rand.Next(cavern.Size); Column = rand.Next(cavern.Size);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You were flung by a maelstrom!");
        }

        if (cavern.Layout[Row, Column] == RoomType.Pit) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You fell into a pit!");
            return true;
        }

    

        if (cavern.Layout[Row, Column] == RoomType.Amarok)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You were mauled by an amarok!");
            return true;
        }
        return false;
    }



    public ICommand? GetCommand()
    {
        Console.Write("What would you like to do? ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string commandWanted = Console.ReadLine();
        return commandWanted switch
        {
            "move north" => new MoveNorth(),
            "move south" => new MoveSouth(),
            "move east" => new MoveEast(),
            "move west" => new MoveWest(),
            "enable fountain" => new EnableFountain(),
            "shoot north" => new ShootNorth(),
            "shoot south" => new ShootSouth(),
            "shoot east" => new ShootEast(),
            "shoot west" => new ShootWest(),
            "help" => new Help(),
            _ => null,
        };
    }

    public void ClampPosition(Cavern cavern)
    {
        Row = Math.Clamp(Row, 0, cavern.Size - 1);
        Column = Math.Clamp(Column, 0, cavern.Size - 1);
    }
}

public interface ICommand
{
    void Execute(Player player, Cavern cavern);
}

public class MoveNorth : ICommand
{
    public void Execute(Player player, Cavern cavern)
    {
        player.Row -= 1;
    }
}

public class MoveSouth : ICommand
{
    public void Execute(Player player, Cavern cavern)
    {
        player.Row += 1;
    }
}

public class MoveEast : ICommand
{
    public void Execute(Player player, Cavern cavern)
    {
        player.Column += 1;
    }
}

public class MoveWest : ICommand
{
    public void Execute(Player player, Cavern cavern)
    {
        player.Column -= 1;
    }
}

public class EnableFountain : ICommand
{
    public void Execute(Player player, Cavern cavern)
    {
        if (cavern.Layout[player.Row, player.Column] == RoomType.FountainOff)
        {
            cavern.Layout[player.Row, player.Column] = RoomType.FountainOn;

            int[]? roomIndex = cavern.SearchForRoom(RoomType.Entrance);
            if (roomIndex != null) cavern.Layout[roomIndex[0], roomIndex[1]] = RoomType.Exit;
        }


    }
}

public class ShootNorth : ICommand
{
    public void Execute( Player player, Cavern cavern)
    {
        player.Arrow--;
        if (cavern.Layout[Math.Clamp(player.Row - 1, 0, cavern.Size-1), player.Column] == RoomType.Maelstrom || cavern.Layout[Math.Clamp(player.Row - 1, 0, cavern.Size - 1), player.Column] == RoomType.Amarok)
        {
            cavern.Layout[Math.Clamp(player.Row - 1, 0, cavern.Size - 1), player.Column] = RoomType.Empty;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("You shot and killed a monster!");
        }
        else
        {
            Console.ForegroundColor= ConsoleColor.DarkMagenta;
            Console.WriteLine("You hit nothing.");
        }
    }
}

public class ShootSouth : ICommand
{
    public void Execute(Player player, Cavern cavern)
    {
        player.Arrow--;
        if (cavern.Layout[Math.Clamp(player.Row + 1, 0, cavern.Size - 1), player.Column] == RoomType.Maelstrom || cavern.Layout[Math.Clamp(player.Row + 1, 0, cavern.Size - 1), player.Column] == RoomType.Amarok)
        {
            cavern.Layout[Math.Clamp(player.Row + 1, 0, cavern.Size - 1), player.Column] = RoomType.Empty;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("You shot and killed a monster!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("You hit nothing.");
        }
    }
}

public class ShootEast : ICommand
{
    public void Execute(Player player, Cavern cavern)
    {
        player.Arrow--;
        if (cavern.Layout[player.Row, Math.Clamp(player.Column + 1, 0, cavern.Size - 1)] == RoomType.Maelstrom || cavern.Layout[player.Row, Math.Clamp(player.Column + 1, 0, cavern.Size - 1)] == RoomType.Amarok)
        {
            cavern.Layout[player.Row, Math.Clamp(player.Column + 1, 0, cavern.Size - 1)] = RoomType.Empty;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("You shot and killed a monster!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("You hit nothing.");
        }
    }
}

public class ShootWest : ICommand
{
    public void Execute(Player player, Cavern cavern)
    {
        player.Arrow--;
        if (cavern.Layout[player.Row, Math.Clamp(player.Column - 1, 0, cavern.Size - 1)] == RoomType.Maelstrom || cavern.Layout[Math.Clamp(player.Row - 1, 0, cavern.Size - 1), Math.Clamp(player.Column - 1, 0, cavern.Size - 1)] == RoomType.Amarok)
        {
            cavern.Layout[player.Row, Math.Clamp(player.Column - 1, 0, cavern.Size - 1)] = RoomType.Empty;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("You shot and killed a monster!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("You hit nothing.");
        }
    }
}

public class Help : ICommand
{
    public void Execute(Player player, Cavern cavern)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\"move north\" - move up");
        Console.WriteLine("\"move east\" - move right");
        Console.WriteLine("\"move south\" - move down");
        Console.WriteLine("\"move west\" - move left");
        Console.WriteLine("\"shoot north\" - shoot an arrow into the room above");
        Console.WriteLine("\"shoot east\" - shoot an arrow into the room to the right");
        Console.WriteLine("\"shoot south\" - shoot an arrow into the room below");
        Console.WriteLine("\"shoot west\" - shoot an arrow into the room to the left");
        Console.WriteLine("\"enable fountain\" - enables the fountain and allows you to leave when you go back to the entrance");

    }
}
public enum RoomType { Empty, Entrance, FountainOn, FountainOff, Pit, Maelstrom, Amarok, Exit }