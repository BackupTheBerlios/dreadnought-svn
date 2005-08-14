<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true"
    CodeFile="CreatePage.aspx.cs" Inherits="Dreadnought.Pages.CreatePage" Title="Dreadnought : Create page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    Use this form to create a new page. You have to specify the entire relative path
    starting from the root of your application directory; this usually looks something
    like <em>directory/subdirectory/page</em>. The file extension <em>.aspx</em> is
    added automatically.<br />
    <br />
    <asp:TextBox ID="txtPage" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="rfvPage" runat="server" Display="Dynamic" ErrorMessage="Please specify the entire relative path of the new page." ControlToValidate="txtPage"></asp:RequiredFieldValidator><br />
    <asp:Button
            ID="btnCreate" runat="server" Text="Create >>" OnClick="btnCreate_Click" /><br />
    <br />
    <asp:CheckBox ID="chkRedirect" runat="server" Checked="True" Text="Redirect after creation to edit the new page?" /></asp:Content>
