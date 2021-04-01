using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Core.Entities
{
  // Could have placed updateBy, updatedDate, addedBy, and addedDate
  public class Policy : BaseEntity
  {
    [Required]
    public int PropertyId { get; set; }

    [Required]
    public Property Property { get; set; }

    // Quote, Issued
    [Required]
    [StringLength(50)]
    public string Status { get; set; }  
  }
}
