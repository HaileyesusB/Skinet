using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Products, ProductReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public string Resolve(Products source, ProductReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                {
                return _configuration["ApiUrl"] + source.PictureUrl;
                }
            return null;
        }
    }
}
