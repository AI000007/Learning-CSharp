
Robot robot = new();
Console.WriteLine("Enter commands and type \"stop\" when you have finished:");

while (true)
{
    string? command = Console.ReadLine();
    command = command.ToLower();
    if (command == "stop") break;
    IRobotCommand? command2 = command switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "east" => new EastCommand(),
        "south" => new SouthCommand(),
        "west" => new WestCommand(),
        _ => null
    };
    if (command2 != null) robot.Commands.Add(command2);
    else Console.WriteLine("That is not a command. Try again: ");
}

robot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; } = false;
    public List<IRobotCommand?> Commands { get; } = new List<IRobotCommand?>();
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}


public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) robot.Y += 1;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) robot.Y += -1;
    }
}

public class EastCommand : IRobotCommand
{
    public  void Run(Robot robot)
    {
        if (robot.IsPowered == true) robot.X += 1;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true) robot.X += -1;
    }
}
