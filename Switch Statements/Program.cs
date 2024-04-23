Console.WriteLine("The following items are available: \n 1 - Rope \n 2 - Torches \n 3 - Climbing Equipment \n 4 - Clean Water \n 5 - Machete \n 6 - Canoe \n 7 - Food Supplies");
Console.Write("What number do you want to see the price of? ");
int item = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter your name: ");
string name = Console.ReadLine();
string response;
if (name == "Alessandro")
{
    response = item switch
    {
        1 => "Rope costs 5 gold.",
        2 => "Torches cost 7.5 gold.",
        3 => "Climbing Equipment costs 12.5 gold.",
        4 => "Clean water costs 0.5 gold.",
        5 => "Machete costs 10 gold.",
        6 => "Canoe costs 100 gold.",
        7 => "Food Supples cost 5 gold.",
        _ => "Sorry, I don't know that one."
    };
}

else
{
    response = item switch
    {
        1 => "Rope costs 10 gold.",
        2 => "Torches cost 15 gold.",
        3 => "Climbing Equipment costs 25 gold.",
        4 => "Clean water costs 1 gold.",
        5 => "Machete costs 20 gold.",
        6 => "Canoe costs 200 gold.",
        7 => "Food Supples cost 10 gold.",
        _ => "Sorry, I don't know that one."
    };
}

Console.WriteLine(response);