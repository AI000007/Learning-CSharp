
Console.WriteLine("1 - Even \n2 - Positive \n3 - Multiple of 10");
int choice = Convert.ToInt16(Console.ReadLine());
Sieve sieve = choice switch
{
    1 => new Sieve(IsEven),
    2 => new Sieve(IsPositive),
    3 => new Sieve(Is10)
};

while (true)
{
    Console.WriteLine("Enter number");
    int num = Convert.ToInt16(Console.ReadLine());
    Console.WriteLine(sieve.IsGood(num));
}

bool IsEven(int number) => (number % 2 == 0);

bool IsPositive(int number) => (number > 0);

bool Is10(int number) => (number % 10 == 0);
