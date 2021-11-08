using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFilterForCountSpecification : BaseSpecification<Products>
    {
        public ProductWithFilterForCountSpecification(ProductSpecParams productParams)
            : base(x =>
             (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
             (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        { 


        }
    }
}
