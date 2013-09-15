<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XmlTreeView.aspx.cs" Inherits="_06.TreeViewFromXml.XmlTreeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formTreeView" runat="server">
    <div>
    
        <asp:TreeView ID="TreeViewXml" runat="server" ImageSet="Arrows" OnSelectedNodeChanged="TreeViewXml_SelectedNodeChanged">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
    
    </div>
        <p>
            <asp:Literal ID="LiteralDisplay" runat="server"></asp:Literal>
        </p>
    </form>
</body>
</html>
