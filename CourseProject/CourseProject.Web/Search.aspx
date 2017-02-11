<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="CourseProject.Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <asp:TextBox runat="server" ID="SearchWord" CssClass="form-control inline-block" placeholder="Search..."></asp:TextBox>
        <asp:Button runat="server" ID="SearchBtn" Text="Search" OnClick="SearchBtn_Click" CssClass="btn btn-success" />

        <div class="jumbotron">

            <asp:ListView runat="server" ID="ListView1"
                DataSource="<%# this.Model.Advertisements %>"
                ItemType="CourseProject.Models.Advertisement">
                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <h3><a href="/addetails/?id=<%# Item.Id %>"><%#: Item.Name %></a></h3>
                    <div>
                        <img class="col-md-3" src="<%# Item.ImagePath%>" alt="<%#: Item.Name %>" />
                    </div>
                    <p>Price: <%#: Item.Price %>lv.</p>
                </ItemTemplate>
            </asp:ListView>
        </div>

</asp:Content>
