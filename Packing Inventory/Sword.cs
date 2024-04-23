namespace PackingInventory
{
    class Sword : InventoryItem
    {
        public Sword() : base(5, 3) { }
        public override string ToString() => "Sword";
    }
}