using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notFound")]
        public ActionResult GetNotFoundRequest() 
        { 
            var things = _context.Products.Find(34);
            if (things == null) {

                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("serverError")]
        public ActionResult GetServerRequest()
        {
            var thing = _context.Products.Find(32);

            var thingsToReturn = thing.ToString();
            
            return Ok();
        }

        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badRequest/{id}")]
        public ActionResult GetBadByIdRequest(int id)
        {
            return Ok();
        }
    }
}
