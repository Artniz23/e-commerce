using API.Errors;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

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
        Product? product = _context.Products.Find(42);

        if (product == null)
        {
            return NotFound(new ApiResponse(404));
        }
        
        return Ok(product);
    }
    
    [HttpGet("servererror")]
    public ActionResult GetServerError()
    {
        Product? product = _context.Products.Find(42);

        product.ToString();
        
        return Ok();
    }
    
    [HttpGet("badrequest")]
    public ActionResult GetBadRequest()
    {
        return BadRequest(new ApiResponse(400));
    }
    
    [HttpGet("badrequest/{id}")]
    public ActionResult GetBadRequest(int id)
    {
        return BadRequest();
    }
}