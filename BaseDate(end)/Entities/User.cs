namespace BaseDate_end_.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    public string Username { get; set; }
    public string? Mail { get; set; }
    public string Password { get; set; }
    public bool isAdmin { get; set; }
    public List<Note>? Notes { get; set; }
}
