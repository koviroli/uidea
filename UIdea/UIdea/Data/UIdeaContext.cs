using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UIdea.Models
{
    public class UIdeaContext : DbContext
    {
        public UIdeaContext (DbContextOptions<UIdeaContext> options)
            : base(options)
        {
        }

        public DbSet<UIdea.Models.Idea> Idea { get; set; }
    }
}
