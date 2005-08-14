<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true" Theme="Dreadnought"
    CodeFile="CreateMaster.aspx.cs" Inherits="Dreadnought.Pages.CreateMaster" Title="Dreadnought : Create master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    Use this form to create a new master. You have to specify the entire relative path
    starting from the root of your application directory; this usually looks something
    like <em>directory/subdirectory/master</em>. The file extension <em>.master</em> is
    added automatically.<br />
    <br />
    <asp:TextBox ID="txtMaster" runat="server" Width="200px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="rfvPage" runat="server" Display="Dynamic" ErrorMessage="Please specify the entire relative path of the new master." ControlToValidate="txtMaster"></asp:RequiredFieldValidator><br />
    <asp:Button
            ID="btnCreate" runat="server" Text="Create >>" OnClick="btnCreate_Click" /><br />
    <br />
    <asp:CheckBox ID="chkRedirect" runat="server" Checked="True" Text="Redirect after creation to edit the new master?" /></asp:Content>
