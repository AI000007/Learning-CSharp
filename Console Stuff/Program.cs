

Console.Title = "Defense of Consolas";
Console.Write("Target Row? ");
int row = Convert.ToInt32(Console.ReadLine()); 

Console.Write("Target Column? ");
int col = Convert.ToInt32(Console.ReadLine());

Console.ForegroundColor = ConsoleColor.Red;

Console.WriteLine("Deploy to: ");
Console.WriteLine($"({row},{col + 1})" );
Console.WriteLine($"({row},{col - 1})");
Console.WriteLine($"({row + 1},{col})");
Console.WriteLine($"({row - 1},{col})");

Console.Beep();

Console.ForegroundColor = ConsoleColor.White;