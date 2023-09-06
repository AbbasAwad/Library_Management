using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsBorrows
    {
        public static DataTable GetBooksBorrow()
        {
            DataTable books = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM BooksBorrow";
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
        public static int AddNewBooksBorrow(string name, string title, DateTime firstdate,
                                            DateTime lastdate, decimal Price)
        {
            int BookID = -1;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO BooksBorrow(Name,Title,FirstDate,LastDate,Price)
                           VALUES (@Name,@Title,@firstdate,@lastdate,@price)
                           SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@FirstDate", firstdate);
            cmd.Parameters.AddWithValue("@LastDate", lastdate);
            cmd.Parameters.AddWithValue("@Price", Price);

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

        public static bool DeleteBooksBorrow(int bookID)
        {
            int rowsAffected = 0;

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM BooksBorrow WHERE ID=@ID;";
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

        public static bool UpDateBooksBorrow(int id, string name, string title, DateTime firstdate,
                                            DateTime lastdate, decimal Price)
        {
            int rowsAffected = 0;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"UPDATE BooksBorrow
                             set Name=@name,
                                 Title=@title,
                                 FirstDate=@firstdate,
                                 LastDate=@lastdate,
                                 Price=@Date
                                 WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(@Query, con);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@FirstDate", firstdate);
            cmd.Parameters.AddWithValue("@LastDate", lastdate);
            cmd.Parameters.AddWithValue("@Price", Price);

            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);

        }

        public static bool GetBooksBorrowInfoByID( int id,ref string name,ref string title,
                              ref DateTime firstdate,ref DateTime lastdate,ref decimal Price)
        {
            bool isfound = false;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM BooksBorrow WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("ID", id);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;

                    name = (string)reader["Name"];
                    title = (string)reader["Title"];
                    firstdate = (DateTime)reader["FirstDate"];
                    lastdate = (DateTime)reader["LastDate"];
                    Price = (decimal)reader["Price"];
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
            string Query = @"SELECT * FROM BooksBorrow WHERE Name LIKE @SEARCH+'%';";
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

        public static DataTable LoadBooks()
        {
            DataTable Books = new DataTable();

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT ID,Title FROM Books;";

            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Books.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Books;
        }
        public static DataTable LoadStudents()
        {
            DataTable Students = new DataTable();

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT ID , FirstName +' '+ LastName as Full_Name FROM Persons;";

            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Students.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Students;
        }
    }
}
