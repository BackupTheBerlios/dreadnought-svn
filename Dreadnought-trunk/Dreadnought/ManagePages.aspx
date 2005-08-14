<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true" Theme="Dreadnought"
    CodeFile="ManagePages.aspx.cs" Inherits="Dreadnought.Pages.ManagePages" Title="Dreadnought : Manage pages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    You can manage all pages of this Dreadnought installation here.<br />
    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create a new page >>" /><br />
    <br />
    <asp:ListBox ID="lstPages" runat="server" Height="200px"></asp:ListBox><br />
    &nbsp;<asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit >>" />
    <asp:Button ID="btnEditDetails" runat="server" OnClick="btnEditDetails_Click" Text="Edit details >>" />
    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete >>" /><br />
</asp:Content>
