using Core.Seed;

namespace Core.Entities
{
    public class Products: BaseEntity
    {
        public string Name { get; set; }

        public string Descriprtion { get; set; }

        public decimal Price{ get; set; }

        public string PictureUrl { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public int ProductBrandId { get; set; }

    }
}