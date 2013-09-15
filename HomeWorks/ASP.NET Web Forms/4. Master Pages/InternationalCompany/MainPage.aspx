<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="bg">
    <h2>Здравейте изберете си език</h2>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Bulgarian/BGHome.aspx" 
        Text="Bulgarian" CssClass="bg-icon"/>
        </div>
    <div id="eng">
    <h2>Hello choose lenguage</h2>
            
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/English/EngHome.aspx"
         Text="English" CssClass="eng-icon"/>
        </div>
</asp:Content>
