using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace UIdea.Models
{
    public class IdeaContext : DbContext
    {
        public IdeaContext() : base("DefaultConnection")
        {
        }

        public DbSet<Idea> Ideas { get; set; }
    }
}