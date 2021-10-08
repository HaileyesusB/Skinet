using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly StoreContext _Context;
        public ProductController(StoreContext context) {
            _Context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts(){
            var products = await _Context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet ("{id}")]
        public async Task <ActionResult<Products>> GetProduct(int id){

            return await _Context.Products.FindAsync(id);
        }
    }
}