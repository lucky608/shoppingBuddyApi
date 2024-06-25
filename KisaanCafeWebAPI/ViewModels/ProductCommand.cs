namespace KisaanCafeWebAPI.ViewModels
{
    public class ProductCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Prize { get; set; }
        public decimal Weight { get; set; }
        public byte[] ImageData { get; set; }
    }
}
