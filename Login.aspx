
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Intern.Login" %>


<!DOCTYPE html>
<html lang="en">
<head runat="server">
	<meta charset="UTF-8">
	<meta content="width=device-width, initial-scale=1" name="viewport">
	<meta content="IE=edge" http-equiv="X-UA-Compatible">

	<title>POWERGRID</title>

	<link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:400,700" rel="stylesheet">
	
	<link rel='stylesheet prefetch' href='https://fonts.googleapis.com/css?family=Open+Sans:400,700,300,600'>

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
</head>

<body>
<form id="form2" runat="server">
<img src="images/header.svg" width="100%">
          	              	    
 <div class="navbar2"><h2 float="center"></h2></div>
  
    <div class="loginbox">
		<img src="images/q3.png" class="avatar">
        <h1>LOG IN</h1>
			<p>Employee No.</p>
			<asp:TextBox ID="txtuser1" CssClass="input" placeholder="Enter Employee No." runat="server"></asp:TextBox>
			<p>Password</p>
			<asp:TextBox ID="txtpass1" CssClass="input" placeholder="Enter Password" TextMode="Password" runat="server"></asp:TextBox>




			<asp:Button ID="Button11"  runat="server" CssClass="input" Text="Login" OnClick="Button11_Click"></asp:Button>   
        <p>Use Your Intranet Login & Password</p>
		<asp:Label ID="Label1" CssClass="errorMsg" runat="server" Text="" ForeColor="#FF3300"></asp:Label>
	</div>  	

    <div class="navbar"><h2 float="center">© Copyright Power Grid Corporation of India Ltd.</h2></div>
	
	
</form>
</body>
</html>

<script type="text/javascript">
	
	function a() {
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

 <style>
        body{
    margin: 0;
    padding: 0;

    background-size: cover;
    background-position: center;
    font-family: sans-serif;
}
.navbar2 a {
	float: left;
	display: block;
	color: #f2f2f2;
	text-align: center;
	padding: 14px 16px;
	text-decoration: none;
	font-size: 17px;
}
.loginbox {
    width: 330px;
    height: 450px;
    background:	#0081c9;
    color: #fff;
    top: auto;
    left: auto;
    margin: 0 auto;
    margin-top: 100px;
    margin-bottom: 50px;
    position: relative;
    box-sizing: border-box;
    padding: 70px 30px;
}

.avatar{
    width: 100px;
    height: 100px;
    border-radius: 50%;
    position: absolute;
    top: -50px;
    left: calc(50% - 50px);
}

h1{
    margin: 0;
    padding: 0 0 20px;
    text-align: center;
    font-size: 22px;
}

.loginbox p{
    margin: 0;
    padding: 0;
    font-weight: bold;
}

.loginbox input{
    width: 100%;
    margin-bottom: 20px;
}

.loginbox input[type="text"], input[type="password"]
{
    border: none;
    border-bottom: 1px solid #fff;
    background: transparent;
    outline: none;
    height: 40px;
    color: #fff;
    font-size: 16px;
}

.loginbox input[type="submit"]
{
    border: none;
    outline: none;
    height: 40px;
    background:#ed7700;
    color: #fff;
    font-size: 18px;
    border-radius: 20px;
}
.loginbox input[type="submit"]:hover
{
    cursor: pointer;
    background: #ff8000;
    color: #000;
}
.loginbox a{
    text-decoration: none;
    font-size: 12px;
    line-height: 20px;
    color: darkgrey;
}

.loginbox a:hover
{
    color: #ffc107;
}

@-webkit-keyframes autofill {
    to {
        color: #000;
        background: transparent;
    }
}

input:-webkit-autofill {
    -webkit-animation-name: autofill;
    -webkit-animation-fill-mode: both;
}

.errorMsg {
    margin: 0;
    padding: 0 0 20px;
    text-align: center;

    color: #000;
}


#navbar {
    overflow: hidden;
    background-color:	#0081c9;
    padding:30px;
}

.navbar {
	background-color:	#0081c9;
	overflow: hidden;
	
	bottom: 0;
	width: 100%;
}

.navbar2 {
	background-color:	#0081c9;
	overflow: hidden;
	width: 100%;
}


.navbarT {
	background-color:	#0081c9;
	overflow: hidden;
	
	bottom: 0;
	width: 100%;
}


.navbar a {
	float: right;
	display: block;
	color: #f2f2f2;
	text-align: center;
	padding: 14px 16px;
	text-decoration: none;
	font-size: 17px;
}

	.navbar h2 {
		
		display: block;
		color: #f2f2f2;
		text-align: center;
		padding: 10px 12px;
		text-decoration: none;
		font-size: 17px;
	}

    .navbar2 h2 {
		
		display: block;
		color: #f2f2f2;
		text-align: center;
		margin-top:5px;
		text-decoration: none;
		font-size: 25px;
	}

.navbar a:hover {
	background-color: #A8CACB;
	color: black;
}


.navbar a.active {
	background-color:	#0081c9;
	color: white;
}




.modal {
    display: none; /* Hidden by default */
    position: fixed; /* Stay in place */
    z-index: 1; /* Sit on top */
    padding-top: 100px; /* Location of the box */
    left: 0;
    top: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgba(0,0,0,0.7); /* Black w/ opacity */
    
}

/* Modal Content */
.modal-content {
    background-color: #fefefe;
    margin: auto;
    padding: 20px 20px 20px 20px;
    border: 3px solid rgb(16, 154, 245);
    width: 60%;
    border-radius: 6px;
}

/* The Close Button */
.close {
    color: #aaaaaa;
    float: right;
    font-size: 28px;
    font-weight: bold;
}

.close:hover,
.close:focus {
    color: #000;
    text-decoration: none;
    cursor: pointer;
}




    </style>
