namespace Chitalka_v3.Models
{
    public class Image2
    {
        public int Id { get; set; }
        public string img { get; set; }

        public virtual Author Author { get; set; }
    }
}
