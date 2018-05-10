using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIdea.Models
{
    public class Idea
    {
        public string ID { get; set; }
        public string OwnerID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Members { get; set; }
        public string RequiredMembers { get; set; }
    }
}
