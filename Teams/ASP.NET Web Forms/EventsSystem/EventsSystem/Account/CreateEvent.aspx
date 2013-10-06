<%@ Page Title="Create event" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="EventsSystem.Account.CreateEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
    </header>
<%--    <div class="createEventForm row">
        Title: 
    <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
        <br />
        Description: 
    <textarea id="TextAreaDescription" cols="20" name="S1" rows="2" runat="server"></textarea>
        <br />
        Location
    <asp:TextBox ID="TextBoxLocation" runat="server"></asp:TextBox>
        <br />
        Date Of Event: 
    <asp:TextBox ID="TextBoxDateOfEvent" placeholder="dd-MM-YYYY" runat="server"></asp:TextBox>
        <br />
        <asp:LinkButton CssClass="btn btn-success" Text="Create" runat="server"
            OnClick="Create_Click" />--%>
    <asp:ValidationSummary runat="server" ShowValidationErrors="true" ShowModelStateErrors="true" CssClass="text-error" />
    <asp:FormView runat="server" ID="FormViewCreateEvent" 
        ItemType="EventsSystem.Models.Event" 
        DefaultMode="Insert"
        InsertMethod="FormViewCreateEvent_InsertItem" RenderOuterTable="false">
        <InsertItemTemplate>
            <fieldset>
            <ol>
                <asp:DynamicEntity runat="server" Mode="Insert" ></asp:DynamicEntity>
            </ol>

            <asp:Button Text="Create" CommandName="Insert" runat="server" CssClass="btn" />
            <asp:Button ID="ButtonCancelEvent" Text="Cancel" CausesValidation="false" runat="server"
                 CssClass="btn" OnClick="ButtonCancelEvent_Click" />
            </fieldset>
        </InsertItemTemplate>
    </asp:FormView>
    <%--</div>--%>
</asp:Content>
