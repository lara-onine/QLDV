namespace ADO.UC.DV
{
    partial class DoanVienUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoanVienUC));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNganh = new System.Windows.Forms.ComboBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoDaDong = new System.Windows.Forms.RadioButton();
            this.rdoChuaDong = new System.Windows.Forms.RadioButton();
            this.rdoTatCa = new System.Windows.Forms.RadioButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnDoanPhi = new Bunifu.Framework.UI.BunifuFlatButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(123, 225);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(795, 29);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaHoc.FormattingEnabled = true;
            this.cboKhoaHoc.Location = new System.Drawing.Point(123, 39);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(316, 32);
            this.cboKhoaHoc.TabIndex = 2;
            this.cboKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.cboKhoaHoc_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tìm kiếm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ngành học";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(505, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(505, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Khoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khóa học";
            // 
            // cboNganh
            // 
            this.cboNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNganh.FormattingEnabled = true;
            this.cboNganh.Location = new System.Drawing.Point(123, 89);
            this.cboNganh.Name = "cboNganh";
            this.cboNganh.Size = new System.Drawing.Size(316, 32);
            this.cboNganh.TabIndex = 0;
            this.cboNganh.SelectedIndexChanged += new System.EventHandler(this.cboNganh_SelectedIndexChanged);
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(602, 86);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(316, 32);
            this.cboLop.TabIndex = 0;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(602, 39);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(316, 32);
            this.cboKhoa.TabIndex = 0;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.cboKhoaHoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboNganh);
            this.groupBox1.Controls.Add(this.cboLop);
            this.groupBox1.Controls.Add(this.cboKhoa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(949, 264);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoDaDong);
            this.groupBox2.Controls.Add(this.rdoChuaDong);
            this.groupBox2.Controls.Add(this.rdoTatCa);
            this.groupBox2.Location = new System.Drawing.Point(17, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(901, 81);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tình trạng đoàn phí";
            // 
            // rdoDaDong
            // 
            this.rdoDaDong.AutoSize = true;
            this.rdoDaDong.Location = new System.Drawing.Point(720, 38);
            this.rdoDaDong.Name = "rdoDaDong";
            this.rdoDaDong.Size = new System.Drawing.Size(101, 28);
            this.rdoDaDong.TabIndex = 2;
            this.rdoDaDong.Text = "Đã đóng";
            this.rdoDaDong.UseVisualStyleBackColor = true;
            this.rdoDaDong.CheckedChanged += new System.EventHandler(this.rdoDaDong_CheckedChanged);
            // 
            // rdoChuaDong
            // 
            this.rdoChuaDong.AutoSize = true;
            this.rdoChuaDong.Location = new System.Drawing.Point(397, 38);
            this.rdoChuaDong.Name = "rdoChuaDong";
            this.rdoChuaDong.Size = new System.Drawing.Size(123, 28);
            this.rdoChuaDong.TabIndex = 1;
            this.rdoChuaDong.Text = "Chưa đóng";
            this.rdoChuaDong.UseVisualStyleBackColor = true;
            this.rdoChuaDong.CheckedChanged += new System.EventHandler(this.rdoChuaDong_CheckedChanged);
            // 
            // rdoTatCa
            // 
            this.rdoTatCa.AutoSize = true;
            this.rdoTatCa.Checked = true;
            this.rdoTatCa.Location = new System.Drawing.Point(66, 38);
            this.rdoTatCa.Name = "rdoTatCa";
            this.rdoTatCa.Size = new System.Drawing.Size(79, 28);
            this.rdoTatCa.TabIndex = 0;
            this.rdoTatCa.TabStop = true;
            this.rdoTatCa.Text = "Tất cả";
            this.rdoTatCa.UseVisualStyleBackColor = true;
            this.rdoTatCa.CheckedChanged += new System.EventHandler(this.rdoTatCa_CheckedChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.dataGridView1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 350);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(980, 620);
            this.mainPanel.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(980, 620);
            this.dataGridView1.TabIndex = 4;
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
            // Column9
            // 
            this.Column9.DataPropertyName = "da_dong_doan_phi";
            this.Column9.HeaderText = "Đã đóng đoàn phí";
            this.Column9.Name = "Column9";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.White;
            this.topPanel.Controls.Add(this.btnDoanPhi);
            this.topPanel.Controls.Add(this.groupBox1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(980, 350);
            this.topPanel.TabIndex = 2;
            // 
            // btnDoanPhi
            // 
            this.btnDoanPhi.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDoanPhi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDoanPhi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoanPhi.BorderRadius = 0;
            this.btnDoanPhi.ButtonText = "Xuất đơn";
            this.btnDoanPhi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoanPhi.DisabledColor = System.Drawing.Color.Gray;
            this.btnDoanPhi.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDoanPhi.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDoanPhi.Iconimage")));
            this.btnDoanPhi.Iconimage_right = null;
            this.btnDoanPhi.Iconimage_right_Selected = null;
            this.btnDoanPhi.Iconimage_Selected = null;
            this.btnDoanPhi.IconMarginLeft = 0;
            this.btnDoanPhi.IconMarginRight = 0;
            this.btnDoanPhi.IconRightVisible = true;
            this.btnDoanPhi.IconRightZoom = 0D;
            this.btnDoanPhi.IconVisible = true;
            this.btnDoanPhi.IconZoom = 90D;
            this.btnDoanPhi.IsTab = false;
            this.btnDoanPhi.Location = new System.Drawing.Point(722, 292);
            this.btnDoanPhi.Name = "btnDoanPhi";
            this.btnDoanPhi.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDoanPhi.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnDoanPhi.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDoanPhi.selected = false;
            this.btnDoanPhi.Size = new System.Drawing.Size(241, 48);
            this.btnDoanPhi.TabIndex = 1;
            this.btnDoanPhi.Text = "Xuất đơn";
            this.btnDoanPhi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoanPhi.Textcolor = System.Drawing.Color.White;
            this.btnDoanPhi.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanPhi.Click += new System.EventHandler(this.btnDoanPhi_Click);
            // 
            // DoanVienUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "DoanVienUC";
            this.Size = new System.Drawing.Size(980, 970);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNganh;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoDaDong;
        private System.Windows.Forms.RadioButton rdoChuaDong;
        private System.Windows.Forms.RadioButton rdoTatCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column9;
        private Bunifu.Framework.UI.BunifuFlatButton btnDoanPhi;
    }
}
