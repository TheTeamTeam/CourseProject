<%@ Page Title="CreateAdvertisement" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAdvertisement.aspx.cs" Inherits="CourseProject.Web.CreateAdvertisement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h3>Create your advertisement</h3>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" />  
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" ControlToValidate="Name" 
                    runat="server" Display="Dynamic" ErrorMessage="Name field is required!" ForeColor="Red" EnableClientScript="False"/>            
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Description" CssClass="form-control" /> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" ControlToValidate="Description" 
                    runat="server" ErrorMessage="Description field is required!" ForeColor="Red" EnableClientScript="False"/>             
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Places" CssClass="col-md-2 control-label">Free places</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Places" CssClass="form-control" />
                <asp:RangeValidator runat="server" Type="Integer" MinimumValue="0" MaximumValue="1000" ControlToValidate="Places" 
                    ForeColor="Red" ErrorMessage="Value must be a whole number between 0 and 1000" />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Price" CssClass="form-control" />
                 <asp:RangeValidator runat="server" Type="Currency" MinimumValue="0" MaximumValue="1000" ControlToValidate="Price" 
                    ForeColor="Red" ErrorMessage="Value must be a whole number between 0 and 1000" />
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
