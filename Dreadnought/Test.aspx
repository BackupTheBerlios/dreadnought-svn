<%@ Page Language="C#" Inherits="Dreadnought.Page" MasterPageFile="~/Test.master" Title="powered by Dreadnought" Theme="Dreadnought" %>
<script type="text/C#" runat="server">
	protected override void OnPreInit(object sender, EventArgs e) {
		date = new DateTime(632594469771421200);
		author = "";
	}
</script>



<asp:Content ID="Content_ContentPlaceholder" ContentPlaceHolderID="ContentPlaceholder" Runat="server">
<p>hallo?</p>
</asp:Content>