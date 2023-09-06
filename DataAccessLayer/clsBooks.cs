using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    public class clsBooks
    {
        public static DataTable GetBooks()
        {
            DataTable books = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Books";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    books.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return books;
        }
        public static int AddNewBook(string title, string auther, decimal price,
                      int CAT, DateTime date, int rate, string cover)
        {
            int BookID = -1;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Books(Title,Auther,Price,CAT,Date,Rate,Cover)
                           VALUES (@Title,@Auther,@Price,@CAT,@Date,@Rate,@Cover)
                           SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(Query, con);

            if (title != "")
                cmd.Parameters.AddWithValue("@Title", title);
            else
                cmd.Parameters.AddWithValue("@Title", System.DBNull.Value);

            if (auther != "")
                cmd.Parameters.AddWithValue("@Auther", auther);
            else
                cmd.Parameters.AddWithValue("@Auther", System.DBNull.Value);

            if (price != 0)
                cmd.Parameters.AddWithValue("@Price", price);
            else
                cmd.Parameters.AddWithValue("@Price", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@CAT", CAT);
            cmd.Parameters.AddWithValue("@Date", date);

            if (rate != 0)
                cmd.Parameters.AddWithValue("@Rate", rate);
            else
                cmd.Parameters.AddWithValue("@Rate", System.DBNull.Value);

            if (cover != " ")
                cmd.Parameters.AddWithValue("@Cover", cover);
            else
                cmd.Parameters.AddWithValue("@Cover", System.DBNull.Value);
            try
            {
                con.Open();
                object result1 = cmd.ExecuteScalar();
                con.Close();
                if (result1 != null && int.TryParse(result1.ToString(), out int insertedID))
                    BookID = insertedID;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return BookID;
        }

        public static bool DeleteBook(int bookID)
        {
            int rowsAffected = 0;

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM Books WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("ID", bookID);

            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);
        }

        public static bool UpDateBook(int id, string title, string auther,
                      decimal price, int CAT, DateTime date, int rate, string cover)
        {
            int rowsAffected = 0;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"UPDATE Books
                             set Title=@Title,
                                 Auther=@Auther,
                                 Price=@Price,
                                 CAT=@CAT,
                                 Date=@Date,
                                 Rate=@Rate,
                                 Cover=@Cover
                                 WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(@Query, con);

            cmd.Parameters.AddWithValue("ID", id);
            if (title != "")
                cmd.Parameters.AddWithValue("@Title", title);
            else
                cmd.Parameters.AddWithValue("@Title", System.DBNull.Value);

            if (auther != "")
                cmd.Parameters.AddWithValue("@Auther", auther);
            else
                cmd.Parameters.AddWithValue("@Auther", System.DBNull.Value);

            if (price != 0)
                cmd.Parameters.AddWithValue("@Price", price);
            else
                cmd.Parameters.AddWithValue("@Price", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@CAT", CAT);
            cmd.Parameters.AddWithValue("@Date", date);

            if (rate != 0)
                cmd.Parameters.AddWithValue("@Rate", rate);
            else
                cmd.Parameters.AddWithValue("@Rate", System.DBNull.Value);

            if (cover != " ")
                cmd.Parameters.AddWithValue("@Cover", cover);
            else
                cmd.Parameters.AddWithValue("@Cover", System.DBNull.Value);
            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);

        }

        public static bool GetBooksInfoByID(int bookID, ref string title,
          ref string auther, ref decimal price,
          ref int cat, ref DateTime date, ref int rate, ref string cover)
        {
            bool isfound = false;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Books WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("ID", bookID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    if (reader["Title"] != DBNull.Value)
                    { title = (string)reader["Title"]; }
                    else title = "";

                    if (reader["Auther"] != DBNull.Value)
                    { auther = (string)reader["Auther"]; }
                    else auther = "";

                    if (reader["Price"] != DBNull.Value)
                    { price = (decimal)reader["Price"]; }
                    else price = 0;

                    cat = (int)reader["CAT"];

                    date = (DateTime)reader["Date"];

                    if (reader["Rate"] != DBNull.Value)
                    { rate = (int)reader["Rate"]; }
                    else rate = 0;

                    if (reader["Cover"] != DBNull.Value)
                    { cover = (string)reader["Cover"]; }
                    else cover = "";
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
            string Query = @"SELECT * FROM Books WHERE Title LIKE @SEARCH+'%';";
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
    }
}
