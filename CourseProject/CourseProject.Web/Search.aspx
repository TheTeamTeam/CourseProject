<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    EnableEventValidation="false"
    CodeBehind="Search.aspx.cs"
    Inherits="CourseProject.Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <asp:SqlDataSource runat="server" ID="ListData" ConnectionString="<%$ ConnectionStrings:AdsHub %>" SelectCommand="SELECT * FROM [Advertisements]"></asp:SqlDataSource>--%>

    <asp:TextBox runat="server" ID="SearchWord" CssClass="form-control inline-block" placeholder="Search..."></asp:TextBox>
    <asp:Button runat="server" ID="SearchBtn" Text="Search" OnClick="SearchBtn_Click" CssClass="btn btn-success" />

    <div class="row">
        <div class="col-md-6">
            <asp:Label runat="server" AssociatedControlID="CitiesDropDown" Text="Choose city:"></asp:Label>
            <asp:DropDownList runat="server" ID="CitiesDropDown"
                DataValueField="Id"
                DataTextField="Name"
                DataSource="<%# this.Model.Cities %>"
                AppendDataBoundItems="true"
                AutoPostBack="true"
                OnSelectedIndexChanged="Options_Changed"
                CssClass="form-control">
                <asp:ListItem Value="-1" Selected="True"> All </asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6">
            <asp:Label runat="server" AssociatedControlID="CategoriesDropDown" Text="Choose category:"></asp:Label>
            <asp:DropDownList runat="server" ID="CategoriesDropDown"
                DataValueField="Id"
                DataTextField="Name"
                DataSource="<%# this.Model.Categories %>"
                AppendDataBoundItems="true"
                AutoPostBack="true"
                OnSelectedIndexChanged="Options_Changed"
                CssClass="form-control">
                <asp:ListItem Value="-1" Selected="True"> All </asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <asp:Label runat="server" AssociatedControlID="OrderProperties" Text="Order by: "></asp:Label>
            <asp:DropDownList runat="server" ID="OrderProperties" CssClass="form-control"
                AutoPostBack="true"
                OnSelectedIndexChanged="Options_Changed">
                <asp:ListItem Selected="True" Value="Name"> Name </asp:ListItem>
                <asp:ListItem Value="Price"> Price </asp:ListItem>
                <asp:ListItem Value="Places"> Places </asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-3 col-md-offset-3">
            <%-- TODO: Mask --%>

            <asp:Label runat="server" AssociatedControlID="PageSize" Text="Items on page:"></asp:Label>
            <asp:TextBox runat="server" ID="PageSize" CssClass="form-control" TextMode="Number" Text="5" AutoPostBack="true" OnTextChanged="Options_Changed"></asp:TextBox>
        </div>
    </div>

    <div class="row top-margin">
        <p class="lead">Results: <%# this.Model.Count %></p>
    </div>
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
                    <img height="50px" class="col-md-3" src="<%#: Item.ImagePath %>" alt="<%#: Item.Name %>" />
                </div>
                <p>Price: <%#: Item.Price %>lv. Expire date: <%#: Item.ExpireDate %></p>
                <p>Places: <%#: Item.Places %>, City: <%#: Item.City.Name %>, Category: <%#: Item.Category.Name %></p>
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
