using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using WesternMutual.Library;
using System.Linq;

namespace Core.Models
{
  public class PolicyViewModel
  {
    public PolicyViewModel()
    {
      Policy = new Policy();
      InsuredList = new List<Insured>();
      CoverageList = new List<Coverage>();
    }
    public Policy Policy { get; set; }
    public List<Insured> InsuredList { get; set; }
    public List<Coverage> CoverageList { get; set; }
    public int Rating {
      get
      {
        return Util.CalcRating(CoverageList.Select(x => x.Cost).ToList(), Policy.Property.Value, Policy.Property.State); 
      }
    }
  }
}
