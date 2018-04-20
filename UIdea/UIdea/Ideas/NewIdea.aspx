<%@ Page Title="New idea" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewIdea.aspx.cs" Inherits="UIdea.Ideas.NewIdea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <h2><%: Title %>.</h2>

    <div class="form-horizontal">
        <h4>Create new idea</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbTitle" CssClass="col-md-2 control-label">Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbTitle" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbDescription" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbDescription" CssClass="form-control" TextMode="MultiLine" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="cbRequiredMembers" CssClass="col-md-2 control-label">Required members</asp:Label>
            <div class="col-md-10">
                <asp:CheckBoxList ID="cbRequiredMembers" runat="server">
                    <asp:ListItem>Coder</asp:ListItem>
                    <asp:ListItem>Designer</asp:ListItem>
                    <asp:ListItem>Engineer</asp:ListItem>
                    <asp:ListItem>Sales</asp:ListItem>
                </asp:CheckBoxList>
            </div>
        </div>
        <div>
            <asp:Label runat="server" ID="lblErrorMessage"></asp:Label>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="btnCreateIdea_Click" Text="Create" CssClass="btn btn-default" ID="btnCreateIdea" />
            </div>
        </div>
    </div>
</asp:Content>
