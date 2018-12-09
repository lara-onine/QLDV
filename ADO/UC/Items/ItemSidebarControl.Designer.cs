namespace ADO.UC
{
    partial class ItemSidebarControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSidebarControl));
            this.btnItem = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // btnItem
            // 
            this.btnItem.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(117)))), ((int)(((byte)(239)))));
            this.btnItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnItem.BorderRadius = 0;
            this.btnItem.ButtonText = "bunifuFlatButton1";
            this.btnItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItem.DisabledColor = System.Drawing.Color.Gray;
            this.btnItem.Iconcolor = System.Drawing.Color.Transparent;
            this.btnItem.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnItem.Iconimage")));
            this.btnItem.Iconimage_right = null;
            this.btnItem.Iconimage_right_Selected = null;
            this.btnItem.Iconimage_Selected = null;
            this.btnItem.IconMarginLeft = 0;
            this.btnItem.IconMarginRight = 0;
            this.btnItem.IconRightVisible = true;
            this.btnItem.IconRightZoom = 0D;
            this.btnItem.IconVisible = true;
            this.btnItem.IconZoom = 90D;
            this.btnItem.IsTab = false;
            this.btnItem.Location = new System.Drawing.Point(0, 0);
            this.btnItem.Margin = new System.Windows.Forms.Padding(0);
            this.btnItem.Name = "btnItem";
            this.btnItem.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(117)))), ((int)(((byte)(239)))));
            this.btnItem.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(136)))), ((int)(((byte)(234)))));
            this.btnItem.OnHoverTextColor = System.Drawing.Color.White;
            this.btnItem.selected = false;
            this.btnItem.Size = new System.Drawing.Size(300, 60);
            this.btnItem.TabIndex = 0;
            this.btnItem.Text = "bunifuFlatButton1";
            this.btnItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItem.Textcolor = System.Drawing.Color.White;
            this.btnItem.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // ItemSidebarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnItem);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ItemSidebarControl";
            this.Size = new System.Drawing.Size(300, 60);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton btnItem;
    }
}
