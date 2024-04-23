while (true)
{
    Console.WriteLine("Enter a number");
    string? number = Console.ReadLine();
    if (int.TryParse(number, out int value)) { Console.WriteLine(value); break; }
    else if (double.TryParse(number, out double value2)) { Console.WriteLine(value2); break; }
    else if (bool.TryParse(number, out bool value3)) { Console.WriteLine(value3); break; }
}
