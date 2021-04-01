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
  public class InsuredController : BaseApiController
  {
    private readonly IGenericRepository<Core.Entities.Insured> _repo;

    private readonly IMapper _mapper;

    public InsuredController(IGenericRepository<Core.Entities.Insured> repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<List<Insured>>> GetAll()
    {
      return Ok(await _repo.ListAllAsync());
    }

    [HttpGet]
    public async Task<ActionResult<List<Insured>>> GetByPolicyId(int id)
    {
      var objs = await _repo.GetAllByExpression(x => x.Policy.Id == id);
      if (objs != null)
      {
        return Ok(objs);
      }
      return NotFound();
    }

    [HttpGet]
    public async Task<ActionResult<Insured>> GetById(int id)
    {
      var obj = await _repo.GetByIdAsync(id);
      if (obj != null)
      {
        return Ok(obj);
      }
      return NotFound();
    }
    [HttpPost]
    public ActionResult<Insured> Save([FromBody] Insured insured)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }
      _repo.Add(insured);
      bool isOk = _repo.Save();
      if (isOk)
      {
        return CreatedAtAction(nameof(GetById), new { id = insured.Id, insured });
      }
      return BadRequest();
    }

  }
}
