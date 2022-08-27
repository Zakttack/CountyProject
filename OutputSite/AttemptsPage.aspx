<%@ Page Title="" Language="C#" MasterPageFile="~/OutputSite/Site2.Master" AutoEventWireup="true" CodeBehind="AttemptsPage.aspx.cs" Inherits="CountyProject.AttemptsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView AutoGenerateSelectButton="true" ID="attemptsView" OnRowCommand="SelectAttempt" 
        OnSelectedIndexChanging="ViewAttempt" runat="server"></asp:GridView>
    <asp:Button ID="startNewAttemptButton" OnClick="NewAttempt" Text="Start New Attempt" runat="server"/>
</asp:Content>
