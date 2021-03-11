namespace TextFileParser.Model
{
    public class GraphicCard
    {
        public string Type { get; set; }
        public string Vram { get; set; }

        public GraphicCard(string type, string vram)
        {
            Type = type;
            Vram = vram;
        }
    }
}