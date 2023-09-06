using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBusinssLayer;
using Guna.UI.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Labrary_Managment
{
    public partial class BooksBorrow : Form
    {
        public enum enMode { Addnew = 0, Updat = 1 }
        enMode _Mode;
        int _ContactID = -1;
        BussBorrows _Book;
      
        public BooksBorrow(int conactid)
        {
            InitializeComponent();
            _ContactID = conactid;
            if (_ContactID == -1)
                _Mode = enMode.Addnew;
            else
                _Mode = enMode.Updat;
        }

        private void _LoadData()
        {
            if (_Mode == enMode.Addnew)
            {
                lblTitleBook.Text = "Add New Book Borrow";
                _Book = new BussBorrows();
                return;
            }
            _Book = BussBorrows.Find(_ContactID);
            if (_Book == null)
            {
                MessageBox.Show("This Form Will be Closde because With ID");
                this.Close();
                return;
            }
            lblTitleBook.Text = "Edit Book Borrow ID = " + _ContactID;
            txtPrice.Text = _Book.Price.ToString();
            dTPFirstDate.Text = _Book.FirstDate.ToString();
            dTPLastDate.Text = _Book.LastDate.ToString();
            lblBuyer.Text = _Book.Name;
            lblBook.Text = _Book.Title;
            lblBook.BackColor = Color.Red; lblBuyer.BackColor = Color.Red;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BooksBorrow_Load(object sender, EventArgs e)
        {
            _LoadData();
            DGVBooks.DataSource = BussBookSell.GetBooks();
            DGVStudents.DataSource = BussBookSell.GetStudents();
        }

        private void btnSaveBookBorrow_Click_1(object sender, EventArgs e)
        {
            if (txtPrice.Text != "")
            {
                _Book.Price = (decimal)Convert.ToDouble(txtPrice.Text);
                _Book.FirstDate = dTPFirstDate.Value;
                _Book.LastDate = dTPLastDate.Value;
                _Book.Title = DGVBooks.CurrentRow.Cells[1].Value.ToString();
                _Book.Name = DGVStudents.CurrentRow.Cells[1].Value.ToString();
                if (_Book.Save())
                    MessageBox.Show("Data Save Successfully");
                else
                    MessageBox.Show("Data Save Faild");

                lblTitleBook.Text = "Book Borrow " + _Book.ID.ToString();
                dTPFirstDate.Enabled = false;
                btnSaveBookBorrow.Enabled = false;
                txtPrice.Enabled = false;
                lblBook.Text = DGVBooks.CurrentRow.Cells[1].Value.ToString();
                lblBuyer.Text = DGVStudents.CurrentRow.Cells[1].Value.ToString();

            }
            else
                MessageBox.Show("Please Fill In All Fields");
        }
    }
}
