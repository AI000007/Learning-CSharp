using System.Dynamic;

Console.WriteLine(Add(1, 2));
Console.WriteLine(Add(123.221, 1.02));
Console.WriteLine(Add("hi", "hello"));
Console.WriteLine(Add(DateTime.Now, TimeSpan.FromDays(1) ));

dynamic Add(dynamic a, dynamic b) => a + b;
