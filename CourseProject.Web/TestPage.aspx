<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="CourseProject.Web.TestPage" %>
<%@ Register Src="~/Test/TestControl.ascx" TagPrefix="uc" TagName="TestControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:TestControl runat="server" />
</asp:Content>
