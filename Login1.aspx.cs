using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Divya_Darshan
{
    public partial class Login11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='E:\\Khushi\\DB.mdf';Integrated Security=True;Connect Timeout=30");
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int s1 = 0;        //if user is invalid s1=0 . else s1=1; 
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from users where email_id='"+txtEmail.Text+"' AND password='"+txtPwd.Text+"'",con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                s1 = 1;          // user found
            }
            if (s1==1)           // user is allowed to mover further
            {
                Session["u1"] = txtEmail.Text;
                Response.Redirect("TempleNGOCards.aspx");
                
            }
            else                 // user is send to registration page 
            {
                txtEmail.Text = "";
                txtPwd.Text = "";
                lblError.Text = "Not Registered user!!!";
                Response.Redirect("register.aspx");
            }
            con.Close();
        }
    }
}