<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" EnableEventValidation = "false" Inherits="Intern.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   	<script type="text/javascript">
           $(document).ready(function () {
               $("#TextBoxPG").autocomplete({
                   source: function (request, response) {
                       var param = { EmpNo: $('#TextBoxPG').val() };
                       $.ajax({
                           url: "request.aspx/getEmployees",
                           data: JSON.stringify(param),
                           dataType: "json",
                           type: "POST",
                           contentType: "application/json; charset=utf-8",
                           dataFilter: function (data) { return data; },
                           success: function (data) {
                               console.log(JSON.stringify(data));
                               response($.map(data.d, function (item) {
                                   return {
                                       value: item.EmpDbKey + ", " + item.EmpName + ", " + item.EmpDesg + " (" + item.EmpDept + ")"
                                   }
                               }))
                           },
                           error: function (XMLHttpRequest, textStatus, errorThrown) {
                               var err = eval("(" + XMLHttpRequest.responseText + ")");
                               alert(err.Message)

                           }
                       });
                   },
                   select: function (e, i) {
                       $("#TextBoxPG").val(i.item.val);
                   },
                   change: function (e, ui) {
                       if (!(ui.item)) e.target.value = "";
                   },
                   minLength: 4
               });
           });
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
            
            <asp:Label ID="Label2" runat="server" Text="Labe2"></asp:Label>
           <div >
				<label class="w3-text-blue"><b>Preferred Guide (POWERGRID Employee)</b></label>
				<asp:TextBox ID="TextBoxPG" CssClass="w3-input w3-border" placeholder="Enter 5-digit Employee Number" runat="server"  Visible="True" Required="false" ClientIdMode="Static" ></asp:TextBox><br />
			</div>

            <div style = "text-align: right ; margin-right:41%";>

		</div>
            <div class="w3-second">
				<label class="w3-text-blue"><b>Remarks</b></label>
				<asp:TextBox ID="TextBoxR" CssClass="w3-input w3-border" runat="server" TextMode="MultiLine" Style="resize:none;" Height="100" Visible="True" Required="false" ClientIdMode="Static" ></asp:TextBox><br />
			</div>
			<asp:Button ID="TransferButton" runat="server" CssClass="w3-btn w3-blue" OnClick="TransferButton_Click" Text="Forward/Submit"  Visible="True" ></asp:Button> 	 
           
		</div>
	</div>

	<div style="padding:10px;">
		<asp:Label ID="Label_welcome" runat="server" Text="Welcome " ForeColor="#0081c9"></asp:Label>
	 	<asp:Button ID="ButtonLogout"  runat="server" CssClass="w3-btn w3-blue" Text="LogOut" style="float:right;"  Visible="True" onClick="ButtonLogout_Click" CausesValidation="False" UseSubmitBehavior="False" ></asp:Button>
	 	<asp:Button ID="HButton" runat="server" CssClass="w3-btn w3-blue" Text="Home" style="float:right;margin-right: 10px;"  Visible="True" onClick="H_Click" CausesValidation="False" UseSubmitBehavior="False"></asp:Button>
	 	<asp:Button ID="RButton" runat="server" CssClass="w3-btn w3-blue" Text="Your Requests" style="float:right;margin-right: 10px;"  Visible="True" onClick="R_Click" CausesValidation="False" UseSubmitBehavior="False" ></asp:Button>
		<asp:Button ID="IButton" runat="server" CssClass="w3-btn w3-blue" Text="My Interns" style="float:right;margin-right: 10px;"  Visible="True" onClick="I_Click" CausesValidation="False" UseSubmitBehavior="False" ></asp:Button>
		<asp:Button ID="NButton" runat="server" CssClass="w3-btn w3-blue" Text="New Request" style="float:right;margin-right: 10px;"  Visible="True" onClick="N_Click" CausesValidation="False" UseSubmitBehavior="False" ></asp:Button>
		
	 	<br/><hr/>
            
		<h2 id="tnastatus" runat="server">Admin</h2>       <hr/>

	</div>

	<asp:GridView ID="GridView2" runat="server" ShowHeader="True" AutoGenerateColumns="False" CellPadding="8" CellSpacing="8" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Large" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="true" OnRowCommand="GridView_RowCommand2">

            <Columns>
                <asp:BoundField DataField="iid" HeaderText="ID" ItemStyle-Width="50" />
                <asp:BoundField DataField="Student" HeaderText="Name of Student" ItemStyle-Width="350" HtmlEncode="False" />
                <asp:BoundField DataField="period" HeaderText="period" ItemStyle-Width="250" HtmlEncode="False" />
                <asp:TemplateField HeaderText="Uploads" ItemStyle-Width="100">
                    <ItemTemplate>

                        <asp:LinkButton ID="LinkButton1" Text="College ID Card" runat="server" CommandName="Select1" CommandArgument="<%# Container.DataItemIndex %>" /><br />
                        <br />
                        <asp:LinkButton ID="LinkButton2" Text="College Letter" runat="server" CommandName="Select2" CommandArgument="<%# Container.DataItemIndex %>" /><br />
                        <br />
                        <asp:LinkButton ID="LinkButton3" Text="CV" runat="server" CommandName="Select3" CommandArgument="<%# Container.DataItemIndex %>" /><br />
                        <br />

                    </ItemTemplate>
                </asp:TemplateField>
                

                <asp:BoundField DataField="status" HeaderText="Internship status" ItemStyle-Width="250" HtmlEncode="False" />
                <asp:TemplateField HeaderText="" ItemStyle-Width="100">
                    <ItemTemplate>

                        <asp:LinkButton ID="LinkButtonSelect" Text="Select" runat="server" CommandName="EditButton" CommandArgument="<%# Container.DataItemIndex %>"  CausesValidation="False" UseSubmitBehavior="False"/>
                                <div id="myModal" class="modal">
                                    <div class="modal-content">
                                        <span class="close">&times;</span>
                                        


                                    </div>
                                    
                                </div>

                    </ItemTemplate>

                </asp:TemplateField>

            </Columns>

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

 

</asp:Content>
