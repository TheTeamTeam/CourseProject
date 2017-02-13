<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    EnableEventValidation="false"
    CodeBehind="Search.aspx.cs" 
    Inherits="CourseProject.Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <asp:SqlDataSource runat="server" ID="ListData" ConnectionString="<%$ ConnectionStrings:AdsHub %>" SelectCommand="SELECT * FROM [Advertisements]"></asp:SqlDataSource>--%>

    <asp:TextBox runat="server" ID="SearchWord" CssClass="form-control inline-block" placeholder="Search..."></asp:TextBox>
    <asp:Button runat="server" ID="SearchBtn" Text="Search" OnClick="SearchBtn_Click" CssClass="btn btn-success" />
    <asp:DropDownList runat="server" ID="OrderProperties" CssClass="form-control">
        <asp:ListItem Selected="True" Value="Name"> Name </asp:ListItem>
        <asp:ListItem Value="Price"> Price </asp:ListItem>
        <asp:ListItem Value="Places"> Places </asp:ListItem>
    </asp:DropDownList>
    <%-- TODO: Mask --%>
    <asp:TextBox runat="server" ID="PageSize" CssClass="form-control"  TextMode="Number" Text="5"></asp:TextBox>

    <div class="jumbotron">
        <%--DataSourceID="ListData" --%>

        <asp:ListView runat="server" ID="MainList"
            DataSource="<%# this.Model.Advertisements %>"
            ItemType="CourseProject.Models.Advertisement">
            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <h3><a href="/addetails/?id=<%# Item.Id %>"><%#: Item.Name %></a></h3>
                <div>
                    <img height="50px" class="col-md-3" src="<%# Item.ImagePath %>" alt="<%#: Item.Name %>" />
                </div>
                <p>Price: <%#: Item.Price %>lv.</p>
            </ItemTemplate>
        </asp:ListView>


        <%--<asp:DataPager runat="server" ID="PagerControl" PageSize="5" PagedControlID="MainList">
            <Fields>
                <asp:NumericPagerField />
            </Fields>
        </asp:DataPager>--%>

        <asp:Repeater runat="server" ID="PageControl">
            <ItemTemplate>
                <asp:Button Text="<%# Container.ItemIndex + 1 %>" runat="server" OnClick="ChangePage_Click" CssClass="btn btn-success" />
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
