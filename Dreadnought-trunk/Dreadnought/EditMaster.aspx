<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true" Theme="Dreadnought"
    CodeFile="EditMaster.aspx.cs" Inherits="Dreadnought.Pages.EditMaster" Title="Dreadnought : Edit master"
    ValidateRequest="false" %>

<%@ Register TagPrefix="fckeditorv2" Namespace="FredCK.FCKeditorV2" Assembly="DreadnoughtLib" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    Use this richtext editor to edit the master. You have to edit the ContentPlaceholder
    manually (if you need them changed) by switching to the source view and for example
    add one, which looks something like <em>&lt;contentplaceholder id="ContentPlaceholder"
        runat="server"&gt;&lt;/contentplaceholder&gt;</em> (all other necessary ASP.NET
    parameters will be added automatically, Due to a compatibility issue with the editor,
    you cannot edit the entire HTML of the master, only the content between the &lt;body
    /&gt; tags. Due to another issue you cannot use &lt;asp: /&gt; tags, too.<br />
    <br />
    <fckeditorv2:FCKeditor ID="editor" runat="server" BasePath="" Height="500px" />
    <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" Text="<< Exit" CausesValidation="False" />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save >>" CausesValidation="False" />
    <asp:Button ID="btnSaveAndExit" runat="server" OnClick="btnSaveAndExit_Click" Text="Save &amp; Exit >>" CausesValidation="False" /></asp:Content>
