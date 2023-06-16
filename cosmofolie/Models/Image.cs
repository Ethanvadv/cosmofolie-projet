using cosmofolie.Base;

namespace cosmofolie.Models
{
    public class Image : Entity
    {
        public string FileName { get; set; } = default!;
        public string Path { get; set; } = default!;


        public Guid ArticleId { get; set; }
        public Article Article { get; set; } = default!;
    }
}
