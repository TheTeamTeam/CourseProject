<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sitemap.aspx.cs" Inherits="CourseProject.Web.Sitemap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>A map of our site</h3>
    <asp:TreeView ID="Navigation" runat="server" SkipLinkText=""
        EnableViewState="False"
        DataSourceID="SiteMapDataSource" StaticDisplayLevels="2"
        StaticHoverStyle-Font-Underline="true"
        Font-Size="Large"
        ForeColor="Black"
        Orientation="Vertical">
    </asp:TreeView>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" ShowStartingNode="false" />

</asp:Content>
