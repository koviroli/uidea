<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IdeasPage.aspx.cs" Inherits="UIdea.IdeasPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-8">
                <h2>Ideas</h2>
                <asp:Table ID="tblIdeas" runat="server" CssClass="table table-hover"></asp:Table>
                <asp:Button ID="btnAddRow" runat="server" OnClick="btnAddRow_Click" Text="New Idea" />
            </div>
            <div class="col-md-4">
                <div class="row">
                    <div class="jumbotron">
                        <h2>Make private idea groups</h2>
                         <p class="lead">Private ideas that can bee seen only with invitation.</p>
                    </div>
                </div>

                <div class="row">
                    <div class="jumbotron">
                        <h2>Search or offer jobs</h2>
                        <p class="lead">Ideas can become real invetions. Hire somebody.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
