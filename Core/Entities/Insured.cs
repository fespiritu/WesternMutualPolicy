using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
  public class Insured : BaseEntity
  {
    [Required]
    [StringLength(30)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(30)]
    public string LastName { get; set; }

    [Required]
    public Policy Policy { get; set; }
  }
}
