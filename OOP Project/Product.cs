namespace LabActivity4
{
    public class Product
    {
        public string Name;
        public string Description;
        public float Price;
        public float SRP;
        public int Items;

        public string GetDescription()
        {
            return Description;
        }

        public void DeductItems(int items)
        {
            Items -= items;
        }
    }
}