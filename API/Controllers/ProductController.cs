using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
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
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository) {
            _productRepository = productRepository;

        }
        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts() {
            var products = await _productRepository.GetProductAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id) {

            return await _productRepository.GetProductByIDAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {

            return Ok(await _productRepository.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
            {
            return Ok(await _productRepository.GetProductTypesAsync());
        }
    }
}