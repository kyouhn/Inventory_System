namespace syohin
{
    partial class Add_publiser
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.pbtn_Minimize = new System.Windows.Forms.PictureBox();
            this.pbtn_Dispose = new System.Windows.Forms.PictureBox();
            this.lbl_Menu = new System.Windows.Forms.Label();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Dispose)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.label3.Location = new System.Drawing.Point(433, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "出版社";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.label4.Location = new System.Drawing.Point(433, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "フリガナ";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox2.Location = new System.Drawing.Point(570, 272);
            this.textBox2.MaxLength = 24;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(258, 32);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox3.Location = new System.Drawing.Point(570, 363);
            this.textBox3.MaxLength = 32;
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(258, 32);
            this.textBox3.TabIndex = 6;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.button1.Location = new System.Drawing.Point(698, 490);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "出版社追加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.button2.Location = new System.Drawing.Point(916, 490);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = "閉じる";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.Gainsboro;
            this.panel_Top.Controls.Add(this.pbtn_Minimize);
            this.panel_Top.Controls.Add(this.pbtn_Dispose);
            this.panel_Top.Controls.Add(this.lbl_Menu);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(1280, 97);
            this.panel_Top.TabIndex = 9;
            // 
            // pbtn_Minimize
            // 
            this.pbtn_Minimize.Image = global::Inventory_System.Properties.Resources.Syukusyo_v3_fix1;
            this.pbtn_Minimize.Location = new System.Drawing.Point(1046, 25);
            this.pbtn_Minimize.Name = "pbtn_Minimize";
            this.pbtn_Minimize.Size = new System.Drawing.Size(100, 50);
            this.pbtn_Minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbtn_Minimize.TabIndex = 10;
            this.pbtn_Minimize.TabStop = false;
            this.pbtn_Minimize.Click += new System.EventHandler(this.pbtn_Minimize_Click);
            // 
            // pbtn_Dispose
            // 
            this.pbtn_Dispose.Image = global::Inventory_System.Properties.Resources.batsu;
            this.pbtn_Dispose.Location = new System.Drawing.Point(1152, 25);
            this.pbtn_Dispose.Name = "pbtn_Dispose";
            this.pbtn_Dispose.Size = new System.Drawing.Size(100, 50);
            this.pbtn_Dispose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbtn_Dispose.TabIndex = 9;
            this.pbtn_Dispose.TabStop = false;
            this.pbtn_Dispose.Click += new System.EventHandler(this.pbtn_Dispose_Click);
            // 
            // lbl_Menu
            // 
            this.lbl_Menu.Font = new System.Drawing.Font("MS UI Gothic", 48F);
            this.lbl_Menu.ForeColor = System.Drawing.Color.Black;
            this.lbl_Menu.Location = new System.Drawing.Point(470, 9);
            this.lbl_Menu.Name = "lbl_Menu";
            this.lbl_Menu.Size = new System.Drawing.Size(376, 85);
            this.lbl_Menu.TabIndex = 0;
            this.lbl_Menu.Text = "出版社追加";
            // 
            // Add_publiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel_Top);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_publiser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.Load += new System.EventHandler(this.Publiser_Load);
            this.panel_Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Dispose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.PictureBox pbtn_Minimize;
        private System.Windows.Forms.PictureBox pbtn_Dispose;
        private System.Windows.Forms.Label lbl_Menu;
    }
}