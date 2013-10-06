<%@ Page Title="My events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyEvents.aspx.cs" Inherits="EventsSystem.Account.MyEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Events created by me</h2>
    <asp:ValidationSummary runat="server" ShowValidationErrors="true" ShowModelStateErrors="true" CssClass="text-error" />
<%--    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <asp:GridView ID="GridViewCreatedEvents" runat="server"
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                DataKeyNames="Id" PageSize="5" SelectMethod="GridViewCreatedEvents_GetData"
                UpdateMethod="GridViewCreatedEvents_UpdateItem" OnSelectedIndexChanged="GridViewCreatedEvents_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Descrition" />
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                    <asp:BoundField DataField="EventDate" HeaderText="Date Of Event" SortExpression="EventDate" />
                    <asp:CommandField ShowEditButton="true" SelectText="Edit" HeaderText="" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Participants" HeaderText="" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Literal Text="There is no events created by me currently in the system" runat="server" />
                </EmptyDataTemplate>
            </asp:GridView>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <h2>Events I have been joined</h2>
<%--    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <asp:GridView ID="GridViewJoined" runat="server"
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                DataKeyNames="Id" PageSize="5" SelectMethod="GridViewJoined_GetData"
                OnSelectedIndexChanged="GridViewJoined_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Descrition" />
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                    <asp:BoundField DataField="EventDate" HeaderText="Date Of Event" SortExpression="EventDate" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Details" HeaderText="" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Literal Text="There is no events currently that I am participating in" runat="server" />
                </EmptyDataTemplate>
            </asp:GridView>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
        <a class="btn btn-success createEventButton" href="CreateEvent">Create Event</a>
<%--    <asp:UpdatePanel runat="server" ID="UpdatePanelUsers">
        <%-- <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridViewCreatedEvents" EventName="SelectedIndexChanged" />
        </Triggers>--%>
        <%--<ContentTemplate>--%>
            <asp:Panel ID="PanelParticipants" runat="server">
                <h3 runat="server" class="joinEventTitle">Participants</h3>
                <asp:ListView runat="server" ID="ListViewParticipants" ItemType="EventsSystem.Models.ApplicationUser" DataKeyNames="Id">
                    <ItemTemplate>
                        <p class="participantsUsers">
                            <img src='data:image/jpg;base64,<%# Item.ProfilePicture != null ? Convert.ToBase64String((byte[])Item.ProfilePicture) : string.Empty %>' alt="profile image" height="40" width="40" />
                            <asp:Label ID="Label1" Text="<%#: Item.UserName %>" runat="server" />
                            <asp:LinkButton ID="LinkButton1" CommandName="Kick" CommandArgument="<%# Item.Id %>" OnCommand="Kick_Command"
                                Text="Kick" runat="server" CssClass="btn btn-danger"/>
                        </p>
                    </ItemTemplate>
                </asp:ListView>
                <asp:LinkButton CssClass="btn btn-success" ID="ButtonClosePanel" Text="Close" runat="server"
                    OnCommand="ButtonClosePanel_Command" />
            </asp:Panel>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
<%--    <asp:UpdatePanel ID="UpdatePanelDetaiils" runat="server">
        <ContentTemplate>--%>
            <asp:ListView ID="ListViewDetailsEvent" runat="server" ItemType="EventsSystem.Models.Event"
                DataKeyNames="Id">
                <ItemTemplate>
                    <h3 id="H1" class="joinEventTitle" runat="server"><%#: Item.Title %></h3>
                    <p id="P1" runat="server">Event date - <em><%#: Item.EventDate %></em></p>
                    <p id="P2" runat="server">Description - <em><%#: Item.Description %></em></p>
                    <p id="P3" runat="server">Event location - <em><%#: Item.Location %></em></p>
                    <ul class="joinedUsers">
                        <asp:Repeater ID="RepeaterDetails" runat="server" ItemType="EventsSystem.Models.ApplicationUser" DataSource="<%# Item.Participants %>">
                            <HeaderTemplate>
                                <asp:Literal ID="Literal1" runat="server"><h4>Users who joined the event</h4></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <img src='data:image/jpg;base64,<%# Item.ProfilePicture != null ? Convert.ToBase64String((byte[])Item.ProfilePicture) : string.Empty %>' alt="profile image" height="20" width="20" />
                                    <asp:Label ID="IdLabel" runat="server" Text='<%#: Item.UserName %>' />
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <asp:LinkButton CssClass="btn btn-danger" ID="ButonLeave" Text="Leave event" CommandArgument="<%# Item.Id %>" runat="server"
                        OnCommand="ButonLeave_Command" />
                    <asp:LinkButton CssClass="btn btn-success" ID="ButtonClose" Text="Close" runat="server"
                        OnCommand="ButtonClose_Command" />
                </ItemTemplate>
            </asp:ListView>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
