
Console.Write("Please enter your name: ");
string? name = Console.ReadLine();
long score = 0;

if (File.Exists($"{name}.txt"))
{
    score = Convert.ToInt64(File.ReadAllText($"{name}.txt"));
}


while (Console.ReadKey(true).Key != ConsoleKey.Enter)
{
    score++;
    Console.WriteLine($"Score : {score}");

}

File.WriteAllText($"{name}.txt", score.ToString());