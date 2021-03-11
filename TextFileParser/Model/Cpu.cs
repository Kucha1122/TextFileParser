namespace TextFileParser.Model
{
    public class Cpu
    {
        public string Series { get; set; }
        public string Cores { get; set; }
        public string Clock { get; set; }

        public Cpu(string series, string cores, string clock)
        {
            Series = series;
            Cores = cores;
            Clock = clock;
        }
    }
}