




public class Sieve
{
    public Func<int, bool> Func {  get; set; }
    public Sieve(Func<int, bool> func)
    {
        Func = func;
    }

    public bool IsGood(int number) => Func(number);



}