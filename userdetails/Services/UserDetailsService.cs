using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using userdetails.Models;

namespace userdetails.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        public void DeleteUser(int id)
        {
            using (SqlConnection con = new SqlConnection("Data Source = DESKTOP-Q0AORF2;Integrated Security = true;Initial Catalog =MySampleDB"))
            {
                using (SqlCommand cmd = new SqlCommand("Delete from userdetails where userid=@id;", con))
                {
                    //cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public UserDetails GetUserDetails()
        {
            UserDetails objuser = new UserDetails();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection("Data Source = DESKTOP-Q0AORF2;Integrated Security = true;Initial Catalog =MySampleDB"))
            {
                using (SqlCommand cmd = new SqlCommand("usercrudoperations", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "GET");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    List<UserDetails> userlist = new List<UserDetails>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        UserDetails uobj = new UserDetails();
                        uobj.UserId = Convert.ToInt32(ds.Tables[0].Rows[i]["userid"].ToString());
                        uobj.UserName = ds.Tables[0].Rows[i]["username"].ToString();
                        uobj.Education = ds.Tables[0].Rows[i]["education"].ToString();
                        uobj.Location = ds.Tables[0].Rows[i]["location"].ToString();
                        userlist.Add(uobj);
                    }
                    objuser.usersinfo = userlist;
                }
                con.Close();
            }
            return objuser;
        }

        public int InsertNewUser(UserDetails user)
        {
            int res = 0;
            using (SqlConnection con = new SqlConnection("Data Source = DESKTOP-Q0AORF2;Integrated Security = true;Initial Catalog =MySampleDB"))
            {
                using (SqlCommand cmd = new SqlCommand("usercrudoperations", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", user.UserName);
                    cmd.Parameters.AddWithValue("@education", user.Education);
                    cmd.Parameters.AddWithValue("@location", user.Location);
                    cmd.Parameters.AddWithValue("@status", "INSERT");
                    con.Open();
                    res= cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return res;
        }
    }
}
