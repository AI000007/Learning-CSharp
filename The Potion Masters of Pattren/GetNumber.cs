
namespace GetNumber;

public static class GetNumber
{
    public static int AskForNumber(string text)
    {
        while (true)
        {


            try
            {
                Console.WriteLine(text);
                return Convert.ToInt32(Console.ReadLine());

            }

            catch
            {
                Console.WriteLine("Enter a number");
            }
        }
    }

    public static int AskForNumberInRange(string text, int min, int max)
    {
        int num;
        do
        {
            num = AskForNumber(text);

        }
        while (num > max || num < min);
        return num;
    }
}

