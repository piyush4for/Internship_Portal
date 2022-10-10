<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master"  EnableEventValidation = "false" AutoEventWireup="true" CodeBehind="request.aspx.cs" Inherits="Intern.request" %>

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
									 value: item.EmpDbKey +", "+ item.EmpName +", "+ item.EmpDesg +" (" + item.EmpDept + ")"
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
					//modal.style.display = "none";
					location.replace("YourRequests.aspx")
				}
		}
		
  </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

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
		<asp:Button ID="IButton" runat="server" CssClass="w3-btn w3-blue" Text="Your Interns" style="float:right;margin-right: 10px;"  Visible="True" onClick="I_Click" CausesValidation="False" UseSubmitBehavior="False" ></asp:Button>
		<asp:Button ID="AButton" runat="server" CssClass="w3-btn w3-blue" Text="Admin" style="float:right;margin-right: 10px;"  Visible="False" onClick="A_Click" CausesValidation="False" UseSubmitBehavior="False" ></asp:Button>
		
	 	<br/><hr/>
            
		<h2 id="tnastatus" runat="server">New Request</h2>       
		
		<hr/>

		<div class="w3-row-padding">

			<div class="w3-third">
				<label class="w3-text-blue"><b>Name Prefix</b></label>
				<asp:DropDownList ID="DropDownListNP" CssClass="w3-input w3-border" runat="server" Required="True" Visible="True" >
					<asp:ListItem Text="	----select----" Value="0" />
          <asp:ListItem Text="Mr." Value="Mr." />
					<asp:ListItem Text="Miss" Value="Miss" />
					<asp:ListItem Text="Mrs." Value="Mrs." />			
				</asp:DropDownList>

				<asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="DropDownListNP" InitialValue="0" runat="server" ForeColor="Red" /><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Name</b></label>
				<asp:TextBox ID="TextBoxN" CssClass="w3-input w3-border" placeholder="Name of Student" Required="true" runat="server" Visible="True" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Email ID</b></label>
				<asp:TextBox ID="TextBoxE" CssClass="w3-input w3-border" TextMode="Email" placeholder="Email ID of Student" Required="true" runat="server" Visible="True" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Phone No.</b></label>
				<asp:TextBox ID="TextBoxP" CssClass="w3-input w3-border" TextMode="Phone" placeholder="Phone No. of Student" Required="true" runat="server" Visible="True" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Course Persuing/Completed</b></label>
				<asp:DropDownList ID="DropDownListC" CssClass="w3-input w3-border" runat="server" Required="True" Visible="True" SelectionMode="Multiple">
					<asp:ListItem Text="	----select----" Value="0" />
          <asp:ListItem Text="Diploma" Value="Diploma" />
					<asp:ListItem Text="Under Graduate - BCom" Value="Under Graduate - BCom" />
					<asp:ListItem Text="Under Graduate - BBA" Value="Under Graduate - BBA" />
					<asp:ListItem Text="Under Graduate - Btech/BE" Value="Under Graduate - Btech/BE" />
					<asp:ListItem Text="Under Graduate - BA/BSc" Value="Under Graduate - BA/BSc" />
					<asp:ListItem Text="Under Graduate - LLB" Value="Under Graduate - LLB" />
					<asp:ListItem Text="Post Graduate - MBA" Value="Post Graduate - MBA" />
					<asp:ListItem Text="Post Graduate - Mtech/ME" Value="Post Graduate - Mtech/ME" />
					<asp:ListItem Text="Post Graduate - MA/MSc" Value="Post Graduate - MA/MSc" />
					<asp:ListItem Text="Post Graduate - LLM" Value="Post Graduate - LLM" />
					<asp:ListItem Text="Others" Value="Others" />
				</asp:DropDownList>

				<asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="DropDownListC" InitialValue="0" runat="server" ForeColor="Red" /><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Branch/Trade</b></label>
				<asp:TextBox ID="TextBoxB" CssClass="w3-input w3-border" placeholder="Branch/Trade" Required="true" runat="server" Visible="True" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Institute/University</b></label>
				<asp:TextBox ID="TextBoxI" CssClass="w3-input w3-border" placeholder="Institute/University" Required="true" runat="server" Visible="True" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Start Date</b></label>
				<asp:TextBox ID="TextBoxSD"  CssClass="w3-input w3-border" TextMode="Date" placeholder="Start Date" runat="server" Required="true" Visible="True" AutoPostBack = "true" OnTextChanged = "OnDChanged" onkeypress="return false;" onpaste="return false"></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>End Date</b></label>
				<asp:TextBox ID="TextBoxED"  CssClass="w3-input w3-border" TextMode="Date" placeholder="End Date" runat="server" Required="true" Visible="True" AutoPostBack = "true" OnTextChanged = "OnDChanged" onkeypress="return false;" onpaste="return false"></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Duration (in Days)</b></label>
				<asp:TextBox ID="TextBoxD" CssClass="w3-input w3-border" TextMode="Number" placeholder="Duration" runat="server" Required="true" Visible="True" AutoPostBack = "true" OnTextChanged = "OnDaysChanged"></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Preferred Guide (POWERGRID Employee)</b></label>
				<asp:TextBox ID="TextBoxPG" CssClass="w3-input w3-border" placeholder="Enter 5-digit Employee Number" runat="server"  Visible="True" Required="true" ClientIdMode="Static" ></asp:TextBox><br />
			</div>
			
			<div class="w3-third">
				<label class="w3-text-blue"><b>Select Region</b></label>            
				<asp:DropDownList ID="DropDownList1R1" CssClass="w3-input w3-border" runat="server" Required="True" Visible="True" SelectionMode="Multiple">
					<asp:ListItem Text="	----select Region----" Value="0" />
					<asp:ListItem Text="CC" Value="CC" />
					<asp:ListItem Text="ER-I" Value="ER-I" />
					<asp:ListItem Text="ER-II" Value="ER-II" />
					<asp:ListItem Text="NER" Value="NER" />
					<asp:ListItem Text="NR-I" Value="NR-I" />
					<asp:ListItem Text="NR-II" Value="NR-II" />
					<asp:ListItem Text="NR-III" Value="NR-III" />
					<asp:ListItem Text="Odisha" Value="Odisha" />
					<asp:ListItem Text="SR-I" Value="SR-I" />
					<asp:ListItem Text="SR-II" Value="SR-II" />
					<asp:ListItem Text="WR-I" Value="WR-I" />
					<asp:ListItem Text="WR-II" Value="WR-II" />
				</asp:DropDownList>
				<asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="DropDownList1R1"  InitialValue="0" runat="server" ForeColor="Red" />
 
				<br />
			  <br />
			</div>
			

			<div class="w3-third">
				<label class="w3-text-blue"><b>.</b></label>
		    </div>



			<div class="w3-third">
				<label class="w3-text-blue"><b>Remarks</b></label>
				<asp:TextBox ID="TextBoxR" CssClass="w3-input w3-border" runat="server" TextMode="MultiLine" Style="resize:none;" Height="100" Visible="True" Required="true" ClientIdMode="Static" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>.</b></label>
		
			</div>

		</div>

		<hr/>

		<div class="w3-row-padding">
			
			<div class="w3-third">
				<label class="w3-text-blue"><b>Upload College ID Card (PDF File)</b></label> <br />                	
				<asp:FileUpload ID="FileUploadID" runat="server" Required="true" ToolTip="Only PDF File"  /><br /><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Upload College recommendation letter (PDF File)</b></label><br />               	
				<asp:FileUpload ID="FileUploadLOR" runat="server" Required="true" ToolTip="Only PDF File"  /> <br /> <br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Upload CV (PDF File)</b></label><br /> 
				<asp:FileUpload ID="FileUploadCV" runat="server" Required="true" ToolTip="Only PDF File"  /> <br /><br />     
			</div>
		</div>
		<label id="lpdf" Visible="false" runat="server" Style="color: orangered;"><b>Please Upload only PDF Files.. </b></label><br />
                   

		<hr/>

		<div style = "text-align: center ; ">
				<asp:Button ID="SubmitButton" runat="server" CssClass="w3-btn w3-blue" OnClick="SubmitButton_Click" Text="Submit"  Visible="True" ></asp:Button> 	 
		</div>

		<br/><br/>
		
	</div>

 

</asp:Content>
