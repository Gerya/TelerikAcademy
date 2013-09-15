<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloASP.NET.aspx.cs" Inherits="HelloPage.HelloASP_NET" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            height: 18px;
            width: 338px;
        }

        #TextName {
            width: 262px;
        }
    </style>
</head>
<body>
    <div id="wrapper">
        <h3>Hello give me your name</h3>
        <form id="form1" runat="server">
            <asp:Label ID="LabelName" runat="server" Text="Your Name" AssociatedControlID="TextName"></asp:Label>
            <input id="TextName" runat="server" type="text" />
                <asp:Button ID="ButtonGreet" runat="server" OnClick="ButtonGreet_Click" Text="Greet" />
            <br />
            <asp:TextBox ID="TextBoxResponse" runat="server" Height="16px" ReadOnly="True" Width="278px"></asp:TextBox>
            <p>
                &nbsp;</p>
        </form>
    </div>
</body>
</html>
