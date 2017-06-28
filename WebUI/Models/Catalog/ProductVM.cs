namespace WebUI.Models.Catalog
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string[] Sizes { get; set; }
        public string[] Colors { get; set; }
        public string[] Images { get; set; }
    }
}