using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using AutoMapper;
using Core.Entities;


namespace WesternMutual.Policy.Controllers
{
  public class CoverageController : BaseApiController
  {
    private readonly IGenericRepository<Core.Entities.Coverage> _repo;

    private readonly IMapper _mapper;

    public CoverageController(IGenericRepository<Core.Entities.Coverage> repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<List<Coverage>>> GetAll()
    {
      return Ok(await _repo.ListAllAsync());
    }

  }
}
