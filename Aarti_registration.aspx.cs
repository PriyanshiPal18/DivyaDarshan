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
    public partial class Aarti_registration : System.Web.UI.Page
    { 
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='E:\\Khushi\\DB.mdf';Integrated Security=True;Connect Timeout=30");
        String t = "t1", u = "u1", booking_id, trans_id = "td1", a;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select MAx(ticket_id) from aarti_booking", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                booking_id = dr[0].ToString();
            }
            if(booking_id=="")
            {
                booking_id = "R0";
            }
            String s1 = booking_id.Substring(1);
            int id = Convert.ToInt32(s1) + 1;
            booking_id = "R" + Convert.ToString(id);
            con.Close();

            con.Open();
            cmd = new SqlCommand("SELECT MAX(trans_id) FROM transactions", con);   //taking maximum trans_id from transaction
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                trans_id = dr[0].ToString();
            }
            if (trans_id == "")
            {
                trans_id = "TD0";
            }
            s1 = trans_id.Substring(2);
            id = Convert.ToInt32(s1) + 1;
            trans_id = "TD" + Convert.ToString(id);
            con.Close();
            con.Open();
            cmd = new SqlCommand("SELECT * FROM aarti WHERE temple_id='" + t + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            DropDownList2.DataTextField = ds.Tables[0].Columns["time"].ToString();
            DropDownList2.DataValueField = ds.Tables[0].Columns["aarti_id"].ToString();
            DropDownList2.DataSource = ds.Tables[0];    //assigning data source to dropdown list
            DropDownList2.DataBind();
            con.Close();
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            lblDate.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            lblError.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(Calendar1.SelectedDate);
            DateTime curr = DateTime.Now;
            if (lblDate.Text == "")
            {
                lblError.Text = "Select a date from the calendar";
            }
            else if (date < curr)
            {
                lblError.Text = "Select a valid date from the calendar";
            }
            else
            {
                String date_str = date.ToShortDateString();
                a = DropDownList2.SelectedValue;
                con.Open();
                SqlCommand cmdIns1 = new SqlCommand("INSERT INTO aarti_booking VALUES('" + booking_id + "', '" + u + "', '" + a + "', '" + date_str + "')", con);
                cmdIns1.ExecuteNonQuery();

                /*SqlCommand cmdIns2 = new SqlCommand("INSERT INTO transactions VALUES('" + trans_id + "', '" + u + "', '" + booking_id + "', '" + DateTime.Now.Date.ToShortDateString() + "', 200, '" + t + "', 'Aarti', 'null')", con);
                cmdIns2.ExecuteNonQuery();*/
                con.Close();
            }
        }
    }
}