<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UserRegistration.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User registration</title>
    <link href="Content/bootstrap/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap/bootstrap-theme.css" rel="stylesheet" />
</head>
<body class="well">
    <form id="form1" runat="server" class="container">
        <div class="control-group">
            <asp:Label ID="LabelUsername" CssClass="control-label" AssociatedControlID="TextBoxUsername" runat="server">Enter username</asp:Label>
            <div class="controls">
                <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="input-group-lg" ValidationGroup="LogonInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" runat="server" ControlToValidate="TextBoxUsername"
                    CssClass="text-error" ErrorMessage="The user name field is required." Display="None" />
            </div>
        </div>

        <div class="control-group">
            <asp:Label ID="LabelPassword" CssClass="control-label" AssociatedControlID="TextBoxPassword" runat="server">Enter password</asp:Label>
            <div class="controls">
                <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" CssClass="input-group-lg" ValidationGroup="LogonInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="TextBoxPassword"
                    ErrorMessage="The password field is required." Display="None" />
            </div>
        </div>

        <div class="control-group">
            <asp:Label ID="LabelReenterPassword" CssClass="control-label" runat="server">Re-enter password</asp:Label>
            <div class="controls">
                <asp:TextBox ID="TextBoxRepeatPassword" TextMode="Password" runat="server" CssClass="input-group-lg" ValidationGroup="LogonInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRepeatPassword" runat="server" ControlToValidate="TextBoxRepeatPassword"
                    CssClass="text-error" ErrorMessage="Please repeat password" Display="None" />
                <asp:CompareValidator ID="CompareValidatorPasswords" runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxRepeatPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match!" />
            </div>
        </div>

        <div class="control-group">
            <asp:Label ID="LabelEmail" CssClass="control-label" runat="server">Email</asp:Label>
            <div class="controls">
                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="input-group-lg" ValidationGroup="LogonInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TextBoxEmail"
                    ErrorMessage="Please provide email address" Display="None" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                    ControlToValidate="TextBoxEmail"
                    ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}"
                    ErrorMessage="Please enter a valid email!" Display="Dynamic" CssClass="text-danger">
                </asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="control-group">
            <asp:Label ID="LabelAge" CssClass="control-label" runat="server">Age</asp:Label>
            <div class="controls">
                <asp:TextBox ID="TextBoxAge" runat="server" CssClass="input-group-lg" ValidationGroup="PersonalInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" runat="server" ControlToValidate="TextBoxAge"
                    ErrorMessage="Please provide your age" Display="None" />
                <asp:RangeValidator ID="RangeValidatorAge" runat="server" CssClass="text-danger"
                    ControlToValidate="TextBoxAge" Type="Integer"
                    ErrorMessage="You are not at proper age to enter this website!"
                    MaximumValue="81" MinimumValue="18"></asp:RangeValidator>
            </div>
        </div>

        <div class="control-group">
            <asp:Label ID="LabelPhoneNumber" CssClass="control-label" runat="server">Phone number (e.g. +359xxxxxxxxx)</asp:Label>
            <div class="controls">
                <asp:TextBox ID="TextBoxPhoneNumber" AutoCompleteType="Cellular" runat="server" CssClass="input-group-lg" ValidationGroup="PersonalInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" runat="server" ControlToValidate="TextBoxPhoneNumber"
                    CssClass="text-error" ErrorMessage="Please provide your phone number" Display="None" />
                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidatorPhone"
                    ValidationExpression="^\+[359]{3}[8]{1}[2-9]{2}[0-9]{6}$"
                    CssClass="text-danger" ControlToValidate="TextBoxPhoneNumber"
                    ErrorMessage="Please provide a valid BG mobile phone number"
                    Display="Dynamic"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="control-group">
            <asp:Label ID="LabelAddress" CssClass="control-label" runat="server">Address</asp:Label>
            <div class="controls">
                <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="input-group-lg" ValidationGroup="AddressInfo"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="TextBoxAddress"
                    CssClass="text-error" ErrorMessage="Please provide your address" Display="None" />
            </div>
        </div>

        <div class="control-group"></div>
        <asp:Label runat="server" CssClass="control-label">Accept</asp:Label>
        <div class="controls">
            <asp:CheckBox ID="CheckBoxAccept" runat="server" CssClass="checkbox-inline" ValidationGroup="LogonInfo" />
            <asp:CustomValidator runat="server" ID="CheckBoxRequired"
                OnServerValidate="CheckBoxRequired_ServerValidate" CssClass="text-danger">You must select this box to proceed.</asp:CustomValidator>
        </div>
        <asp:Button ID="ButtonSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="ButtonSubmit_Click"></asp:Button>

        <asp:ValidationSummary
            ID="ValidationSummaryControl"
            DisplayMode="List"
            HeaderText="Please complete all required fields"
            CssClass="text-warning"
            runat="server" />
    </form>
</body>
</html>
