using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using UIdea.Models;

namespace UIdea
{
    public partial class UsersPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Database.Initialize(true);
                IQueryable<ApplicationUser> queryUsers = _db.Users;
                var usersCount = queryUsers.Count();
                lblUsersCount.Text = string.Format("There are {0} registered users.", usersCount);
                foreach (var user in queryUsers)
                {
                    
                }
            }
        }

    }
}