
Sword basicSword = new Sword(Material.Iron, Gemstone.None, 100, 30);
Sword otherSword1 = basicSword with { gemstone = Gemstone.Bitstone };
Sword otherSword2 = basicSword with { material = Material.Binarium };

Console.WriteLine(basicSword);
Console.WriteLine(otherSword2);
Console.WriteLine(otherSword1);

public record Sword(Material material, Gemstone gemstone, float length, float crossguardWidth);

public enum Material { Wood, Bronze, Iron, Steel, Binarium }
public enum Gemstone { Emerald, Amber, Sapphire, Diamond, Bitstone, None}