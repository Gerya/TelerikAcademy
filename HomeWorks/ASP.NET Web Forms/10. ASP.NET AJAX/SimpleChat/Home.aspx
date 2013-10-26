<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SimpleChat.Home" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" />
        <div>
            <asp:UpdatePanel ID="UpdatePanelMessages" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
                </Triggers>
                <ContentTemplate>
                    <asp:Timer ID="TimerTimeRefresh" runat="server" Interval="500" OnTick="TimerTimeRefresh_Tick" />

                    <asp:ListView ID="ListViewMessages" runat="server" DataKeyNames="Id" DataSourceID="EntityDataSourceMessages" InsertItemPosition="LastItem" OnItemInserting="ListViewMessages_ItemInserting">
                        <AlternatingItemTemplate>
                            <span style="background-color: #FFF8DC;">Contents:
                <asp:Label ID="ContentsLabel" runat="server" Text='<%#: Eval("Contents") %>' />
                                <br />
                                Author:
                <asp:Label ID="AuthorLabel" runat="server" Text='<%#: Eval("Author") %>' />
                                <br />
                                Timestamp:
                <asp:Label ID="TimestampLabel" runat="server" Text='<%#: Eval("Timestamp") %>' />
                                <br />
                                <br />
                            </span>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <span>No data was returned.</span>
                        </EmptyDataTemplate>
                        <InsertItemTemplate>
                            <span style="">Contents:
                <asp:TextBox ID="ContentsTextBox" runat="server" Text='<%# Bind("Contents") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContents" ForeColor="Red" runat="server" Display="Dynamic" ControlToValidate="ContentsTextBox"
                                    ErrorMessage="Contents is required.">
                                </asp:RequiredFieldValidator>
                                <br />
                                Author:
                <asp:TextBox ID="AuthorTextBox" runat="server" Text='<%# Bind("Author") %>' />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAuthor" ForeColor="Red" runat="server" Display="Dynamic" ControlToValidate="AuthorTextBox"
                                    ErrorMessage="Author is required.">
                                </asp:RequiredFieldValidator>
                                <br />
                                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                                <br />
                                <br />
                            </span>
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <span style="background-color: #DCDCDC; color: #000000;">Contents:
                <asp:Label ID="ContentsLabel" runat="server" Text='<%#: Eval("Contents") %>' />
                                <br />
                                Author:
                <asp:Label ID="AuthorLabel" runat="server" Text='<%#: Eval("Author") %>' />
                                <br />
                                Timestamp:
                <asp:Label ID="TimestampLabel" runat="server" Text='<%#: Eval("Timestamp") %>' />
                                <br />
                                <br />
                            </span>
                        </ItemTemplate>
                        <LayoutTemplate>
                            <div id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <span runat="server" id="itemPlaceholder" />
                            </div>
                            <div style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                                <asp:DataPager ID="DataPager1" runat="server">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </div>
                        </LayoutTemplate>
                    </asp:ListView>
                    <asp:EntityDataSource ID="EntityDataSourceMessages" runat="server" ConnectionString="name=SimpleChatEntities" DefaultContainerName="SimpleChatEntities" EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Messages" EntityTypeFilter="Message">
                    </asp:EntityDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />

            <asp:Label ID="LabelAuthorError" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="LabelContentsError" runat="server" ForeColor="Red"></asp:Label>

        </div>
    </form>
</body>
</html>
