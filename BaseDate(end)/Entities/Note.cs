namespace BaseDate_end_.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Note
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    [Required]
    public string Username { get; set; }
    [ForeignKey(nameof(Username))]
    public User? User { get; set; }
}
