

using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Serialization;

int type = AskForNumberInRange("What type of arrow would you like? \n1 - Elite \n2 - Beginner \n3 - Marksman \n4 - Custom", 1, 4);
Arrow arrow = type switch
{
    1 => Arrow.CreateEliteArrow(),
    2 => Arrow.CreateBeginnerArrow(),
    3 => Arrow.CreateMarksmanArrow(),
    4 => CreateCustomArrow(),
};

Arrow CreateCustomArrow()
{
    int arrowHead = AskForNumberInRange("What type of arrow head would you like? \n1 - Steel (10) \n2 - Obsidian (5) \n3 - Wood (3)", 1, 3);
    int arrowFletching = AskForNumberInRange("What type of arrow fletching would you like? \n1 - Plastic (10) \n2 - Turkey Feathers (5) \n3 - Goose Feathers (3)", 1, 3);
    int shaftLength = AskForNumberInRange("How long would you like the shaft in cm? (0.05 per cm)", 60, 100);

    ArrowHead head = arrowHead switch
    {
        2 => ArrowHead.Obsidian,
        1 => ArrowHead.Steel,
        3 => ArrowHead.Wood,
    };

    ArrowFletching fletching = arrowFletching switch
    {
        1 => ArrowFletching.Plastic,
        3 => ArrowFletching.GooseFeathers,
        2 => ArrowFletching.TurkeyFeathers,
    };

    return new Arrow { Head = head, Fletching = fletching, Shaft = shaftLength };
}


Console.WriteLine($"The arrow (Head: {arrow.Head},  Fletching: {arrow.Fletching},  Shaft Length: {arrow.Shaft}cm) will cost {arrow.GetCost()} gold");


int AskForNumber(string text)
{
    Console.WriteLine(text);
    return Convert.ToInt32(Console.ReadLine());
}

int AskForNumberInRange(string text, int min, int max)
{
    int num;
    do
    {
        num = AskForNumber(text);

    }
    while (num > max || num < min);
    return num;
}

class Arrow
{
    public ArrowHead Head { get; init; }
    public ArrowFletching Fletching { get; init; }
    public float Shaft { get; init; }


    public static Arrow CreateEliteArrow()
    {
        return new Arrow { Head = ArrowHead.Steel, Fletching = ArrowFletching.Plastic, Shaft = 95 };
    }

    public static Arrow CreateBeginnerArrow()
    {
        return new Arrow { Head = ArrowHead.Wood, Fletching = ArrowFletching.GooseFeathers, Shaft = 75 };
    }

    public static Arrow CreateMarksmanArrow()
    {
        return new Arrow { Head = ArrowHead.Steel, Fletching = ArrowFletching.GooseFeathers, Shaft = 65 };
    }
    public float GetCost()
    {
        float headP = Head switch
        {
            ArrowHead.Obsidian => 5,
            ArrowHead.Steel => 10,
            ArrowHead.Wood => 3,
        };

        float fletchingP = Fletching switch
        {
            ArrowFletching.Plastic => 10,
            ArrowFletching.GooseFeathers => 3,
            ArrowFletching.TurkeyFeathers => 5,
        };

        float shaftP = Shaft * (float)0.05;

        return headP + shaftP + fletchingP;
    }

}

enum ArrowHead { Steel, Obsidian, Wood }
enum ArrowFletching { Plastic, TurkeyFeathers, GooseFeathers }
