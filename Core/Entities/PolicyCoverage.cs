using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
  // many-many
  public class PolicyCoverage : BaseEntity
  {
    [Required]
    public Policy Policy { get; set; }

    [Required]
    public Coverage Coverage { get; set; }
  }
}
