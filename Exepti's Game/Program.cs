
Random random = new Random();
int oatmeal = random.Next(0, 10);
int pnum = 1;

List<int> chosen = new List<int>();

while (true)
{
    Console.Write($"Player {pnum}, choose a number: ");
    int num = Convert.ToInt16(Console.ReadLine());
    try
    {
        if (num == oatmeal) throw new Exception();

        if (chosen.Contains(num)) Console.WriteLine("That has already been chosen");
        else
        {
            chosen.Add(num);
            pnum = (pnum == 1) ? 2 : 1;
        }
    }

    catch
    {
        Console.WriteLine($"Player {pnum} has eaten the oatmeal cookie and loses!"); break;
    }
}
