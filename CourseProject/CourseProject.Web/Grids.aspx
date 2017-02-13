<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grids.aspx.cs" Inherits="CourseProject.Web.Grids" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource runat="server" ID="CategoriesSource"
        ConnectionString="<%$ ConnectionStrings:AdsHub %>"
        SelectCommand="SELECT c.Id, c.Name,
    (SELECT COUNT(*) FROM Advertisements a WHERE a.CategoryId = c.Id) AS CountAds
FROM Categories c"></asp:SqlDataSource>

    <asp:SqlDataSource runat="server" ID="CitiesSource"
        ConnectionString="<%$ ConnectionStrings:AdsHub %>"
        SelectCommand="SELECT c.Id, c.Name,
    (SELECT COUNT(*) FROM Advertisements a WHERE a.CityId = c.Id) AS CountAds
FROM Cities c"></asp:SqlDataSource>
    <%--  SELECT [Id], [Name] FROM [Categories]--%>

    <div class="col-md-6">
        <h3 class="text-success">Categories</h3>
        <asp:GridView runat="server" ID="CategoriesGrid"
            DataSourceID="CategoriesSource"
            AllowSorting="true"
            AutoGenerateColumns="false"
            CssClass="table table-bordered col-md-6">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="CountAds" HeaderText="All ads in category" SortExpression="CountAds" />
                <asp:HyperLinkField Text="See all ads" DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="~/Search?categoryId={0}" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="col-md-6">
        <h3 class="text-success">Cities</h3>
        <asp:GridView runat="server" ID="CitiesGrid"
            DataSourceID="CitiesSource"
            AllowSorting="true"
            AutoGenerateColumns="false"
            CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="CountAds" HeaderText="All ads in city" SortExpression="CountAds" />
                <asp:HyperLinkField Text="See all ads" DataNavigateUrlFields="Id"
                    DataNavigateUrlFormatString="~/Search?cityId={0}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
