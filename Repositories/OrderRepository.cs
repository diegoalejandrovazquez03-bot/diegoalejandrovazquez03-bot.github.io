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
    /// Repositorio de pedidos conectado a la base de datos SQL Server.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(string userId)
        {
            return await _context.Orders.Where(o => o.UserId == userId).ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(string id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(Order order)
        {
            if (string.IsNullOrEmpty(order.Id))
            {
                int count = await _context.Orders.CountAsync();
                int orderNumber = count + 1;
                if (string.IsNullOrEmpty(order.UserId))
                {
                    order.Id = $"INV-2026-{orderNumber:D3}";
                    if (string.IsNullOrEmpty(order.CustomerName))
                    {
                        order.CustomerName = "Invitado";
                    }
                }
                else
                {
                    order.Id = $"ORD-2026-{orderNumber:D3}";
                }
            }
            order.Date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(string id, string status)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order != null)
            {
                order.Status = status;
                await _context.SaveChangesAsync();
            }
        }
    }
}
