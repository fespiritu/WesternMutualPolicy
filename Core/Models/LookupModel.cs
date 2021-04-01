using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
  public class LookupModel : BaseEntity
  {
    public List<States> StateList { get; set; }
    // public List<PolicyCoverage> PolicyCoverageList { get; set; }
    public List<CoverageAreaLimit> CoverageAreaLimitList { get; set; }
    public List<Coverage> CoverageList { get; set; }
  }
}
