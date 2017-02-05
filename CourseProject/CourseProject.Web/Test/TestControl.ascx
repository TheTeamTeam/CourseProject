<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestControl.ascx.cs" Inherits="CourseProject.Web.Test.TestControl" %>
<h1>Test control is here!</h1>
<asp:TextBox runat="server" ID="NameBox" ></asp:TextBox>
<asp:Button runat="server" ID="Search" OnClick="Search_Click" Text="Search"/>
<p><%# Model.Person.FirstName %></p>
<p><%# Model.Person.Age %></p>
<asp:Literal runat="server" ID="UsernamesLiteral"></asp:Literal>