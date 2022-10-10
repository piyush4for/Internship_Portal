<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="interns.aspx.cs" Inherits="Intern.interns" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   	<script type="text/javascript">

		function a() 
		{
				var modal = document.getElementById('myModal');
				// Get the <span> element that closes the modal
				var span = document.getElementsByClassName("close")[0];
				// When the user clicks the button, open the modal 
				modal.style.display = "block";
				// When the user clicks on <span> (x), close the modal
				span.onclick = function() {
					modal.style.display = "none";
				}
		}
		
       </script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

	<div id="myModal" class="modal">
		<div class="modal-content">
			<span class="close">&times;</span>
			<h2 id="modalH" runat="server"></h2>
			<p id="modalP" runat="server"></p>			
		</div>
	</div>

	<div style="padding:10px;">
		<asp:Label ID="Label_welcome" runat="server" Text="Welcome " ForeColor="#0081c9"></asp:Label>
	 	<asp:Button ID="ButtonLogout"  runat="server" CssClass="w3-btn w3-blue" Text="LogOut" style="float:right;"  Visible="True" onClick="ButtonLogout_Click" CausesValidation="False" UseSubmitBehavior="False" ></asp:Button>
	 	<asp:Button ID="HButton" runat="server" CssClass="w3-btn w3-blue" Text="Home" style="float:right;margin-right: 10px;"  Visible="True" onClick="H_Click" CausesValidation="False" UseSubmitBehavior="False"></asp:Button>
	 	<asp:Button ID="RButton" runat="server" CssClass="w3-btn w3-blue" Text="Your Requests" style="float:right;margin-right: 10px;"  Visible="True" onClick="R_Click" CausesValidation="False" UseSubmitBehavior="False" ></asp:Button>
		<asp:Button ID="NButton" runat="server" CssClass="w3-btn w3-blue" Text="New Request" style="float:right;margin-right: 10px;"  Visible="True" onClick="N_Click" CausesValidation="False" UseSubmitBehavior="False" ></asp:Button>
		<asp:Button ID="AButton" runat="server" CssClass="w3-btn w3-blue" Text="Admin" style="float:right;margin-right: 10px;"  Visible="False" onClick="A_Click" CausesValidation="False" UseSubmitBehavior="False" ></asp:Button>
		
	 	<br/><hr/>
            
		<h2 id="tnastatus" runat="server">My Interns</h2>       <hr/>

	</div>

 

</asp:Content>
