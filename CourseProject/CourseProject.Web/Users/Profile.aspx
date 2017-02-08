<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CourseProject.Web.Users.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%# this.Model.ProfileUser.FirstName %> <%# this.Model.ProfileUser.LastName %></h3>
    <h5><%# this.Model.ProfileUser.UserName %></h5>

    <p>Age: <%# this.Model.ProfileUser.Age %></p>
    <p>Email: <%# this.Model.ProfileUser.Email %></p>
</asp:Content>
