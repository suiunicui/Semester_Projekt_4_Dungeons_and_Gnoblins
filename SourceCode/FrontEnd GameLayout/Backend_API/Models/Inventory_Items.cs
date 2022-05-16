namespace Backend_API.Models
{
    public class Inventory_Items
    {

        public uint ItemID { get; set; }

        public int SaveID { get; set; }

        public Save save { get; set; }
    }
}
