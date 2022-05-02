namespace Chitalka_v3.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biogr { get; set; }
        
        public Country Country { get; set; }
        public string Books { get; set; }
    }
}
