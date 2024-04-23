public class PotionMaker
{
    public Potion Potion { get; set; } = Potion.Water;

    public Potion AddIngredient(Ingredient? ingredient)
    {
        Potion = (Potion, ingredient) switch
        {
            (Potion.Water, Ingredient.Stardust)           => Potion.Elixir,
            (Potion.Elixir, Ingredient.SnakeVenom)        => Potion.Poison,
            (Potion.Elixir, Ingredient.DragonBreath)      => Potion.Flying,
            (Potion.Elixir, Ingredient.ShadowGlass)       => Potion.Invisibility,
            (Potion.Elixir, Ingredient.EyeshineGem)       => Potion.NightSight,
            (Potion.NightSight, Ingredient.ShadowGlass)   => Potion.CloudyBrew,
            (Potion.Invisibility, Ingredient.EyeshineGem) => Potion.CloudyBrew,
            (Potion.CloudyBrew, Ingredient.Stardust)      => Potion.Wraith,
            _                                             => Potion.Ruined,
        };
        return Potion;
    }

    public Ingredient? GetIngredient()
    {

        int choice = GetNumber.GetNumber.AskForNumberInRange($"Your current potion type is: {Potion} \nWhat ingredient would you like to add? \n1 - Stardust " +
                                                             $"\n2 - Snake Venom \n3 - Dragon Breath \n4 - Shadow Glass \n5 - Eyeshine Gem \n6 - None", 1, 6);
        return choice switch
        {
            1 => Ingredient.Stardust,
            2 => Ingredient.SnakeVenom,
            3 => Ingredient.DragonBreath,
            4 => Ingredient.ShadowGlass,
            5 => Ingredient.EyeshineGem,
            _ => null
        };
    }
}

public enum Potion { Water, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined }
public enum Ingredient { Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem }