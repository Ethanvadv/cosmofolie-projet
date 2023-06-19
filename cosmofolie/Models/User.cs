using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace cosmofolie.Models
{
    public class User :IdentityUser
    {
        public ICollection<Comment>? Comments { get; set; }
    }
}
