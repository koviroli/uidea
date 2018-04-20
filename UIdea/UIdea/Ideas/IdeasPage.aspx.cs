using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using UIdea.Models;

namespace UIdea
{
    public partial class IdeasPage : System.Web.UI.Page
    {
        enum RequiredMember
        {
            CODER = 0,
            DESIGNER = 1,
            ENGINEER = 2,
            SALES = 3
        };

        private void AddIdeaRow(Idea idea)
        {
            TableRow rowIdea = new TableRow();
            rowIdea.CssClass = "default";
            rowIdea.Cells.Add(new TableCell() { Text = idea.Title });

            TableCell cellRquiredMembers = new TableCell();
            foreach(var member in idea.RequiredMembers.Split(';'))
            {
                switch(member)
                {
                    case "coder":
                        cellRquiredMembers.Controls.Add(new Image() { ImageUrl = "Images/Icons/RquiredMemberIcon/requiredCoder18x18.png", ToolTip = "Coder wanted" });
                        break;
                    case "designer":
                        cellRquiredMembers.Controls.Add(new Image() { ImageUrl = "Images/Icons/RquiredMemberIcon/requiredDesigner18x18.png", ToolTip = "Deisgner wanted" });
                        break;
                    case "engineer":
                        cellRquiredMembers.Controls.Add(new Image() { ImageUrl = "Images/Icons/RquiredMemberIcon/requiredEngineer18x18.png", ToolTip = "Engineer wanted" });
                        break;
                    case "sales":
                        cellRquiredMembers.Controls.Add(new Image() { ImageUrl = "Images/Icons/RquiredMemberIcon/requiredSales18x18.png", ToolTip = "Sales" });
                        break;
                }
            }
            rowIdea.Cells.Add(cellRquiredMembers);

            rowIdea.Cells.Add(new TableCell() { Text = !idea.Open ? "Closed" : "Open" });

            TableCell btnCell = new TableCell();
            string btnClass = "btn btn-success btn-xs";
            if(!idea.Open)
            {
                btnClass += " disabled";
            }
            btnCell.Controls.Add(new Button() { CssClass = btnClass, Text = "Join" });
            rowIdea.Cells.Add(btnCell);

            tblIdeas.Rows.Add(rowIdea);//add the new row to table
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var _db = new Models.IdeaContext())
            {
                _db.Database.Initialize(true);
                IQueryable<Models.Idea> query = _db.Ideas;
                var ideas = _db.Ideas;
                foreach(var idea in ideas)
                {
                    AddIdeaRow(idea);
                }
            }

            if ((System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                btnAddRow.Visible = true;
            }
            else
            {
                btnAddRow.Visible = false;
            }
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewIdea.aspx");

            //var idea = new Idea()
            //{
            //    Title = "TestIdea",
            //    Description = "Some test description",
            //    RequiredMembers = "coder,sales",
            //    Open = true,
            //};
            //using (var _db = new IdeaContext())
            //{
            //    _db.Ideas.Add(idea);
            //    _db.SaveChanges();
            //}
            //AddIdeaRow(idea);
            //AddIdeaToDB(IdeaTitleTest, "Some Description", reqMembers, isOpen);
        }
    }
}