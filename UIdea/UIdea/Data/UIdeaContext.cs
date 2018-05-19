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
