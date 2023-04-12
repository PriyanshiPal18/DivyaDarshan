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
    public partial class E_paas_Reg : System.Web.UI.Page
    {

        String t = "T1", u = "U1", trans_id = "TD1", tid = "E1";
        int val = 1, amt;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='E:\\Khushi\\DB.mdf';Integrated Security=True;Connect Timeout=30");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(ticket_id) FROM epass", con);   //taking maximum ticket_id in epass
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tid = dr[0].ToString();
            }
            if (tid == "")
            {
                tid = "E0";
            }
            String s1 = tid.Substring(1);
            int id = Convert.ToInt32(s1) + 1;
            tid = "E" + Convert.ToString(id);
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
            cmd = new SqlCommand("SELECT * FROM users WHERE user_id='" + u + "' ", con); //taking name of user by user_id   
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtName.Text = Convert.ToString(dr[1]) + " " + Convert.ToString(dr[2]);
            }
            con.Close();

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            int count = 0;
            lblDate.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            lblError.Text = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT no_of_people FROM epass WHERE date='" + lblDate.Text + "' ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                count += Convert.ToInt32(dr["no_of_people"]);
            }
            if (count >= 50)
            {
                lblError.Text = "This slot is full. Please select another date to visit temple.";
            }
            con.Close();
        }

        protected void btnSubt_Click(object sender, EventArgs e)
        {
            if (txtVal.Text == "1")
            {
                lblError2.Text = "1 is the minimum value";
            }
            else
            {
                lblError2.Text = "";
                val = Convert.ToInt32(txtVal.Text) - 1;
                txtVal.Text = Convert.ToString(val);

                amt = 500 * val;
                txtAmt.Text = Convert.ToString(amt);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtVal.Text == "5")
            {
                lblError2.Text = "5 is the maximum value";
            }
            else
            {
                lblError2.Text = "";
                val = Convert.ToInt32(txtVal.Text) + 1;
                txtVal.Text = Convert.ToString(val);

                amt = 500 * val;
                txtAmt.Text = Convert.ToString(amt);
            }
        }

       

        protected void btnCon_Click(object sender, EventArgs e)
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
                con.Open();
                string insert1 = "INSERT INTO epass VALUES ('" + tid + "', '" + u + "', '" + lblDate.Text + "', '" + txtVal.Text + "', '" + t + "')";
                SqlCommand cmdIns1 = new SqlCommand(insert1, con);
                cmdIns1.ExecuteNonQuery();
                /*SqlCommand cmdIns2 = new SqlCommand("INSERT INTO transactions VALUES('" + trans_id + "', '" + u + "', '" + tid + "', '" + date + "', " + amt + ", '" + t + "', 'EPass', 0)", con);
                cmdIns2.ExecuteNonQuery();*/
                con.Close();
            }
        }
    }
}