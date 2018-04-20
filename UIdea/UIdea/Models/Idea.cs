using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace UIdea.Models
{
    public class Idea
    {
        public int IdeaID { get; set; }

        public string UserID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string RequiredMembers { get; set; }

        public bool Open { get; set; }
    }
}