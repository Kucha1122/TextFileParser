namespace TextFileParser.Model
{
    public class Screen
    {
        public string Size { get; set; }
        public string Resolution { get; set; }
        public string Type { get; set; }
        public string Touch { get; set; }

        public Screen(string size, string resolution,
            string type, string touch)
        {
            Size = size;
            Resolution = resolution;
            Type = type;
            Touch = touch;
        }
    }
}