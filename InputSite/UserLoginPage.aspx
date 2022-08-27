<%@ Page Title="" Language="C#" MasterPageFile="~/InputSite/Site1.Master" AutoEventWireup="true" CodeBehind="UserLoginPage.aspx.cs" Inherits="CountyProject.UserLoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Login ID="userLogin" OnAuthenticate="CheckUser" OnLoggingIn="Login" OnLoginError="LoginError" 
            OnLoggedIn="OpenMainPage" runat="server"></asp:Login>
    </p>
</asp:Content>
