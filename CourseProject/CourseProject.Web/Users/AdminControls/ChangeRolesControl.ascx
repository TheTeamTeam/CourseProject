<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangeRolesControl.ascx.cs" Inherits="CourseProject.Web.Users.AdminControls.ChangeRolesControl" %>

 <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="col-md-4">
                                    <%-- TODO: Have one button for change --%>
                                    <asp:Button runat="server" Visible="<%# !this.Model.IsSeller %>" ID="MakeSellerBtn" Text="Make seller" OnClick="MakeSellerBtn_Click" CssClass="btn btn-primary" />
                                    <asp:Button runat="server" Visible="<%# this.Model.IsSeller %>" ID="RemoveSellerBtn" Text="Remove as seller" OnClick="RemoveSellerBtn_Click" CssClass="btn btn-danger" />
                                    <asp:Button runat="server" Visible="<%# !this.Model.IsAdmin %>" ID="MakeAdminBtn" Text="Make admin" OnClick="MakeAdminBtn_Click" CssClass="btn btn-primary" />
                                    <asp:Button runat="server" Visible="<%# this.Model.IsAdmin %>" ID="RemoveAdminBtn" Text="Remove as admin" OnClick="RemoveAdminBtn_Click" CssClass="btn btn-danger" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>