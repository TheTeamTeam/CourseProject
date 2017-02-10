<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CourseProject.Web.Users.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%# this.Model.ProfileUser.FirstName %> <%# this.Model.ProfileUser.LastName %></h3>
    <h5><%# this.Model.ProfileUser.UserName %></h5>

    <p>Age: <%# this.Model.ProfileUser.Age %></p>
    <p>Email: <%# this.Model.ProfileUser.Email %></p>

    <div class="col-md-6 jumbotron">
        <h3>Upcoming</h3>
        <asp:ListView runat="server" ID="UpcomingList"
            DataSource="<%# this.Model.ProfileUser.UpcomingAds %>"
            ItemType="CourseProject.Models.Advertisement">
            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <h3><a href="/addetails/?id=<%# Item.Id %>"><%#: Item.Name %></a></h3>
                <div>
                    <img class="col-md-3" src="<%# Item.ImagePath%>" alt="<%#: Item.Name %>" />
                </div>
                <p>Price: <%#: Item.Price %>lv.</p>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div class="col-md-6 jumbotron">
        <h3>Saved</h3>
        <asp:ListView runat="server" ID="ListView1"
            DataSource="<%# this.Model.ProfileUser.SavedAds %>"
            ItemType="CourseProject.Models.Advertisement">
            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <h3><a href="/addetails/?id=<%# Item.Id %>"><%#: Item.Name %></a></h3>
                <div>
                    <img class="col-md-3" src="<%# Item.ImagePath%>" alt="<%#: Item.Name %>" />
                </div>
                <p>Price: <%#: Item.Price %>lv.</p>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
