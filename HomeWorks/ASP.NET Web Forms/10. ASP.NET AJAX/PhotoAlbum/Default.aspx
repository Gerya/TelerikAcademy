<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoAlbum.Default" %>

<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ajaxtoolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxtoolkit:ToolkitScriptManager>
        <h1>My Slideshow</h1>

        <asp:Image ID="Image1" runat="server" Height="250" />
        <ajaxtoolkit:SlideShowExtender ID="Image1_SlideShowExtender" runat="server" 
            Enabled="True" ImageDescriptionLabelID="txtDesc"
            SlideShowServiceMethod="GetSlides" AutoPlay="true" 
            NextButtonID="btnNext" PreviousButtonID="btnPrev"
            TargetControlID="Image1">
        </ajaxtoolkit:SlideShowExtender>
        <br />
        <asp:Button ID="btnPrev" runat="server" Text="<" />
        <asp:Button ID="btnNext" runat="server" Text=">" />
        <asp:Label ID="txtDesc" runat="server" Text="Label" />
    </form>
</body>
</html>
