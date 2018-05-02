<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsersPage.aspx.cs" Inherits="UIdea.UsersPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Label ID="lblUsersCount" runat="server"></asp:Label>
</asp:Content>
