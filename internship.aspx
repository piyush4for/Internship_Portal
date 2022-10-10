<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="internship.aspx.cs" Inherits="Intern.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <html>

    <head>
        <script>
            $(document).ready(function () {

                $('body').addClass('light');

                $('ul.menu li').mouseover(function () {
                    $('body').addClass('dark').removeClass('light');
                });

                $('ul.menu li').mouseout(function () {
                    $('body').addClass('light').removeClass('dark');
                });

            })
        </script>
        <link href="CSSFiles/StyleSheet1.css" rel="stylesheet" />

    </head>
    <body>
        <link href='https://fonts.googleapis.com/css?family=Raleway:200' rel='stylesheet' type='text/css'>

<ul class="menu">
	<li><span>Your Training Details</span></li>
	<li><span>Sandarshikha</span></li>
	<li><span>Pragyan</span></li>
	<li><span>Learning KRA</span></li>
	<li><span>Sarvekshan</span></li>
	<li><span>TNA</span></li>
	<li><span>Internship</span></li>
	<li><span>Apprenticeship</span></li>
</ul>
        
        <img src="https://upload.wikimedia.org/wikipedia/commons/c/c0/Official_Photograph_of_Prime_Minister_Narendra_Modi_Potrait.png" alt="Trulli" width="400" height="533" align="right" style="margin-right: 150px; margin-top:50px; border: 5px solid #555;">
    </body>

    </html>
</asp:Content>
