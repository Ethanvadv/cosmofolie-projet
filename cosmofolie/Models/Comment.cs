using cosmofolie.Base;
using Microsoft.AspNetCore.Identity;

namespace cosmofolie.Models;

public class Comment : Entity
{
    public Guid Id { get; set; } 
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    public string UserId { get; set; } = default!;
    public User User { get; set; }

    public Guid ArticleId { get; set; }
    public Article Article { get; set; } = default!;
}
