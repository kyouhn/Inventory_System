namespace Inventory_System
{
    partial class autoPurchase
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
            this.components = new System.ComponentModel.Container();
            this.pbar_Percent = new System.Windows.Forms.ProgressBar();
            this.pbar_Percent_Block = new System.Windows.Forms.ProgressBar();
            this.lbl_Progress_Info = new System.Windows.Forms.Label();
            this.lbl_Progress_Percent = new System.Windows.Forms.Label();
            this.lbl_Progress_Percent_Block = new System.Windows.Forms.Label();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.lbl_Progress_Percent_Info = new System.Windows.Forms.Label();
            this.lbl_Progress_Percent_Block_Info = new System.Windows.Forms.Label();
            this.lbl_Progress_Block_Info = new System.Windows.Forms.Label();
            this.panel_All = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_SysDate = new System.Windows.Forms.Label();
            this.panel_LogTable = new System.Windows.Forms.Panel();
            this.panel_LogTable_Log = new System.Windows.Forms.Panel();
            this.lbl_fake = new System.Windows.Forms.Label();
            this.panel_LogTable_Log_Info = new System.Windows.Forms.Panel();
            this.lbl_LogTable_Log_Info = new System.Windows.Forms.Label();
            this.panel_LogTable_SysDate_Info = new System.Windows.Forms.Panel();
            this.lbl_LogTable_SysDate_Info = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.closeTimer = new System.Windows.Forms.Timer(this.components);
            this.panel_All.SuspendLayout();
            this.panel_LogTable.SuspendLayout();
            this.panel_LogTable_Log.SuspendLayout();
            this.panel_LogTable_Log_Info.SuspendLayout();
            this.panel_LogTable_SysDate_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbar_Percent
            // 
            this.pbar_Percent.Location = new System.Drawing.Point(12, 571);
            this.pbar_Percent.Name = "pbar_Percent";
            this.pbar_Percent.Size = new System.Drawing.Size(1240, 35);
            this.pbar_Percent.TabIndex = 0;
            this.pbar_Percent.Value = 100;
            // 
            // pbar_Percent_Block
            // 
            this.pbar_Percent_Block.Location = new System.Drawing.Point(12, 501);
            this.pbar_Percent_Block.Name = "pbar_Percent_Block";
            this.pbar_Percent_Block.Size = new System.Drawing.Size(1240, 35);
            this.pbar_Percent_Block.TabIndex = 1;
            this.pbar_Percent_Block.Value = 100;
            // 
            // lbl_Progress_Info
            // 
            this.lbl_Progress_Info.AutoSize = true;
            this.lbl_Progress_Info.Location = new System.Drawing.Point(56, 447);
            this.lbl_Progress_Info.Name = "lbl_Progress_Info";
            this.lbl_Progress_Info.Size = new System.Drawing.Size(159, 16);
            this.lbl_Progress_Info.TabIndex = 2;
            this.lbl_Progress_Info.Text = "〇〇を実行しています。";
            // 
            // lbl_Progress_Percent
            // 
            this.lbl_Progress_Percent.AutoSize = true;
            this.lbl_Progress_Percent.Location = new System.Drawing.Point(1216, 552);
            this.lbl_Progress_Percent.Name = "lbl_Progress_Percent";
            this.lbl_Progress_Percent.Size = new System.Drawing.Size(36, 16);
            this.lbl_Progress_Percent.TabIndex = 3;
            this.lbl_Progress_Percent.Text = "NN%";
            this.lbl_Progress_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Progress_Percent_Block
            // 
            this.lbl_Progress_Percent_Block.AutoSize = true;
            this.lbl_Progress_Percent_Block.Location = new System.Drawing.Point(1216, 482);
            this.lbl_Progress_Percent_Block.Name = "lbl_Progress_Percent_Block";
            this.lbl_Progress_Percent_Block.Size = new System.Drawing.Size(36, 16);
            this.lbl_Progress_Percent_Block.TabIndex = 3;
            this.lbl_Progress_Percent_Block.Text = "NN%";
            this.lbl_Progress_Percent_Block.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Title.Location = new System.Drawing.Point(3, 9);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(273, 24);
            this.lbl_Title.TabIndex = 4;
            this.lbl_Title.Text = "自動発注リスト作成ツール";
            // 
            // lbl_Progress_Percent_Info
            // 
            this.lbl_Progress_Percent_Info.AutoSize = true;
            this.lbl_Progress_Percent_Info.Location = new System.Drawing.Point(12, 552);
            this.lbl_Progress_Percent_Info.Name = "lbl_Progress_Percent_Info";
            this.lbl_Progress_Percent_Info.Size = new System.Drawing.Size(107, 16);
            this.lbl_Progress_Percent_Info.TabIndex = 5;
            this.lbl_Progress_Percent_Info.Text = "全体進行状況:";
            // 
            // lbl_Progress_Percent_Block_Info
            // 
            this.lbl_Progress_Percent_Block_Info.AutoSize = true;
            this.lbl_Progress_Percent_Block_Info.Location = new System.Drawing.Point(12, 482);
            this.lbl_Progress_Percent_Block_Info.Name = "lbl_Progress_Percent_Block_Info";
            this.lbl_Progress_Percent_Block_Info.Size = new System.Drawing.Size(75, 16);
            this.lbl_Progress_Percent_Block_Info.TabIndex = 6;
            this.lbl_Progress_Percent_Block_Info.Text = "進行状況:";
            // 
            // lbl_Progress_Block_Info
            // 
            this.lbl_Progress_Block_Info.AutoSize = true;
            this.lbl_Progress_Block_Info.Location = new System.Drawing.Point(12, 447);
            this.lbl_Progress_Block_Info.Name = "lbl_Progress_Block_Info";
            this.lbl_Progress_Block_Info.Size = new System.Drawing.Size(35, 16);
            this.lbl_Progress_Block_Info.TabIndex = 7;
            this.lbl_Progress_Block_Info.Text = "0/0:";
            // 
            // panel_All
            // 
            this.panel_All.Controls.Add(this.button1);
            this.panel_All.Controls.Add(this.lbl_SysDate);
            this.panel_All.Controls.Add(this.panel_LogTable);
            this.panel_All.Controls.Add(this.btn_Close);
            this.panel_All.Controls.Add(this.lbl_Title);
            this.panel_All.Controls.Add(this.lbl_Progress_Percent_Block);
            this.panel_All.Controls.Add(this.lbl_Progress_Percent_Block_Info);
            this.panel_All.Controls.Add(this.lbl_Progress_Percent_Info);
            this.panel_All.Controls.Add(this.lbl_Progress_Block_Info);
            this.panel_All.Controls.Add(this.lbl_Progress_Info);
            this.panel_All.Controls.Add(this.lbl_Progress_Percent);
            this.panel_All.Controls.Add(this.pbar_Percent);
            this.panel_All.Controls.Add(this.pbar_Percent_Block);
            this.panel_All.Location = new System.Drawing.Point(0, 0);
            this.panel_All.Name = "panel_All";
            this.panel_All.Size = new System.Drawing.Size(1280, 720);
            this.panel_All.TabIndex = 8;
            this.panel_All.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_All_Paint);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(12, 663);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 45);
            this.button1.TabIndex = 9;
            this.button1.Text = "本日実行分削除(Demo)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_SysDate
            // 
            this.lbl_SysDate.AutoSize = true;
            this.lbl_SysDate.Location = new System.Drawing.Point(988, 413);
            this.lbl_SysDate.Name = "lbl_SysDate";
            this.lbl_SysDate.Size = new System.Drawing.Size(264, 16);
            this.lbl_SysDate.TabIndex = 0;
            this.lbl_SysDate.Text = "システム日時:YYYY/MM/DD HH:mm:SS";
            // 
            // panel_LogTable
            // 
            this.panel_LogTable.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel_LogTable.AutoScroll = true;
            this.panel_LogTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_LogTable.Controls.Add(this.panel_LogTable_Log);
            this.panel_LogTable.Controls.Add(this.panel_LogTable_Log_Info);
            this.panel_LogTable.Controls.Add(this.panel_LogTable_SysDate_Info);
            this.panel_LogTable.Location = new System.Drawing.Point(7, 47);
            this.panel_LogTable.Name = "panel_LogTable";
            this.panel_LogTable.Size = new System.Drawing.Size(975, 382);
            this.panel_LogTable.TabIndex = 11;
            // 
            // panel_LogTable_Log
            // 
            this.panel_LogTable_Log.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_LogTable_Log.Controls.Add(this.lbl_fake);
            this.panel_LogTable_Log.Location = new System.Drawing.Point(-1, 38);
            this.panel_LogTable_Log.Name = "panel_LogTable_Log";
            this.panel_LogTable_Log.Size = new System.Drawing.Size(972, 340);
            this.panel_LogTable_Log.TabIndex = 13;
            // 
            // lbl_fake
            // 
            this.lbl_fake.AutoSize = true;
            this.lbl_fake.Location = new System.Drawing.Point(0, 0);
            this.lbl_fake.Name = "lbl_fake";
            this.lbl_fake.Size = new System.Drawing.Size(0, 16);
            this.lbl_fake.TabIndex = 0;
            // 
            // panel_LogTable_Log_Info
            // 
            this.panel_LogTable_Log_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_LogTable_Log_Info.Controls.Add(this.lbl_LogTable_Log_Info);
            this.panel_LogTable_Log_Info.Location = new System.Drawing.Point(147, -1);
            this.panel_LogTable_Log_Info.Name = "panel_LogTable_Log_Info";
            this.panel_LogTable_Log_Info.Size = new System.Drawing.Size(824, 38);
            this.panel_LogTable_Log_Info.TabIndex = 12;
            // 
            // lbl_LogTable_Log_Info
            // 
            this.lbl_LogTable_Log_Info.AutoSize = true;
            this.lbl_LogTable_Log_Info.Location = new System.Drawing.Point(377, 9);
            this.lbl_LogTable_Log_Info.Name = "lbl_LogTable_Log_Info";
            this.lbl_LogTable_Log_Info.Size = new System.Drawing.Size(32, 16);
            this.lbl_LogTable_Log_Info.TabIndex = 13;
            this.lbl_LogTable_Log_Info.Text = "ログ";
            // 
            // panel_LogTable_SysDate_Info
            // 
            this.panel_LogTable_SysDate_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_LogTable_SysDate_Info.Controls.Add(this.lbl_LogTable_SysDate_Info);
            this.panel_LogTable_SysDate_Info.Location = new System.Drawing.Point(-1, -1);
            this.panel_LogTable_SysDate_Info.Name = "panel_LogTable_SysDate_Info";
            this.panel_LogTable_SysDate_Info.Size = new System.Drawing.Size(151, 38);
            this.panel_LogTable_SysDate_Info.TabIndex = 12;
            // 
            // lbl_LogTable_SysDate_Info
            // 
            this.lbl_LogTable_SysDate_Info.AutoSize = true;
            this.lbl_LogTable_SysDate_Info.Location = new System.Drawing.Point(21, 9);
            this.lbl_LogTable_SysDate_Info.Name = "lbl_LogTable_SysDate_Info";
            this.lbl_LogTable_SysDate_Info.Size = new System.Drawing.Size(106, 16);
            this.lbl_LogTable_SysDate_Info.TabIndex = 13;
            this.lbl_LogTable_SysDate_Info.Text = "-システム日時-";
            this.lbl_LogTable_SysDate_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Close
            // 
            this.btn_Close.Enabled = false;
            this.btn_Close.Location = new System.Drawing.Point(1079, 663);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(173, 45);
            this.btn_Close.TabIndex = 9;
            this.btn_Close.Text = "閉じる";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.button2_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // closeTimer
            // 
            this.closeTimer.Interval = 10000;
            this.closeTimer.Tick += new System.EventHandler(this.closeTimer_Tick);
            // 
            // autoPurchase
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel_All);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "autoPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "autoPurchase";
            this.Load += new System.EventHandler(this.autoPurchase_Load);
            this.panel_All.ResumeLayout(false);
            this.panel_All.PerformLayout();
            this.panel_LogTable.ResumeLayout(false);
            this.panel_LogTable_Log.ResumeLayout(false);
            this.panel_LogTable_Log.PerformLayout();
            this.panel_LogTable_Log_Info.ResumeLayout(false);
            this.panel_LogTable_Log_Info.PerformLayout();
            this.panel_LogTable_SysDate_Info.ResumeLayout(false);
            this.panel_LogTable_SysDate_Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbar_Percent;
        private System.Windows.Forms.ProgressBar pbar_Percent_Block;
        private System.Windows.Forms.Label lbl_Progress_Info;
        private System.Windows.Forms.Label lbl_Progress_Percent;
        private System.Windows.Forms.Label lbl_Progress_Percent_Block;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Label lbl_Progress_Percent_Info;
        private System.Windows.Forms.Label lbl_Progress_Percent_Block_Info;
        private System.Windows.Forms.Label lbl_Progress_Block_Info;
        private System.Windows.Forms.Panel panel_All;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label lbl_SysDate;
        private System.Windows.Forms.Panel panel_LogTable;
        private System.Windows.Forms.Panel panel_LogTable_Log;
        private System.Windows.Forms.Panel panel_LogTable_Log_Info;
        private System.Windows.Forms.Label lbl_LogTable_Log_Info;
        private System.Windows.Forms.Panel panel_LogTable_SysDate_Info;
        private System.Windows.Forms.Label lbl_LogTable_SysDate_Info;
        private System.Windows.Forms.Label lbl_fake;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Timer closeTimer;
        private System.Windows.Forms.Button button1;
    }
}