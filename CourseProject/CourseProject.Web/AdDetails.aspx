<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdDetails.aspx.cs" Inherits="CourseProject.Web.AdDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3> <%#: this.Model.Advertisement.Name %></h3>
    <div>
        <p class="details-description col-md-6"> <%#: this.Model.Advertisement.Description %> </p> 
        <img class="col-md-6" src="<%#this.Model.Advertisement.ImagePath%>" alt="<%#: this.Model.Advertisement.Name %>"/>
    </div>
    <p>Price: <b><%#: this.Model.Advertisement.Price %>lv.</b></p>
    <p>Free places: <b><%#: this.Model.Advertisement.Places %></b></p>
    <asp:Button runat="server" ID="BookButton" Text="Book" OnClick="BookButton_Click" />
    <asp:Button runat="server" ID="SaveButton" Text="Save Ad" OnClick="SaveButton_Click"/>
</asp:Content>
