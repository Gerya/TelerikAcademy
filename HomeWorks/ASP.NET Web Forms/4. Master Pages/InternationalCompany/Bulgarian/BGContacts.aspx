<%@ Page Title="" Language="C#" MasterPageFile="~/Bulgarian/BGPage.master" AutoEventWireup="true" CodeBehind="BGContacts.aspx.cs" %>

<asp:Content ID="ContactsContent" ContentPlaceHolderID="ContentPlaceHolderBGArea" runat="server">
    <div id="info">
        <h2>Нашите контакти</h2>
        <ul>
            <li><b>Държава:</b> България</li>
            <li><b>Град:</b> София</li>
            <li><b>Пощенски Код:</b> 1217</li>
            <li><b>Улица:</b> "Хан Крум" N 22</li>
            <li><b>Телефон:</b> 02 9722222</li>
            <li><b>Мобилен:</b> 0899 999 999</li>
            <li><b>Факс:</b> 02 9722221</li>
            <li><b>Имейл:</b> office@youda.com</li>
        </ul>
    </div>
    <div id="map"></div>
</asp:Content>
