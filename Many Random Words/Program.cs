
while (true)
{
    Console.Write("Enter a word: ");
    string? word = Console.ReadLine();

    TimeAndOut(word);
}

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run(() => RandomlyRecreate(word));
}


async void TimeAndOut(string word)
{
    DateTime start = DateTime.Now;
    Console.WriteLine($"\nIt took {await RandomlyRecreateAsync(word)} times to recreate '{word}' randomly");
    DateTime end = DateTime.Now;
    TimeSpan time = end - start;
    Console.WriteLine($"This took {time.Minutes} minutes, {time.Seconds} seconds and {time.Milliseconds} milliseconds");
    Console.Write("\nEnter a word: ");
}

int RandomlyRecreate(string word)
{
    Random random = new Random();
    int count = 0;
    string newWord = "";
    while (newWord != word)
    {
        count++;
        newWord = "";
        for (int i = 0; i < word.Length; i++)
        {
            newWord += (char)('a' + random.Next(26));

        }
    }
    return count;

}