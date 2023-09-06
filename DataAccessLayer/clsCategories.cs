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
    public class clsCategories
    {
        public static bool GetCATByName(ref int id, string catname)
        {
            bool isfound = false;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM CATS WHERE CAT=@CAT;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("CAT", catname);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    id = (int)reader["ID"];
                }
                else
                    isfound = false;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return isfound;
        }
        public static bool GetCATByID(int ID, ref string catname)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM CATS WHERE ID=@ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    catname = (string)reader["CAT"];
                    isfound = true;
                }
                else isfound = false;
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return isfound;
        }
        public static int AddCAT(string catname)
        {
            int id = -1;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO CATS(CAT)
                           VALUES (@CAT)
                           SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("CAT", catname);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    id = insertedID;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return id;
        }
        public static DataTable GetAllCAT()//int id,string title,string auther,float price,int cat,DateTime date,int rate,string cover)
        {
            DataTable Books = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM CATS;";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                { Books.Load(reader); }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Books;
        }
        public static bool DeletesCAT(int ID)
        {
            int rowsAffects = 0;
             SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
             string Query = @"DELETE FROM CATS WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(Query,con);
            cmd.Parameters.AddWithValue("ID",ID);
            try
            {
                con.Open();
                rowsAffects = cmd.ExecuteNonQuery();
             }
            catch (Exception ex) { }
            finally { con.Close(); }

          return (rowsAffects > 0);
        } 
        public static bool UpdataCAT(int ID, string CATName)
        {
            int rowsAffects = 0;
            SqlConnection con = new SqlConnection( DataAccessSettings.ConnectionString);
            string Query = @"UPDATE CATS  
                            SET CAT=@CAT
                                where ID = @ID";
 
            SqlCommand command = new SqlCommand(Query, con);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@CAT", CATName);
            try
            {
                con.Open();
                rowsAffects = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffects > 0);
        }
        public static bool ISExistByID(int ID)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT X=1 FROM CATS WHERE ID=@ID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isfound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { isfound = false; }
            finally { connection.Close(); }
            return isfound;
        }
        public static bool ISExistByCATName(string CATName)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT X=1 FROM Countries WHERE CATName=@CATName;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CATName", CATName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isfound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex) { isfound = false; }
            finally { connection.Close(); }
            return isfound;
        }

        public static DataTable Search (string search)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection (DataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM CATS WHERE CAT LIKE @SEARCH+'%';";
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
