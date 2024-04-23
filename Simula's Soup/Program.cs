using static System.Net.Mime.MediaTypeNames;

(Type type, MainIngredient main, Seasoning seasoning) food;

int type = AskForNumberInRange("Enter the number of which type you would like: \n1 - Soup \n2 - Stew \n3 - Gumbo", 1, 3);
food.type = type switch
{
    1 => Type.Soup,
    2 => Type.Stew,
    3 => Type.Gumbo,
};

int main = AskForNumberInRange("Enter the number of which main ingredient you would like: \n1 - Mushrooms \n2 - Chicken \n3 - Carrots \n4 - Potatoes", 1, 4);
food.main = main switch
{
    1 => MainIngredient.Mushroom,
    2 => MainIngredient.Chicken,
    3 => MainIngredient.Carrot,
    4 => MainIngredient.Potato,
};

int seasoning = AskForNumberInRange("Enter the number of which seasoning you would like: \n1 - Spicy \n2 - Salty \n3 - Sweet", 1, 3);
food.seasoning = seasoning switch
{
    1 => Seasoning.Spicy,
    2 => Seasoning.Salty,
    3 => Seasoning.Sweet,
};

Console.WriteLine($"{food.seasoning} {food.main} {food.type}");


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



enum Type { Soup, Stew, Gumbo };
enum MainIngredient { Mushroom, Chicken, Carrot, Potato };
enum Seasoning { Spicy, Salty, Sweet }