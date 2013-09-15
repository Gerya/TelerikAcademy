<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarForm.aspx.cs" Inherits="_01.CarForm.CarForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="LabelProducer" runat="server" Text="Producer"></asp:Label>
            <asp:DropDownList ID="DropDownListProducer" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListProducer_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelModel" runat="server" Text="Model"></asp:Label>
            <asp:DropDownList ID="DropDownListModel" runat="server">
            </asp:DropDownList>

            <br />
            <asp:CheckBoxList ID="CheckBoxListExtras" runat="server">
            </asp:CheckBoxList>
            <asp:RadioButtonList ID="RadioButtonListEngineType" runat="server" RepeatDirection="Horizontal">
            </asp:RadioButtonList>
            <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit" />
            <br />
            <asp:Literal ID="LiteralUserChoice" runat="server"></asp:Literal>

        </div>
    </form>
</body>
</html>
