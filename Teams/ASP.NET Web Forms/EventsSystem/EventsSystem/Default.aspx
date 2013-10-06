<%@ Page Title="Latest events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EventsSystem._Default" %>

<%@ Register Src="~/Controls/CountdownControl/CountdownControl.ascx" TagPrefix="uc1" TagName="CountdownControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Latest future events</h2>
    <div class="row">
        <asp:Repeater ID="LatestEvents" runat="server" ItemType="EventsSystem.Models.Event">
            <ItemTemplate>
                <div class="span4">
                    <h3><%#: Item.Title %></h3>
                    <h5>Event Date: <%#: Item.EventDate %></h5>
                    <p>Description: <%#: Item.Description %></p>
                    <p>Time to event: <uc1:CountdownControl runat="server" id="CountdownControl" EndDate="<%#: Item.EventDate %>" ControlId="<%#: Item.Id %>" /></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Literal ID="NoEvents" Text="No events added yet" runat="server" Visible="false" />
    </div>
</asp:Content>
