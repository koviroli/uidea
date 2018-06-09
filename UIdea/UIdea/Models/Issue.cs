using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIdea.Models
{
    public enum EIssueType { Bug, Feature };

    public enum EIssuePriority { Low, Medium, High };

    public enum ERewardType { XP, Money };

    public class Issue
    {
        /// <summary>
        /// ID of the Issue
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// ID of the project that containing this Issue
        /// </summary>
        public string ProjectID { get; set; }

        public EIssueType IssueType { get; set; }

        public EIssuePriority Priority { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public ERewardType RewardType { get; set; }

        public int Reward { get; set; }
    }
}
