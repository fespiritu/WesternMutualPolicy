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

  public class PolicyController : BaseApiController
  {
    private readonly IGenericRepository<Core.Entities.Policy> _repo;

    private readonly IMapper _mapper;

    public PolicyController(IGenericRepository<Core.Entities.Policy> repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Core.Entities.Policy>>> GetAll()
    {
      return Ok(await _repo.ListAllAsync());
    }

    [HttpGet]
    public async Task<ActionResult<List<Core.Entities.Policy>>> GetByPropertyId(int id)
    {
      var objs = await _repo.GetAllByExpression(x => x.PropertyId == id);
      if (objs != null)
      {
        return Ok(objs);
      }
      return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<Core.Entities.Policy>> GetById(int id)
    {
      var obj = await _repo.GetByIdAsync(id);
      if (obj != null)
      {
        return Ok(obj);
      }
      return NotFound();
    }
    [HttpPost]
    public ActionResult<Core.Entities.Policy> Save([FromBody] Core.Entities.Policy policy)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }
      _repo.Add(policy);
      bool isOk = _repo.Save();
      if (isOk)
      {
        return CreatedAtAction(nameof(GetById), new { id = policy.Id, policy });
      }
      return BadRequest();
    }
  }
}
