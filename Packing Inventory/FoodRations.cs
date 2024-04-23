namespace PackingInventory
{
    class FoodRations : InventoryItem
    {
        public FoodRations() : base(1, 0.5f) { }
        public override string ToString() => "Food Rations";
    }
}