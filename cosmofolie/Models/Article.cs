﻿using cosmofolie.Base;
using System.ComponentModel.DataAnnotations;

namespace cosmofolie.Models;

public class Article : Entity
{

 
    public string Titre { get; set; } = default!;

    public string Contenu { get; set; } = default!;
    public bool IsTrend { get; set; }


    public Guid ImageId { get; set; }
    public Image Image { get; set; } = default!;
  


    public List<Comment>? Comments { get; set; }

}
