
public class Notifier
{
    private void OnRipenend() => Console.WriteLine("A charberry fruit has ripened!");
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnRipenend;
    }
}
