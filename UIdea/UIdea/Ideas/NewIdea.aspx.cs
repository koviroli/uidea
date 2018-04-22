using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.AspNet.Identity;
using UIdea.Models;

namespace UIdea.Ideas
{
    public partial class NewIdea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                btnCreateIdea.Visible = true;
            }
            else
            {
                btnCreateIdea.Visible = false;
            }
        }

        protected void btnCreateIdea_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbTitle.Text) || string.IsNullOrEmpty(tbDescription.Text))
            {
                lblErrorMessage.ForeColor = System.Drawing.Color.Red;
                lblErrorMessage.Text = "Title and Description must not be empty!";
                return;
            }
            else
            {
                lblErrorMessage.Text = string.Empty;
            }

            string userId = string.Empty;
            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            }
            else
            {
                return;
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (cbRequiredMembers.Items[0].Selected)
                sb.Append("coder;");
            if (cbRequiredMembers.Items[1].Selected)
                sb.Append("designer;");
            if (cbRequiredMembers.Items[2].Selected)
                sb.Append("engineer;");
            if (cbRequiredMembers.Items[3].Selected)
                sb.Append("sales;");

            var requiredMembers = sb.ToString();
            var idea = new Idea
            {
                Title = tbTitle.Text,
                Description = tbDescription.Text,
                IsOpen = true,
                RequiredMembers = requiredMembers,
                UserID = userId
            };

            using (var _db = new IdeaContext())
            {
                _db.Ideas.Add(idea);
                _db.SaveChanges();
            }
            Response.Redirect("IdeasPage.aspx");
        }
    }
}