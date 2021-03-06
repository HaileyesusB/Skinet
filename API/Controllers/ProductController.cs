using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductController : BaseAPIController
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

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductReturnDto>>> GetProducts(
            [FromQuery]ProductSpecParams productParams) {
            var spec = new ProductTypeBrandsSpecification(productParams);
            var countSpec = new ProductWithFilterForCountSpecification(productParams);
            var totalItems = await _productRepository.CountAsync(countSpec);
            var products = await _productRepository.ListAsync(spec);
            var data = _IMapper.Map<IReadOnlyList<Products>, IReadOnlyList<ProductReturnDto>>(products);
           
           
            return Ok(new Pagination<ProductReturnDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse) , StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductReturnDto>> GetProduct(int id) {

            var spec = new ProductTypeBrandsSpecification(id);
           
          //  return await _productRepository.GetEntityWithSpec(spec);
          var products = await _productRepository.GetEntityWithSpec(spec);
            if (products == null) return NotFound(new ApiResponse(404));
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