using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Contracts.Models;

namespace WebApiTemplate.DataAccess.Configuration
{
    public class WebApiDBContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public WebApiDBContext(IConfiguration configuration,DbContextOptions<WebApiDBContext> options) : base(options)

        {
            _configuration = configuration;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnectionString"));
        }

        public virtual DbSet<User> User { get; set; }
    }
}
