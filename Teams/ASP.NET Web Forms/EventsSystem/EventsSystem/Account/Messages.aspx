<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="EventsSystem.Account.Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
         <Triggers>
             <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
        </Triggers>
        <ContentTemplate>   
<%--            The time now is: 
                <%= DateTime.Now.ToString("hh:mm:ss") %>--%>
    <h2 id="H1" runat="server">Your messages</h2>
    <asp:GridView CssClass="allEventsGrid" ID="GridViewAllMessages" runat="server" 
        AllowPaging="True" PageSize="5" AllowSorting="True" AutoGenerateColumns="False"
        DataKeyNames="Id" SelectMethod="GridViewAllMessages_GetData" 
        OnSelectedIndexChanged="GridViewAllMessages_SelectedIndexChanged" 
        ItemType="EventsSystem.Models.Invite"
        DeleteMethod="GridViewAllMessages_DeleteItem"
        OnSorting="GridViewAllMessages_Sorting">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="False" />
            <asp:BoundField DataField="Sender.UserName" HeaderText="Sender" SortExpression="Sender.UserName"/>
            <asp:BoundField DataField="Event.Title" HeaderText="Event title" SortExpression="Event.Title" />
            <asp:BoundField DataField="InviteStatus.InviteStatus" HeaderText="Invite Status" SortExpression="InviteStatus.InviteStatus"/>
            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="CreatedDate" />
            <asp:CommandField ShowSelectButton="True" SelectText="Read" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" />
        </Columns>
        <EmptyDataTemplate>
            <asp:Literal ID="Literal1" Text="You do not have messages" runat="server" />
        </EmptyDataTemplate>
    </asp:GridView>
   
        <asp:Timer ID="TimerTimeRefresh" OnTick="TimerTimeRefresh_Tick" runat="Server" Interval="100000" />
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel runat="server">
        <ContentTemplate>
     <asp:Panel ID="PanelMessagesDetails" runat="server">
        <asp:ListView runat="server" ID="ListViewDetails" ItemType="EventsSystem.Models.Invite" DataKeyNames="Id">
            <ItemTemplate>
                <h3 id="H2" class="joinEventTitle" runat="server"><%#: Item.Sender.UserName %></h3>
                <p id="P1" runat="server">Message: <em><%#: Item.Message %></em></p>
                <p id="P2" runat="server">Date: <em><%#: Item.CreatedDate %></em></p>
                <h3 id="H3" class="joinEventTitle" runat="server">Event info:</h3>
                <p id="P3" runat="server">Title: <em><%#: Item.Event.Title %></em></p>
                <p id="P4" runat="server">Date: <em><%#: Item.Event.EventDate %></em></p>
                <p id="P5" runat="server">Location: <em><%#: Item.Event.Location %></em></p>
                <p id="P6" runat="server">Description: <em><%#: Item.Event.Description %></em></p>
                <ul class="joinedUsers">
                    <asp:Repeater ID="RepeaterDetails" runat="server" ItemType="EventsSystem.Models.ApplicationUser" DataSource="<%# Item.Event.Participants%>">
                        <HeaderTemplate>
                            <asp:Literal ID="Literal2" runat="server"><h4>Users who joined the event</h4></asp:Literal>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <img src='data:image/jpg;base64,<%# Item.ProfilePicture != null ? Convert.ToBase64String((byte[])Item.ProfilePicture) : string.Empty %>' alt="profile image" height="20" width="20" />
                                <asp:Label ID="IdLabel" runat="server" Text='<%#: Item.UserName %>' />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <asp:LinkButton ID="ButonJoin" Text="Join event" CommandArgument="<%# Item.Event.Id %>" runat="server" OnCommand="ButonJoin_Command" CssClass="btn btn-success" />
                <asp:LinkButton ID="LinkButtonCancel" Text="Close" runat="server" OnCommand="LinkButtonCancel_Command" CssClass="btn btn-success" />
            </ItemTemplate>
        </asp:ListView>
    </asp:Panel>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
