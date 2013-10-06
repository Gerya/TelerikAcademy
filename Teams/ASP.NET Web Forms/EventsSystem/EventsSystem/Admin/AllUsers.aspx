<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AllUsers.aspx.cs" Inherits="EventsSystem.Admin.AllUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <h2>All users</h2>
            <asp:GridView ID="GridViewAllUsers" runat="server"
                AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                DataKeyNames="Id" PageSize="5"
                ItemType="EventsSystem.Models.ApplicationUser"
                SelectMethod="GridViewAllUsers_GetData"
                DeleteMethod="GridViewAllUsers_DeleteItem"
                OnSelectedIndexChanged="GridViewAllUsers_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="User name" SortExpression="UserName" />
                    <asp:TemplateField HeaderText="Picture">
                        <ItemTemplate>
                            <img src='data:image/jpg;base64,<%# Item.ProfilePicture != null ? Convert.ToBase64String((byte[])Item.ProfilePicture) : string.Empty %>' alt="profile image" height="30" width="30" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="true" SelectText="Delete" HeaderText="" />
                    <asp:CommandField ShowSelectButton="true" SelectText="Events Participating" HeaderText="" />
                </Columns>
            </asp:GridView>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>

<%--    <asp:UpdatePanel ID="UpdatePanelDetailsEvent" runat="server">
        <ContentTemplate>--%>
            <asp:Panel runat="server" ID="PanelDetailsEvent">
                <h2 runat="server">All events user participating</h2>
                <asp:GridView ID="GridViewDetailsEvent" ItemType="EventsSystem.Models.Event" runat="server" DataKeyNames="Id"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Visible="false" CssClass="allEventsGrid"
                    SelectMethod="GridViewDetailsEvent_GetData"
                    PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Description" SortExpression="Title" />
                        <asp:BoundField DataField="Location" HeaderText="Description" SortExpression="Location" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="EventDate" HeaderText="Date of event" SortExpression="EventDate" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="ButtonDelete"
                                    CommandArgument="<%# Item.Id %>"
                                    OnClientClick="return confirm('Do you want to delete?')"
                                    Text="Kick" OnClick="DeleteUserFromEvent" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <%--<ItemTemplate>
             <h1 runat="server" ><%#: Item.Title %></h1> 
                             <p runat="server"><%#: Item.EventDate %></p>
                             <p runat="server"><%#: Item.Description %></p>
                             <p runat="server"><%#: Item.Location %></p>
            
        </ItemTemplate>  --%>
                </asp:GridView>
                <asp:LinkButton CssClass="btn btn-success" ID="ButtonClose" Text="Close" runat="server"
                        OnCommand="ButtonClose_Command" />
            </asp:Panel>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
