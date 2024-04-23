namespace PackingInventory
{
    class Arrow : InventoryItem
    {
        public Arrow() : base(0.1f, 0.05f) { }
        public override string ToString() => "Arrow";
    }
}