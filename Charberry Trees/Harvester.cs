
public class Harvester
{
    private CharberryTree _tree;

    private void OnRipened() => _tree.Ripe = false;
    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        tree.Ripened += OnRipened;
    }
}