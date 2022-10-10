<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="YourRequests.aspx.cs" Inherits="Intern.YourRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        function a() {
            var modal = document.getElementById('myModal');
            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];
            // When the user clicks the button, open the modal 
            modal.style.display = "block";
            // When the user clicks on <span> (x), close the modal
            span.onclick = function () {
                modal.style.display = "none";
            }
        }

    </script>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div id="myModal" class="modal">
        <div class="modal-content">
            <span class="close">&times;</span>
          

            <div class="w3-row-padding">

			<div class="w3-third">
				<label class="w3-text-blue"><b>Name Prefix</b></label>
				<asp:DropDownList ID="DropDownListNP" CssClass="w3-input w3-border" runat="server" Required="false" Visible="True" >
					<asp:ListItem Text="	----select----" Value="0" />
          <asp:ListItem Text="Mr." Value="Mr." />
					<asp:ListItem Text="Miss" Value="Miss" />
					<asp:ListItem Text="Mrs." Value="Mrs." />			
				</asp:DropDownList>

				<asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="DropDownListNP" InitialValue="0" runat="server" ForeColor="Red" /><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Name</b></label>
				<asp:TextBox ID="TextBoxN" CssClass="w3-input w3-border" placeholder="Name of Student" Required="false" runat="server" Visible="True" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Email ID</b></label>
				<asp:TextBox ID="TextBoxE" CssClass="w3-input w3-border" TextMode="Email" placeholder="Email ID of Student" Required="false" runat="server" Visible="True" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Phone No.</b></label>
				<asp:TextBox ID="TextBoxP" CssClass="w3-input w3-border" TextMode="Phone" placeholder="Phone No. of Student" Required="false" runat="server" Visible="True" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Course Persuing/Completed</b></label>
				<asp:DropDownList ID="DropDownListC" CssClass="w3-input w3-border" runat="server" Required="false" Visible="True" SelectionMode="Multiple">
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
				<asp:TextBox ID="TextBoxB" CssClass="w3-input w3-border" placeholder="Branch/Trade" Required="false" runat="server" Visible="True" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Institute/University</b></label>
				<asp:TextBox ID="TextBoxI" CssClass="w3-input w3-border" placeholder="Institute/University" Required="false" runat="server" Visible="True" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Start Date</b></label>
				<asp:TextBox ID="TextBoxSD"  CssClass="w3-input w3-border" TextMode="Date" placeholder="Start Date" runat="server" Required="false" Visible="True" AutoPostBack = "true" OnTextChanged = "OnDChanged" onkeypress="return false;" onpaste="return false"></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>End Date</b></label>
				<asp:TextBox ID="TextBoxED"  CssClass="w3-input w3-border" TextMode="Date" placeholder="End Date" runat="server" Required="false" Visible="True" AutoPostBack = "true" OnTextChanged = "OnDChanged" onkeypress="return false;" onpaste="return false"></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Duration (in Days)</b></label>
				<asp:TextBox ID="TextBoxD" CssClass="w3-input w3-border" TextMode="Number" placeholder="Duration" runat="server" Required="false" Visible="True" AutoPostBack = "true" OnTextChanged = "OnDaysChanged"></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Preferred Guide (POWERGRID Employee)</b></label>
				<asp:TextBox ID="TextBoxPG" CssClass="w3-input w3-border" placeholder="Enter 5-digit Employee Number" runat="server"  Visible="True" Required="false" ClientIdMode="Static" ></asp:TextBox><br />
			</div>
			
			<div class="w3-third">
				<label class="w3-text-blue"><b>Select Region</b></label>            
				<asp:DropDownList ID="DropDownList1R1" CssClass="w3-input w3-border" runat="server" Required="false" Visible="True" SelectionMode="Multiple">
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
				<asp:TextBox ID="TextBoxR" CssClass="w3-input w3-border" runat="server" TextMode="MultiLine" Style="resize:none;" Height="100" Visible="True" Required="false" ClientIdMode="Static" ></asp:TextBox><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>.</b></label>
		
			</div>

		</div>

		<hr/>

		<div class="w3-row-padding">
			
			<div class="w3-third">
				<label class="w3-text-blue"><b>Upload College ID Card (PDF File)</b></label> <br />                	
				<asp:FileUpload ID="FileUploadID" runat="server"  ToolTip="Only PDF File"  /><br /><br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Upload College recommendation letter (PDF File)</b></label><br />               	
				<asp:FileUpload ID="FileUploadLOR" runat="server"  ToolTip="Only PDF File"  /> <br /> <br />
			</div>

			<div class="w3-third">
				<label class="w3-text-blue"><b>Upload CV (PDF File)</b></label><br /> 
				<asp:FileUpload ID="FileUploadCV" runat="server"  ToolTip="Only PDF File"  /> <br /><br />     
			</div>
		</div>
		<label id="lpdf" Visible="false" runat="server" Style="color: orangered;"><b>Please Upload only PDF Files.. </b></label><br />
                   
			<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
		<hr/>
			

		<div style = "text-align: left;margin-left: 40%;margin-bottom: -39px;">
				<asp:Button ID="SubmitButton" runat="server" CssClass="w3-btn w3-blue" OnClick="SubmitButton_Click" Text="Update"  Visible="True" ></asp:Button> 	 
		</div>
		<div style = "text-align: right ; margin-right:41%";>
			<asp:Button ID="DeleteButton" runat="server" CssClass="w3-btn w3-blue" OnClick="DeleteButton_Click" Text="Delete"  Visible="True" ></asp:Button> 	 
		</div>

		<br/><br/>
		
	</div>





        </div>
    </div>

    <div style="padding: 10px;">
        <asp:Label ID="Label_welcome" runat="server" Text="Welcome " ForeColor="#0081c9"></asp:Label>
        <asp:Button ID="ButtonLogout" runat="server" CssClass="w3-btn w3-blue" Text="LogOut" Style="float: right;" Visible="True" OnClick="ButtonLogout_Click" CausesValidation="False" UseSubmitBehavior="False"></asp:Button>
        <asp:Button ID="HButton" runat="server" CssClass="w3-btn w3-blue" Text="Home" Style="float: right; margin-right: 10px;" Visible="True" OnClick="H_Click" CausesValidation="False" UseSubmitBehavior="False"></asp:Button>
        <asp:Button ID="NButton" runat="server" CssClass="w3-btn w3-blue" Text="New Request" Style="float: right; margin-right: 10px;" Visible="True" OnClick="N_Click" CausesValidation="False" UseSubmitBehavior="False"></asp:Button>
        <asp:Button ID="IButton" runat="server" CssClass="w3-btn w3-blue" Text="Your Interns" Style="float: right; margin-right: 10px;" Visible="True" OnClick="I_Click" CausesValidation="False" UseSubmitBehavior="False"></asp:Button>
        <asp:Button ID="AButton" runat="server" CssClass="w3-btn w3-blue" Text="Admin" Style="float: right; margin-right: 10px;" Visible="False" OnClick="A_Click" CausesValidation="False" UseSubmitBehavior="False"></asp:Button>

        <br />
        <hr />

        <h2 id="tnastatus" runat="server">Your Request</h2>
        <hr />

        <asp:GridView ID="GridView1" runat="server" ShowHeader="True" AutoGenerateColumns="False" CellPadding="8" CellSpacing="8" ForeColor="#333333" HorizontalAlign="Center" Font-Size="Large" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="true" OnRowCommand="GridView_RowCommand">

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

                        <asp:LinkButton ID="LinkButtonEdit" Text="Edit" runat="server" CommandName="EditButton" CommandArgument="<%# Container.DataItemIndex %>"  CausesValidation="False" UseSubmitBehavior="False"/>
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
        <hr />
        <hr />

    </div>



</asp:Content>
