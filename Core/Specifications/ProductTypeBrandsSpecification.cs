using Core.Entities;

namespace Core.Specifications
{
    public class ProductTypeBrandsSpecification: BaseSpecification <Products>
    {
        public ProductTypeBrandsSpecification() 
        {

            AddInclude(x => x.ProductType);

            AddInclude(x => x.ProductBrand);
        }

        public ProductTypeBrandsSpecification(int Id)
                 : base(x => x.ID == Id)
        {
            AddInclude(x => x.ProductType);

            AddInclude(x => x.ProductBrand);
        }
    }
}
