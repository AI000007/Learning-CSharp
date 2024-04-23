using System.Dynamic;

int i = 0;
while (true)
{
    i++;
    Console.WriteLine($"You are producing robot #{i}");
    dynamic robot = new ExpandoObject();
    robot.ID = i;
    Console.Write("Do you want to name the robot? ");
    if (Console.ReadLine() == "yes")
    {
        Console.Write("What is its name? ");
        robot.Name = Console.ReadLine();
    }

    Console.Write("Does the robot have a specific size? ");
    if (Console.ReadLine() == "yes")
    {
        Console.Write("What is its height? ");
        robot.Height = Console.ReadLine();

        Console.Write("What is its width? ");
        robot.Width = Console.ReadLine();
    }

    Console.Write("Does the robot need to be a specific colour? ");
    if (Console.ReadLine() == "yes")
    {
        Console.Write("What colour? ");
        robot.Colour = Console.ReadLine();
    }

    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot) Console.WriteLine($"{property.Key}: {property.Value}");
}