

using System.Xml.Serialization;


PotionMaker potion = new PotionMaker();
while (true)
{
    Ingredient? ingredient = potion.GetIngredient();
    if (ingredient != null)
    {
        if (potion.AddIngredient(ingredient) == Potion.Ruined)
        {
            Console.WriteLine("\nYour potion was ruined. Starting again with water");
            potion.Potion = Potion.Water;
        }
    }
    else break;


}



