<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SamplePage.aspx.cs" Inherits="_04.JavaScriptInjection.SamplePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonOK" runat="server" OnClick="ButtonOK_Click" Text="OK" />
        <br />
        <asp:Button ID="ButtonClickMe" runat="server" OnClick="ButtonClickMe_Click" Text="Click Me!" />
        <asp:Label ID="LabelClicks" runat="server"></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
