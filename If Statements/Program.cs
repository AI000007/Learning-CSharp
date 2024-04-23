// See https://aka.ms/new-console-template for more information

Console.WriteLine("Enter the x value: ");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter the y value: ");
int y = Convert.ToInt32(Console.ReadLine());

if (x == 0 && y == 0)
    Console.WriteLine("They are here");
else if (x == 0 && y > 0)
    Console.WriteLine("They are to the north");
else if (x == 0 && y < 0)
    Console.WriteLine("They are to the south");
else if (x > 0 && y == 0)
    Console.WriteLine("They are to the east");
else if (x < 0 && y == 0)
    Console.WriteLine("They are to the west");
else if (x > 0 && y > 0)
    Console.WriteLine("They are to the northeast");
else if (x > 0 && y < 0)
    Console.WriteLine("They are to the southeast");
else if (x < 0 && y > 0)
    Console.WriteLine("They are to the northwest");
else if (x < 0 && y < 0)
    Console.WriteLine("They are to the southwest");
