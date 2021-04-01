using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
  public class Property : BaseEntity
  {
    [Column(TypeName = "decimal(19,4)")]
    public decimal Value { get; set; }

    [Required]
    [StringLength(100)]
    public string Address1 { get; set; }

    [StringLength(50)]
    public string Address2 { get; set; }

    [Required]
    [StringLength(100)]
    public string City { get; set; }

    [Required]
    [StringLength(2)]
    public string State { get; set; }

    [Required]
    [StringLength(15)]

    public string ZipCode { get; set; }

  }
}
