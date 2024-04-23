namespace PackingInventory
{
    class Pack
    {
        public int TotalItems { get; }
        public float MaxWeight { get; }
        public float MaxVolume { get; }

        public int CurrentItems { get; private set; } = 0;
        public float CurrentWeight { get; private set; } = 0;
        public float CurrentVolume { get; private set; } = 0;


        public InventoryItem?[] Items { get; set; }

        public Pack(int totalItems, float maxWeight, float maxVolume)
        {
            TotalItems = totalItems;
            MaxWeight = maxWeight;
            MaxVolume = maxVolume;
            Items = new InventoryItem[totalItems];

        }

        public bool Add(InventoryItem item)
        {
            if (CurrentItems + 1 <= TotalItems && CurrentWeight + item.Weight <= MaxWeight && CurrentVolume + item.Volume <= MaxVolume)
            {
                Items[CurrentItems] = item;
                CurrentItems++;
                CurrentVolume += item.Volume;
                CurrentWeight += item.Weight;

                return true;
            }
            else return false;

        }

        public override string ToString()
        {
            string items = string.Empty;
            foreach (var item in Items)
            {
                if (item != null) items += $"{item.ToString()} ";
            }
            return items;
        }

    }
}