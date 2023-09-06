using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace DataBusinssLayer
{
    public class BussCategories
    {
        enum enMode { Addnew = 0, Updatenew = 1 }
      enMode Mode = enMode.Addnew;
       
        public int ID { get; set; }
        public string CATName { get; set; }

       public BussCategories()
        {
            this.ID = -1;
            this.CATName = "";
            Mode = enMode.Addnew;
        }
        public BussCategories(int id,string catname)
        {
            this.ID = id;
            this.CATName = catname;
            Mode = enMode.Updatenew;
        }

        public static BussCategories Find(int id)
        {
            string catname = "";
            if (clsCategories.GetCATByID(id, ref catname))
                return new BussCategories(id, catname);
            else
                return null ;
        }

        public static BussCategories Find(string catname)
        {
            int id = -1;
            if(clsCategories.GetCATByName(ref id,catname))
                return new BussCategories(id,catname);
            else
                return null ;
        }

        public static DataTable Search(string search)
        {
            return clsCategories.Search(search);
        }
        private bool _AddNewCAT()
        {
           this.ID = clsCategories.AddCAT(this.CATName);
            return (this.ID != -1);             
        }

        private bool _UpdateCAT()
        {
            return (clsCategories.UpdataCAT(ID, CATName));
        }

        public static bool DeleteCAT(int id)
        {
            BussCategories CAT = BussCategories.Find(id);
            if (CAT != null)
            {
                clsCategories.DeletesCAT(id);
                return true;
            }
            else
                return false;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Addnew:
                    if (_AddNewCAT())
                    {
                        Mode = enMode.Updatenew;
                        return true;
                    }
                    return false;
                case enMode.Updatenew:
                    return _UpdateCAT();
            }
            return false;
        }

        public static DataTable GetAllCAT()
        {
            return clsCategories.GetAllCAT();
        }

        public static bool ISExistCAT(int id)
        {
            return clsCategories.ISExistByID(id);
        }

        public static bool ISExistCAT(string catname)
        {
            return clsCategories.ISExistByCATName(catname);
        }
    }
}
