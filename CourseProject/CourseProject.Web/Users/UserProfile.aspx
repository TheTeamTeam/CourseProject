<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="CourseProject.Web.Users.UserProfile" %>

<%@ Register Src="~/Users/AdminControls/ChangeRolesControl.ascx" TagPrefix="uc" TagName="ChangeRolesControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="container col-md-8">
            <h3><%#: this.Model.ProfileUser.FirstName %> <%#: this.Model.ProfileUser.LastName %></h3>
            <h5><%#: this.Model.ProfileUser.UserName %></h5>

            <p>Age: <%# this.Model.ProfileUser.Age %></p>
            <p>Email: <%#: this.Model.ProfileUser.Email %></p>
        </div>

        <asp:LoginView runat="server">
            <RoleGroups>
                <asp:RoleGroup Roles="Admin">
                    <ContentTemplate>
                        <uc:ChangeRolesControl runat="server" ID="AdminControl" UserId="<%# this.Model.ProfileUser.Id %>"></uc:ChangeRolesControl>
                    </ContentTemplate>
                </asp:RoleGroup>
            </RoleGroups>
        </asp:LoginView>
    </div>
    <asp:Panel runat="server" CssClass="row" Visible="<%# this.Model.IsSeller %>">
        <h3>The Advertisements...</h3>
        <div class="jumbotron">
            <asp:ListView runat="server" ID="ListView2"
                DataSource="<%# this.Model.SellerAds %>"
                ItemType="CourseProject.Models.Advertisement">
                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <h3><a href="/addetails/?id=<%# Item.Id %>"><%#: Item.Name %></a></h3>
                    <div>
                        <img class="col-md-3" src="<%#: Item.ImagePathSmall%>" alt="<%#: Item.Name %>" />
                    </div>
                    <p>Price: <%#: Item.Price %>lv.</p>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p class="text-green">This seller has no ads yet!</p>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </asp:Panel>
</asp:Content>
