<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true"
    CodeFile="EditPage.aspx.cs" Inherits="Dreadnought.Pages.EditPage" Title="Dreadnought : Edit page"
    ValidateRequest="false" %>

<%@ Register TagPrefix="fckeditorv2" Namespace="FredCK.FCKeditorV2" Assembly="DreadnoughtLib" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    Use this richtext editor to edit the page. You can edit the entire page, or just
    a specific ContentPlaceholder (if your page contains one). To add or remove ContentPlaceholders
    edit the master of this page.<br />
    <br />
    <asp:DropDownList ID="drpLoad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpLoad_SelectedIndexChanged">
    </asp:DropDownList><br />
    <fckeditorv2:FCKeditor ID="editor" runat="server" BasePath="" Height="500px" />
    <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="<< Exit" CausesValidation="False" />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save >>" CausesValidation="False" />
    <asp:Button ID="btnSaveAndExit" runat="server" OnClick="btnSaveAndExit_Click" Text="Save &amp; Exit >>" CausesValidation="False" /></asp:Content>
