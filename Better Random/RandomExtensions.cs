
public static class RandomExtensions
{
    public static double NextDouble(this Random rand, double cap)
    {
        return rand.NextDouble()*cap;
    }

    public static string NextString(this Random rand, params string[] strings)
    {
        return strings[rand.Next(strings.Length)];
    }

    public static bool CoinFlip(this Random rand, double prob = 0.5)
    {
        if (rand.NextDouble() <= prob) return true;
        return false;
    }
}
