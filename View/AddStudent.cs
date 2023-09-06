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
    public partial class AddStudent : Form
    {
        public enum enMode { Addnew = 0, Updat = 1 }
        enMode _Mode;
        int _ContactID = -1;
        BussStudents _Student;
        public AddStudent(int conactid)
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
                lblTitleBook.Text = "Add New Student";
                _Student = new BussStudents();
                label9.Visible = false;
                lblID.Visible = false;
                linkLabel2.Visible = (pictureStudent.ImageLocation != null);
                return;
            }
            _Student = BussStudents.Find(_ContactID);
            if ( _Student == null)
            {
                MessageBox.Show("This Form Will be Closde because With ID");
                this.Close();
                return;
            }
            lblTitleBook.Text = "Edit Student ID = " + _ContactID;
            lblID.Text = _ContactID.ToString();
            txtFirstName.Text = _Student.FirstName;
            txtLastName.Text = _Student.LastName;
            txtAddress.Text = _Student.Address;
            txtEmail.Text = _Student.Email;
            txtPhone.Text = _Student.Phone;
            txtSchool.Text = _Student.School;
            txtDepatment.Text = _Student.Department;
            pictureStudent.Load(_Student.Picture);
            linkLabel2.Visible = (pictureStudent.ImageLocation != null);
            txtFirstName.Focus();
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
                pictureStudent.Load(selectedFilePath);
                // ...
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureStudent.ImageLocation = null;
            linkLabel2.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "First Name ...")
            {
                txtFirstName.Text = "";
                txtFirstName.ForeColor = Color.Black;
            }
        }
        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                txtFirstName.Text = "First Name ...";
                txtFirstName.ForeColor = Color.Silver;
            }
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            if (txtLastName.Text == "Last Name ...")
            {
                txtLastName.Text = "";
                txtLastName.ForeColor = Color.Black;
            }
        }
        private void txtLastName_Leave(object sender, EventArgs e)
        {
            if (txtLastName.Text == "")
            {
                txtLastName.Text = "Last Name ...";
                txtLastName.ForeColor = Color.Silver;
            }
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            _LoadData();    
        }

        private void btnSaveAddStudent_Click_1(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "")
            {
                _Student.FirstName = txtFirstName.Text;
                _Student.LastName = txtLastName.Text;
                _Student.Address = txtAddress.Text;
                _Student.Email = txtEmail.Text;
                _Student.Phone = txtPhone.Text;
                _Student.School = txtSchool.Text;
                _Student.Department = txtDepatment.Text;
                _Student.Picture = pictureStudent.ImageLocation;
                linkLabel2.Visible = (pictureStudent.ImageLocation != null);
                if (_Student.Save())
                    MessageBox.Show("Data Save Successfully");
                else
                    MessageBox.Show("Data Save Faild");

                label9.Visible = true;
                lblID.Visible = true;
                lblID.Text = _Student.ID.ToString();
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtAddress.Enabled = false;
                txtEmail.Enabled = false;
                txtPhone.Enabled = false;
                txtDepatment.Enabled = false;
                txtSchool.Enabled = false;
                linkLabel1.Enabled = false;
                linkLabel2.Enabled = false;
                btnSaveAddStudent.Enabled = false;
            }
            else
                MessageBox.Show("Please Fill In All Fields");
        }
    }
}
