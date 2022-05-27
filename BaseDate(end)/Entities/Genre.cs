namespace BaseDate_end_.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Genre
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book>? Books { get; set; }
}
