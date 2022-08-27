<%@ Page Title="" Language="C#" MasterPageFile="~/OutputSite/Site2.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="CountyProject.TestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1> <asp:Label ID="stateNameLabel" runat="server"></asp:Label>&nbsp State Test</h1>
    <table id="testTable" runat="server"></table>
    <asp:Button ID="submitButton" OnClick="SubmitTest" Text="Submit" runat="server" />
</asp:Content>
