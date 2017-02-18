<%@ Page Title="CreateAdvertisement" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAdvertisement.aspx.cs" Inherits="CourseProject.Web.CreateAdvertisement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h3>Create your advertisement</h3>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="The title field is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Description" CssClass="form-control" /> 
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Description"
                    CssClass="text-danger" ErrorMessage="The description field is required." />            
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Places" CssClass="col-md-2 control-label">Free places</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Places" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Places"
                    CssClass="text-danger" ErrorMessage="The places field is required." />
                <asp:RangeValidator runat="server" ControlToValidate="Places" Type="Integer" MinimumValue="0" MaximumValue="1000" 
                    CssClass="text-danger" ErrorMessage="Places must be an integer number between 0 and 1000."></asp:RangeValidator>
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Price" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Places"
                    CssClass="text-danger" ErrorMessage="The price field is required." />
                 <asp:RangeValidator runat="server" ControlToValidate="Price" Type="Double" MinimumValue="0" MaximumValue="1000" 
                    CssClass="text-danger" ErrorMessage="Price must be a number between 0 and 1000."></asp:RangeValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ExpireDate" CssClass="col-md-2 control-label">Expire Date</asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="ExpireDate" CssClass="form-control" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="ExpireDate"  Format="MM/dd/yyyy"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ExpireDate"
                    CssClass="text-danger" ErrorMessage="The date field is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Categories" CssClass="col-md-2 control-label">Category</asp:Label>
             <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Categories" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
             </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Cities" CssClass="col-md-2 control-label">City</asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Cities" CssClass="form-control" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Image" CssClass="col-md-2 control-label">Image</asp:Label>
            <div class="col-md-3">
                <asp:FileUpload runat="server" ID="Image" CssClass="form-control"></asp:FileUpload>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateAdvertisement_Click" Text="Create" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
