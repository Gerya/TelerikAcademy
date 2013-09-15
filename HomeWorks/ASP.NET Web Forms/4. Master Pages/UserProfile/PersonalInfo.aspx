<%@ Page Title="Personal info" Language="C#" MasterPageFile="~/UserProfile.Master" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="UserProfile.PersonalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHeader" runat="server">
    <h1>Personal Info</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContainer" runat="server">
    <h2>My personality</h2>
    <ul>
        <li><b>Full name:</b> Katalina Milkova Mihova</li>
        <li><b>Date of birth:</b> 20.12.1980</li>
        <li><b>Address:</b> Bulgaria, Sofia, kv. Mladost 1a</li>
        <li><b>Phone number:</b> 0899999999</li>
        <li><b>Marital:</b> Divorced</li>
        <li><b>Race:</b> Bulgarian</li>
        <li><b>Ethnicity:</b> Christian</li>
        <li><b>Drivers category:</b> B</li>
        <li><b>Emergency Contacts:</b> 0899999999</li>
    </ul>
</asp:Content>
