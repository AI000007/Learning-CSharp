
int[] ints = new int[9] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

foreach (int i in Stuff(ints)) Console.Write($"{i} ");
Console.WriteLine();
foreach (int i in Stuff2(ints)) Console.Write($"{i} ");
Console.WriteLine();
foreach (int i in Stuff3(ints)) Console.Write($"{i} ");

List<int> Stuff(int[] array)
{
    Array.Sort(array);
    List<int> list = new List<int>();
    list.AddRange(array);
    for(int i = 0; i < list.Count; i++) if (list[i] % 2 != 0) list.Remove(list[i]);
    List<int> result = new List<int>();
    foreach (int i in list) result.Add(i*2);
    return result;
}

IEnumerable<int> Stuff2(int[] array)
{
    return from a in array
               where a % 2 == 0
               orderby a ascending
               select a * 2;
}

IEnumerable<int> Stuff3(int[] array)
{
    return array
        .Where(a => a % 2 == 0)
        .OrderBy(a => a)
        .Select(a => a * 2);

}
