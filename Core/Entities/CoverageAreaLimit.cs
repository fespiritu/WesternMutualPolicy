using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
  public class CoverageAreaLimit : BaseEntity
  {
    [Required]
    public Coverage Coverage { get; set; }

    [Required]
    public States States { get; set; }
  }
}
