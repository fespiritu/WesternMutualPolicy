using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using AutoMapper;
using Core.Entities;
using Core.Models;

namespace WesternMutual.Policy.Controllers
{
  public class LookupModelController : Controller
  {
    private readonly IGenericRepository<States> _repoStates;
    private readonly IGenericRepository<CoverageAreaLimit> _repoCoverageAreaLimit;
    private readonly IGenericRepository<Coverage> _repoCoverage;

    private readonly IMapper _mapper;

    public LookupModelController(IGenericRepository<States> repoStates,
      IGenericRepository<CoverageAreaLimit> repoCoverageAreaLimit,
      IGenericRepository<Coverage> repoCoverage,
      IMapper mapper)
    {
      _repoStates = repoStates;
      _repoCoverageAreaLimit = repoCoverageAreaLimit;
      _repoCoverage = repoCoverage;
      _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<LookupModel>> GetAll()
    {
      var model = new LookupModel();
      var states = await _repoStates.ListAllAsync();
      var cals = await _repoCoverageAreaLimit.ListAllAsync();
      var cvgs = await _repoCoverage.ListAllAsync();
      
      // States
      if (states != null && states.Count > 0)
      {
        model.StateList.AddRange(states);
      }

      // CoverageAreaLimitList
      if (cals != null && cals.Count > 0)
      {
        model.CoverageAreaLimitList.AddRange(cals);
      }

      // Coverage
      if (cvgs != null && cvgs.Count > 0)
      {
        model.CoverageList.AddRange(cvgs);
      }

      return Ok(model);
    }
  }
}
