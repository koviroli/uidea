using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace UIdea.Ideas
{
    public class DbAdapterIdeas
    {
        public static List<IdeaObj> LoadAllIdeas()
        {
            List<IdeaObj> loadedIdeas = new List<IdeaObj>();
            var conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlcon = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("select * from Ideas", sqlcon);
                sqlcon.Open();
                using (SqlDataReader oReader = command.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var ideaTitle = oReader["Title"].ToString();
                        var ideaDescription = oReader["Description"].ToString();
                        var requiredMembers = oReader["RequiredMembers"].ToString();
                        bool isOpen = (bool)oReader["IsOpen"];

                        var reqMembers = new List<ERequiredMember>();
                        foreach (var reqmem in requiredMembers.Split(';'))
                        {
                            if (string.Equals(reqmem, "coder"))
                                reqMembers.Add(ERequiredMember.CODER);
                            if (string.Equals(reqmem, "designer"))
                                reqMembers.Add(ERequiredMember.DESIGNER);
                            if (string.Equals(reqmem, "engineer"))
                                reqMembers.Add(ERequiredMember.ENGINEER);
                            if (string.Equals(reqmem, "sales"))
                                reqMembers.Add(ERequiredMember.SALES);

                        }
                        var idea = new IdeaObj(ideaTitle, ideaDescription, reqMembers, isOpen);
                        loadedIdeas.Add(idea);
                    }
                }
            }
            return loadedIdeas;
        }

        public static bool InsertIdea(IdeaObj idea)
        {
            bool success = true;
            StringBuilder sb = new StringBuilder();

            foreach (var rmem in idea.RequiredMembers)
            {
                switch (rmem)
                {
                    case ERequiredMember.CODER: sb.Append("coder").Append(";"); break;
                    case ERequiredMember.DESIGNER: sb.Append("designer").Append(";"); break;
                    case ERequiredMember.ENGINEER: sb.Append("engineer").Append(";"); break;
                    case ERequiredMember.SALES: sb.Append("sales").Append(";"); break;
                }
            }
            string reqMembersAsDBString = sb.ToString();

            var conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlcon = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("insert into Ideas" +
               "(Title, Description, RequiredMembers, IsOpen)values" +
               "(@ideaTitle, @description, @reqMembersAsDBString, @isOpen)", sqlcon);
                command.Parameters.AddWithValue("@ideaTitle", idea.Title);
                command.Parameters.AddWithValue("@description", idea.Description);
                command.Parameters.AddWithValue("@reqMembersAsDBString", reqMembersAsDBString);
                command.Parameters.AddWithValue("@isOpen", idea.Open);

                try
                {
                    sqlcon.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    success = false;
                }
            }
            return success;
        }
    }
}