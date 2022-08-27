<%@ Page Title="" Language="C#" MasterPageFile="~/OutputSite/Site2.Master" AutoEventWireup="true" CodeBehind="AttemptViewPage.aspx.cs" Inherits="CountyProject.AttemptViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>State Name:&nbsp&nbsp<asp:Label ID="stateNameLabel" runat="server"></asp:Label></p>
    <p>Attempt Date:&nbsp&nbsp<asp:Label ID="attemptDateLabel" runat="server"></asp:Label></p>
    <p>
        <asp:GridView ID="questionsView" runat="server"></asp:GridView>
    </p>
    <p>Score:&nbsp&nbsp<asp:Label ID="scoreLabel" runat="server"></asp:Label></p>
    <asp:Button ID="backButton" OnClick="GoBackToAttempts" Text="Back To Attempts" runat="server"/>
</asp:Content>
