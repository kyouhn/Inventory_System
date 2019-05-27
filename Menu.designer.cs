namespace menu
{
    partial class menu
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
            this.lbl_Menu = new System.Windows.Forms.Label();
            this.btn_Pos = new System.Windows.Forms.Button();
            this.btn_Ranking = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Esc = new System.Windows.Forms.Button();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.pbtn_Minimize = new System.Windows.Forms.PictureBox();
            this.pbtn_Dispose = new System.Windows.Forms.PictureBox();
            this.panel_Side_L = new System.Windows.Forms.Panel();
            this.panel_Side_R = new System.Windows.Forms.Panel();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Dispose)).BeginInit();
            this.panel_Side_L.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Menu
            // 
            this.lbl_Menu.Font = new System.Drawing.Font("MS UI Gothic", 48F);
            this.lbl_Menu.ForeColor = System.Drawing.Color.Black;
            this.lbl_Menu.Location = new System.Drawing.Point(542, 9);
            this.lbl_Menu.Name = "lbl_Menu";
            this.lbl_Menu.Size = new System.Drawing.Size(242, 85);
            this.lbl_Menu.TabIndex = 0;
            this.lbl_Menu.Text = "メニュー";
            // 
            // btn_Pos
            // 
            this.btn_Pos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Pos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pos.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.btn_Pos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Pos.Location = new System.Drawing.Point(0, 356);
            this.btn_Pos.Name = "btn_Pos";
            this.btn_Pos.Size = new System.Drawing.Size(240, 65);
            this.btn_Pos.TabIndex = 4;
            this.btn_Pos.Text = "POS";
            this.btn_Pos.UseVisualStyleBackColor = false;
            this.btn_Pos.Click += new System.EventHandler(this.btn_Pos_Click);
            this.btn_Pos.MouseEnter += new System.EventHandler(this.btn_Pos_MouseEnter);
            this.btn_Pos.MouseLeave += new System.EventHandler(this.btn_Pos_MouseLeave);
            // 
            // btn_Ranking
            // 
            this.btn_Ranking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Ranking.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Ranking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ranking.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.btn_Ranking.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Ranking.Location = new System.Drawing.Point(0, 263);
            this.btn_Ranking.Name = "btn_Ranking";
            this.btn_Ranking.Size = new System.Drawing.Size(240, 65);
            this.btn_Ranking.TabIndex = 3;
            this.btn_Ranking.Text = "ランキング";
            this.btn_Ranking.UseVisualStyleBackColor = false;
            this.btn_Ranking.Click += new System.EventHandler(this.btn_Ranking_Click);
            this.btn_Ranking.MouseEnter += new System.EventHandler(this.btn_Ranking_MouseEnter);
            this.btn_Ranking.MouseLeave += new System.EventHandler(this.btn_Ranking_MouseLeave);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Add.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Add.Location = new System.Drawing.Point(0, 157);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(240, 65);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "登録";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            this.btn_Add.MouseEnter += new System.EventHandler(this.btn_Add_MouseEnter);
            this.btn_Add.MouseLeave += new System.EventHandler(this.btn_Add_MouseLeave);
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Search.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.btn_Search.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Search.Location = new System.Drawing.Point(0, 56);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(240, 65);
            this.btn_Search.TabIndex = 1;
            this.btn_Search.Text = "検索";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            this.btn_Search.MouseEnter += new System.EventHandler(this.btn_Search_MouseEnter);
            this.btn_Search.MouseLeave += new System.EventHandler(this.btn_Search_MouseLeave);
            // 
            // btn_Esc
            // 
            this.btn_Esc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Esc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Esc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Esc.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.btn_Esc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Esc.Location = new System.Drawing.Point(0, 451);
            this.btn_Esc.Name = "btn_Esc";
            this.btn_Esc.Size = new System.Drawing.Size(240, 65);
            this.btn_Esc.TabIndex = 6;
            this.btn_Esc.Text = "その他";
            this.btn_Esc.UseVisualStyleBackColor = false;
            this.btn_Esc.Click += new System.EventHandler(this.btn_Esc_Click);
            this.btn_Esc.MouseEnter += new System.EventHandler(this.btn_Esc_MouseEnter);
            this.btn_Esc.MouseLeave += new System.EventHandler(this.btn_Esc_MouseLeave);
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
            this.panel_Top.TabIndex = 7;
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
            this.pbtn_Minimize.MouseEnter += new System.EventHandler(this.pbtn_Minimize_MouseEnter);
            this.pbtn_Minimize.MouseLeave += new System.EventHandler(this.pbtn_Minimize_MouseLeave);
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
            this.pbtn_Dispose.MouseEnter += new System.EventHandler(this.pbtn_Dispose_MouseEnter);
            this.pbtn_Dispose.MouseLeave += new System.EventHandler(this.pbtn_Dispose_MouseLeave);
            // 
            // panel_Side_L
            // 
            this.panel_Side_L.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_Side_L.Controls.Add(this.btn_Ranking);
            this.panel_Side_L.Controls.Add(this.btn_Search);
            this.panel_Side_L.Controls.Add(this.btn_Add);
            this.panel_Side_L.Controls.Add(this.btn_Esc);
            this.panel_Side_L.Controls.Add(this.btn_Pos);
            this.panel_Side_L.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Side_L.Location = new System.Drawing.Point(0, 97);
            this.panel_Side_L.Name = "panel_Side_L";
            this.panel_Side_L.Size = new System.Drawing.Size(240, 623);
            this.panel_Side_L.TabIndex = 8;
            // 
            // panel_Side_R
            // 
            this.panel_Side_R.BackgroundImage = global::Inventory_System.Properties.Resources.ppp005;
            this.panel_Side_R.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_Side_R.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Side_R.Location = new System.Drawing.Point(240, 97);
            this.panel_Side_R.Name = "panel_Side_R";
            this.panel_Side_R.Size = new System.Drawing.Size(1040, 623);
            this.panel_Side_R.TabIndex = 9;
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel_Side_R);
            this.Controls.Add(this.panel_Side_L);
            this.Controls.Add(this.panel_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.menu_Load);
            this.panel_Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbtn_Dispose)).EndInit();
            this.panel_Side_L.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Menu;
        private System.Windows.Forms.Button btn_Pos;
        private System.Windows.Forms.Button btn_Ranking;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Esc;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_Side_L;
        private System.Windows.Forms.PictureBox pbtn_Dispose;
        private System.Windows.Forms.PictureBox pbtn_Minimize;
        private System.Windows.Forms.Panel panel_Side_R;
    }
}

