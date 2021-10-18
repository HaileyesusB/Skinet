using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Products> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _IMapper;

        public ProductController(IGenericRepository<Products> productRepository, IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository, IMapper imapper) {

            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _IMapper = imapper;

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductReturnDto>>> GetProducts() {
            var spec = new ProductTypeBrandsSpecification();
            var products = await _productRepository.ListAsync(spec);
            //  return Ok(products);
            //return products.Select(products => new ProductReturnDto
            //{ 
            //    ID = products.ID,
            //    Name = products.Name,
            //    Descriprtion = products.Descriprtion,
            //    Price = products.Price,
            //    PictureUrl = products.PictureUrl,
            //    ProductBrand = products.ProductBrand.Name,
            //    ProductType = products.ProductType.Name
            //}).ToList();

            return Ok(_IMapper
                   .Map<IReadOnlyList< Products>, IReadOnlyList<ProductReturnDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReturnDto>> GetProduct(int id) {

            var spec = new ProductTypeBrandsSpecification(id);
          //  return await _productRepository.GetEntityWithSpec(spec);
          var products = await _productRepository.GetEntityWithSpec(spec);
            //return new ProductReturnDto
            //{
            //    ID = products.ID,
            //    Name = products.Name,
            //    Descriprtion = products.Descriprtion,
            //    Price = products.Price,
            //    PictureUrl = products.PictureUrl,
            //    ProductBrand = products.ProductBrand.Name,
            //    ProductType = products.ProductType.Name
            //};
            return _IMapper.Map<Products, ProductReturnDto>(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {

            return Ok(await _productBrandRepository.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
            {
            return Ok(await _productTypeRepository.ListAllAsync());
        }
    }
}