<%@ Page Title="" Language="C#" MasterPageFile="~/InputSite/Site1.Master" AutoEventWireup="true" CodeBehind="CreateAnAccountPage.aspx.cs" Inherits="CountyProject.CreateAnAccountPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome to the County Test Application!!!</h1>
    <p>
        User Name:&nbsp
        <asp:TextBox AutoPostBack="true" ID="userNameInput" OnTextChanged="CheckAttributes" runat="server"></asp:TextBox>
    &nbsp;<asp:Label ID="userNameMessageOutput" runat="server" Text="Enter a User Name!!!"></asp:Label>
    </p>
    <p>
        Password:&nbsp
        <asp:TextBox AutoPostBack="true" ID="passwordInput" OnTextChanged="CheckAttributes" runat="server"></asp:TextBox>
    &nbsp;<asp:Label ID="passwordMessageOutput" runat="server" Text="Enter a password!!!"></asp:Label>
    </p>
    <asp:Button Enabled="false" ID="createAccountButton" OnClick="CreateAccount" Text="Create Account" runat="server" />
</asp:Content>
