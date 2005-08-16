<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true" Theme="Dreadnought"
    CodeFile="Logon.aspx.cs" Inherits="Dreadnought.Pages.Logon" Title="Dreadnought : Logon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    You are about to delete the page
    <asp:Literal ID="lblPage" runat="server" Text="<i> - page is unspecified -</i>"></asp:Literal>. Are you sure you want to do this? It cannot be undone.<br />
    <br />
    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete this page >>" /></asp:Content>
