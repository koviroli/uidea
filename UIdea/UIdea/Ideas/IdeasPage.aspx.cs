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
            rowIdea.Cells.Add(new TableCell() { Text = idea.Title, Width = new Unit("50%") });

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
            cellRquiredMembers.Width = new Unit("20%");
            rowIdea.Cells.Add(cellRquiredMembers);

            TableCell progressBar = new TableCell();
            progressBar.Width = new Unit("20%");
            progressBar.Controls.Add(ProgressBar(20));

            rowIdea.Cells.Add(progressBar);

            TableCell btnCell = new TableCell();
            btnCell.Width = new Unit("10%");
            string btnClass = "btn btn-success btn-xs";
            if(!idea.IsOpen)
            {
                btnClass += " disabled";
            }
            Button btnJoin = new Button()
            {
                CssClass = btnClass,
                Text = "Join"
            };
            btnCell.Controls.Add(btnJoin);
            rowIdea.Cells.Add(btnCell);
            tblIdeas.Rows.Add(rowIdea);//add the new row to table
        }

        private HtmlGenericControl ProgressBar(int percent)
        {
            //< div class="progress">
            //<div class="progress-bar" role="progressbar" aria-valuenow="70" aria-valuemin="0" aria-valuemax="100" style="width:70%">
            //<span class="sr-only">70% Complete</span>
            //</div>
            //</div>

            HtmlGenericControl mainDiv = new HtmlGenericControl("div");
            mainDiv.Attributes.Add("class", "progress");

            HtmlGenericControl progressBarDiv = new HtmlGenericControl("div");
            progressBarDiv.Attributes.Add("class", "progress-bar");
            progressBarDiv.Attributes.Add("role", "progressbar");
            progressBarDiv.Attributes.Add("aria-valuenow", string.Format("{0}", percent));
            progressBarDiv.Attributes.Add("aria-valuemin", "0");
            progressBarDiv.Attributes.Add("aria-valuemax", "100");
            progressBarDiv.Style.Add(HtmlTextWriterStyle.Width, string.Format("{0}%", percent));
            mainDiv.Controls.Add(progressBarDiv);


            return mainDiv;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var _db = new IdeaContext())
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
        }
    }
}