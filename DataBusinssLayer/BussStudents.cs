using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinssLayer
{
    public class BussStudents
    {
       public enum enStudent { AddStudent = 0, UpdateStudent = 1 }
       public enStudent student = enStudent.AddStudent;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string School { get; set; }
        public string Department { get; set; }
        public string Picture { get; set; }

       public BussStudents()
        {
            ID = 0;
            FirstName = "";
            LastName = "";
            Address = "";
            Email = "";
            Phone = "";
            School = "";
            Department = "";
            Picture = "";
            student = enStudent.AddStudent;
        }
       public BussStudents( int iD, string firstName, string lastName, string address,
            string email, string phone, string school, string department,
            string picture)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            Phone = phone;
            School = school;
            Department = department;
            Picture = picture;
            student = enStudent.UpdateStudent;
        }

        public static BussStudents Find(int id)
        {
            string firstName = "", lastName = "", address = "", email = ""
                , phone = "", school = "", department = "", picture = "";
            if(clsStudents.GetStudentByID(id,ref firstName,ref lastName,ref address,
                          ref email,ref phone,ref school,ref department,ref picture))
                return new BussStudents(id,firstName,lastName,address,email,phone,
                                         school,department,picture);
            else 
                return null;
        }

        private void _AddNewStudent()
        {
             clsStudents.AddNewStudent(this.FirstName, this.LastName, this.Address,
                       this.Email,this.Phone,this.School,this.Department,this.Picture);
        }

        private void _UpdatStudent()
        {
            clsStudents.UpDateStudent(this.ID,this.FirstName, this.LastName, this.Address,
                       this.Email, this.Phone, this.School, this.Department, this.Picture);
        }

        public static bool DeleteStudent(int id)
        {
            BussStudents student = BussStudents.Find(id);
            if (student != null)
            {
                clsStudents.DeleteStudent(id);
                return true;
            }
            return false;
        }

        public bool Save()
        {
            switch (student)
            {
                case enStudent.AddStudent:
                    {
                        _AddNewStudent();
                        return true;
                    }
                case enStudent.UpdateStudent:
                    {
                        _UpdatStudent();
                        return true;
                    }
            }
            return false;
        }

        

        public static DataTable GetAllStudents()
        {
            return clsStudents.GetStudents();
        }

        public static DataTable Search(string search)
        {
            return clsStudents.Search(search);
        }
    }
}
