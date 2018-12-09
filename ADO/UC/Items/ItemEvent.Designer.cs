namespace ADO.UC.Items
{
    partial class ItemEvent
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNameEvent = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMonth);
            this.panel1.Controls.Add(this.lblDay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(77, 75);
            this.panel1.TabIndex = 0;
            // 
            // lblNameEvent
            // 
            this.lblNameEvent.AutoSize = true;
            this.lblNameEvent.BackColor = System.Drawing.Color.Transparent;
            this.lblNameEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameEvent.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNameEvent.Location = new System.Drawing.Point(83, 8);
            this.lblNameEvent.MinimumSize = new System.Drawing.Size(280, 0);
            this.lblNameEvent.Name = "lblNameEvent";
            this.lblNameEvent.Size = new System.Drawing.Size(280, 20);
            this.lblNameEvent.TabIndex = 1;
            this.lblNameEvent.Text = "label1";
            this.lblNameEvent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.ForeColor = System.Drawing.SystemColors.Control;
            this.lblContent.Location = new System.Drawing.Point(83, 41);
            this.lblContent.MinimumSize = new System.Drawing.Size(280, 30);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(280, 30);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "label1";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDay.Location = new System.Drawing.Point(8, 10);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(60, 24);
            this.lblDay.TabIndex = 0;
            this.lblDay.Text = "label3";
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMonth.Location = new System.Drawing.Point(15, 44);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(45, 16);
            this.lblMonth.TabIndex = 1;
            this.lblMonth.Text = "label4";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblNameEvent);
            this.Controls.Add(this.panel1);
            this.Name = "ItemEvent";
            this.Size = new System.Drawing.Size(366, 75);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNameEvent;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblContent;
    }
}
