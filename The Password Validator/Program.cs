
while (true)
{
    Console.Write("Enter a password: ");
    string password = Console.ReadLine();
    PasswordValidator passwordValid = new() { Password = password };
    if (passwordValid.IsValid()) Console.WriteLine("Valid");
    else Console.WriteLine("Invalid");
}

class PasswordValidator
{
    public string Password { get; init; }
    public bool LengthCheck() => (Password.Length >= 6 && Password.Length <= 13);
    public bool ContainsUpper()
    {
        foreach (char c in Password) if (char.IsUpper(c)) return true;
        return false;

    }
    
   
    public bool ContainsLower()
    {
        foreach (char c in Password) if (char.IsLower(c)) return true;
        return false;

    }

    public bool ContainsDigit()
    {
        foreach (char c in Password) if (char.IsDigit(c)) return true;
        return false;

    }

    public bool ContainsTOrAmpersand()
    {
        foreach (char c in Password) if (c == Convert.ToChar("T") || c == Convert.ToChar("&")) return true;
        return false;

    }

    public bool IsValid() => ContainsDigit() && ContainsUpper() && ContainsLower() && !ContainsTOrAmpersand() && LengthCheck();

}