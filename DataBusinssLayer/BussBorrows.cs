using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace DataBusinssLayer
{
    public class BussBorrows
    {
        public enum enMode { AddMode = 0, UpdatMode = 1 }
        public enMode Mode = enMode.AddMode;

        public int ID { set; get; }
        public string Name { set; get; }
        public string Title { set; get; }
        public DateTime FirstDate { set; get; }
        public DateTime LastDate { set; get; }
        public decimal Price { set; get; }

        public BussBorrows(int id, string name, string title, DateTime firstdate,
                                                DateTime lastdate, decimal price)
        {
            ID = id;
            Name = name;
            Title = title;
            FirstDate = firstdate;
            LastDate = lastdate;
            Price = price;
            Mode = enMode.UpdatMode;
        }
        public BussBorrows()
        {
            ID = -1;
            Name = "";
            Title = "";
            FirstDate = DateTime.Now;
            LastDate = DateTime.Now;
            Price = 0;
            Mode = enMode.AddMode;
        }
        public static BussBorrows Find(int id)
        {
            string name = "", title = "";
            DateTime firstdate = DateTime.Now;
            DateTime lastdate = DateTime.Now;
            decimal price = 0;


            if (clsBorrows.GetBooksBorrowInfoByID(id, ref name, ref title, ref firstdate,
                                    ref lastdate, ref price))
                return new BussBorrows(id, name, title, firstdate,
                                       lastdate, price);
            else
                return null;
        }
        private bool _AddNewBooksBorrow()
        {
            this.ID = clsBorrows.AddNewBooksBorrow(this.Name, this.Title, this.FirstDate,
                                                             this.LastDate, this.Price);
            return (this.ID != -1);
        }
        private bool _UpdatBooksBorrow()
        {
            return clsBorrows.UpDateBooksBorrow(this.ID, this.Name, this.Title, this.FirstDate,
                                                this.LastDate, this.Price);

        }
        public static bool DeleteBooksBorrow(int id)
        {
            BussBorrows Book = BussBorrows.Find(id);
            if (Book != null)
            {
                clsBorrows.DeleteBooksBorrow(id);
                return true;
            }
            return false;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddNewBooksBorrow())
                    {
                        Mode = enMode.UpdatMode;
                        return true;
                    }
                    return false;
                case enMode.UpdatMode:
                    return _UpdatBooksBorrow();
            }
            return false;
        }
        public static DataTable GetAllBooksBorrow()
        {
            return clsBorrows.GetBooksBorrow();
        }
        public static DataTable Search(string search)
        {
            return clsBorrows.Search(search);
        }
        public static DataTable GetBooks()
        {
            return clsBorrows.LoadBooks();
        }
        public static DataTable GetStudents()
        {
            return clsBorrows.LoadStudents();
        }
    }
}

