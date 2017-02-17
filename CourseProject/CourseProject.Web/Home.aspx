<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CourseProject.Web.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="home-content">
        <div class="text-center home-description">
            <h1>Welcome to Adshub!</h1>
            <p class="lead">
                Here you can find the best offers in town! Just register and you are ready to book and buy awesome things and go to awesome events. Hurry up, the free places for the best offers' places are limited!
            </p>
        </div>
    <%--<div class="home-line"></div>--%>
        <div class="container">
        <h2 class="text-green">Our top offers!</h2>
        <div class="jumbotron">
            <asp:ListView runat="server" ID="MainList"
                DataSource="<%# this.Model.TopAds %>"
                ItemType="CourseProject.Models.Advertisement">
                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <h3><a href="/addetails/?id=<%# Item.Id %>"><%#: Item.Name %></a></h3>
                    <div>
                        <img class="col-md-3" src="<%#: Item.ImagePathSmall %>" alt="<%#: Item.Name %>" />
                    </div>
                    <p>Price: <%#: Item.Price %>lv.</p>
                    <p>Places: <%#: Item.Places %>, City: <%#: Item.City.Name %>, Category: <%#: Item.Category.Name %></p>
                </ItemTemplate>
            </asp:ListView>
        </div>
            </div>
    </div>
</asp:Content>
