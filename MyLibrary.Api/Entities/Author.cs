using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Api.Entities;

public class Author
{
    [Key]
    public int author_id { get; set; }
    public required string first_name { get; set; }
    public required string last_name { get; set; }
    public string? gender { get; set; }
    public DateOnly date_of_birth { get; set; }
}
