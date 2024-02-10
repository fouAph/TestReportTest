using Microsoft.EntityFrameworkCore;
using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.RepositoryContext;

namespace NorthwindWebMvc.Basic.Repository
{
    public class ProductRepository : IRepositoryBaseNew<Product>
    {
        private readonly RepositoryDbContext _context;

        public ProductRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public void Create(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Products.Remove(FindById(id));
            _context.SaveChanges();
        }

        public IEnumerable<Product> FindAll()
        {
            return _context.Products;
        }

        public Product FindById(int id)
        {
            return _context.Products.Find(id);
        }


        public void Update(Product entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
