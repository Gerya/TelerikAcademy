<%@ Page Title="" Language="C#" MasterPageFile="~/Cookies.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_03.Cookies.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentRegister" ContentPlaceHolderID="ContentPlaceHolderCookies" runat="server">
    <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
<asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="LabelNickName" runat="server" Text="Nickname"></asp:Label>
    <asp:TextBox ID="TextBoxNickName" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="LabelPasswor" runat="server" Text="Password"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
    <br />
    <br />
<asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" />
&nbsp;
</asp:Content>
