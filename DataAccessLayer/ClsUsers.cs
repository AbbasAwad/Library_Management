using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClsUsers
    {
        public static DataTable GetUsers()
        {
            DataTable Users = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Users.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Users;
        }

        public static int AddNewUser(string name, string username, string password, string premission)//, int state)

        {
            int UserID = -1;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Users(Name,UserName,PassWord,Permissions)
                           VALUES (@name,@username,@password,@premission)
                           SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(Query, con);

            if (name != "")
                cmd.Parameters.AddWithValue("@Name", name);
            else
                cmd.Parameters.AddWithValue("@Name", System.DBNull.Value);

            if (username != "")
                cmd.Parameters.AddWithValue("@UserName", username);
            else
                cmd.Parameters.AddWithValue("@UserName", System.DBNull.Value);

            if (password != "")
                cmd.Parameters.AddWithValue("@PassWord", password);
            else
                cmd.Parameters.AddWithValue("@PassWord", System.DBNull.Value);

            if (premission != "")
                cmd.Parameters.AddWithValue("@premission", premission);
            else
                cmd.Parameters.AddWithValue("@premission", System.DBNull.Value);
            try
            {
                con.Open();
                object result1 = cmd.ExecuteScalar();
                con.Close();
                if (result1 != null && int.TryParse(result1.ToString(), out int insertedID))
                    UserID = insertedID;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return UserID;
        }
        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM Users WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("ID", UserID);

            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);
        }

        public static bool UpDateUser(int id, string name, string username, string password,
                                                           string premission)//, int state)
        {
            int rowsAffected = 0;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Users
                             set Name=@name,
                                 UserName=@username,
                                 PassWord=@password,
                                 Permissions=@premission
                                 WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(@Query, con);

            cmd.Parameters.AddWithValue("ID", id);
            if (name != "")
                cmd.Parameters.AddWithValue("@name", name);
            else
                cmd.Parameters.AddWithValue("@name", System.DBNull.Value);

            if (username != "")
                cmd.Parameters.AddWithValue("@username", username);
            else
                cmd.Parameters.AddWithValue("@username", System.DBNull.Value);

            if (password != "")
                cmd.Parameters.AddWithValue("@password", password);
            else
                cmd.Parameters.AddWithValue("@password", System.DBNull.Value);

            if (premission != "")
                cmd.Parameters.AddWithValue("@premission", premission);
            else
                cmd.Parameters.AddWithValue("@premission", System.DBNull.Value);

            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);

        }
        public static bool GetUsersInfoByID(int id, ref string name, ref string username, ref string password,
                                                                    ref string premission)//,ref int state)
        {
            bool isfound = false;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Users WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("ID", id);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    if (reader["Name"] != DBNull.Value)
                    { name = (string)reader["Name"]; }
                    else name = "";

                    if (reader["UserName"] != DBNull.Value)
                    { username = (string)reader["UserName"]; }
                    else username = "";

                    if (reader["PassWord"] != DBNull.Value)
                    { password = (string)reader["PassWord"]; }
                    else password = "";

                    if (reader["Permissions"] != DBNull.Value)
                    { premission = (string)reader["Permissions"]; }
                    else premission = "";
                }
                else
                    isfound = false;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isfound;
        }
        public static DataTable Search(string search)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Users WHERE Name LIKE @SEARCH+'%';";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("SEARCH", search);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                { dt.Load(reader); }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return dt;
        }

        public static DataTable GetAllPermissions()
        {
            DataTable Per = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Permissions;";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                { Per.Load(reader); }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Per;
        }

        public static bool Login(string User, string Password ,ref int id ,ref string name, ref string username,
                                                                ref string password,  ref string premission)                    
        {
            bool isfound=false;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Users WHERE UserName=@User AND PassWord=@Password;";
            SqlCommand cmd = new SqlCommand(@Query, con);

            cmd.Parameters.AddWithValue("User", User);
            cmd.Parameters.AddWithValue("Password", Password);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    id = (int)reader["ID"];
                    if (reader["Name"] != DBNull.Value)
                    { name = (string)reader["Name"]; }
                    else name = "";

                    if (reader["UserName"] != DBNull.Value)
                    { username = (string)reader["UserName"]; }
                    else username = "";

                    if (reader["PassWord"] != DBNull.Value)
                    { password = (string)reader["PassWord"]; }
                    else password = "";

                    if (reader["Permissions"] != DBNull.Value)
                    { premission = (string)reader["Permissions"]; }
                    else premission = "";
                }
                else
                    isfound = false;            
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isfound;
        }
    }
    
}
