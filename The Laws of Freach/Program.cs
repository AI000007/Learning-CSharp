int[] array = new int[] {25, 49, 154, -89, -46, 53, 562, 132, -72 };
int min = int.MaxValue;
foreach (int score in array)
{
    if (score < min) min = score;
}
Console.WriteLine(min);