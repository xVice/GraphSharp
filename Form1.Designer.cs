namespace GraphSharp
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.graphArea = new System.Windows.Forms.PictureBox();
            this.panel2 = new ReaLTaiizor.Controls.Panel();
            this.hopeRichTextBox1 = new ReaLTaiizor.Controls.HopeRichTextBox();
            this.hopeButton2 = new ReaLTaiizor.Controls.HopeButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.hopeButton1 = new ReaLTaiizor.Controls.HopeButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.hopeButton5 = new ReaLTaiizor.Controls.HopeButton();
            this.hopeButton4 = new ReaLTaiizor.Controls.HopeButton();
            this.hopeButton3 = new ReaLTaiizor.Controls.HopeButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphArea)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.graphArea);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1551, 833);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(362, 670);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // graphArea
            // 
            this.graphArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.graphArea.Location = new System.Drawing.Point(368, 0);
            this.graphArea.Name = "graphArea";
            this.graphArea.Size = new System.Drawing.Size(1183, 833);
            this.graphArea.TabIndex = 0;
            this.graphArea.TabStop = false;
            this.graphArea.Paint += new System.Windows.Forms.PaintEventHandler(this.graphArea_Paint);
            this.graphArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphArea_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel2.Controls.Add(this.hopeRichTextBox1);
            this.panel2.Controls.Add(this.hopeButton2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1551, 64);
            this.panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panel2.TabIndex = 4;
            this.panel2.Text = "panel2";
            // 
            // hopeRichTextBox1
            // 
            this.hopeRichTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeRichTextBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeRichTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.hopeRichTextBox1.Hint = "";
            this.hopeRichTextBox1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.hopeRichTextBox1.Location = new System.Drawing.Point(12, 12);
            this.hopeRichTextBox1.MaxLength = 32767;
            this.hopeRichTextBox1.Multiline = true;
            this.hopeRichTextBox1.Name = "hopeRichTextBox1";
            this.hopeRichTextBox1.PasswordChar = '\0';
            this.hopeRichTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.hopeRichTextBox1.SelectedText = "";
            this.hopeRichTextBox1.SelectionLength = 0;
            this.hopeRichTextBox1.SelectionStart = 0;
            this.hopeRichTextBox1.Size = new System.Drawing.Size(299, 40);
            this.hopeRichTextBox1.TabIndex = 2;
            this.hopeRichTextBox1.TabStop = false;
            this.hopeRichTextBox1.Text = "Math.Sin(input)";
            this.hopeRichTextBox1.UseSystemPasswordChar = false;
            // 
            // hopeButton2
            // 
            this.hopeButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeButton2.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeButton2.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeButton2.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeButton2.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.hopeButton2.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeButton2.Location = new System.Drawing.Point(317, 12);
            this.hopeButton2.Name = "hopeButton2";
            this.hopeButton2.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.hopeButton2.Size = new System.Drawing.Size(45, 40);
            this.hopeButton2.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeButton2.TabIndex = 1;
            this.hopeButton2.Text = "Add";
            this.hopeButton2.TextColor = System.Drawing.Color.White;
            this.hopeButton2.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton2.Click += new System.EventHandler(this.hopeButton2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel3.Controls.Add(this.hopeButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 770);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1551, 63);
            this.panel3.TabIndex = 2;
            // 
            // hopeButton1
            // 
            this.hopeButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeButton1.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeButton1.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeButton1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.hopeButton1.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeButton1.Location = new System.Drawing.Point(242, 11);
            this.hopeButton1.Name = "hopeButton1";
            this.hopeButton1.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.hopeButton1.Size = new System.Drawing.Size(120, 40);
            this.hopeButton1.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeButton1.TabIndex = 0;
            this.hopeButton1.Text = "Replot";
            this.hopeButton1.TextColor = System.Drawing.Color.White;
            this.hopeButton1.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton1.Click += new System.EventHandler(this.hopeButton1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panel4.Controls.Add(this.hopeButton5);
            this.panel4.Controls.Add(this.hopeButton4);
            this.panel4.Controls.Add(this.hopeButton3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1551, 36);
            this.panel4.TabIndex = 5;
            // 
            // hopeButton5
            // 
            this.hopeButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeButton5.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeButton5.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeButton5.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeButton5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeButton5.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.hopeButton5.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeButton5.Location = new System.Drawing.Point(197, 6);
            this.hopeButton5.Name = "hopeButton5";
            this.hopeButton5.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.hopeButton5.Size = new System.Drawing.Size(89, 24);
            this.hopeButton5.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeButton5.TabIndex = 3;
            this.hopeButton5.Text = "Load";
            this.hopeButton5.TextColor = System.Drawing.Color.White;
            this.hopeButton5.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton5.Click += new System.EventHandler(this.hopeButton5_Click);
            // 
            // hopeButton4
            // 
            this.hopeButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeButton4.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeButton4.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeButton4.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeButton4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeButton4.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.hopeButton4.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeButton4.Location = new System.Drawing.Point(102, 6);
            this.hopeButton4.Name = "hopeButton4";
            this.hopeButton4.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.hopeButton4.Size = new System.Drawing.Size(89, 24);
            this.hopeButton4.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeButton4.TabIndex = 2;
            this.hopeButton4.Text = "Save";
            this.hopeButton4.TextColor = System.Drawing.Color.White;
            this.hopeButton4.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton4.Click += new System.EventHandler(this.hopeButton4_Click);
            // 
            // hopeButton3
            // 
            this.hopeButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeButton3.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeButton3.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeButton3.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeButton3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeButton3.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.hopeButton3.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeButton3.Location = new System.Drawing.Point(7, 6);
            this.hopeButton3.Name = "hopeButton3";
            this.hopeButton3.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.hopeButton3.Size = new System.Drawing.Size(89, 24);
            this.hopeButton3.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeButton3.TabIndex = 1;
            this.hopeButton3.Text = "Save Image";
            this.hopeButton3.TextColor = System.Drawing.Color.White;
            this.hopeButton3.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton3.Click += new System.EventHandler(this.hopeButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1551, 833);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "GraphSharp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Form1_Scroll);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphArea)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox graphArea;
        private System.Windows.Forms.Panel panel3;
        private ReaLTaiizor.Controls.HopeButton hopeButton1;
        private ReaLTaiizor.Controls.Panel panel2;
        private ReaLTaiizor.Controls.HopeButton hopeButton2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ReaLTaiizor.Controls.HopeRichTextBox hopeRichTextBox1;
        private ReaLTaiizor.Controls.HopeButton hopeButton3;
        private System.Windows.Forms.Panel panel4;
        private ReaLTaiizor.Controls.HopeButton hopeButton4;
        private ReaLTaiizor.Controls.HopeButton hopeButton5;
    }
}

