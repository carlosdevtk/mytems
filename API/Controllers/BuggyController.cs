using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class BuggyController : BaseApiController
  {
    private readonly StoreContext _context;

    public BuggyController(StoreContext context)
    {
      _context = context;

    }

    [HttpGet("notfound")]
    public ActionResult GetNotFoundRequest()
    {
      var value = _context.Products.Find(42);

      if (value == null)
      {
        return NotFound(new ErrorResponse(404));
      }

      return Ok();
    }

    [HttpGet("servererror")]
    public ActionResult GetServerError()
    {
      var value = _context.Products.Find(42);
      var valueToReturn = value.ToString();
      return Ok();

    }
    [HttpGet("badrequest")]
    public ActionResult GetBadRequest()
    {
      return BadRequest(new ErrorResponse(400));
    }
    [HttpGet("badrequest/{id}")]
    public ActionResult GetNotFoundRequest(int id)
    {
      return Ok();
    }

  }
}