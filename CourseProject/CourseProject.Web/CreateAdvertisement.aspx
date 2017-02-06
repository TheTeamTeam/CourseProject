<%@ Page Title="CreateAdvertisement" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAdvertisement.aspx.cs" Inherits="CourseProject.Web.CreateAdvertisement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h3>Create your advertisement</h3>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />              
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Description" CssClass="form-control" />              
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Places" CssClass="col-md-2 control-label">Free places</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Places" CssClass="form-control" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Price" CssClass="form-control" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Categories" CssClass="col-md-2 control-label">Category</asp:Label>
             <div class="col-md-10">
                <asp:DropDownList runat="server" ID="Categories" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
             </div>
            <%--<div class="col-md-10">
                <asp:TextBox runat="server" ID="Category" CssClass="form-control" />
            </div>--%>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Cities" CssClass="col-md-2 control-label">City</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="Cities" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                <%--<asp:TextBox runat="server" ID="Cities" CssClass="form-control"/>--%>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateAdvertisement_Click" Text="Create" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
