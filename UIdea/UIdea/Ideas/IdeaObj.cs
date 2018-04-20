using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIdea
{
    public enum ERequiredMember
    {
        CODER = 0,
        DESIGNER = 1,
        ENGINEER = 2,
        SALES = 3
    };

    public class IdeaObj
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ERequiredMember> RequiredMembers { get; set; }
        public bool Open { get; set; }

        public IdeaObj() : this("NoTitle", "", null, true)
        {
        }

        public IdeaObj(string title, string description, List<ERequiredMember> reqMembers, bool isopen)
        {
            Title = title;
            Description = description;
            RequiredMembers = reqMembers;
            Open = isopen;
        }
    }
}