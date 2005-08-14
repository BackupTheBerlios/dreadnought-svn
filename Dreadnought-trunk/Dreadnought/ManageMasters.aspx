<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true" Theme="Dreadnought"
    CodeFile="ManageMasters.aspx.cs" Inherits="Dreadnought.Pages.ManageMasters" Title="Dreadnought : Manage masters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    You can manage all masters of this Dreadnought installation here.<br />
    <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create a new master >>" /><br />
    <br />
    <asp:ListBox ID="lstMasters" runat="server" Height="200px"></asp:ListBox><br />
    &nbsp;<asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit >>" />&nbsp;
    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete >>" /><br />
</asp:Content>
