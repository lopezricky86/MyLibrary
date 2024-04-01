using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.Api.Entities;

public class Book
{
    [Key]    
    public int book_id { get; set; }
    public int author_id { get; set; }
    [ForeignKey("author_id")]
    public Author? Author { get; set; }
    public required string title { get; set; }
    public int publication_year { get; set; }
    public string? type { get; set; }
    public string? genre { get; set; }
}
