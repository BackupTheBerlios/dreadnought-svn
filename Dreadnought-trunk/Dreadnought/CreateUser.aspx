<%@ Page Language="C#" MasterPageFile="~/Dreadnought/Dreadnought.master" AutoEventWireup="true" Theme="Dreadnought"
    CodeFile="CreateUser.aspx.cs" Inherits="Dreadnought.Pages.CreateUser" Title="Dreadnought : Create user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    Use this form to create a new user. Remember that the name has to be unique. The password gets hashed, you cannot retreive it later.<br />
    <br />
    Name:
    <asp:TextBox ID="txtName" runat="server" Width="120px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
        ID="rfvPage" runat="server" Display="Dynamic" ErrorMessage="Please specify a username." ControlToValidate="txtName"></asp:RequiredFieldValidator><br />
    Password:
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="120px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
        Display="Dynamic" ErrorMessage="Please specify a password."></asp:RequiredFieldValidator><br />
    Level:
    <asp:DropDownList ID="drpLevel" runat="server">
        <asp:ListItem>Anonymous</asp:ListItem>
        <asp:ListItem Selected="True">User</asp:ListItem>
        <asp:ListItem>Administrator</asp:ListItem>
    </asp:DropDownList><br />
    <br />
    <asp:Button
            ID="btnCreate" runat="server" Text="Create >>" OnClick="btnCreate_Click" /></asp:Content>
