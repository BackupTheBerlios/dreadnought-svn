<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true" Theme="Dreadnought"
    CodeFile="DeleteUser.aspx.cs" Inherits="Dreadnought.Pages.DeleteUser" Title="Dreadnought : Delete user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    You are about to delete the page
    <asp:Literal ID="lblUser" runat="server" Text="<i> - user is unspecified -</i>"></asp:Literal>. Are you sure you want to do this? It cannot be undone.<br />
    <br />
    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete this user >>" /></asp:Content>
