<%@ Page Title="" Language="C#" MasterPageFile="~/Cookies.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_03.Cookies.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentLogin" ContentPlaceHolderID="ContentPlaceHolderCookies" runat="server">
    <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
<asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
<asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
</asp:Content>
