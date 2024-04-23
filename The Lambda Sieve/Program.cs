using System.Drawing;

Console.WriteLine("1 - Even \n2 - Positive \n3 - Multiple of 10");
int choice = Convert.ToInt16(Console.ReadLine());
Sieve sieve = choice switch
{
    1 => new Sieve(e => e % 2 == 0),
    2 => new Sieve(p => p > 0),
    3 => new Sieve(t => t % 10 == 0)
};

while (true)
{
    Console.WriteLine("Enter number");
    int num = Convert.ToInt16(Console.ReadLine());
    Console.WriteLine(sieve.IsGood(num));
}

