<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true" Theme="Dreadnought"
    CodeFile="DeleteMaster.aspx.cs" Inherits="Dreadnought.Pages.DeleteMaster" Title="Dreadnought : Delete master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    You are about to delete the master
    <asp:Literal ID="lblPage" runat="server" Text="<i> - master is unspecified -</i>"></asp:Literal>. Are you sure you want to do this? It cannot be undone.<br />
    <br />
    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete this master >>" /></asp:Content>
