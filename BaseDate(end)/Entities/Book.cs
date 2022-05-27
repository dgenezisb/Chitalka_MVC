namespace BaseDate_end_.Entities;

using BaseDate_end_.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public bool Visibility { get; set; }
        [Required]
        public string ImagePath { get; set; }

        [Required]
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public virtual Author? Author { get; set; }
        [Required]
        public int CenturyId { get; set; }
        [ForeignKey(nameof(CenturyId))]
        public virtual Century? Century { get; set; }
        public List<Genre>? Genres { get; set; }
    }
