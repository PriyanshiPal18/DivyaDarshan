
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Runtime;
using System.Text.RegularExpressions;

namespace Divya_Darshan
{
    public partial class Login1 : System.Web.UI.Page
    {
        string s1,uid;
        int id, c = 0;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='E:\\Khushi\\DB.mdf';Integrated Security=True;Connect Timeout=30");

        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(CAST(SUBSTRING(user_id, 2, len(user_id)-1) As int )) FROM users", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                uid = dr[0].ToString();
            }
            if (uid == "")
            {
                uid = "U0";
            }
            s1 = uid.Substring(1);
            id = Convert.ToInt32(s1) + 1;
            uid = "U" + Convert.ToString(id);
            con.Close();

        }
       
        protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (txtConpwd.Text != txtPwd.Text)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        public static bool isValidEmail(string inputEmail)
        {
            int i = 0, k = 0;
            String[] eType = new string[4] { "@gmail.com", "@aol.com", "@rediffmail.com", "@yahoo.com" };
            Boolean[] r = new Boolean[eType.Length];
            for (int j = 0; j < eType.Length; j++)
            {
                r[j] = inputEmail.Contains(eType[j]);
                k = r[j] ? j : 0;
                i = r[j] ? eType[j].Length : 0;         //if inputEmail contains given eType then get its length in i
            }
            if (i == 0)      //if inputEmail does not contain any given eType than invalid format
                return false;

            String e = inputEmail.Substring(inputEmail.Length - i, i);
            if (e == eType[k])
                return true;
            else
                return false;
        }
        public static bool isValidPwd(string inputPwd)
        {
            string strRegex = "^.* (?=.{8,32})(?=.[0-9])(?=.[a-z])(?=.[A-Z])(?=.[!@#$%^&+=]).$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputPwd))
                return true;
            else
                return false;
        }
        public static bool isValidMobileNumber(string inputMobileNumber)
        {
            string strRegex = "^[0 - 9]{10}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputMobileNumber))
                return true;
            else
                return false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmdFind = new SqlCommand("SELECT * FROM users WHERE email_id = '" + txtEmail.Text + "'", con);
            SqlDataReader dr;
            dr = cmdFind.ExecuteReader();
            while (dr.Read())
            {
                if (Convert.ToString(dr["email_id"]) == txtEmail.Text)
                {
                    c = 1;
                }
            }
            con.Close();
            lblMsg.Text = "";
            if (txtFname.Text != "" && txtLname.Text != "" && txtEmail.Text != "" && txtPwd.Text != "" && txtConpwd.Text != "" && txtConpwd.Text == txtPwd.Text && txtContact.Text != "" && isValidMobileNumber(txtContact.Text) && isValidPwd(txtPwd.Text) && isValidEmail(txtEmail.Text))
            {
                con.Open();
                string insertQuery = "INSERT INTO users VALUES ('" + uid + "', '" + txtFname.Text + "', '" + txtLname.Text + "', '" + txtEmail.Text + "', '" + txtPwd.Text + "', '" + Convert.ToString(txtContact.Text) + "',  'user')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.ExecuteNonQuery();
                lblMsg.Text = "Registration Successful!!!";
                txtFname.Text = "";
                txtLname.Text = "";
                txtEmail.Text = "";
                txtPwd.Text = "";
                txtConpwd.Text = "";
                txtContact.Text = "";
                con.Close();
                Response.Redirect("Login.aspx");
            }
            else if (c == 1)
            {
                lblMsg.Text = "This user is already registered";
            }
        }
    }
}