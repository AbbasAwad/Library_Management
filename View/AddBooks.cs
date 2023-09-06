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
    public partial class AddBooks : Form
    {
        public enum enMode { Addnew = 0, Updat = 1 }
        enMode _Mode;
        int _ContactID = -1;
        BussBooks _Book;
        public void FillCATSInComboBox()
        {
            DataTable dt = BussCategories.GetAllCAT();
            foreach (DataRow row in dt.Rows)
            {
                cmbCAT.Items.Add(row["CAT"]);
            }
        }
        public AddBooks(int conactid)
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
            FillCATSInComboBox();
            cmbCAT.SelectedIndex = 0;
            if (_Mode == enMode.Addnew)
            {
                lblTitleBook.Text = "Add New Book";
                _Book = new BussBooks();
                label9.Visible = false;
                lblID.Visible = false;
                linkLabel2.Visible = (picture.ImageLocation != null);
                return;
            }
            _Book = BussBooks.Find(_ContactID);
            if (_Book == null)
            {
                MessageBox.Show("This Form Will be Closde because With ID");
                this.Close();
                return;
            }
            lblTitleBook.Text = "Edit Book ID = " + _ContactID;
            lblID.Text = _ContactID.ToString();
            txtTitle.Text = _Book.Title;
            txtAuther.Text = _Book.Auther;
            txtPrice.Text = _Book.Price.ToString();
            txtRate.Text = _Book.Rate.ToString();
            cmbCAT.SelectedIndex = cmbCAT.FindString(BussCategories.Find(_Book.CAT).CATName);
            dTPDate.Text = _Book.Date.ToString();
            picture.Load(_Book.Cover);
            linkLabel2.Visible = (picture.ImageLocation != null);
            txtTitle.Focus();
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSaveAddBook_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtAuther.Text != "" && txtPrice.Text != ""
                && txtRate.Text != "" && picture.ImageLocation != null)
            {
                int CATID = BussCategories.Find(cmbCAT.Text).ID;
                _Book.Title = txtTitle.Text;
                _Book.Auther = txtAuther.Text;
                _Book.Price = (decimal)Convert.ToDouble(txtPrice.Text);

                _Book.CAT = CATID;
                _Book.Date = dTPDate.Value;
                _Book.Rate = Convert.ToInt32(txtRate.Text);
                _Book.Cover = picture.ImageLocation;
                if (_Book.Save())
                    MessageBox.Show("Data Save Successfully");
                else
                    MessageBox.Show("Data Save Faild");

                label9.Visible = true;
                lblID.Visible = true;
                lblID.Text = _Book.ID.ToString();

                txtTitle.Enabled = false;
                txtAuther.Enabled = false;
                txtPrice.Enabled = false;
                cmbCAT.Enabled = false;
                txtRate.Enabled = false;
                dTPDate.Enabled = false;
                linkLabel1.Enabled = false;
                linkLabel2.Enabled = false;
                btnSaveAddBook.Enabled = false;
            }
            else
                MessageBox.Show("Please Fill In All Fields");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            linkLabel2.Visible = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);
                picture.Load(selectedFilePath);
                // ...
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picture.ImageLocation = null;
            linkLabel2.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
