using System;
using System.Threading.Tasks;
using EstoCare.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstoCare.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        Task<int> CompleteAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EstocareDbContext _context;

        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }

        public UnitOfWork(EstocareDbContext context, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _context = context;
            Categories = categoryRepository;
            Products = productRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
