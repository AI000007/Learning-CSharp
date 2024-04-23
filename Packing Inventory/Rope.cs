namespace PackingInventory
{
    class Rope : InventoryItem
    {
        public Rope() : base(1, 1.5f) { }
        public override string ToString() => "Rope";

    }
}