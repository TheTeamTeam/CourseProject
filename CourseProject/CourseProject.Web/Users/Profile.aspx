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
                                <div class="row">
                            <div class="col-md-4">
                                <img src="<%#: Item.ImagePathSmall %>" alt="<%#: Item.Name %>" />
                            </div>
                            <div class ="ad-display-info col-md-8">
                                <h2 class="no-top-margin"><a href="/addetails/?id=<%# Item.Id %>"><%#: Item.Name %></a></h2>
                                <div>Price: <%#: Item.Price %> lv.</div>
                                <div>Places: <%#: Item.Places %></div> 
                                <div>City: <%#: Item.City.Name %> </div>
                                <div>Category: <%#: Item.Category.Name %></div>
                            </div>
                        </div>
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
        <div class="col-md-5 jumbotron small-padding">
            <h2>Upcoming</h2>
            <asp:ListView runat="server" ID="UpcomingList"
                DataSource="<%# this.Model.ProfileUser.UpcomingAds %>"
                ItemType="CourseProject.Models.Advertisement">
                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <div class="row">
                            <div class="col-md-4">
                                <img src="<%#: Item.ImagePathSmall %>" alt="<%#: Item.Name %>" />
                            </div>
                            <div class ="ad-display-info col-md-offset-2 col-md-6">
                                <h3 class="no-top-margin"><a href="/addetails/?id=<%# Item.Id %>"><%#: Item.Name %></a></h3>
                                <div>Price: <%#: Item.Price %> lv.</div>
                                <div>City: <%#: Item.City.Name %> </div>
                                <div>Category: <%#: Item.Category.Name %></div>
                            </div>
                        </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p class="text-green">You have no upcoming events!</p>
                </EmptyDataTemplate>
            </asp:ListView>
        </div>

        <div class="col-md-6 col-md-offset-1 jumbotron small-padding">
            <h2>Saved</h2>
            <asp:UpdatePanel runat="server" ID="SavedAdsPanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:ListView runat="server" ID="ListView1"                        
                        DataSource="<%# this.Model.ProfileUser.SavedAds %>"
                        ItemType="CourseProject.Models.Advertisement">
                        <ItemSeparatorTemplate>
                            <hr />
                        </ItemSeparatorTemplate>
                        <ItemTemplate>
                            <div class="row">
                            <div class="col-md-4">
                                <img src="<%#: Item.ImagePathSmall %>" alt="<%#: Item.Name %>" />
                            </div>
                            <div class ="ad-display-info col-md-offset-1 col-md-6">
                                <h3 class="no-top-margin"><a href="/addetails/?id=<%# Item.Id %>"><%#: Item.Name %></a></h3>
                                <div>Price: <%#: Item.Price %> lv.</div>
                                <div>City: <%#: Item.City.Name %> </div>
                                <div>Category: <%#: Item.Category.Name %></div>
                            <asp:Button runat="server" ID="RemoveFromSaved" Text="Remove From Saved" data-id="<%# Item.Id %>" OnClick="RemoveFromSaved_Click" CssClass="btn btn-default" />
                            </div>
                        </div>
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
