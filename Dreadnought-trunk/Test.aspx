<%@ Page Language="C#" Inherits="Dreadnought.Page" MasterPageFile="~/Test.master" Title="powered by Dreadnought" Theme="Dreadnought" %>
<script type="text/C#" runat="server">
	protected override void OnPreInit(object sender, EventArgs e) {
		date = new DateTime(632596487519389680);
		author = "";
	}
</script>

Welcome to Dreadnought, the slim and fast ASP.NET Content Management System. <br />Visit <a href="http://www.sachsenhofer.com" target="_blank">www.sachsenhofer.com</a> for more information.