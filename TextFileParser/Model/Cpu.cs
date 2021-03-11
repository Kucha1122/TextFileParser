namespace TextFileParser.Model
{
    public class Cpu
    {
        public string Series { get; set; }
        public int Cores { get; set; }
        public int Clock { get; set; }

        public Cpu(string series, int cores, int clock)
        {
            Series = series;
            Cores = cores;
            Clock = clock;
        }
    }
}