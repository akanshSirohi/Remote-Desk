namespace RemoteDesk
{
    partial class Form1
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
            this.NetworkWorker = new System.ComponentModel.BackgroundWorker();
            this.form = new CS_ClassLibraryTester.CarbonFiberTheme();
            this.carbonFiberLabel5 = new CS_ClassLibraryTester.CarbonFiberLabel();
            this.logBox = new System.Windows.Forms.TextBox();
            this.carbonFiberLabel4 = new CS_ClassLibraryTester.CarbonFiberLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.carbonFiberLabel3 = new CS_ClassLibraryTester.CarbonFiberLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.qrBox = new System.Windows.Forms.PictureBox();
            this.port_label = new CS_ClassLibraryTester.CarbonFiberLabel();
            this.ip_label = new CS_ClassLibraryTester.CarbonFiberLabel();
            this.carbonFiberLabel2 = new CS_ClassLibraryTester.CarbonFiberLabel();
            this.carbonFiberLabel1 = new CS_ClassLibraryTester.CarbonFiberLabel();
            this.pictureBtn = new System.Windows.Forms.PictureBox();
            this.close_btn = new CS_ClassLibraryTester.CarbonFiberButton();
            this.min_btn = new CS_ClassLibraryTester.CarbonFiberButton();
            this.form.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // NetworkWorker
            // 
            this.NetworkWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.NetworkWorker_DoWork);
            // 
            // form
            // 
            this.form.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.form.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.form.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.form.Controls.Add(this.carbonFiberLabel5);
            this.form.Controls.Add(this.logBox);
            this.form.Controls.Add(this.carbonFiberLabel4);
            this.form.Controls.Add(this.panel2);
            this.form.Controls.Add(this.carbonFiberLabel3);
            this.form.Controls.Add(this.panel1);
            this.form.Controls.Add(this.qrBox);
            this.form.Controls.Add(this.port_label);
            this.form.Controls.Add(this.ip_label);
            this.form.Controls.Add(this.carbonFiberLabel2);
            this.form.Controls.Add(this.carbonFiberLabel1);
            this.form.Controls.Add(this.pictureBtn);
            this.form.Controls.Add(this.close_btn);
            this.form.Controls.Add(this.min_btn);
            this.form.Customization = "";
            this.form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form.Font = new System.Drawing.Font("Virgo 01", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.form.Icon = null;
            this.form.Image = null;
            this.form.Location = new System.Drawing.Point(0, 0);
            this.form.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.form.Movable = true;
            this.form.Name = "form";
            this.form.NoRounding = false;
            this.form.ShowIcon = false;
            this.form.Sizable = false;
            this.form.Size = new System.Drawing.Size(1067, 554);
            this.form.SmartBounds = true;
            this.form.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.form.TabIndex = 0;
            this.form.Text = "Remote Desk";
            this.form.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.form.Transparent = false;
            // 
            // carbonFiberLabel5
            // 
            this.carbonFiberLabel5.BackColor = System.Drawing.Color.Transparent;
            this.carbonFiberLabel5.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.carbonFiberLabel5.Customization = "";
            this.carbonFiberLabel5.Font = new System.Drawing.Font("Virgo 01", 10F);
            this.carbonFiberLabel5.Image = null;
            this.carbonFiberLabel5.Location = new System.Drawing.Point(407, 512);
            this.carbonFiberLabel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.carbonFiberLabel5.Name = "carbonFiberLabel5";
            this.carbonFiberLabel5.NoRounding = false;
            this.carbonFiberLabel5.Size = new System.Drawing.Size(231, 20);
            this.carbonFiberLabel5.TabIndex = 16;
            this.carbonFiberLabel5.Text = "BY ANONIC TECHNOLOGIES";
            this.carbonFiberLabel5.Transparent = true;
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Font = new System.Drawing.Font("Ubuntu", 8.249999F);
            this.logBox.ForeColor = System.Drawing.Color.Lime;
            this.logBox.Location = new System.Drawing.Point(33, 340);
            this.logBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(997, 161);
            this.logBox.TabIndex = 15;
            // 
            // carbonFiberLabel4
            // 
            this.carbonFiberLabel4.BackColor = System.Drawing.Color.Transparent;
            this.carbonFiberLabel4.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.carbonFiberLabel4.Customization = "";
            this.carbonFiberLabel4.Font = new System.Drawing.Font("Ubuntu", 9F, System.Drawing.FontStyle.Bold);
            this.carbonFiberLabel4.Image = null;
            this.carbonFiberLabel4.Location = new System.Drawing.Point(33, 315);
            this.carbonFiberLabel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.carbonFiberLabel4.Name = "carbonFiberLabel4";
            this.carbonFiberLabel4.NoRounding = false;
            this.carbonFiberLabel4.Size = new System.Drawing.Size(67, 22);
            this.carbonFiberLabel4.TabIndex = 14;
            this.carbonFiberLabel4.Text = "LOG:-";
            this.carbonFiberLabel4.Transparent = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lime;
            this.panel2.Location = new System.Drawing.Point(16, 300);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1033, 2);
            this.panel2.TabIndex = 10;
            // 
            // carbonFiberLabel3
            // 
            this.carbonFiberLabel3.BackColor = System.Drawing.Color.Transparent;
            this.carbonFiberLabel3.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.carbonFiberLabel3.Customization = "";
            this.carbonFiberLabel3.Font = new System.Drawing.Font("Ubuntu", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carbonFiberLabel3.Image = null;
            this.carbonFiberLabel3.Location = new System.Drawing.Point(715, 50);
            this.carbonFiberLabel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.carbonFiberLabel3.Name = "carbonFiberLabel3";
            this.carbonFiberLabel3.NoRounding = false;
            this.carbonFiberLabel3.Size = new System.Drawing.Size(301, 28);
            this.carbonFiberLabel3.TabIndex = 9;
            this.carbonFiberLabel3.Text = "SCAN ME TO CONNECT";
            this.carbonFiberLabel3.Transparent = true;
            this.carbonFiberLabel3.Click += new System.EventHandler(this.carbonFiberLabel3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.Location = new System.Drawing.Point(539, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 240);
            this.panel1.TabIndex = 8;
            // 
            // qrBox
            // 
            this.qrBox.Location = new System.Drawing.Point(708, 63);
            this.qrBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.qrBox.Name = "qrBox";
            this.qrBox.Size = new System.Drawing.Size(248, 215);
            this.qrBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qrBox.TabIndex = 7;
            this.qrBox.TabStop = false;
            // 
            // port_label
            // 
            this.port_label.BackColor = System.Drawing.Color.Transparent;
            this.port_label.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.port_label.Customization = "";
            this.port_label.Font = new System.Drawing.Font("Ubuntu", 9.999999F, System.Drawing.FontStyle.Bold);
            this.port_label.Image = null;
            this.port_label.Location = new System.Drawing.Point(401, 169);
            this.port_label.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.port_label.Name = "port_label";
            this.port_label.NoRounding = false;
            this.port_label.Size = new System.Drawing.Size(65, 25);
            this.port_label.TabIndex = 6;
            this.port_label.Text = "1010";
            this.port_label.Transparent = true;
            // 
            // ip_label
            // 
            this.ip_label.BackColor = System.Drawing.Color.Transparent;
            this.ip_label.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.ip_label.Customization = "";
            this.ip_label.Font = new System.Drawing.Font("Ubuntu", 9.999999F, System.Drawing.FontStyle.Bold);
            this.ip_label.Image = null;
            this.ip_label.Location = new System.Drawing.Point(384, 145);
            this.ip_label.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ip_label.Name = "ip_label";
            this.ip_label.NoRounding = false;
            this.ip_label.Size = new System.Drawing.Size(83, 25);
            this.ip_label.TabIndex = 5;
            this.ip_label.Text = "0.0.0.0";
            this.ip_label.Transparent = true;
            // 
            // carbonFiberLabel2
            // 
            this.carbonFiberLabel2.BackColor = System.Drawing.Color.Transparent;
            this.carbonFiberLabel2.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.carbonFiberLabel2.Customization = "";
            this.carbonFiberLabel2.Font = new System.Drawing.Font("Ubuntu", 9.999999F, System.Drawing.FontStyle.Bold);
            this.carbonFiberLabel2.Image = null;
            this.carbonFiberLabel2.Location = new System.Drawing.Point(283, 169);
            this.carbonFiberLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.carbonFiberLabel2.Name = "carbonFiberLabel2";
            this.carbonFiberLabel2.NoRounding = false;
            this.carbonFiberLabel2.Size = new System.Drawing.Size(160, 25);
            this.carbonFiberLabel2.TabIndex = 4;
            this.carbonFiberLabel2.Text = "Port Number: ";
            this.carbonFiberLabel2.Transparent = true;
            // 
            // carbonFiberLabel1
            // 
            this.carbonFiberLabel1.BackColor = System.Drawing.Color.Transparent;
            this.carbonFiberLabel1.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.carbonFiberLabel1.Customization = "";
            this.carbonFiberLabel1.Font = new System.Drawing.Font("Ubuntu", 9.999999F, System.Drawing.FontStyle.Bold);
            this.carbonFiberLabel1.Image = null;
            this.carbonFiberLabel1.Location = new System.Drawing.Point(283, 145);
            this.carbonFiberLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.carbonFiberLabel1.Name = "carbonFiberLabel1";
            this.carbonFiberLabel1.NoRounding = false;
            this.carbonFiberLabel1.Size = new System.Drawing.Size(136, 25);
            this.carbonFiberLabel1.TabIndex = 3;
            this.carbonFiberLabel1.Text = "IP Address: ";
            this.carbonFiberLabel1.Transparent = true;
            // 
            // pictureBtn
            // 
            this.pictureBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBtn.Location = new System.Drawing.Point(16, 63);
            this.pictureBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBtn.Name = "pictureBtn";
            this.pictureBtn.Size = new System.Drawing.Size(281, 215);
            this.pictureBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBtn.TabIndex = 2;
            this.pictureBtn.TabStop = false;
            this.pictureBtn.Click += new System.EventHandler(this.pictureBtn_Click);
            // 
            // close_btn
            // 
            this.close_btn.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.close_btn.Customization = "";
            this.close_btn.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.close_btn.Image = null;
            this.close_btn.Location = new System.Drawing.Point(997, 0);
            this.close_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.close_btn.Name = "close_btn";
            this.close_btn.NoRounding = false;
            this.close_btn.Size = new System.Drawing.Size(53, 25);
            this.close_btn.TabIndex = 1;
            this.close_btn.Text = "X";
            this.close_btn.Transparent = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // min_btn
            // 
            this.min_btn.Colors = new CS_ClassLibraryTester.Bloom[0];
            this.min_btn.Customization = "";
            this.min_btn.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.min_btn.Image = null;
            this.min_btn.Location = new System.Drawing.Point(944, 0);
            this.min_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.min_btn.Name = "min_btn";
            this.min_btn.NoRounding = false;
            this.min_btn.Size = new System.Drawing.Size(53, 25);
            this.min_btn.TabIndex = 0;
            this.min_btn.Text = "_";
            this.min_btn.Transparent = false;
            this.min_btn.Click += new System.EventHandler(this.min_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.form);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.form.ResumeLayout(false);
            this.form.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qrBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CS_ClassLibraryTester.CarbonFiberTheme form;
        private CS_ClassLibraryTester.CarbonFiberButton min_btn;
        private CS_ClassLibraryTester.CarbonFiberButton close_btn;
        private System.Windows.Forms.PictureBox pictureBtn;
        private CS_ClassLibraryTester.CarbonFiberLabel carbonFiberLabel1;
        private CS_ClassLibraryTester.CarbonFiberLabel carbonFiberLabel2;
        private CS_ClassLibraryTester.CarbonFiberLabel port_label;
        private CS_ClassLibraryTester.CarbonFiberLabel ip_label;
        private System.Windows.Forms.PictureBox qrBox;
        private System.Windows.Forms.Panel panel1;
        private CS_ClassLibraryTester.CarbonFiberLabel carbonFiberLabel3;
        private System.Windows.Forms.Panel panel2;
        private CS_ClassLibraryTester.CarbonFiberLabel carbonFiberLabel4;
        private System.ComponentModel.BackgroundWorker NetworkWorker;
        private System.Windows.Forms.TextBox logBox;
        private CS_ClassLibraryTester.CarbonFiberLabel carbonFiberLabel5;
    }
}

