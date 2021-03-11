namespace TextFileParser.Model
{
    public class Brand
    {
        public string Name { get; set; }
        public int Availablity { get; set; }

        public Brand(string name, int availability)
        {
            Name = name;
            Availablity = availability;
        }
    }
}