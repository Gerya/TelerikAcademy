<%@ Page Title="All events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllEvents.aspx.cs" Inherits="EventsSystem.Account.AllEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <%--    <asp:EntityDataSource ID="EntityDataSourceEvents" runat="server" ConnectionString="name=EventsSystemEntities" 
        DefaultContainerName="EventsSystemEntities" EntitySetName="Events">
    </asp:EntityDataSource>--%>
    <div class="row">
<%--        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <h2 runat="server">All Events</h2>
                <asp:GridView CssClass="allEventsGrid span12" ID="GridViewAllEvents" runat="server" AllowPaging="True" PageSize="5" AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="Id" SelectMethod="GridViewAllEvents_GetData" OnSelectedIndexChanged="GridViewAllEvents_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="False" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                        <asp:BoundField DataField="EventDate" HeaderText="EventDate" SortExpression="EventDate" />
                        <asp:CommandField ShowSelectButton="True" SelectText="View Event Details" />
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Literal Text="There is no events currently in the system" runat="server" />
                    </EmptyDataTemplate>                    
                </asp:GridView>
     <%--       </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
    <%--    <asp:EntityDataSource ID="EntityDataSourceEventDetails" runat="server" ConnectionString="name=EventsSystemEntities" 
        DefaultContainerName="EventsSystemEntities" EnableFlattening="False" EntitySetName="Events"
         Include="Users" Where="it.Id=@Id">
          <WhereParameters>
            <asp:ControlParameter Name="Id" Type="Int32"
                ControlID="GridViewAllEvents" />
        </WhereParameters>
    </asp:EntityDataSource>--%>
<%--    <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
            <asp:ListView ID="ListViewDetailsEvent" runat="server" ItemType="EventsSystem.Models.Event"
                DataKeyNames="Id">
                <ItemTemplate>
                    <h3 class="joinEventTitle" runat="server"><%#: Item.Title %></h3>
                    <p runat="server">Event date - <em><%#: Item.EventDate %></em></p>
                    <p runat="server">Description - <em><%#: Item.Description %></em></p>
                    <p runat="server">Event location - <em><%#: Item.Location %></em></p>
                    <ul class="joinedUsers">
                        <asp:Repeater ID="RepeaterDetails" runat="server" ItemType="EventsSystem.Models.ApplicationUser" DataSource="<%# Item.Participants %>">
                            <HeaderTemplate>
                                <asp:Literal runat="server"><h4>Users who joined the event</h4></asp:Literal>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <img src='data:image/jpg;base64,<%# Item.ProfilePicture != null ? Convert.ToBase64String((byte[])Item.ProfilePicture) : string.Empty %>' alt="profile image" height="20" width="20" />
                                    <asp:Label ID="IdLabel" runat="server" Text='<%#: Item.UserName %>' />
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <asp:LinkButton CssClass="btn btn-success" ID="ButonJoin" Text="Join event" CommandArgument="<%# Item.Id %>" runat="server"
                        OnCommand="ButonJoin_Click" />
                    <asp:LinkButton ID="LinkButtonDeleteEntry" Text="Leave event" runat="server"
                        CommandArgument="<%# Item.Id %>"
                        OnCommand="LinkButtonDeleteEntry_Command" OnClientClick="return confirm('Are you sure?');" CssClass="btn btn-danger" />
                </ItemTemplate>
            </asp:ListView>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
