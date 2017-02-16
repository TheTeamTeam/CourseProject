<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdDetails.aspx.cs" Inherits="CourseProject.Web.AdDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3> <%#: this.Model.Advertisement.Name %></h3>
    <div>
        <p class="details-description col-md-6"> <%#: this.Model.Advertisement.Description %> </p> 
        <img class="col-md-6" src="<%#this.Model.Advertisement.ImagePath%>" alt="<%#: this.Model.Advertisement.Name %>"/>
    </div>
    <p>by <a href="/users/<%#: this.Model.Advertisement.Seller.UserName %>"><%#: this.Model.Advertisement.Seller.UserName %></a></p>
    <p>Price: <strong><%#: this.Model.Advertisement.Price %>lv.</strong></p>
    <p>Expire Date: <strong><%#: this.Model.Advertisement.ExpireDate %></strong></p>
    <p>Free places: <strong><%#: this.Model.Advertisement.Places %></strong></p>
    <p>Book 
    <asp:TextBox runat="server" ID="BookCount" 
        CssClass="book-count" TextMode="Number" 
        Text="1">
    </asp:TextBox> places 
    <asp:Button runat="server" ID="BookButton" Text="Book" OnClick="BookButton_Click" />
    </p> 
    <asp:Button runat="server" ID="SaveButton" Text="Save Ad" Visible="<%# !this.Model.IsSaved %>" OnClick="SaveButton_Click"/>
</asp:Content>
