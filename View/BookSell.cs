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
    public partial class BookSell : Form
    {
        public enum enMode { Addnew = 0, Updat = 1 }
        enMode _Mode;
        int _ContactID = -1;
        BussBookSell _BookSell;
      
        public BookSell(int conactid)
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
                lblTitleBook.Text = "Add New Book Sell";
                _BookSell = new BussBookSell();
                return;
            }
            _BookSell = BussBookSell.Find(_ContactID);
            if (_BookSell == null)
            {
                MessageBox.Show("This Form Will be Closde because With ID");
                this.Close();
                return;
            }
            lblTitleBook.Text = "Edit Book ID = " + _ContactID;
            txtPrice.Text = _BookSell.Price.ToString();
            dTPDate.Text = _BookSell.Date.ToString();
            lblBuyer.Text = _BookSell.Book;
            lblBook.Text = _BookSell.Student;
            lblBook.BackColor = Color.Red; lblBuyer.BackColor = Color.Red;
           //DGVBooks.Visible = false;
           //DGVStudents.Visible = false;
        }
        private void btnSaveBookSell_Click(object sender, EventArgs e)
        {
            if (txtPrice.Text != "" )
            {
                _BookSell.Price = (decimal)Convert.ToDouble(txtPrice.Text);
                _BookSell.Date = dTPDate.Value;
                _BookSell.Book = DGVBooks.CurrentRow.Cells[1].Value.ToString();
                _BookSell.Student = DGVStudents.CurrentRow.Cells[1].Value.ToString();
                if (_BookSell.Save())
                    MessageBox.Show("Data Save Successfully");
                else
                    MessageBox.Show("Data Save Faild");

                lblTitleBook.Text = "Book Sell "+ _BookSell.ID.ToString();
                dTPDate.Enabled = false;
                btnSaveBookSell.Enabled = false;
                txtPrice.Enabled = false;
                lblBook.Text = DGVBooks.CurrentRow.Cells[1].Value.ToString();
                lblBuyer.Text = DGVStudents.CurrentRow.Cells[1].Value.ToString();

            }
            else
                MessageBox.Show("Please Fill In All Fields");
        }
        private void BookSell_Load(object sender, EventArgs e)
        {
            _LoadData();
            DGVBooks.DataSource = BussBookSell.GetBooks();
            DGVStudents.DataSource = BussBookSell.GetStudents();
        }  

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
