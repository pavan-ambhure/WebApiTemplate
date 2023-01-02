using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Contracts.Interfaces.Repositories;
using WebApiTemplate.Contracts.Models;
using WebApiTemplate.DataAccess.Configuration;

namespace WebApiTemplate.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly WebApiDBContext _db;
        public UserRepository(WebApiDBContext db) 
        {
            _db= db;
        }
        public async Task<User> CreateAsync(User entity)
        {
            _db.User.Add(entity);
            await _db.SaveChangesAsync();
            return await GetUserbyEmailAsync(entity.UserEmail);
        }

        public async Task<User> GetUserAsync(User entity)
        {
            var user = await _db.User.FirstOrDefaultAsync(a => a.UserName == entity.UserName 
            && a.Password==entity.Password);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<User> GetUserbyEmailAsync(string email)
        {
            var user = await _db.User.SingleOrDefaultAsync(a => a.UserEmail==email);

            if (user == null)
            {
                return new User();
            }

            return user;
        }
    }
}
