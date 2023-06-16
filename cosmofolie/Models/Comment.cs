using cosmofolie.Base;

namespace cosmofolie.Models;

public class Comment : Entity
{
    public Guid Id { get; set; }
    public string Contenu { get; set; }


    public Guid ArticleId { get; set; }
    public Article Article { get; set; } = default!;
}
