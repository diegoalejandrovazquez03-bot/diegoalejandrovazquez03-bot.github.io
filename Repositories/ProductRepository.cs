using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PescaderiaApi.Data;
using PescaderiaApi.Interfaces;
using PescaderiaApi.Models;

namespace PescaderiaApi.Repositories
{
    /// <summary>
    /// Implementación del repositorio de productos conectado a la base de datos SQL Server.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            if (string.IsNullOrEmpty(product.Id))
            {
                var maxId = 0;
                var ids = await _context.Products.Select(p => p.Id).ToListAsync();
                foreach (var id in ids)
                {
                    if (int.TryParse(id, out var parsedId) && parsedId > maxId)
                    {
                        maxId = parsedId;
                    }
                }
                product.Id = (maxId + 1).ToString();
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var existing = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Description = product.Description;
                existing.Price = product.Price;
                existing.Category = product.Category;
                existing.Image = product.Image;
                existing.Images = product.Images;
                existing.Available = product.Available;
                existing.AvailableForPickup = product.AvailableForPickup;
                existing.AvailableForDelivery = product.AvailableForDelivery;
                existing.Rating = product.Rating;
                existing.Reviews = product.Reviews;
                existing.Origin = product.Origin;
                existing.Nutrition = product.Nutrition;
                existing.Weight = product.Weight;
                existing.PreparationTime = product.PreparationTime;
                existing.Ingredients = product.Ingredients;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Review>> GetReviewsByProductIdAsync(string productId)
        {
            return await _context.Reviews.Where(r => r.ProductId == productId).ToListAsync();
        }

        public async Task AddReviewAsync(Review review)
        {
            if (!string.IsNullOrEmpty(review.UserId) && await _context.Reviews.AnyAsync(r => r.ProductId == review.ProductId && r.UserId == review.UserId))
            {
                throw new InvalidOperationException("Ya has dejado una reseña para este producto.");
            }

            review.Id = Guid.NewGuid().ToString();
            review.Date = DateTime.Now.ToString("yyyy-MM-dd");
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == review.ProductId);
            if (product != null)
            {
                var productReviews = await _context.Reviews.Where(r => r.ProductId == review.ProductId).ToListAsync();
                product.Reviews = productReviews.Count;
                product.Rating = Math.Round(productReviews.Average(r => r.Rating), 1);
                await _context.SaveChangesAsync();
            }
        }
    }
}
