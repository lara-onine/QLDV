namespace ADO.UC.HV
{
    partial class DanhSachHoiVienUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DanhSachHoiVienUC));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXoaDV = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSuaDV = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnThemDV = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(980, 870);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ma_sv";
            this.Column1.HeaderText = "Mã Sinh Viên";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ho_ten";
            this.Column2.HeaderText = "Họ tên";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "dia_chi";
            this.Column3.HeaderText = "Địa chỉ";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "sdt";
            this.Column4.HeaderText = "Sdt";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "lop";
            this.Column5.HeaderText = "Lớp";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "nganh";
            this.Column6.HeaderText = "Ngành";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "khoa";
            this.Column7.HeaderText = "Khoa";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "khoa_hoc";
            this.Column8.HeaderText = "Khóa";
            this.Column8.Name = "Column8";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 870);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnXoaDV);
            this.panel1.Controls.Add(this.btnSuaDV);
            this.panel1.Controls.Add(this.btnThemDV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 100);
            this.panel1.TabIndex = 2;
            // 
            // btnXoaDV
            // 
            this.btnXoaDV.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnXoaDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaDV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXoaDV.BorderRadius = 0;
            this.btnXoaDV.ButtonText = "Xóa đoàn viên";
            this.btnXoaDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDV.DisabledColor = System.Drawing.Color.Gray;
            this.btnXoaDV.Iconcolor = System.Drawing.Color.Transparent;
            this.btnXoaDV.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnXoaDV.Iconimage")));
            this.btnXoaDV.Iconimage_right = null;
            this.btnXoaDV.Iconimage_right_Selected = null;
            this.btnXoaDV.Iconimage_Selected = null;
            this.btnXoaDV.IconMarginLeft = 0;
            this.btnXoaDV.IconMarginRight = 0;
            this.btnXoaDV.IconRightVisible = true;
            this.btnXoaDV.IconRightZoom = 0D;
            this.btnXoaDV.IconVisible = true;
            this.btnXoaDV.IconZoom = 90D;
            this.btnXoaDV.IsTab = false;
            this.btnXoaDV.Location = new System.Drawing.Point(809, 35);
            this.btnXoaDV.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoaDV.Name = "btnXoaDV";
            this.btnXoaDV.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaDV.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnXoaDV.OnHoverTextColor = System.Drawing.Color.White;
            this.btnXoaDV.selected = false;
            this.btnXoaDV.Size = new System.Drawing.Size(154, 48);
            this.btnXoaDV.TabIndex = 2;
            this.btnXoaDV.Text = "Xóa đoàn viên";
            this.btnXoaDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDV.Textcolor = System.Drawing.Color.White;
            this.btnXoaDV.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDV.Click += new System.EventHandler(this.btnXoaDV_Click);
            // 
            // btnSuaDV
            // 
            this.btnSuaDV.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSuaDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(125)))), ((int)(((byte)(252)))));
            this.btnSuaDV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSuaDV.BorderRadius = 0;
            this.btnSuaDV.ButtonText = "Sửa";
            this.btnSuaDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaDV.DisabledColor = System.Drawing.Color.Gray;
            this.btnSuaDV.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSuaDV.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSuaDV.Iconimage")));
            this.btnSuaDV.Iconimage_right = null;
            this.btnSuaDV.Iconimage_right_Selected = null;
            this.btnSuaDV.Iconimage_Selected = null;
            this.btnSuaDV.IconMarginLeft = 0;
            this.btnSuaDV.IconMarginRight = 0;
            this.btnSuaDV.IconRightVisible = true;
            this.btnSuaDV.IconRightZoom = 0D;
            this.btnSuaDV.IconVisible = true;
            this.btnSuaDV.IconZoom = 90D;
            this.btnSuaDV.IsTab = false;
            this.btnSuaDV.Location = new System.Drawing.Point(653, 35);
            this.btnSuaDV.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaDV.Name = "btnSuaDV";
            this.btnSuaDV.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(125)))), ((int)(((byte)(252)))));
            this.btnSuaDV.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(125)))), ((int)(((byte)(252)))));
            this.btnSuaDV.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSuaDV.selected = false;
            this.btnSuaDV.Size = new System.Drawing.Size(148, 48);
            this.btnSuaDV.TabIndex = 1;
            this.btnSuaDV.Text = "Sửa";
            this.btnSuaDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaDV.Textcolor = System.Drawing.Color.White;
            this.btnSuaDV.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaDV.Click += new System.EventHandler(this.btnSuaDV_Click);
            // 
            // btnThemDV
            // 
            this.btnThemDV.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnThemDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnThemDV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnThemDV.BorderRadius = 0;
            this.btnThemDV.ButtonText = "Thêm đoàn viên";
            this.btnThemDV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemDV.DisabledColor = System.Drawing.Color.Gray;
            this.btnThemDV.Iconcolor = System.Drawing.Color.Transparent;
            this.btnThemDV.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnThemDV.Iconimage")));
            this.btnThemDV.Iconimage_right = null;
            this.btnThemDV.Iconimage_right_Selected = null;
            this.btnThemDV.Iconimage_Selected = null;
            this.btnThemDV.IconMarginLeft = 0;
            this.btnThemDV.IconMarginRight = 0;
            this.btnThemDV.IconRightVisible = true;
            this.btnThemDV.IconRightZoom = 0D;
            this.btnThemDV.IconVisible = true;
            this.btnThemDV.IconZoom = 90D;
            this.btnThemDV.IsTab = false;
            this.btnThemDV.Location = new System.Drawing.Point(477, 35);
            this.btnThemDV.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnThemDV.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnThemDV.OnHoverTextColor = System.Drawing.Color.White;
            this.btnThemDV.selected = false;
            this.btnThemDV.Size = new System.Drawing.Size(168, 48);
            this.btnThemDV.TabIndex = 0;
            this.btnThemDV.Text = "Thêm đoàn viên";
            this.btnThemDV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemDV.Textcolor = System.Drawing.Color.White;
            this.btnThemDV.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // DanhSachHoiVienUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DanhSachHoiVienUC";
            this.Size = new System.Drawing.Size(980, 970);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnXoaDV;
        private Bunifu.Framework.UI.BunifuFlatButton btnSuaDV;
        private Bunifu.Framework.UI.BunifuFlatButton btnThemDV;
    }
}
