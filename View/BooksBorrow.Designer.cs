namespace Labrary_Managment
{
    partial class BooksBorrow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitleBook = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI.WinForms.GunaGradientTileButton();
            this.btnSaveBookBorrow = new Guna.UI.WinForms.GunaTileButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dTPLastDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dTPFirstDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.lblBuyer = new System.Windows.Forms.Label();
            this.lblBook = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.DGVBooks = new System.Windows.Forms.DataGridView();
            this.DGVStudents = new System.Windows.Forms.DataGridView();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleBook
            // 
            this.lblTitleBook.AutoSize = true;
            this.lblTitleBook.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitleBook.Location = new System.Drawing.Point(450, 6);
            this.lblTitleBook.Name = "lblTitleBook";
            this.lblTitleBook.Size = new System.Drawing.Size(127, 36);
            this.lblTitleBook.TabIndex = 18;
            this.lblTitleBook.Text = "Book ID";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Controls.Add(this.lblTitleBook);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1056, 54);
            this.panel4.TabIndex = 45;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AnimationHoverSpeed = 0.07F;
            this.btnClose.AnimationSpeed = 0.03F;
            this.btnClose.BaseColor1 = System.Drawing.Color.PaleTurquoise;
            this.btnClose.BaseColor2 = System.Drawing.Color.PaleTurquoise;
            this.btnClose.BorderColor = System.Drawing.Color.Black;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.FocusedColor = System.Drawing.Color.Empty;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Light", 15.75F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::Labrary_Managment.Properties.Resources.close;
            this.btnClose.ImageSize = new System.Drawing.Size(52, 52);
            this.btnClose.Location = new System.Drawing.Point(997, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.OnHoverBaseColor1 = System.Drawing.Color.Teal;
            this.btnClose.OnHoverBaseColor2 = System.Drawing.Color.Teal;
            this.btnClose.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnClose.OnHoverForeColor = System.Drawing.Color.Teal;
            this.btnClose.OnHoverImage = null;
            this.btnClose.OnPressedColor = System.Drawing.Color.Black;
            this.btnClose.Size = new System.Drawing.Size(56, 54);
            this.btnClose.TabIndex = 20;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveBookBorrow
            // 
            this.btnSaveBookBorrow.AnimationHoverSpeed = 0.07F;
            this.btnSaveBookBorrow.AnimationSpeed = 0.03F;
            this.btnSaveBookBorrow.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveBookBorrow.BaseColor = System.Drawing.Color.LightSkyBlue;
            this.btnSaveBookBorrow.BorderColor = System.Drawing.Color.Black;
            this.btnSaveBookBorrow.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveBookBorrow.FocusedColor = System.Drawing.Color.Empty;
            this.btnSaveBookBorrow.Font = new System.Drawing.Font("Segoe UI Light", 15.75F);
            this.btnSaveBookBorrow.ForeColor = System.Drawing.Color.Black;
            this.btnSaveBookBorrow.Image = null;
            this.btnSaveBookBorrow.ImageSize = new System.Drawing.Size(52, 52);
            this.btnSaveBookBorrow.Location = new System.Drawing.Point(821, 25);
            this.btnSaveBookBorrow.Name = "btnSaveBookBorrow";
            this.btnSaveBookBorrow.OnHoverBaseColor = System.Drawing.Color.Teal;
            this.btnSaveBookBorrow.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSaveBookBorrow.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSaveBookBorrow.OnHoverImage = null;
            this.btnSaveBookBorrow.OnPressedColor = System.Drawing.Color.Black;
            this.btnSaveBookBorrow.Radius = 20;
            this.btnSaveBookBorrow.Size = new System.Drawing.Size(169, 57);
            this.btnSaveBookBorrow.TabIndex = 1;
            this.btnSaveBookBorrow.Text = "Save";
            this.btnSaveBookBorrow.TextImageOffsetY = -5;
            this.btnSaveBookBorrow.Click += new System.EventHandler(this.btnSaveBookBorrow_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtPrice);
            this.panel3.Controls.Add(this.dTPLastDate);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnSaveBookBorrow);
            this.panel3.Controls.Add(this.dTPFirstDate);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 461);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1056, 135);
            this.panel3.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(457, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 25);
            this.label5.TabIndex = 35;
            this.label5.Text = "Price :";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(550, 37);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(239, 34);
            this.txtPrice.TabIndex = 36;
            // 
            // dTPLastDate
            // 
            this.dTPLastDate.Location = new System.Drawing.Point(119, 63);
            this.dTPLastDate.Name = "dTPLastDate";
            this.dTPLastDate.Size = new System.Drawing.Size(284, 34);
            this.dTPLastDate.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 33;
            this.label1.Text = "Last Date :";
            // 
            // dTPFirstDate
            // 
            this.dTPFirstDate.Location = new System.Drawing.Point(119, 10);
            this.dTPFirstDate.Name = "dTPFirstDate";
            this.dTPFirstDate.Size = new System.Drawing.Size(284, 34);
            this.dTPFirstDate.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-3, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 25);
            this.label8.TabIndex = 31;
            this.label8.Text = "First Date :";
            // 
            // lblBuyer
            // 
            this.lblBuyer.AutoSize = true;
            this.lblBuyer.Location = new System.Drawing.Point(732, 57);
            this.lblBuyer.Name = "lblBuyer";
            this.lblBuyer.Size = new System.Drawing.Size(198, 25);
            this.lblBuyer.TabIndex = 40;
            this.lblBuyer.Text = "Choose The Buyer";
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(179, 57);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(162, 25);
            this.lblBook.TabIndex = 41;
            this.lblBook.Text = "Choose a Book";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 15;
            this.gunaElipse1.TargetControl = this;
            // 
            // DGVBooks
            // 
            this.DGVBooks.AllowUserToAddRows = false;
            this.DGVBooks.AllowUserToDeleteRows = false;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            this.DGVBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.DGVBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVBooks.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.DGVBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVBooks.DefaultCellStyle = dataGridViewCellStyle23;
            this.DGVBooks.EnableHeadersVisualStyles = false;
            this.DGVBooks.GridColor = System.Drawing.Color.Teal;
            this.DGVBooks.Location = new System.Drawing.Point(12, 85);
            this.DGVBooks.Name = "DGVBooks";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVBooks.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.DGVBooks.RowHeadersWidth = 51;
            this.DGVBooks.RowTemplate.Height = 30;
            this.DGVBooks.Size = new System.Drawing.Size(506, 364);
            this.DGVBooks.TabIndex = 43;
            // 
            // DGVStudents
            // 
            this.DGVStudents.AllowUserToAddRows = false;
            this.DGVStudents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            this.DGVStudents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.DGVStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVStudents.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.DGVStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVStudents.DefaultCellStyle = dataGridViewCellStyle19;
            this.DGVStudents.EnableHeadersVisualStyles = false;
            this.DGVStudents.GridColor = System.Drawing.Color.Teal;
            this.DGVStudents.Location = new System.Drawing.Point(538, 85);
            this.DGVStudents.Name = "DGVStudents";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStudents.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.DGVStudents.RowHeadersWidth = 51;
            this.DGVStudents.RowTemplate.Height = 30;
            this.DGVStudents.Size = new System.Drawing.Size(506, 364);
            this.DGVStudents.TabIndex = 44;
            // 
            // BooksBorrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1056, 596);
            this.Controls.Add(this.DGVStudents);
            this.Controls.Add(this.DGVBooks);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.lblBuyer);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(500, 900);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "BooksBorrow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddBook";
            this.Load += new System.EventHandler(this.BooksBorrow_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleBook;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI.WinForms.GunaTileButton btnSaveBookBorrow;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dTPFirstDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBuyer;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaGradientTileButton btnClose;
        public System.Windows.Forms.DataGridView DGVStudents;
        public System.Windows.Forms.DataGridView DGVBooks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DateTimePicker dTPLastDate;
        private System.Windows.Forms.Label label1;
    }
}