using cosmofolie.Base;
using System.ComponentModel.DataAnnotations;

namespace cosmofolie.Models;

public class Article : Entity
{

 
    public string Titre { get; set; }

 
    public string Contenu { get; set; }


    public Image Image { get; set; }
    public IFormFile ImageFile { get; set; }

    public List<Comment> comments { get; set; }

}
