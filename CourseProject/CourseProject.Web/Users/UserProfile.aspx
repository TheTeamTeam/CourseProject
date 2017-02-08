<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="CourseProject.Web.Users.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container col-md-8">
        <h3><%# this.Model.ProfileUser.FirstName %> <%# this.Model.ProfileUser.LastName %></h3>
        <h5><%# this.Model.ProfileUser.UserName %></h5>

        <p>Age: <%# this.Model.ProfileUser.Age %></p>
        <p>Email: <%# this.Model.ProfileUser.Email %></p>
    </div>
    <asp:LoginView runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Admin">
                <ContentTemplate>
                    <div class="col-md-4">
                        <asp:Button runat="server" ID="MakeSellerBtn" Text="Make seller" OnClick="MakeSellerBtn_Click" CssClass="btn btn-primary" />
                        <asp:Button runat="server" ID="MakeAdminBtn" Text="Make admin" OnClick="MakeAdminBtn_Click" CssClass="btn btn-primary" />
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>
