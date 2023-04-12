<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMAster.Master" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="Divya_Darshan.Login11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style25 {
            height: 806px;
            width: 1081px;
            background-image:url("https://i.pinimg.com/originals/21/99/37/219937dc0d0380c4c24c9ecdb04aca88.jpg");
            overflow:auto;
        }
        .lbl{
            width: 50%;            
	        font-weight:600;
            padding: 10px;      
            font-family: Verdana;      
        }
        .head
        {
            font-size:32px;
            color: #a94106;
            font-family:Verdana;
	        text-align:center;
        }
        body
        {
	        background-color: lavenderblush;
        }
        .login_card
        {	        
            background-color:antiquewhite;
	        border:solid 1px #CCCCCC;
	        border-radius:5px;
	        box-sizing:border-box;	
	        display:block;	
            width: 500px;
	        padding:20px;
            margin:0 auto;
        }
        .btn
        {
	        cursor: pointer;
	        border: none;
	        width: 150px;
	        padding:10px;
	        font-size: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="login_card">
    <h2 class="head">Login</h2>
       <center>
           <img src="Images/left1.png" height="80" width="400" /><br />
       </center>
        <table style="margin:10px 50px;">            
            <tr>
                <td class="lbl">
                    <center><asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label></center>
                </td>
            </tr>
            <tr>
                <td class="lbl">Enter Email ID<br />
                    <asp:TextBox ID="txtEmail" runat="server" Height="30px" Width="350px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email ID is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="lbl">Enter Password<br />
                    <asp:TextBox type="password" ID="txtPwd" runat="server" Height="30px" Width="350px"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPwd" ErrorMessage="Password is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="lbl">
                    <center><asp:Button ID="btnLogin" runat="server" Text="LOGIN" BackColor="#a94106" BorderColor="#a94106" BorderWidth="0px" ForeColor="White" class="btn" OnClick="btnLogin_Click"/></center>
                </td>
            </tr>
            <tr>
                <td class="lbl">
                    <center>Don't have an account yet? <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="register.aspx">Click Here</asp:HyperLink>
                    </center>
                </td>
            </tr>
        </table>
       </div>
</asp:Content>
