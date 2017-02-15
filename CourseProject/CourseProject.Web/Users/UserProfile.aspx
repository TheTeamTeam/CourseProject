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
                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="col-md-4">
                                <%-- TODO: Have one button for change --%>
                                <asp:Button runat="server" Visible="<%# !this.Model.IsSeller %>" ID="MakeSellerBtn" Text="Make seller" OnClick="MakeSellerBtn_Click" CssClass="btn btn-primary" />
                                <asp:Button runat="server" Visible="<%# this.Model.IsSeller %>" ID="RemoveSellerBtn" Text="Remove as seller" OnClick="RemoveSellerBtn_Click" CssClass="btn btn-danger" />
                                <asp:Button runat="server" Visible="<%# !this.Model.IsAdmin %>" ID="MakeAdminBtn" Text="Make admin" OnClick="MakeAdminBtn_Click" CssClass="btn btn-primary" />
                                <asp:Button runat="server" Visible="<%# this.Model.IsAdmin %>" ID="RemoveAdminBtn" Text="Remove as admin" OnClick="RemoveAdminBtn_Click" CssClass="btn btn-danger" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>
