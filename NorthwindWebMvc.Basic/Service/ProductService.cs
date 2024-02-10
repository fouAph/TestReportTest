using AutoMapper;
using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.Models.Dto;
using NorthwindWebMvc.Basic.Repository;

namespace NorthwindWebMvc.Basic.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryBaseNew<Product> _repositoryBase;

        public ProductService(IRepositoryBaseNew<Product> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Create(ProductDto entity)
        {
            Product product = new()
            {
                Id = entity.Id,
                ProductName = entity.ProductName,
                Price = entity.Price,
                Stock = entity.Stock,
                Photo = entity.Photo,
                CategoryId = entity.CategoryId,
            };

            _repositoryBase.Create(product);

        }

        public void Delete(int id)
        {
            _repositoryBase.Delete(id);
        }

        public IEnumerable<ProductDto> FindAll()
        {
            var products = _repositoryBase.FindAll();
            var dtos = products.Select(entity => new ProductDto
            {
                Id = entity.Id,
                ProductName = entity.ProductName,
                Price = entity.Price,
                Stock = entity.Stock,
                Photo = entity.Photo,
                CategoryId = entity.CategoryId,
            });

            return dtos;
        }

        public ProductDto FindById(int id)
        {
            var entity = _repositoryBase.FindById(id);
            var dto = new ProductDto
            {
                Id = entity.Id,
                ProductName = entity.ProductName,
                Price = entity.Price,
                Stock = entity.Stock,
                Photo = entity.Photo,
                CategoryId = entity.CategoryId,
            };

            return dto;

        }

        public void Update(ProductDto entity)
        {

            var product = new Product
            {
                Id = entity.Id,
                ProductName = entity.ProductName,
                Price = entity.Price,
                Stock = entity.Stock,
                Photo = entity.Photo,
                CategoryId = entity.CategoryId,
            };
            _repositoryBase.Update(product);

        }
    }
}
