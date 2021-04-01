using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
  public class Coverage : BaseEntity
  {
    [Required]
    [StringLength(255)]
    public string Description { get; set; }

    [Column(TypeName = "decimal(19,4)")]
    public decimal Cost { get; set; }
  }
}
