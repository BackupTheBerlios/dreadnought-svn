<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true" Theme="Dreadnought"
    CodeFile="EditPageDetails.aspx.cs" Inherits="Dreadnought.Pages.EditPageDetails" Title="Dreadnought : Edit page details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    Use this form to edit the details of a page. Remember, if you change the master
    of a page and don't make sure that the ContentPlaceholders fit to this new master,
    exceptions may occurr.<br />
    <br />
    Master:
    <asp:DropDownList ID="drpMaster" runat="server">
    </asp:DropDownList><br />
    Theme:
    <asp:DropDownList ID="drpTheme" runat="server">
    </asp:DropDownList><br />
    Title:&nbsp;
    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnEdit" runat="server" Text="Save >>" OnClick="btnEdit_Click" /></asp:Content>
