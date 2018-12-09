namespace ADO.Dialog
{
    partial class ConfirmDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmDialog));
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnYes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNo = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.Control;
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(388, 30);
            this.topPanel.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(5, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(77, 20);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Xác nhận";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Image = global::ADO.Properties.Resources.Delete_96px;
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(343, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 30);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnYes
            // 
            this.btnYes.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYes.BorderRadius = 0;
            this.btnYes.ButtonText = "Có";
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.DisabledColor = System.Drawing.Color.Gray;
            this.btnYes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnYes.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnYes.Iconimage")));
            this.btnYes.Iconimage_right = null;
            this.btnYes.Iconimage_right_Selected = null;
            this.btnYes.Iconimage_Selected = null;
            this.btnYes.IconMarginLeft = 0;
            this.btnYes.IconMarginRight = 0;
            this.btnYes.IconRightVisible = true;
            this.btnYes.IconRightZoom = 0D;
            this.btnYes.IconVisible = true;
            this.btnYes.IconZoom = 90D;
            this.btnYes.IsTab = false;
            this.btnYes.Location = new System.Drawing.Point(38, 163);
            this.btnYes.Name = "btnYes";
            this.btnYes.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnYes.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnYes.OnHoverTextColor = System.Drawing.Color.White;
            this.btnYes.selected = false;
            this.btnYes.Size = new System.Drawing.Size(92, 48);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "Có";
            this.btnYes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYes.Textcolor = System.Drawing.Color.White;
            this.btnYes.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNo.BorderRadius = 0;
            this.btnNo.ButtonText = "Không";
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.DisabledColor = System.Drawing.Color.Gray;
            this.btnNo.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNo.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnNo.Iconimage")));
            this.btnNo.Iconimage_right = null;
            this.btnNo.Iconimage_right_Selected = null;
            this.btnNo.Iconimage_Selected = null;
            this.btnNo.IconMarginLeft = 0;
            this.btnNo.IconMarginRight = 0;
            this.btnNo.IconRightVisible = true;
            this.btnNo.IconRightZoom = 0D;
            this.btnNo.IconVisible = true;
            this.btnNo.IconZoom = 90D;
            this.btnNo.IsTab = false;
            this.btnNo.Location = new System.Drawing.Point(227, 163);
            this.btnNo.Name = "btnNo";
            this.btnNo.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnNo.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnNo.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNo.selected = false;
            this.btnNo.Size = new System.Drawing.Size(117, 48);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "Không";
            this.btnNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNo.Textcolor = System.Drawing.Color.White;
            this.btnNo.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bạn có chắc chắn muốn xóa?";
            // 
            // ConfirmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 223);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuFlatButton btnYes;
        private Bunifu.Framework.UI.BunifuFlatButton btnNo;
        private System.Windows.Forms.Label label1;
    }
}