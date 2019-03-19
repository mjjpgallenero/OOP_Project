using System.Security.Policy;

namespace OOP_Project
{
    public class Jewelry
    {
        public Jewelry()
        {
            
        }
        public int JewelryId { get; set; }
        public string JewelryType { get; set; }
        public string JewelryQuality { get; set; }
        public double Weight { get; set; }
        public double CrystalWeight { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }

    }

    public enum JewelryTypes
    {
        Ring, Necklace, Bracelet, Earring
    }

}