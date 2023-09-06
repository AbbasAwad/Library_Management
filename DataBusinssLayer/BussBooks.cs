using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace DataBusinssLayer
{
    public class BussBooks
    {
        public enum enMode { AddMode = 0, UpdatMode = 1 }
        public enMode Mode = enMode.AddMode;

        public int ID { set; get; }
        public string Title { set; get; }
        public string Auther { set; get; }
        public decimal Price { set; get; }
        public int CAT { set; get; }
        public DateTime Date { set; get; }
        public int Rate { set; get; }
        public string Cover { set; get; }

        public BussBooks(int id, string title, string auther,
            decimal price, int cat, DateTime date, int rate, string cover)

        {
            ID = id;
            Title = title;
            Auther = auther;
            Price = price;
            CAT = cat;
            Date = date;
            Rate = rate;
            Cover = cover;
            Mode = enMode.UpdatMode;
        }
        public BussBooks()
        {
            ID = -1;
            Title = "";
            Auther = "";
            Price = 0;
            CAT = 0;
            Date = DateTime.Now;
            Rate = 0;
            Cover = "";
            Mode = enMode.AddMode;
        }

        public static BussBooks Find(int id)
        {
            string title = "", auther = "", cover = "";
            int cat = -1, rate = 0; decimal price = 0;
            DateTime date = DateTime.Now;

            if (clsBooks.GetBooksInfoByID(id, ref title, ref auther, ref price,
                                    ref cat, ref date, ref rate, ref cover))
                return new BussBooks(id, title, auther, price, cat, date,
                                        rate, cover);
            else
                return null;
        }

        private bool _AddNewBook()
        {
            this.ID = clsBooks.AddNewBook(this.Title, this.Auther, this.Price,
                          this.CAT, this.Date, this.Rate, this.Cover);
            return (this.ID != -1);
        }

        private bool _UpdatBook()
        {
            return clsBooks.UpDateBook(this.ID, this.Title, this.Auther,
                   this.Price, this.CAT, this.Date, this.Rate, this.Cover);

        }

        public static bool DeleteBook(int id)
        {
            BussBooks Book = BussBooks.Find(id);
            if (Book != null)
            {
                clsBooks.DeleteBook(id);
                return true;
            }
            return false;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddNewBook())
                    {
                        Mode = enMode.UpdatMode;
                        return true;
                    }
                    return false;
                case enMode.UpdatMode:
                    return _UpdatBook();
            }
            return false;
        }
        public static DataTable GetAllBooks()
        {
            return clsBooks.GetBooks();
        }

        public static DataTable Search(string search)
        {
            return clsBooks.Search(search);
        }
    }
}
