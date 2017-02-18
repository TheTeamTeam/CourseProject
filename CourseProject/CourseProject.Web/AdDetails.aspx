<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdDetails.aspx.cs" Inherits="CourseProject.Web.AdDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="AdForm"
        SelectMethod="AdForm_GetItem"
        DeleteMethod="AdForm_DeleteItem"
        UpdateMethod="AdForm_UpdateItem"
        DataKeyNames="Id"
        ItemType="CourseProject.Models.Advertisement">
        <ItemTemplate>
            <h3><%#: Item.Name %></h3>
            <div>
                <p class="details-description col-md-6"><%#: Item.Description %> </p>
                <img class="col-md-6" src="<%#Item.ImagePathBig %>" alt="<%#: Item.Name %>" />
            </div>
            <p>City: <strong><%#: Item.City.Name %></strong></p>
            <p>Category: <strong><%#: Item.Category.Name %></strong></p>
            <p>by <a href="/users/<%#: Item.Seller.UserName %>"><%#: Item.Seller.UserName %></a></p>
            <p>Price: <strong><%#: Item.Price %>lv.</strong></p>
            <p>Expire Date: <strong><%#: Item.ExpireDate %></strong></p>
            <p>Free places: <strong><%#: Item.Places %></strong></p>
            <asp:LoginView runat="server">
                <RoleGroups>
                    <asp:RoleGroup Roles="Admin">
                        <ContentTemplate>
                            <asp:Button runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-warning" />
                            <asp:Button runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger" />
                        </ContentTemplate>
                    </asp:RoleGroup>
                </RoleGroups>
            </asp:LoginView>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:Label runat="server" AssociatedControlID="EditName" Text="Names:"></asp:Label>
            <asp:TextBox runat="server" ID="EditName" Text="<%# BindItem.Name %>" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="EditName" 
                    CssClass="text-danger" ValidationExpression="^[\s\S]{3,20}$" Text="Minimum 3 and maximum 20 characters required." />

            <asp:Label runat="server" AssociatedControlID="EditDescription" Text="Description:"></asp:Label>
            <asp:TextBox runat="server" ID="EditDescription" Text="<%# BindItem.Description %>" TextMode="MultiLine" Rows="7" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="EditDescription" 
                    CssClass="text-danger" ValidationExpression="^[\s\S]{3,500}$" Text="Minimum 3 and maximum 500 characters required."  />

            <asp:Label runat="server" AssociatedControlID="EditPrice" Text="Price:"></asp:Label>
            <asp:TextBox runat="server" ID="EditPrice" Text="<%# BindItem.Price %>" CssClass="form-control"></asp:TextBox>
            <asp:RangeValidator runat="server" ControlToValidate="EditPrice" Type="Double" MinimumValue="0" MaximumValue="1000"
                CssClass="text-danger" ErrorMessage="Price must be a number between 0 and 1000."></asp:RangeValidator>
            <br />
            <asp:Label runat="server" AssociatedControlID="EditPlaces" Text="Places:"></asp:Label>
            <asp:TextBox runat="server" ID="EditPlaces" Text="<%# BindItem.Places %>" CssClass="form-control"></asp:TextBox>
            <asp:RangeValidator runat="server" ControlToValidate="EditPlaces" Type="Integer" MinimumValue="0" MaximumValue="1000"
                CssClass="text-danger" ErrorMessage="Places must be an integer number between 0 and 1000."></asp:RangeValidator>

            <p>by <a href="/users/<%#: Item.Seller.UserName %>"><%#: Item.Seller.UserName %></a></p>

            <asp:Button runat="server" Text="Update" CommandName="Update" CssClass="btn btn-success" />
            <asp:Button runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-danger" />
        </EditItemTemplate>
    </asp:FormView>

    <%-- Buttons outside of the view because the ajaxtoolkit wouldn't work --%>
    <br />
    <asp:Button runat="server" ID="BookButton" Text="Book"
        Visible="<%# this.Model.BookButtonVisible && this.Model.Advertisement.Places > 0 %>" OnClick="BookButton_Click" CssClass="btn btn-default"/>

    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender" runat="server" DisplayModalPopupID="mpe" TargetControlID="BookButton" />
    <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" PopupControlID="PopUpPnl" TargetControlID="BookButton"
        OkControlID="btnYes" CancelControlID="btnCancel">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="PopUpPnl" runat="server" CssClass="confirm-popup" Style="display: none">
        <p><strong>Confirmation</strong></p>
        <p>Are you sure you want to book the offer? </p>
        <p>You will not be able to cancel the booking afterwards!</p>
        <asp:Button ID="btnYes" runat="server" Text="Yes" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </asp:Panel>
    <asp:Button runat="server" ID="SaveButton" Text="Save Ad"
        Visible="<%# this.Model.SaveButtonVisible %>" OnClick="SaveButton_Click" CssClass="btn btn-default"/>
</asp:Content>
