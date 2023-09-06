using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Runtime.Versioning;
using System.Net;

namespace DataAccessLayer
{
    public class clsStudents
    {
        public static int GetPersonID(int studentID)
        {
            int personid = -1;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "select Persons.ID from Persons join Students" +
                           " on Persons.ID = Students.personID where Students.ID =@studentID ;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("studentID", studentID);
            try
            {
                con.Open();
                  personid = (int)cmd.ExecuteScalar();

                //object result1 = cmd.ExecuteScalar();
                //con.Close();
                //if (result1 != null && int.TryParse(result1.ToString(), out int insertedID))
                //    personid = insertedID;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return personid;
        }
        public static DataTable GetStudents()
        {
            DataTable books = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = "SELECT Students.ID,Persons.FirstName,Persons.LastName,Persons.Address,Persons.Email,Persons.Phone,Students.School,Students.Department,Students.Picture FROM Persons  JOIN Students  ON Students.personID=Persons.ID;";
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
        public static void AddNewStudent(string FirstName,string LastName,string Address,
            string Email,string Phone,string Shool,string Department,string picture)
                      
        {
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "insert into Persons Values (@FirstName,@LastName,@Address,@Email,@Phone); SELECT SCOPE_IDENTITY()";
                cmd.Parameters.AddWithValue("FirstName", FirstName);
                cmd.Parameters.AddWithValue("LastName", LastName);
                cmd.Parameters.AddWithValue("Address", Address);
                cmd.Parameters.AddWithValue("Email", Email);
                cmd.Parameters.AddWithValue("Phone", Phone);

                con.Open();

                object result = cmd.ExecuteScalar();
                int.TryParse(result.ToString(), out int insertedPersonID);

                cmd.CommandText = "insert into Students Values (@Shool,@Department,@Picture,@PersonId)";
                cmd.Parameters.AddWithValue("shool",Shool);
                cmd.Parameters.AddWithValue("Department", Department);
                cmd.Parameters.AddWithValue("Picture",picture);
                cmd.Parameters.AddWithValue("PersonId", insertedPersonID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
        }
        public static void DeleteStudent(int StudentID)
        {
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Students where ID= @StudentID";
                cmd.Parameters.AddWithValue("StudentID", StudentID);

                con.Open();

                cmd.ExecuteNonQuery();

             //   int personid = GetPersonID(StudentID);

                cmd.CommandText = "delete from Persons where ID = personId;";
                cmd.Parameters.AddWithValue("personId", GetPersonID(StudentID));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
        }
        public static void UpDateStudent(int id,string FirstName,string LastName,string Address,
            string Email,string Phone,string School,string Department,string picture)

        {
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "update Persons set FirstName=@FirstName," +
                                                     "LastName=@LastName, " +
                                                     "Address=@Address, " +
                                                     "Email=@Email," +
                                                     "Phone=@Phone " +
                                                     "where " +
                                                     "Id = @personId";
                cmd.Parameters.AddWithValue("firstName",FirstName);
                cmd.Parameters.AddWithValue("lastName",LastName);
                cmd.Parameters.AddWithValue("Address", Address);
                cmd.Parameters.AddWithValue("email",Email);
                cmd.Parameters.AddWithValue("phone",Phone);
                cmd.Parameters.AddWithValue("personId", GetPersonID(id));
                con.Open();

                cmd.ExecuteNonQuery();

                cmd.CommandText = "update Students set School= @School, " +
                                                       "Department=@Department," +
                                                       "Picture=@picture," +
                                                       "personID=@personid " +
                                                       "where ID = @id";
                cmd.Parameters.AddWithValue("School", School);
                cmd.Parameters.AddWithValue("Department", Department);
                cmd.Parameters.AddWithValue("Picture", picture);
                cmd.Parameters.AddWithValue("id", id);

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
        public static bool GetStudentByID(int ID, ref string firstname,
          ref string lastname, ref string address,ref string email,
           ref string phone, ref string school, ref string departmemt,ref string image)
        {
            bool isfound = false;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT Persons.FirstName,Persons.LastName,Persons.Address,Persons.Email,Persons.Phone,Students.School,Students.Department,Students.Picture FROM Persons JOIN Students ON Students.personID=Persons.ID WHERE Students.ID=@ID;";
            SqlCommand cmd = new SqlCommand(Query,con);
            cmd.Parameters.AddWithValue("ID",ID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isfound = true;
                    if (reader["FirstName"] != DBNull.Value)
                    { firstname = (string)reader["FirstName"]; }
                    else firstname = "";

                    if (reader["LastName"] != DBNull.Value)
                    { lastname = (string)reader["LastName"]; }
                    else lastname = "";

                    if (reader["Address"] != DBNull.Value)
                    { address = (string)reader["Address"]; }
                    else address = "";

                    if (reader["Email"] != DBNull.Value)
                    { email = (string)reader["Email"]; }
                    else email = "";

                    if (reader["Phone"] != DBNull.Value)
                    { phone = (string)reader["Phone"]; }
                    else phone = "";

                    if (reader["School"] != DBNull.Value)
                    { school = (string)reader["School"]; }
                    else school = "";

                    if (reader["Department"] != DBNull.Value)
                    { departmemt = (string)reader["Department"]; }
                    else departmemt = "";

                    if (reader["Picture"] != DBNull.Value)
                    { image = (string)reader["Picture"]; }
                    else image = "";
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
            string Query = @"SELECT Students.ID, Persons.FirstName,Persons.LastName,Persons.Address,Persons.Email,Persons.Phone,Students.School,Students.Department,Students.Picture FROM Persons JOIN Students ON Students.personID=Persons.ID WHERE Persons.FirstName LIKE @SEARCH+'%';";
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
