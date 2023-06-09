﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="E_paas_Reg.aspx.cs" Inherits="Divya_Darshan.E_paas_Reg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <!--<script>
        function valid_sub()
        {
            if (document.getElementById('<%=txtVal.ClientID%>').value == 1)
            {
                document.getElementById('<%=lblError2.ClientID%>').value = "1 is the minimum value";
            }
        }
        function valid_add()
        {
            if (document.getElementById('<%=txtVal.ClientID%>').value == 5)
            {
                document.getElementById('<%=lblError2.ClientID%>').value = "5 is the maximum value";
            }
        }    
    </script>-->
    <style>
        .btn {
            padding: 5px;
            font-size: 18px;
        }

        body {
            background-color: lavenderblush;
        }

        .heading {
            font-size: 32px;
            color: #a94106;
        }

        .headImg {
            width: 100%;
            height: 180px;
        }

        .container {
            position: relative;
            text-align: center;
        }

        .centered {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }

        .cell {
            width: 100px;
            padding: 25px;
            font-family: Verdana;
        }

        .btn {
            padding: 10px;
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
        <div class="container"><img src="images/bg3.jpg"  class="headImg"/><div class="centered"><h2 class="heading"> E-PASS REGISTRATION </h2></div></div>
    <center><img src="images/line4.png" height="80" width="500" /></center>
        <table width="70%" align="center">
            <tr>
                <td class="cell">Name</td>
                <td class="cell">
                    <asp:TextBox ID="txtName" padding="10px" runat="server" BorderColor="#A94106" BorderStyle="Solid" Height="30px" Width="350px"  Enabled="False" EnableTheming="True" ReadOnly="True" ForeColor="Black">Firstname Lastname</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cell">Date<font color="red">*</font></td>
                <td class="cell">
                    <asp:Label ID="lblDate" runat="server" Visible="False"></asp:Label>
                    <asp:Calendar ID="Calendar1" runat="server" BorderColor="#A94106" BorderStyle="Solid" ></asp:Calendar>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </td>                
                
            </tr>
            <tr>
                <td class="cell">No. of people<font color="red">*</font></td>
                <td class="cell">
                    <asp:Button ID="btnSubt" runat="server" Text="-" Font-Size="Large" Font-Bold="true" Width="50px" Height="30px" BorderColor="#A94106" BorderStyle="Solid" ForeColor="#A94106" OnClientClick="valid_sub()" OnClick="btnSubt_Click" />
&nbsp;&nbsp;
                    <asp:TextBox ID="txtVal" runat="server" BackColor="Transparent" BorderWidth="0px" OnTextChanged="txtVal_TextChanged" Width="50px"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" Text="+" Font-Size="Large" Font-Bold="true" Width="50px" Height="30px" BorderColor="#A94106" BorderStyle="Solid" ForeColor="#A94106" OnClientClick="valid_add()" OnClick="btnAdd_Click" />
                <br />
                    <asp:Label ID="lblError2" runat="server" ForeColor="#CC0000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="cell">Amount (₹)</td>
                <td class="cell">
                    <asp:TextBox ID="txtAmt" padding="10px" runat="server" BorderColor="#A94106" BorderStyle="Solid" Height="30px" Width="350px" Enabled="False" EnableTheming="True" ReadOnly="True" ForeColor="Black">500</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="cell" colspan="2">
                    <b>Note:</b><br /><font size="small">
                        1. Devotee without Epass will not be allowed to temple.<br />
                        2. At the time of entry, all devotees shall produce their aadhar card and the ID provided to them after Epass registration<br />
                        3. Maximum 5 persons are allowed within one Epass<br />
                        4. Devotees have completed 14 days from the receipt of 2nd dose of vaccination and produce the final vaccination certificate at the counter.<br />
                        5. Wear mask all the time and maintain social distancing and sanitize hands.<br /></font>
                </td>
            </tr>
            <tr>
                <td class="cell" colspan="2"><center><asp:Button ID="btnCon" runat="server" Text="CONTINUE" BackColor="#a94106" BorderColor="#a94106" BorderWidth="0px" CommandName="cmdSubmit" ForeColor="White" class="btn" OnClick="btnCon_Click"/></td>
            </tr>
            </table>
        <br />
    </div>
</asp:Content>
