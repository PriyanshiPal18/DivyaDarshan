<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Divya_Darshan.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <!--<script>
        function match_pwd(source, args) {
            var pwd = document.getElementById('<%=txtPwd.ClientID%>').value;
            var conPwd = document.getElementById('<%=txtConpwd.ClientID%>').value;
            if (pwd != conPwd) {
                args.IsValid = false;
                document.getElementById('<%=CustomValidator1.ClientID%>').ErrorMessage="Password does not match";
            }
            return true;
        }
    </script>-->
    
    <style type="text/css">
        .lbl{
            width: 50%;            
	        font-weight:600;
            padding: 10px;            
        }
        .head
        {
            font-size:32px;
            color: #a94106;
            font-family:Verdana;
	        text-align:center;
        }
        .signup_card
        {	        
	        background-color: antiquewhite;
	        border:solid 1px #CCCCCC;
	        border-radius:5px;
	        box-sizing:border-box;	
	        display:block;	
            width: 500px;
	        padding:20px 20px 10px 20px;
            margin-left:28%;
        }
        .btn
        {
	        cursor: pointer;
	        border: none;
	        width: 150px;
	        padding:10px;
	        font-size: 18px;
        }
        .auto-style25 {
            height: 806px;
            width: 1081px;
            background-color: lavenderblush;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="auto-style25">
    <div class="signup_card" >
    <h2 class="head">Sign Up Here!</h2>
    <center>
        <img src="Images/left1.png" height="80" width="400" /><br />
        <asp:Label class="lbl" ID="lblMsg" runat="server" Font-Size="Medium" ForeColor="#009933"></asp:Label><br />
          </center>
    <table style="margin:10px 50px;">
        <tr>
            <td class="lbl">Enter Firstname<br />
                <asp:TextBox ID="txtFname" runat="server" Height="30px" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFname" ErrorMessage="First Name is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="lbl">Enter Lastname<br />
                <asp:TextBox ID="txtLname" runat="server" Height="30px" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLname" ErrorMessage="Last Name is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="lbl">Enter Email ID<br />
                <asp:TextBox ID="txtEmail" runat="server" Height="30px" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email ID is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email ID must be in valid format" ValidationExpression="\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*" ForeColor="#CC0000"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="lbl">Enter Password<br />
                <asp:TextBox Type="Password" ID="txtPwd" runat="server" Height="30px" Width="350px" ToolTip="Password must have at least 1 lowercase, 1 uppercase, 1 number, 1 special character and must be of length greater than equal to 8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPwd" ErrorMessage="Password is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPwd" ErrorMessage="Password must be in valid format" ForeColor="#CC0000" ValidationExpression="^.(?=.{8,32})(?=.\d)(?=.[a-z])(?=.[A-Z])(?=.[!@#$%^&+=]).*$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="lbl">Confirm Password<br />
                <asp:TextBox  Type="password" ID="txtConpwd" runat="server" Height="30px" Width="350px" CausesValidation="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtConpwd" ErrorMessage="Confirm your password" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                <br />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Password does not match" ControlToValidate="txtConpwd" ClientValidationFunction="match_pwd()" ForeColor="#CC0000" OnClientClick="match_pwd()" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="lbl">Enter Contact no<br />
                <asp:TextBox ID="txtContact" runat="server" Height="30px" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtContact" ErrorMessage="Contact number is required" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Contact no. must be a 10-digit number" ForeColor="#CC0000" ValidationExpression="[0-9]{10}" ControlToValidate="txtContact"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="lbl">
                <center>
                    <asp:Button ID="Button1" runat="server" Text="REGISTER" BackColor="#a94106" BorderColor="#a94106" BorderWidth="0px" ForeColor="White" class="btn" OnClick="Button1_Click"/>
                </center>
            </td>
        </tr>
    </table>
   </div>
  </div>
</asp:Content>
