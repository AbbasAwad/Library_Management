using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBusinssLayer.BussStudents;

namespace DataBusinssLayer
{
    public class BussBookSell
    {
        public enum enSellMode { AddnewSell = 0, UpdateSell = 1 }
        public enSellMode SellMode = enSellMode.AddnewSell;

        public int ID {  get; set; }
        public string Student { set; get; }
        public string Book { set; get; }
        public decimal Price { set; get; }
        public DateTime Date { set; get; }
        public BussBookSell()
        {
            ID = 0;
            Student = "";
            Book = "";
            Price = 0;
            Date = DateTime.Now;
            SellMode = enSellMode.AddnewSell;
        }
        public BussBookSell(int id,string student, string book, decimal price, DateTime date)
        {
            ID = id;
            Student = student;
            Book = book;
            Price = price;
            Date = date;
            SellMode = enSellMode.UpdateSell;
        }
        public static DataTable GetBooksSell()
        {
            return clsBookSell.LoadBooksSell();
        }
        public static DataTable GetBooks()
        {
            return clsBookSell.LoadBooks();
        }
        public static DataTable GetStudents()
        {
            return clsBookSell.LoadStudents();
        }
        private void _AddNewSellBook()
        {
            clsBookSell.AddSellBook(Book, Student, Price, Date);
        }
        private void _UpdateSellBook()
        {
            clsBookSell.UpdateSellBook(ID,Book, Student, Price, Date);
        }
        public static BussBookSell Find(int ID)
        {
            string title="", Student = ""; decimal Price = 0; DateTime date= DateTime.Now;

            if (clsBookSell.GetSellBokkByID(ID,ref title,ref Student,ref Price,ref date))
                return new BussBookSell(ID, title, Student, Price, date);
            else
                return null;
        }
        public bool Save()
        {
            switch (SellMode)
            {
                case enSellMode.AddnewSell:
                    {
                        _AddNewSellBook();
                        return true;
                    }
                case enSellMode.UpdateSell:
                    {
                        _UpdateSellBook();
                        return true;
                    }
            }
            return false;
        }
        public static bool DeleteBookSell(int id)
        {
            BussBookSell Book = BussBookSell.Find(id);
            if (Book != null)
            {
                clsBookSell.DeleteBookSell(id);
                return true;
            }
            return false;
        }
        public static DataTable Search(string search)
        {
            return clsBookSell.Search(search);
        }
    }
}
