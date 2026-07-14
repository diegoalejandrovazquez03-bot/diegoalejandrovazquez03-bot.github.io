using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PescaderiaApi.Data;
using PescaderiaApi.Interfaces;
using PescaderiaApi.Models;

namespace PescaderiaApi.Repositories
{
    /// <summary>
    /// Repositorio de usuarios conectado a la base de datos SQL Server.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        public async Task AddAsync(User user)
        {
            if (string.IsNullOrEmpty(user.Id))
            {
                user.Id = Guid.NewGuid().ToString();
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var existing = await _context.Users.FindAsync(user.Id);
            if (existing != null)
            {
                existing.Name = user.Name;
                existing.Phone = user.Phone;
                existing.Address = user.Address;
                existing.Email = user.Email;
                if (!string.IsNullOrEmpty(user.PasswordHash))
                {
                    existing.PasswordHash = user.PasswordHash;
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
