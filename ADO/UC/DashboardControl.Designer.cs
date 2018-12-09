namespace ADO.UC
{
    partial class DashboardControl
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMore = new System.Windows.Forms.Button();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblNameEvent = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.EventPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.headerPanel.SuspendLayout();
            this.itemPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(117)))), ((int)(((byte)(239)))));
            this.headerPanel.Controls.Add(this.pictureBox2);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Controls.Add(this.label1);
            this.headerPanel.Controls.Add(this.pictureBox1);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1280, 220);
            this.headerPanel.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(233, 56);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(245, 39);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "DASHBOARD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(236, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hệ thống quản lý đoàn viên";
            // 
            // itemPanel
            // 
            this.itemPanel.Controls.Add(this.panel2);
            this.itemPanel.Controls.Add(this.panel1);
            this.itemPanel.Controls.Add(this.flowLayoutPanel1);
            this.itemPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.itemPanel.Location = new System.Drawing.Point(0, 220);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(1280, 750);
            this.itemPanel.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.EventPanel);
            this.panel2.Location = new System.Drawing.Point(762, 269);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 393);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMore);
            this.panel1.Controls.Add(this.lblContent);
            this.panel1.Controls.Add(this.lblNameEvent);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Controls.Add(this.lblSeconds);
            this.panel1.Controls.Add(this.lblMinutes);
            this.panel1.Controls.Add(this.lblHour);
            this.panel1.Controls.Add(this.lblDay);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(157, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 393);
            this.panel1.TabIndex = 1;
            // 
            // lblMore
            // 
            this.lblMore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(171)))), ((int)(((byte)(79)))));
            this.lblMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMore.ForeColor = System.Drawing.Color.White;
            this.lblMore.Location = new System.Drawing.Point(220, 346);
            this.lblMore.Name = "lblMore";
            this.lblMore.Size = new System.Drawing.Size(80, 32);
            this.lblMore.TabIndex = 3;
            this.lblMore.Text = "Xem thêm";
            this.lblMore.UseVisualStyleBackColor = false;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.Location = new System.Drawing.Point(0, 314);
            this.lblContent.MinimumSize = new System.Drawing.Size(526, 28);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(526, 28);
            this.lblContent.TabIndex = 2;
            this.lblContent.Text = "Nhà C19 - Cơ sở 3 Hà Nam";
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNameEvent
            // 
            this.lblNameEvent.AutoSize = true;
            this.lblNameEvent.BackColor = System.Drawing.Color.Transparent;
            this.lblNameEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameEvent.Location = new System.Drawing.Point(0, 276);
            this.lblNameEvent.MinimumSize = new System.Drawing.Size(526, 28);
            this.lblNameEvent.Name = "lblNameEvent";
            this.lblNameEvent.Size = new System.Drawing.Size(526, 28);
            this.lblNameEvent.TabIndex = 2;
            this.lblNameEvent.Text = "CHÀO TÂN ĐỘI NHÓM";
            this.lblNameEvent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(401, 215);
            this.label8.MinimumSize = new System.Drawing.Size(30, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 37);
            this.label8.TabIndex = 0;
            this.label8.Text = "Giây";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(279, 215);
            this.label7.MinimumSize = new System.Drawing.Size(30, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 37);
            this.label7.TabIndex = 0;
            this.label7.Text = "Phút";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(155, 215);
            this.label6.MinimumSize = new System.Drawing.Size(30, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 37);
            this.label6.TabIndex = 0;
            this.label6.Text = "Giờ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bunifuSeparator1.LineThickness = 3;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 0);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(526, 35);
            this.bunifuSeparator1.TabIndex = 1;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(117)))), ((int)(((byte)(239)))));
            this.lblSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.ForeColor = System.Drawing.Color.White;
            this.lblSeconds.Location = new System.Drawing.Point(394, 65);
            this.lblSeconds.MinimumSize = new System.Drawing.Size(30, 150);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(30, 150);
            this.lblSeconds.TabIndex = 0;
            this.lblSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(117)))), ((int)(((byte)(239)))));
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.ForeColor = System.Drawing.Color.White;
            this.lblMinutes.Location = new System.Drawing.Point(272, 65);
            this.lblMinutes.MinimumSize = new System.Drawing.Size(30, 150);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(30, 150);
            this.lblMinutes.TabIndex = 0;
            this.lblMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(117)))), ((int)(((byte)(239)))));
            this.lblHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHour.ForeColor = System.Drawing.Color.White;
            this.lblHour.Location = new System.Drawing.Point(148, 65);
            this.lblHour.MinimumSize = new System.Drawing.Size(30, 150);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(30, 150);
            this.lblHour.TabIndex = 0;
            this.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(117)))), ((int)(((byte)(239)))));
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.ForeColor = System.Drawing.Color.White;
            this.lblDay.Location = new System.Drawing.Point(23, 65);
            this.lblDay.MinimumSize = new System.Drawing.Size(30, 150);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(30, 150);
            this.lblDay.TabIndex = 0;
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(30, 215);
            this.label5.MinimumSize = new System.Drawing.Size(30, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 37);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ngày";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(157, 68);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1020, 150);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ADO.Properties.Resources.Huy_hieu_Doan;
            this.pictureBox2.Location = new System.Drawing.Point(1096, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(107, 118);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ADO.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(56, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // EventPanel
            // 
            this.EventPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EventPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventPanel.Location = new System.Drawing.Point(0, 0);
            this.EventPanel.Name = "EventPanel";
            this.EventPanel.Size = new System.Drawing.Size(366, 393);
            this.EventPanel.TabIndex = 0;
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.itemPanel);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(1280, 970);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.itemPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel itemPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblNameEvent;
        private System.Windows.Forms.Button lblMore;
        private System.Windows.Forms.FlowLayoutPanel EventPanel;
    }
}
