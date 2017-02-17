﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    EnableEventValidation="false"
    CodeBehind="Search.aspx.cs"
    Inherits="CourseProject.Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <asp:SqlDataSource runat="server" ID="ListData" ConnectionString="<%$ ConnectionStrings:AdsHub %>" SelectCommand="SELECT * FROM [Advertisements]"></asp:SqlDataSource>--%>

    <asp:TextBox runat="server" ID="SearchWord" CssClass="form-control inline-block" placeholder="Search..."></asp:TextBox>
    <asp:Button runat="server" ID="SearchBtn" Text="Search" OnClick="SearchBtn_Click" CssClass="btn btn-success" />

    <div class="row">
        <div class="col-md-6">
            <asp:Label runat="server" AssociatedControlID="CitiesDropDown" Text="Choose city:"></asp:Label>
            <asp:DropDownList runat="server" ID="CitiesDropDown"
                DataValueField="Id"
                DataTextField="Name"
                DataSource="<%# this.Model.Cities %>"
                AppendDataBoundItems="true"
                AutoPostBack="true"
                OnSelectedIndexChanged="Options_Changed"
                CssClass="form-control">
                <asp:ListItem Value="-1" Selected="True"> All </asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" AssociatedControlID="CategoriesDropDown" Text="Choose category:"></asp:Label>
            <asp:DropDownList runat="server" ID="CategoriesDropDown"
                DataValueField="Id"
                DataTextField="Name"
                DataSource="<%# this.Model.Categories %>"
                AppendDataBoundItems="true"
                AutoPostBack="true"
                OnSelectedIndexChanged="Options_Changed"
                CssClass="form-control">
                <asp:ListItem Value="-1" Selected="True"> All </asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <asp:Label runat="server" AssociatedControlID="OrderProperties" Text="Order by: "></asp:Label>
            <asp:DropDownList runat="server" ID="OrderProperties" CssClass="form-control"
                AutoPostBack="true"
                OnSelectedIndexChanged="Options_Changed">
                <asp:ListItem Selected="True" Value="Name"> Name </asp:ListItem>
                <asp:ListItem Value="Price"> Price </asp:ListItem>
                <asp:ListItem Value="Places"> Places </asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="jumbotron">
        <asp:ListView runat="server" ID="MainList"
            SelectMethod="MainList_GetData"
            ItemType="CourseProject.Models.Advertisement">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>

            </LayoutTemplate>
            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <h3><a href="/addetails/?id=<%# Item.Id %>"><%#: Item.Name %></a></h3>
                <div>
                    <img class="col-md-3" src="<%#: Item.ImagePathSmall %>" alt="<%#: Item.Name %>" />
                </div>
                <p>Price: <%#: Item.Price %>lv. Expire date: <%#: Item.ExpireDate %></p>
                <p>Places: <%#: Item.Places %>, City: <%#: Item.City.Name %>, Category: <%#: Item.Category.Name %></p>
            </ItemTemplate>
            <EmptyDataTemplate>
                <p class="lead">There are no results to your search!</p>
            </EmptyDataTemplate>
        </asp:ListView>

        <asp:DataPager runat="server" ID="PagerControl" PageSize="5" PagedControlID="MainList">
            <Fields>
                <asp:NumericPagerField />
            </Fields>
        </asp:DataPager>
    </div>

</asp:Content>
