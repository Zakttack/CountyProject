<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PasswordResetPage.aspx.cs" Inherits="CountyApplication.PasswordResetPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="userNameControls" runat="server" visible="true">
        <p>
            User Name: &nbsp
            <asp:DropDownList AutoPostBack="true" ID="userNames" OnTextChanged="UserSelected" runat="server">
            </asp:DropDownList>
        </p>
    </div>
    <div id="passwordResetControls" runat="server" visible="false">
        <p>
            New Password: &nbsp
            <asp:TextBox AutoPostBack="true" ID="newPasswordInput" OnTextChanged="CheckPassword" runat="server">
            </asp:TextBox> &nbsp
            <asp:Label ID="passwordMessageOutput" Text="Enter a password!!!" runat="server"></asp:Label> &nbsp
            <asp:Button ID="undoSelectionButton" OnClick="UndoSelection" Text="Undo Selection" runat="server" /> &nbsp
            <asp:Button ID="resetPasswordButton" OnClick="ResetPassword" Text="Reset Password" runat="server" />
        </p>
    </div>
    <asp:Button ID="backToLoginButton" OnClick="GoBack" Text="Back To Login" runat="server"/>
</asp:Content>
