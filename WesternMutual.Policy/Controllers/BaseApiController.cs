using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;


namespace WesternMutual.Policy.Controllers
{
  [EnableCors("CorsPolicy")]
  [ApiController]
  [Route("api/v01/[controller]")]
  public class BaseApiController : Controller
  {
    //public IActionResult Index()
    //{
    //  return View();
    //}
  }
}
