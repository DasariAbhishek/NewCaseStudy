using backend.Models;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class CGDbContext : DbContext
    {

        public CGDbContext(DbContextOptions<CGDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        public DbSet<CandidateSkills> candidateSkills { get; set; }

        public DbSet<Skills> skills { get; set; }
    }
}
