using System.Collections.Generic;
using System.Data.Entity;


namespace UIdea.Models
{
    public class IdeaDatabaseInitalizer : DropCreateDatabaseIfModelChanges<IdeaContext>
    {
        public IdeaDatabaseInitalizer() : base()
        {
        }
        protected override void Seed(IdeaContext context)
        {
            GetIdeas().ForEach(i => context.Ideas.Add(i));
        }

        private static List<Idea> GetIdeas()
        {
            var ideas = new List<Idea>
            {
                new Idea
                {
                    Title = "Celver home",
                    Description = "Allows you to control devices in your home.",
                    RequiredMembers = "coder;designer;engineer",
                    Open = true
                },
                new Idea
                {
                    Title = "Self driving drone",
                    Description = "AI driver done",
                    RequiredMembers = "coder;designer;engineer,sales",
                    Open = true
                },
                new Idea
                {
                    Title = "Home selling website",
                    Description = "A new way of selling homes",
                    RequiredMembers = "coder",
                    Open = false
                },
                new Idea
                {
                    Title = "Democraty Social Network",
                    Description = "A social network that envolving by it's users",
                    RequiredMembers = "coder;designer",
                    Open = true
                }
            };
            return ideas;
        }
    }
}