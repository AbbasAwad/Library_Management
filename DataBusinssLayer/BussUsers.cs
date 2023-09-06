using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBusinssLayer
{
    public class BussUsers
    {
        public enum enMode { AddMode = 0, UpdatMode = 1 }
        public enMode Mode = enMode.AddMode;

        public int ID { set; get; }
        public string Name { set; get; }
        public string UserName { set; get; }
        public string PassWord { set; get; }
        public string Premissions { set; get; }
      //  public int stateUser { set; get; }

        public BussUsers(int id, string name, string username, string password, string premission)//, int state)
                                                 
        {
            ID = id;
            Name = name;
            UserName = username;
            PassWord = password;
            Premissions = premission;
           // stateUser = state;
            Mode = enMode.UpdatMode;
        }
        public BussUsers()
        {
            ID = -1;
            Name = "";
            UserName = "";
            PassWord = "";
            Premissions = "";
          //  stateUser = 0;
            Mode = enMode.AddMode;
        }

        public static BussUsers Find(int id)
        {
            string name = "", username = "", password = "", premission="";
          //  int state = -1;
            DateTime date = DateTime.Now;

            if (ClsUsers.GetUsersInfoByID( id,ref name,ref username,ref password,ref premission))
                                                          
                return new BussUsers(id, name, username, password, premission);
            else
                return null;
        }
        public static BussUsers Find(string User, string Password)
        {
            string name = "", username = "", password = "", premission = "";
            int id = -1;

            if (ClsUsers.Login(User, Password,ref id, ref name, ref username, ref password, ref premission))

                return new BussUsers(id, name, username, password, premission);
            else
                return null;
        }

        private bool _AddNewUser()
        {
            this.ID = ClsUsers.AddNewUser(this.Name, this.UserName, this.PassWord,
                                                  this.Premissions);//, this.stateUser=0);
            return (this.ID != -1);
        }

        private bool _UpdatUser()
        {
            return ClsUsers.UpDateUser(this.ID, this.Name, this.UserName, this.PassWord,
                                                        this.Premissions);//, this.stateUser);
        }

        public static bool DeleteUser(int id)
        {
            BussUsers user = BussUsers.Find(id);
            if (user != null)
            {
                ClsUsers.DeleteUser(id);
                return true;
            }
            return false;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddNewUser())
                    {
                        Mode = enMode.UpdatMode;
                        return true;
                    }
                    return false;
                case enMode.UpdatMode:
                    return _UpdatUser();
            }
            return false;
        }
        public static DataTable GetAllUses()
        {
            return ClsUsers.GetUsers();
        }

        public static DataTable Search(string search)
        {
            return ClsUsers.Search(search);
        }

        public static DataTable GetAllPermissions()
        {
            return ClsUsers.GetAllPermissions();
        }
    }
}
