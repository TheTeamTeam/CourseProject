<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CourseProject.Web.Users.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%#: this.Model.ProfileUser.FirstName %> <%#: this.Model.ProfileUser.LastName %></h3>
    <h5><%#: this.Model.ProfileUser.UserName %></h5>

    <p>Age: <%#: this.Model.ProfileUser.Age %></p>
    <p>Email: <%#: this.Model.ProfileUser.Email %></p>

    <%-- Control for listing ? --%>

    <asp:LoginView runat="server">
        <RoleGroups>
            <asp:RoleGroup Roles="Admin,Seller">
                <ContentTemplate>
                    <h2>Your Ads!</h2>
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
                                <p class="text-green">You have not ads yet!</p>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>

    <div class="row">
        <div class="col-md-5 jumbotron">
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
                        <img class="col-md-3" src="<%#: Item.ImagePathSmall%>" alt="<%#: Item.Name %>" />
                    </div>
                    <p>Price: <%#: Item.Price %>lv.</p>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p class="text-green">You have no upcoming events!</p>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>

        <div class="col-md-6 col-md-offset-1 jumbotron">
            <h3>Saved</h3>
            <asp:UpdatePanel runat="server" ID="SavedAdsPanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:ListView runat="server" ID="ListView1"
                        DataSource="<%# this.Model.ProfileUser.SavedAds %>"
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
                            <asp:Button runat="server" ID="RemoveFromSaved" Text="Remove From Saved" data-id="<%# Item.Id %>" OnClick="RemoveFromSaved_Click" CssClass="btn btn-default" />
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <p class="text-green">You have not saved any ads yet!</p>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
