using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Generics;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService:IGenericCrudOperationService<Product>
    {
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<List<ProductDetailDto>> GetProductDetailsByMinPriceAndMaxPrice(decimal minPrice,decimal maxPrice);
        IDataResult<List<ProductDetailDto>> GetProductDetailsFilteredDesc();
        IDataResult<List<ProductDetailDto>> GetProductDetailsFilteredAsc(); 
        IDataResult<List<ProductDetailDto>>GetProductDetailsEvaluation();
        IDataResult<List<ProductDetailDto>> GetProductDetailByCategoryId(int categoryId);
        IDataResult<List<ProductDetailDto>> GetProductDetailByProductId(int productId);
        IDataResult<List<ProductDetailDto>> GetProductDetailByBrandId(int brandId);
        IDataResult<List<ProductDetailDto>> GetLimitedProductDetailsByProduct(int limit);
        IDataResult<List<ProductDetailDto>> GetAllProductDetailsByProductWithPage(int page, int pageSize);
        Task<IDataResult<List<Product>>> GetAllByCategory(int categoryId);

    }
}