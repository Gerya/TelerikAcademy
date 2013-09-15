<%@ Page Title="" Language="C#" MasterPageFile="~/Cookies.Master" AutoEventWireup="true" CodeBehind="Hidden.aspx.cs" Inherits="_03.Cookies.Hidden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentHiddenPage" ContentPlaceHolderID="ContentPlaceHolderCookies" runat="server">
    <h1>You are logged in</h1>

    <h2>
        <asp:Label ID="LabelCookie" runat="server" Text="Label"></asp:Label>
    </h2>
    <h2>You have one minute to see our secret page</h2>
</asp:Content>
