<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CourseProject.Web.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home-content">
        <div class="text-center home-description">
            <h1>Welcome to Adshub!</h1>
            <p class="lead">
                Here you can find the best offers in town! Just register and you are ready to book and buy awesome things and go to awesome events. Hurry up, the free places for the best offers' places are limited!
            </p>
        </div>
        <div class="container">
            <h2 class="text-green">Offers ending soon!</h2>
            <div class="jumbotron">
                <asp:ListView runat="server" ID="MainList"
                    DataSource="<%# this.Model.TopAds %>"
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
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
