int manticore = 10;
int city = 15;
int round = 1;
int damage;
string hit;

Console.Title = "Hunting the Mancticore";

int manticoreDist = AskForNumberInRange("Player 1, how far away from the city do you want to station the Manticore? ", 1, 100);
Console.Clear();

Console.WriteLine("Player 2, it is your turn");
while (manticore > 0 && city > 0)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"STATUS: Round: {round}  City: {city}/15  Manticore: {manticore}/10");
    damage = CannonDamage(round);

    Console.ForegroundColor= ConsoleColor.White;
    Console.Write($"The cannon is expected to deal ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(damage);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" damage this round.");
    Console.WriteLine();

    hit = HitManticore(manticoreDist, AskForNumber("Enter the desired cannon range: "));


    if (hit == "DIRECTLY HIT")
    {
        manticore -= damage;
        Console.ForegroundColor = ConsoleColor.Red;
    }
    else Console.ForegroundColor = ConsoleColor.Yellow;
    if (manticore > 0) city--;
    round++;

    Console.WriteLine($"That round {hit} the target");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("--------------------------------------------------------------");

}

Console.ForegroundColor = ConsoleColor.Blue;
if (manticore <= 0) Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved! ");
else Console.WriteLine("The city has been destroyed! Flee while you still can!");






int AskForNumber(string text)
{
    Console.Write(text);
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

int CannonDamage(int round)
{
    int damage = 0;

    if (round % 5 == 0 && round % 3 == 0) damage = 10;
    else if (round % 5 == 0 || round % 3 == 0) damage = 3;
    else damage = 1;

    return damage;
}

string HitManticore(int dist, int targetDist)
{
    if (targetDist == dist) return "DIRECTLY HIT";
    else if (targetDist > dist) return "OVERSHOT";
    else return "FELL SHORT of";
}