using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
  public class States : BaseEntity
  {
    // e.g. CA
    [Required]
    [StringLength(2)]
    public string State { get; set; }


    // e.g. California
    [Required]
    [StringLength(100)]
    public string Description { get; set; }
  }
}
