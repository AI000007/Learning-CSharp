

using static System.Net.Mime.MediaTypeNames;

int guess = -1;
int number = -1;
while (number < 0 || number > 100)
{
    number = AskForNumberInRange("User 1, enter a number between 0 and 100: ", 0, 100);

}

Console.Clear();

while (guess != number)
{
    Console.Write("User 2, enter a number between 0 and 100: ");
    guess = AskForNumber("");
    if (guess > number) Console.WriteLine("That is too big ");
    else if (guess < number) Console.WriteLine("That is too small ");
}

Console.WriteLine("Well done! You guessed the number! ");

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