<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdDetails.aspx.cs" Inherits="CourseProject.Web.AdDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3> <%#: this.Model.Advertisement.Name %></h3>
    <div>
        <p class="details-description col-md-6"> <%#: this.Model.Advertisement.Description %> </p> 
        <img class="col-md-6" src="<%#this.Model.Advertisement.ImagePathBig%>" alt="<%#: this.Model.Advertisement.Name %>"/>
    </div>
    <p>by <a href="/users/<%#: this.Model.Advertisement.Seller.UserName %>"><%#: this.Model.Advertisement.Seller.UserName %></a></p>
    <p>Price: <strong><%#: this.Model.Advertisement.Price %>lv.</strong></p>
    <p>Expire Date: <strong><%#: this.Model.Advertisement.ExpireDate %></strong></p>
    <p>Free places: <strong><%#: this.Model.Advertisement.Places %></strong></p>
    <asp:Button runat="server" ID="BookButton" Text="Book" 
        Visible="<%# this.Model.BookButtonVisible && this.Model.Advertisement.Places > 0 %>" OnClick="BookButton_Click" />
    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender" runat="server" DisplayModalPopupID="mpe" TargetControlID="BookButton"/>
    <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="PopUpPnl" TargetControlID="BookButton"
        OkControlID = "btnYes" CancelControlID ="btnCancel">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="PopUpPnl" runat="server" CssClass="confirm-popup" Style="display: none">      
        <p><strong>Confirmation</strong></p>                  
        <p>Are you sure you want to book the offer? </p>
        <p>You will not be able to cancel the booking afterwards!</p>
        <asp:Button ID="btnYes" runat="server" Text="Yes" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </asp:Panel>
    <asp:Button runat="server" ID="SaveButton" Text="Save Ad" 
        Visible="<%# this.Model.SaveButtonVisible %>" OnClick="SaveButton_Click"/>
</asp:Content>
