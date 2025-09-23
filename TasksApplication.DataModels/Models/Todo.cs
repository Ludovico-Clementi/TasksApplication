using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TasksApplication.DataModels.Models;

[Table("todos")]
public class Todo
{
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    public string Title { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("completed")]
    public bool Completed { get; set; } = false;

    [Column("start_date")]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    [Column("due_date")]
    public DateTime? DueDate { get; set; } = DateTime.UtcNow.AddDays(1);

    [Column("user_id")]
    public int UserId { get; set; }

    [JsonIgnore]
    [ForeignKey("UserId")]
    public User? User { get; set; }

}
