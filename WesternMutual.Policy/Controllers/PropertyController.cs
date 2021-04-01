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
  public class PropertyController : BaseApiController
  {
    private readonly IGenericRepository<Core.Entities.Property> _repo;

    private readonly IMapper _mapper;

    public PropertyController(IGenericRepository<Core.Entities.Property> repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Property>>> GetAll()
    {
      return Ok(await _repo.ListAllAsync());
    }


    [HttpGet]
    public async Task<ActionResult<Property>> GetById(int id)
    {
      var obj = await _repo.GetByIdAsync(id);
      if (obj != null)
      {
        return Ok(obj);
      }
      return NotFound();
    }
    [HttpPost]
    public ActionResult<Property> Save([FromBody] Property property)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }
      _repo.Add(property);
      bool isOk = _repo.Save();
      if (isOk)
      {
        return CreatedAtAction(nameof(GetById), new { id = property.Id, property });
      }
      return BadRequest();
    }
  }
}
