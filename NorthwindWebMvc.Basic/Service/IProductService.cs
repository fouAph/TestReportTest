using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.Models.Dto;

namespace NorthwindWebMvc.Basic.Service
{
    public interface IProductService
    {

        IEnumerable<ProductDto> FindAll();


        ProductDto FindById(int id);

        void Create(ProductDto entity);

        void Update(ProductDto entity);

        void Delete(int id);

    }
}
