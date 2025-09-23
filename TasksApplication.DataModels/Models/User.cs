using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TasksApplication.DataModels.Models;

[Table("users")]
public class User
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [JsonIgnore]
    public ICollection<Todo>? TodoItems { get; set; }
}
