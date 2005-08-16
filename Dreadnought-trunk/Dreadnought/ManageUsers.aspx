<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true" Theme="Dreadnought"
    CodeFile="ManageUsers.aspx.cs" Inherits="Dreadnought.Pages.ManageUsers" Title="Dreadnought : Manage users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    You can manage all users of this Dreadnought installation here.<br />
    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create a new user >>" /><br />
    <br />
    <asp:ListBox ID="lstUsers" runat="server" Height="200px"></asp:ListBox><br />
    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit >>" />&nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete >>" /><br />
</asp:Content>
