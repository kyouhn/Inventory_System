using System;

namespace stock_2
{
    partial class stock_2
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.pbtn_Minimize = new System.Windows.Forms.PictureBox();
            this.pbtn_Dispose = new System.Windows.Forms.PictureBox();
            this.lbl_Menu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Dispose)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(1194, 221);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.groupBox1.Location = new System.Drawing.Point(2, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1222, 288);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索結果";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.label12.Location = new System.Drawing.Point(917, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 24);
            this.label12.TabIndex = 59;
            this.label12.Text = "～";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.label11.Location = new System.Drawing.Point(917, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 24);
            this.label11.TabIndex = 58;
            this.label11.Text = "～";
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox11.Location = new System.Drawing.Point(796, 206);
            this.textBox11.MaxLength = 4;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(115, 31);
            this.textBox11.TabIndex = 57;
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox12.Location = new System.Drawing.Point(961, 207);
            this.textBox12.MaxLength = 4;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(115, 31);
            this.textBox12.TabIndex = 56;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.Location = new System.Drawing.Point(636, 207);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 26);
            this.label16.TabIndex = 55;
            this.label16.Text = "出版年";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(1059, 611);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 45);
            this.button2.TabIndex = 54;
            this.button2.Text = "閉じる";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(746, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 45);
            this.button1.TabIndex = 53;
            this.button1.Text = "検索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.label5.Location = new System.Drawing.Point(917, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 24);
            this.label5.TabIndex = 52;
            this.label5.Text = "～";
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox10.Location = new System.Drawing.Point(961, 163);
            this.textBox10.MaxLength = 5;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(115, 31);
            this.textBox10.TabIndex = 51;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox9.Location = new System.Drawing.Point(796, 161);
            this.textBox9.MaxLength = 6;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(115, 31);
            this.textBox9.TabIndex = 50;
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox8.Location = new System.Drawing.Point(961, 126);
            this.textBox8.MaxLength = 6;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(115, 31);
            this.textBox8.TabIndex = 49;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox7.Location = new System.Drawing.Point(796, 122);
            this.textBox7.MaxLength = 5;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(115, 31);
            this.textBox7.TabIndex = 48;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox5.Location = new System.Drawing.Point(403, 273);
            this.textBox5.MaxLength = 24;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(214, 31);
            this.textBox5.TabIndex = 47;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox4.Location = new System.Drawing.Point(403, 239);
            this.textBox4.MaxLength = 64;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(214, 31);
            this.textBox4.TabIndex = 46;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox3.Location = new System.Drawing.Point(403, 202);
            this.textBox3.MaxLength = 15;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(214, 31);
            this.textBox3.TabIndex = 45;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox2.Location = new System.Drawing.Point(403, 167);
            this.textBox2.MaxLength = 100;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(214, 31);
            this.textBox2.TabIndex = 44;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.textBox1.Location = new System.Drawing.Point(403, 126);
            this.textBox1.MaxLength = 26;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(214, 31);
            this.textBox1.TabIndex = 43;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(243, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 35);
            this.label10.TabIndex = 42;
            this.label10.Text = "出版社";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(243, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 34);
            this.label9.TabIndex = 41;
            this.label9.Text = "著者";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(243, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 28);
            this.label8.TabIndex = 40;
            this.label8.Text = "ジャンル";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(636, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 28);
            this.label7.TabIndex = 39;
            this.label7.Text = "販売価格";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(636, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 26);
            this.label6.TabIndex = 38;
            this.label6.Text = "入荷価格";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(243, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 31);
            this.label3.TabIndex = 37;
            this.label3.Text = "商品名";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(243, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 27);
            this.label2.TabIndex = 36;
            this.label2.Text = "商品番号";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("MS UI Gothic", 18F);
            this.button3.Location = new System.Drawing.Point(961, 257);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 45);
            this.button3.TabIndex = 61;
            this.button3.Text = "クリア";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.panel_Top.TabIndex = 62;
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
            this.lbl_Menu.Location = new System.Drawing.Point(489, 9);
            this.lbl_Menu.Name = "lbl_Menu";
            this.lbl_Menu.Size = new System.Drawing.Size(300, 85);
            this.lbl_Menu.TabIndex = 0;
            this.lbl_Menu.Text = "在庫管理";
            // 
            // stock_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel_Top);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "stock_2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.stock_2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Dispose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.PictureBox pbtn_Minimize;
        private System.Windows.Forms.PictureBox pbtn_Dispose;
        private System.Windows.Forms.Label lbl_Menu;

        public EventHandler Form1_Load { get; private set; }
    }
}

