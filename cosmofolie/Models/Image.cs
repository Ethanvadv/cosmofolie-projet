using cosmofolie.Base;

namespace cosmofolie.Models
{
    public class Image : Entity
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = default!;
        public IFormFile FormFile { get; set; } = default!;

        public Guid ArticleId { get; set; }
        public Article? Article { get; set; }
    }
}
