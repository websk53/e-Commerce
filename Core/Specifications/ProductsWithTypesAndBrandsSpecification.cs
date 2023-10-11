using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpecParams) 
            : base(x=>
                (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search)) &&
                (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId) &&
                (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId)
            )
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
            AddOrderBy(x=>x.Name);
            ApplyPaging(productSpecParams.PageSize,productSpecParams.PageSize * (productSpecParams.PageIndex - 1));

            if(!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                    AddOrderBy(p=>p.Price);
                    break;
                    case "priceDesc":
                    AddOrderByDesc(p=>p.Price);
                    break;
                    default:
                    AddOrderBy(p=>p.Name);
                    break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
    }
}