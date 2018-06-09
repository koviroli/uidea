using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UIdea.Models
{
    public class IssueContext : DbContext
    {
        public IssueContext (DbContextOptions<IssueContext> options)
            : base(options)
        {
        }

        public DbSet<Issue> Issue { get; set; }
    }
}
