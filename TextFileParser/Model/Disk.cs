namespace TextFileParser.Model
{
    public class Disk
    {
        public string Capacity { get; set; }
        public string Type { get; set; }

        public Disk(string capacity, string type)
        {
            Capacity = capacity;
            Type = type;
        }
    }
}