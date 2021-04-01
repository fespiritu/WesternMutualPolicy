using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WesternMutual.Library
{
  // Place this utility functions in a separate library project if it gets too much
  public class Util
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="coverageCostList"></param>
    /// <param name="propertyValue">1066000</param>
    /// <param name="state">CA</param>
    /// <returns></returns>
    /// - e.g. (1066000*0.11)+30
    /// Policy rating
    ///    Each state has its own algorithm for rating:
    ///     If state = AZ
    ///       Rating = property value * 0.1 + sum(optional coverages selected)
    ///     If state = CA
    ///       Rating = property value * 0.11 + sum(optional coverages selected)
    public static int CalcRating(List<decimal> coverageCostList, decimal propertyValue, string state)
    {
      int rating = 0;
      int sumCoverages = Decimal.ToInt32(coverageCostList.Sum());
      // e.g. 117290
      rating = Decimal.ToInt32(propertyValue * getRatingMultiplier(state)) + sumCoverages;

      return rating;
    }


    // See CalcRating()
    public static decimal getRatingMultiplier(string state)
    {
      decimal mult = 0;
      if (string.IsNullOrEmpty(state)) return mult;
      switch(state.ToUpper())
      {
        case "AZ":
          mult = .1M;
          break;
        case "CA":
          mult = 0.11M;
          break;
        default:
          mult = 0;
          break;
      }
      return mult;
    }
  }
}
