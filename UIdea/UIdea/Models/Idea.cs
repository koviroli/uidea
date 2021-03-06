﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UIdea.Models
{
    public class Idea
    {
        /// <summary>
        /// ID of the idea
        /// </summary>
        public string ID { get; set; }
        
        /// <summary>
        /// ID of the user who created this idea
        /// </summary>
        public string OwnerID { get; set; }

        /// <summary>
        /// Title of the idea
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [MinLength(30)]
        [MaxLength(2000)]
        public string Description { get; set; }

        /// <summary>
        /// User members' ids
        /// </summary>
        public string Members { get; set; }

        /// <summary>
        /// Required skills(eg.: c#, c++, html, qt)
        /// </summary>
        [Required]
        [Display(Name = "Required skills")]
        public string RequiredMembers { get; set; }

        [Display(Name = "Facebook")]
        public string FacebookContact { get; set; }

        [Display(Name = "Instagram")]
        public string InstagramContact { get; set; }

        [Display(Name = "Twitter")]
        public string TwitterContact { get; set; }

        [Display(Name = "Github")]
        public string GitHubContact { get; set; }

        [Display(Name = "E-mail")]
        public string EmailContact { get; set; }

        [Display(Name = "LinkedIn")]
        public string LinkedinContact { get; set; }

        [Display(Name = "Other")]
        public string OtherContact { get; set; }

        public byte[] AvatarImage { get; set; }
    }
}
