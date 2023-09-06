using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsBookSell
    {
        public static DataTable LoadBooksSell()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM BookSell;";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
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

        public static bool GetSellBokkByID(int ID,ref string title,ref string Name,ref decimal price,ref DateTime date)
        {
            bool isfound = false;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM BookSell WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("ID", ID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    if (reader["BookTitle"] != DBNull.Value)
                    { title = (string)reader["BookTitle"]; }
                    else title = "";

                    if (reader["StudentName"] != DBNull.Value)
                    { Name = (string)reader["StudentName"]; }
                    else Name = "";

                    if (reader["SellPrice"] != DBNull.Value)
                    { price = (decimal)reader["SellPrice"]; }
                    else price = 0;

                    if (reader["SellDate"] != DBNull.Value)
                    { date = (DateTime)reader["SellDate"]; }
                    else date = DateTime.Now;                  
                }
                else
                    isfound = false;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isfound;
        }
        public static void AddSellBook(string Title, string Name, decimal Price, DateTime date)
        {
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"insert into BookSell (StudentName,BookTitle,SellPrice,SellDate) Values (@Name,@Title,@Price,@Date);";
                cmd.Parameters.AddWithValue("Name", Name);
                cmd.Parameters.AddWithValue("Title", Title);
                cmd.Parameters.AddWithValue("Price", Price);
                cmd.Parameters.AddWithValue("Date", date);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
        }
   
        public static void UpdateSellBook(int ID,string Title, string Student, decimal Price, DateTime date)
        {
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"update BookSell
                                               set StudentName=@Student,
                                                     BookTitle=@Title, 
                                                     SellPrice=@Price, 
                                                     SellDate=@Date
                                                     where ID = @Id;";
                cmd.Parameters.AddWithValue("Student",Student);
                cmd.Parameters.AddWithValue("Title", Title);
                cmd.Parameters.AddWithValue("Price", Price);
                cmd.Parameters.AddWithValue("Date", date);
                cmd.Parameters.AddWithValue("id", ID);
                con.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static bool DeleteBookSell(int booksellID)
        {
            int rowsAffected = 0;

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM BookSell WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("ID", booksellID);

            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);
        }
        public static DataTable Search(string search)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString); 
            string Query = @"SELECT * FROM BookSell WHERE StudentName LIKE @SEARCH+'%';";
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
