<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_02.SessionStorage.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formView" runat="server">
        <div>

            <asp:TextBox ID="TextBoxInputFiled" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonAddText" runat="server" Text="Add text" OnClick="ButtonAddText_Click" />
        </div>
        <p>
            <asp:Label ID="LabelSessionStorage" runat="server" Text="Add text"></asp:Label>
        </p>
    </form>
</body>
</html>
