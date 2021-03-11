namespace TextFileParser.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public Screen Screen { get; set; }
        public Cpu Cpu { get; set; }
        public string Ram { get; set; }
        public Disk Disk { get; set; }
        public GraphicCard GraphicCard { get; set; }
        public string OperatingSystem { get; set; }
        public string DriverType { get; set; }
        
    }
}