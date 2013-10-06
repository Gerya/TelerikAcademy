<%@ Page Title="Invite user" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InviteUser.aspx.cs" Inherits="EventsSystem.Account.InviteUser" %>

<asp:Content ID="ContentInvite" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" ID="PanelSearch">
        <h3 id="Hs" runat="server">Search for users</h3>
        <asp:TextBox runat="server" MaxLength="100" ID="TextBoxUserSearch"></asp:TextBox>
        <asp:LinkButton runat="server" CssClass="btn btn-success" Text="Search" OnClick="Search_Click"></asp:LinkButton>
        <br />
    </asp:Panel>
    <%--        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
    <asp:Panel ID="PanelUsersResult" runat="server">
        <h3 id="H1" runat="server">All found users</h3>
        <asp:GridView CssClass="allEventsGrid" ID="GridViewUsersResult" runat="server" AllowPaging="True" PageSize="2" AllowSorting="True" AutoGenerateColumns="False"
            DataKeyNames="UserName" SelectMethod="GridViewUsersResult_GetData" OnSelectedIndexChanged="GridViewUsersResult_SelectedIndexChanged" ItemType="EventsSystem.Models.ApplicationUser">
            <Columns>
                <asp:TemplateField HeaderText="Picture">
                    <ItemTemplate>
                        <img src='data:image/jpg;base64,<%# Item.ProfilePicture != null ? Convert.ToBase64String((byte[])Item.ProfilePicture) : string.Empty %>' alt="profile image" height="30" width="30" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UserName" HeaderText="User name" SortExpression="UserName" />
                <asp:CommandField ShowSelectButton="true" SelectText="Invite" HeaderText="" />
            </Columns>
            <EmptyDataTemplate>
                <asp:Literal Text="No existing users were found" runat="server" />
            </EmptyDataTemplate>
        </asp:GridView>
    </asp:Panel>

    <%--            </ContentTemplate>
        </asp:UpdatePanel>--%>
    <asp:Panel ID="PanelInviteUser" runat="server" Visible="false">
        <h3 runat="server">Invite user</h3>
        <asp:Label runat="server" Text="User" AssociatedControlID="TextBoxInvitedUser"></asp:Label>
        <asp:TextBox runat="server" ReadOnly="true" ID="TextBoxInvitedUser"></asp:TextBox>
        <asp:Label ID="LabelMessage" runat="server" Text="Message to User" AssociatedControlID="TextBoxMessage"></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxMessage" TextMode="MultiLine"></asp:TextBox>
        <asp:Label ID="LabelListEvenets" runat="server" Text="Choose Event" AssociatedControlID="DropDownListEvents"></asp:Label>
        <asp:DropDownList runat="server" ID="DropDownListEvents" ItemType="EventsSystem.Models.Event" 
            DataTextField="Title" DataValueField="Id" AppendDataBoundItems="true">
            <asp:ListItem Text="- Select event - " Value="-1" />
        </asp:DropDownList>
        <br />
        <asp:LinkButton runat="server" CssClass="btn btn-success" ID="ButonIvate" Text="Invite User" OnCommand="ButonIvate_Command" />
        <asp:LinkButton ID="LinkButtonCancel" Text="Cancel" runat="server" OnCommand="LinkButtonCancel_Command"  CssClass="btn btn-success" />
    </asp:Panel>
</asp:Content>
