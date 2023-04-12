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
   
    public partial class HomeMaster : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Khushi\\DB.mdf;Integrated Security=True;Connect Timeout=30");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["user"]) == " ")
            {
                btnSignIn.Text = "LOGIN";
            }
            else
            {
                Response.Write(Session["user"]);
                btnSignIn.Text = "LOGOUT";
            }
            DateTime db1, db;
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Calendar ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            db1 = DateTime.Now.Date;

            while (dr.Read())
            {
                db = Convert.ToDateTime(dr[0]).Date;
                if (DateTime.Compare(db, db1) == 0)
                {
                    Label8.Text = "Today";
                    TextBox2.Text = db1.ToString("dd/MM/yyyy");
                    TextBox3.Text = Convert.ToString(dr[1]);
                    break;
                }
                else
                {
                    TextBox2.Text = db1.ToString("dd/MM/yyyy");
                    TextBox3.Text = "No Occasion Today";
                }
            }
            con.Close();
            /*
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 7 * FROM calendar WHERE date > CONVERT(DATE, GETDATE(), 102)", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();            
            con.Close();*/

            con.Open();
            SqlCommand da = new SqlCommand("SELECT TOP 7 * FROM calendar WHERE date > CONVERT(DATE, GETDATE(), 102)", con);
            dr = da.ExecuteReader();
            DataTable tbl = new DataTable("Occassions");
            DataColumn col;
            DataRow row;
            col = new DataColumn();
            col.DataType = typeof(String);
            col.ColumnName = "Date";
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.DataType = typeof(String);
            col.ColumnName = "Occassion";
            tbl.Columns.Add(col);
            while (dr.Read())
            {
                row = tbl.NewRow();
                row["Date"] = Convert.ToDateTime(dr[0]).ToString("dd/MM/yyyy");
                row["Occassion"] = dr[1];
                tbl.Rows.Add(row);
            }
            GridView1.DataSource = tbl;
            GridView1.DataBind();
            con.Close();
        }
        protected void btnHome_Click1(object sender, EventArgs e)
        {
            Response.Redirect("TempleNGOCards.aspx");
        }

        protected void btnTemple_Click(object sender, EventArgs e)
        {
            Response.Redirect("Temple1.aspx");
        }

        protected void btnNgo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NgoPage.aspx");
        }

        protected void btnLocation_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectionPage.aspx");
        }

        protected void btnAbout_Click(object sender, EventArgs e)
        {
            Response.Redirect("About_us.aspx");
        }

        protected void btnDonation_Click(object sender, EventArgs e)
        {
            Response.Redirect("Donation.aspx");
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["user"]) == "")
            {
                Response.Redirect("Login1.aspx");
            }
            else
            {
                Session.Contents.RemoveAll();
            }
        }
    }
}