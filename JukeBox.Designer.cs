namespace menu
{
    partial class JukeBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JukeBox));
            this.lblbtn_sys_BackPos = new System.Windows.Forms.Label();
            this.panel_MediaSelect_MediaInfo = new System.Windows.Forms.Panel();
            this.lblbtn_cnt_MediaSelect_Next = new System.Windows.Forms.Label();
            this.lblbtn_cnt_MediaSelect_Back = new System.Windows.Forms.Label();
            this.panel_SysControl = new System.Windows.Forms.Panel();
            this.lblbtn_sys_HeyBoss = new System.Windows.Forms.Label();
            this.lbl_TitleLogo = new System.Windows.Forms.Label();
            this.lbl_exc_I_am_seclet_application = new System.Windows.Forms.Label();
            this.panel_MediaPlay_TimeBar = new System.Windows.Forms.Panel();
            this.lbl_info_playtime = new System.Windows.Forms.Label();
            this.trackBar_MediaPlay_Time = new System.Windows.Forms.TrackBar();
            this.lbl_info_volume = new System.Windows.Forms.Label();
            this.trackBar_MediaPlay_Volume = new System.Windows.Forms.TrackBar();
            this.panel_ControlWindow = new System.Windows.Forms.Panel();
            this.lblbtn_ctl_Stop = new System.Windows.Forms.Label();
            this.lblbtn_ctl_FolderSelect = new System.Windows.Forms.Label();
            this.lblbtn_ctl_FileOpen = new System.Windows.Forms.Label();
            this.lblbtn_ctl_Reverse = new System.Windows.Forms.Label();
            this.lblbtn_ctl_Forward = new System.Windows.Forms.Label();
            this.lblbtn_cnt_PlayAndPause = new System.Windows.Forms.Label();
            this.panel_MediaPlay = new System.Windows.Forms.Panel();
            this.panel_MediaPlay_PlayWindow = new System.Windows.Forms.Panel();
            this.window_MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.timer_getMediaPlayTime_250 = new System.Windows.Forms.Timer(this.components);
            this.timer_changeMediaPlayTime_150 = new System.Windows.Forms.Timer(this.components);
            this.lblbtn_comeonbabyboss_fuckinfuckin = new System.Windows.Forms.Label();
            this.timer_statusGetMediaPlayTime_50 = new System.Windows.Forms.Timer(this.components);
            this.tbx_RecentMemoInput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_info_MemoSum = new System.Windows.Forms.Label();
            this.lbl_info_MemoSousu = new System.Windows.Forms.Label();
            this.lblbtn_ctl_MemoSave = new System.Windows.Forms.Label();
            this.lbl_info_RecentMemoTime = new System.Windows.Forms.Label();
            this.lbl_info_RecentMemo = new System.Windows.Forms.Label();
            this.lbl_info_MemoTime = new System.Windows.Forms.Label();
            this.lbl_info_Memo = new System.Windows.Forms.Label();
            this.lblbtn_ctl_RecentMemoRemove = new System.Windows.Forms.Label();
            this.lblbtn_ctl_MemoAdd = new System.Windows.Forms.Label();
            this.lblbtn_ctl_RecentMemoUpdate = new System.Windows.Forms.Label();
            this.lblbtn_ctl_GetMemoTime = new System.Windows.Forms.Label();
            this.lblbtn_ctl_MemoInputRemove = new System.Windows.Forms.Label();
            this.tbx_MemoInput = new System.Windows.Forms.TextBox();
            this.panel_MediaSelect = new System.Windows.Forms.Panel();
            this.panel_MemoList = new System.Windows.Forms.Panel();
            this.panel_MemoList_All = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblbtn_ctl_AllMemoRemove = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_MemoList_Title_Time = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_MemoList_info = new System.Windows.Forms.Panel();
            this.lbl_ctl_MemoList_FakeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_MediaSelect_MediaInfo.SuspendLayout();
            this.panel_SysControl.SuspendLayout();
            this.panel_MediaPlay_TimeBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MediaPlay_Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MediaPlay_Volume)).BeginInit();
            this.panel_ControlWindow.SuspendLayout();
            this.panel_MediaPlay.SuspendLayout();
            this.panel_MediaPlay_PlayWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.window_MediaPlayer)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_MediaSelect.SuspendLayout();
            this.panel_MemoList.SuspendLayout();
            this.panel_MemoList_All.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_MemoList_Title_Time.SuspendLayout();
            this.panel_MemoList_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblbtn_sys_BackPos
            // 
            this.lblbtn_sys_BackPos.BackColor = System.Drawing.Color.Transparent;
            this.lblbtn_sys_BackPos.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_sys_BackPos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblbtn_sys_BackPos.Image = global::Inventory_System.Properties.Resources.button_off_144_blue;
            this.lblbtn_sys_BackPos.Location = new System.Drawing.Point(175, 6);
            this.lblbtn_sys_BackPos.Name = "lblbtn_sys_BackPos";
            this.lblbtn_sys_BackPos.Size = new System.Drawing.Size(144, 74);
            this.lblbtn_sys_BackPos.TabIndex = 1;
            this.lblbtn_sys_BackPos.Text = "POSへ戻る";
            this.lblbtn_sys_BackPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_sys_BackPos.Click += new System.EventHandler(this.back_POS);
            this.lblbtn_sys_BackPos.MouseEnter += new System.EventHandler(this.lblbtn_sys_BackPos_MouseEnter);
            this.lblbtn_sys_BackPos.MouseLeave += new System.EventHandler(this.lblbtn_sys_BackPos_MouseLeave);
            // 
            // panel_MediaSelect_MediaInfo
            // 
            this.panel_MediaSelect_MediaInfo.BackColor = System.Drawing.Color.Transparent;
            this.panel_MediaSelect_MediaInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_MediaSelect_MediaInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_MediaSelect_MediaInfo.Controls.Add(this.lblbtn_cnt_MediaSelect_Next);
            this.panel_MediaSelect_MediaInfo.Controls.Add(this.lblbtn_cnt_MediaSelect_Back);
            this.panel_MediaSelect_MediaInfo.Location = new System.Drawing.Point(11, 95);
            this.panel_MediaSelect_MediaInfo.Name = "panel_MediaSelect_MediaInfo";
            this.panel_MediaSelect_MediaInfo.Size = new System.Drawing.Size(410, 217);
            this.panel_MediaSelect_MediaInfo.TabIndex = 2;
            // 
            // lblbtn_cnt_MediaSelect_Next
            // 
            this.lblbtn_cnt_MediaSelect_Next.AutoSize = true;
            this.lblbtn_cnt_MediaSelect_Next.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_cnt_MediaSelect_Next.ForeColor = System.Drawing.Color.White;
            this.lblbtn_cnt_MediaSelect_Next.Location = new System.Drawing.Point(334, 160);
            this.lblbtn_cnt_MediaSelect_Next.Name = "lblbtn_cnt_MediaSelect_Next";
            this.lblbtn_cnt_MediaSelect_Next.Size = new System.Drawing.Size(69, 48);
            this.lblbtn_cnt_MediaSelect_Next.TabIndex = 1;
            this.lblbtn_cnt_MediaSelect_Next.Text = "▼";
            // 
            // lblbtn_cnt_MediaSelect_Back
            // 
            this.lblbtn_cnt_MediaSelect_Back.AutoSize = true;
            this.lblbtn_cnt_MediaSelect_Back.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_cnt_MediaSelect_Back.ForeColor = System.Drawing.Color.White;
            this.lblbtn_cnt_MediaSelect_Back.Location = new System.Drawing.Point(334, 11);
            this.lblbtn_cnt_MediaSelect_Back.Name = "lblbtn_cnt_MediaSelect_Back";
            this.lblbtn_cnt_MediaSelect_Back.Size = new System.Drawing.Size(69, 48);
            this.lblbtn_cnt_MediaSelect_Back.TabIndex = 0;
            this.lblbtn_cnt_MediaSelect_Back.Text = "▲";
            // 
            // panel_SysControl
            // 
            this.panel_SysControl.BackColor = System.Drawing.Color.Transparent;
            this.panel_SysControl.Controls.Add(this.lblbtn_sys_HeyBoss);
            this.panel_SysControl.Controls.Add(this.lblbtn_sys_BackPos);
            this.panel_SysControl.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel_SysControl.Location = new System.Drawing.Point(914, 624);
            this.panel_SysControl.Name = "panel_SysControl";
            this.panel_SysControl.Size = new System.Drawing.Size(333, 84);
            this.panel_SysControl.TabIndex = 0;
            // 
            // lblbtn_sys_HeyBoss
            // 
            this.lblbtn_sys_HeyBoss.BackColor = System.Drawing.Color.Silver;
            this.lblbtn_sys_HeyBoss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblbtn_sys_HeyBoss.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_sys_HeyBoss.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblbtn_sys_HeyBoss.Location = new System.Drawing.Point(3, 11);
            this.lblbtn_sys_HeyBoss.Name = "lblbtn_sys_HeyBoss";
            this.lblbtn_sys_HeyBoss.Size = new System.Drawing.Size(134, 64);
            this.lblbtn_sys_HeyBoss.TabIndex = 2;
            this.lblbtn_sys_HeyBoss.Text = "Bossが来た";
            this.lblbtn_sys_HeyBoss.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_sys_HeyBoss.Click += new System.EventHandler(this.lblbtn_sys_HeyBoss_Click);
            this.lblbtn_sys_HeyBoss.MouseEnter += new System.EventHandler(this.lblbtn_sys_HeyBoss_MouseEnter);
            this.lblbtn_sys_HeyBoss.MouseLeave += new System.EventHandler(this.lblbtn_sys_HeyBoss_MouseLeave);
            // 
            // lbl_TitleLogo
            // 
            this.lbl_TitleLogo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TitleLogo.Image = global::Inventory_System.Properties.Resources.txtimage_tracklist_x_tracklist;
            this.lbl_TitleLogo.Location = new System.Drawing.Point(9, 11);
            this.lbl_TitleLogo.Name = "lbl_TitleLogo";
            this.lbl_TitleLogo.Size = new System.Drawing.Size(333, 81);
            this.lbl_TitleLogo.TabIndex = 0;
            // 
            // lbl_exc_I_am_seclet_application
            // 
            this.lbl_exc_I_am_seclet_application.BackColor = System.Drawing.Color.Transparent;
            this.lbl_exc_I_am_seclet_application.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_exc_I_am_seclet_application.Location = new System.Drawing.Point(400, 28);
            this.lbl_exc_I_am_seclet_application.Name = "lbl_exc_I_am_seclet_application";
            this.lbl_exc_I_am_seclet_application.Size = new System.Drawing.Size(269, 24);
            this.lbl_exc_I_am_seclet_application.TabIndex = 3;
            this.lbl_exc_I_am_seclet_application.Text = "I Am \"Secret Application\"";
            this.lbl_exc_I_am_seclet_application.DoubleClick += new System.EventHandler(this.lbl_exc_I_am_seclet_application_DoubleClick);
            // 
            // panel_MediaPlay_TimeBar
            // 
            this.panel_MediaPlay_TimeBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_MediaPlay_TimeBar.Controls.Add(this.lbl_info_playtime);
            this.panel_MediaPlay_TimeBar.Controls.Add(this.trackBar_MediaPlay_Time);
            this.panel_MediaPlay_TimeBar.Controls.Add(this.lbl_info_volume);
            this.panel_MediaPlay_TimeBar.Controls.Add(this.trackBar_MediaPlay_Volume);
            this.panel_MediaPlay_TimeBar.Location = new System.Drawing.Point(0, 380);
            this.panel_MediaPlay_TimeBar.Name = "panel_MediaPlay_TimeBar";
            this.panel_MediaPlay_TimeBar.Size = new System.Drawing.Size(810, 40);
            this.panel_MediaPlay_TimeBar.TabIndex = 4;
            // 
            // lbl_info_playtime
            // 
            this.lbl_info_playtime.AutoSize = true;
            this.lbl_info_playtime.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_info_playtime.Location = new System.Drawing.Point(556, 12);
            this.lbl_info_playtime.Name = "lbl_info_playtime";
            this.lbl_info_playtime.Size = new System.Drawing.Size(79, 12);
            this.lbl_info_playtime.TabIndex = 2;
            this.lbl_info_playtime.Text = "0:00:00/0:00:00";
            // 
            // trackBar_MediaPlay_Time
            // 
            this.trackBar_MediaPlay_Time.AutoSize = false;
            this.trackBar_MediaPlay_Time.LargeChange = 1;
            this.trackBar_MediaPlay_Time.Location = new System.Drawing.Point(0, 0);
            this.trackBar_MediaPlay_Time.Maximum = 36000;
            this.trackBar_MediaPlay_Time.Name = "trackBar_MediaPlay_Time";
            this.trackBar_MediaPlay_Time.Size = new System.Drawing.Size(550, 38);
            this.trackBar_MediaPlay_Time.TabIndex = 2;
            this.trackBar_MediaPlay_Time.TabStop = false;
            this.trackBar_MediaPlay_Time.TickFrequency = 36000;
            this.trackBar_MediaPlay_Time.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_MediaPlay_Time.Scroll += new System.EventHandler(this.trackBar_MediaPlay_Time_Scroll);
            // 
            // lbl_info_volume
            // 
            this.lbl_info_volume.AutoSize = true;
            this.lbl_info_volume.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_info_volume.Location = new System.Drawing.Point(652, 12);
            this.lbl_info_volume.Name = "lbl_info_volume";
            this.lbl_info_volume.Size = new System.Drawing.Size(52, 13);
            this.lbl_info_volume.TabIndex = 1;
            this.lbl_info_volume.Text = "Volume:";
            // 
            // trackBar_MediaPlay_Volume
            // 
            this.trackBar_MediaPlay_Volume.AutoSize = false;
            this.trackBar_MediaPlay_Volume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.trackBar_MediaPlay_Volume.Location = new System.Drawing.Point(700, 0);
            this.trackBar_MediaPlay_Volume.Maximum = 100;
            this.trackBar_MediaPlay_Volume.Name = "trackBar_MediaPlay_Volume";
            this.trackBar_MediaPlay_Volume.Size = new System.Drawing.Size(108, 38);
            this.trackBar_MediaPlay_Volume.TabIndex = 0;
            this.trackBar_MediaPlay_Volume.TabStop = false;
            this.trackBar_MediaPlay_Volume.TickFrequency = 10;
            this.trackBar_MediaPlay_Volume.Value = 50;
            this.trackBar_MediaPlay_Volume.Scroll += new System.EventHandler(this.trackBar_MediaPlay_Volume_Scroll);
            // 
            // panel_ControlWindow
            // 
            this.panel_ControlWindow.BackColor = System.Drawing.Color.Transparent;
            this.panel_ControlWindow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_ControlWindow.Controls.Add(this.lblbtn_ctl_Stop);
            this.panel_ControlWindow.Controls.Add(this.lblbtn_ctl_FolderSelect);
            this.panel_ControlWindow.Controls.Add(this.lblbtn_ctl_FileOpen);
            this.panel_ControlWindow.Controls.Add(this.lblbtn_ctl_Reverse);
            this.panel_ControlWindow.Controls.Add(this.lblbtn_ctl_Forward);
            this.panel_ControlWindow.Controls.Add(this.lblbtn_cnt_PlayAndPause);
            this.panel_ControlWindow.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel_ControlWindow.Location = new System.Drawing.Point(14, 532);
            this.panel_ControlWindow.Name = "panel_ControlWindow";
            this.panel_ControlWindow.Size = new System.Drawing.Size(1233, 84);
            this.panel_ControlWindow.TabIndex = 5;
            // 
            // lblbtn_ctl_Stop
            // 
            this.lblbtn_ctl_Stop.Enabled = false;
            this.lblbtn_ctl_Stop.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_ctl_Stop.Image = global::Inventory_System.Properties.Resources.button_off_144_red;
            this.lblbtn_ctl_Stop.Location = new System.Drawing.Point(662, 4);
            this.lblbtn_ctl_Stop.Name = "lblbtn_ctl_Stop";
            this.lblbtn_ctl_Stop.Size = new System.Drawing.Size(144, 74);
            this.lblbtn_ctl_Stop.TabIndex = 1;
            this.lblbtn_ctl_Stop.Text = "■ 停止\r\n(ダブルクリック)";
            this.lblbtn_ctl_Stop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_Stop.DoubleClick += new System.EventHandler(this.lblbtn_ctl_Stop_DoubleClick);
            this.lblbtn_ctl_Stop.MouseEnter += new System.EventHandler(this.lblbtn_ctl_Stop_MouseEnter);
            this.lblbtn_ctl_Stop.MouseLeave += new System.EventHandler(this.lblbtn_ctl_Stop_MouseLeave);
            // 
            // lblbtn_ctl_FolderSelect
            // 
            this.lblbtn_ctl_FolderSelect.Enabled = false;
            this.lblbtn_ctl_FolderSelect.Image = global::Inventory_System.Properties.Resources.button_off_144_red;
            this.lblbtn_ctl_FolderSelect.Location = new System.Drawing.Point(897, 4);
            this.lblbtn_ctl_FolderSelect.Name = "lblbtn_ctl_FolderSelect";
            this.lblbtn_ctl_FolderSelect.Size = new System.Drawing.Size(144, 74);
            this.lblbtn_ctl_FolderSelect.TabIndex = 1;
            this.lblbtn_ctl_FolderSelect.Text = "CSV選択...";
            this.lblbtn_ctl_FolderSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_FolderSelect.Click += new System.EventHandler(this.lblbtn_ctl_FolderSelect_Click);
            this.lblbtn_ctl_FolderSelect.MouseEnter += new System.EventHandler(this.lblbtn_ctl_FolderSelect_MouseEnter);
            this.lblbtn_ctl_FolderSelect.MouseLeave += new System.EventHandler(this.lblbtn_ctl_FolderSelect_MouseLeave);
            // 
            // lblbtn_ctl_FileOpen
            // 
            this.lblbtn_ctl_FileOpen.Image = global::Inventory_System.Properties.Resources.button_off_144_red;
            this.lblbtn_ctl_FileOpen.Location = new System.Drawing.Point(1057, 4);
            this.lblbtn_ctl_FileOpen.Name = "lblbtn_ctl_FileOpen";
            this.lblbtn_ctl_FileOpen.Size = new System.Drawing.Size(144, 74);
            this.lblbtn_ctl_FileOpen.TabIndex = 1;
            this.lblbtn_ctl_FileOpen.Text = "メディア選択...";
            this.lblbtn_ctl_FileOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_FileOpen.Click += new System.EventHandler(this.lblbtn_cnt_FileOpen_Click);
            this.lblbtn_ctl_FileOpen.MouseEnter += new System.EventHandler(this.lblbtn_cnt_FileOpen_MouseEnter);
            this.lblbtn_ctl_FileOpen.MouseLeave += new System.EventHandler(this.lblbtn_cnt_FileOpen_MouseLeave);
            // 
            // lblbtn_ctl_Reverse
            // 
            this.lblbtn_ctl_Reverse.Image = global::Inventory_System.Properties.Resources.button_off_144_lgreen;
            this.lblbtn_ctl_Reverse.Location = new System.Drawing.Point(114, 4);
            this.lblbtn_ctl_Reverse.Name = "lblbtn_ctl_Reverse";
            this.lblbtn_ctl_Reverse.Size = new System.Drawing.Size(144, 74);
            this.lblbtn_ctl_Reverse.TabIndex = 0;
            this.lblbtn_ctl_Reverse.Text = "◀◀ 巻戻";
            this.lblbtn_ctl_Reverse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_Reverse.Click += new System.EventHandler(this.lblbtn_ctl_Reverse_Click);
            this.lblbtn_ctl_Reverse.MouseEnter += new System.EventHandler(this.lblbtn_ctl_Reverse_MouseEnter);
            this.lblbtn_ctl_Reverse.MouseLeave += new System.EventHandler(this.lblbtn_ctl_Reverse_MouseLeave);
            // 
            // lblbtn_ctl_Forward
            // 
            this.lblbtn_ctl_Forward.Image = global::Inventory_System.Properties.Resources.button_off_144_lgreen;
            this.lblbtn_ctl_Forward.Location = new System.Drawing.Point(434, 4);
            this.lblbtn_ctl_Forward.Name = "lblbtn_ctl_Forward";
            this.lblbtn_ctl_Forward.Size = new System.Drawing.Size(144, 74);
            this.lblbtn_ctl_Forward.TabIndex = 0;
            this.lblbtn_ctl_Forward.Text = "▶▶ 早送";
            this.lblbtn_ctl_Forward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_Forward.Click += new System.EventHandler(this.lblbtn_ctl_Forward_Click);
            this.lblbtn_ctl_Forward.MouseEnter += new System.EventHandler(this.lblbtn_ctl_Forward_MouseEnter);
            this.lblbtn_ctl_Forward.MouseLeave += new System.EventHandler(this.lblbtn_ctl_Forward_MouseLeave);
            // 
            // lblbtn_cnt_PlayAndPause
            // 
            this.lblbtn_cnt_PlayAndPause.Image = global::Inventory_System.Properties.Resources.button_off_144_blue;
            this.lblbtn_cnt_PlayAndPause.Location = new System.Drawing.Point(274, 4);
            this.lblbtn_cnt_PlayAndPause.Name = "lblbtn_cnt_PlayAndPause";
            this.lblbtn_cnt_PlayAndPause.Size = new System.Drawing.Size(144, 74);
            this.lblbtn_cnt_PlayAndPause.TabIndex = 0;
            this.lblbtn_cnt_PlayAndPause.Text = "▶ 再生";
            this.lblbtn_cnt_PlayAndPause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_cnt_PlayAndPause.Click += new System.EventHandler(this.lblbtn_cnt_PlayAndPause_Click);
            this.lblbtn_cnt_PlayAndPause.MouseEnter += new System.EventHandler(this.lblbtn_cnt_PlayAndPause_MouseEnter);
            this.lblbtn_cnt_PlayAndPause.MouseLeave += new System.EventHandler(this.lblbtn_cnt_PlayAndPause_MouseLeave);
            // 
            // panel_MediaPlay
            // 
            this.panel_MediaPlay.BackColor = System.Drawing.Color.Transparent;
            this.panel_MediaPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_MediaPlay.Controls.Add(this.panel_MediaPlay_PlayWindow);
            this.panel_MediaPlay.Controls.Add(this.panel_MediaPlay_TimeBar);
            this.panel_MediaPlay.Location = new System.Drawing.Point(12, 93);
            this.panel_MediaPlay.Name = "panel_MediaPlay";
            this.panel_MediaPlay.Size = new System.Drawing.Size(810, 420);
            this.panel_MediaPlay.TabIndex = 6;
            // 
            // panel_MediaPlay_PlayWindow
            // 
            this.panel_MediaPlay_PlayWindow.Controls.Add(this.window_MediaPlayer);
            this.panel_MediaPlay_PlayWindow.Location = new System.Drawing.Point(0, 0);
            this.panel_MediaPlay_PlayWindow.Name = "panel_MediaPlay_PlayWindow";
            this.panel_MediaPlay_PlayWindow.Size = new System.Drawing.Size(810, 380);
            this.panel_MediaPlay_PlayWindow.TabIndex = 5;
            // 
            // window_MediaPlayer
            // 
            this.window_MediaPlayer.AllowDrop = true;
            this.window_MediaPlayer.Enabled = true;
            this.window_MediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.window_MediaPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.window_MediaPlayer.Name = "window_MediaPlayer";
            this.window_MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("window_MediaPlayer.OcxState")));
            this.window_MediaPlayer.Size = new System.Drawing.Size(810, 380);
            this.window_MediaPlayer.TabIndex = 0;
            this.window_MediaPlayer.TabStop = false;
            // 
            // timer_getMediaPlayTime_250
            // 
            this.timer_getMediaPlayTime_250.Interval = 250;
            this.timer_getMediaPlayTime_250.Tick += new System.EventHandler(this.timer_getMediaPlayTime_250_Tick);
            // 
            // timer_changeMediaPlayTime_150
            // 
            this.timer_changeMediaPlayTime_150.Interval = 150;
            this.timer_changeMediaPlayTime_150.Tick += new System.EventHandler(this.timer_changeMediaPlayTime_150_Tick);
            // 
            // lblbtn_comeonbabyboss_fuckinfuckin
            // 
            this.lblbtn_comeonbabyboss_fuckinfuckin.Image = global::Inventory_System.Properties.Resources.background_jukebox_x_5000;
            this.lblbtn_comeonbabyboss_fuckinfuckin.Location = new System.Drawing.Point(0, 0);
            this.lblbtn_comeonbabyboss_fuckinfuckin.Name = "lblbtn_comeonbabyboss_fuckinfuckin";
            this.lblbtn_comeonbabyboss_fuckinfuckin.Size = new System.Drawing.Size(0, 0);
            this.lblbtn_comeonbabyboss_fuckinfuckin.TabIndex = 7;
            this.lblbtn_comeonbabyboss_fuckinfuckin.Click += new System.EventHandler(this.lblbtn_comeonbabyboss_fuckinfuckin_Click);
            // 
            // timer_statusGetMediaPlayTime_50
            // 
            this.timer_statusGetMediaPlayTime_50.Interval = 50;
            this.timer_statusGetMediaPlayTime_50.Tick += new System.EventHandler(this.timer_statusGetMediaPlayTime_50_Tick);
            // 
            // tbx_RecentMemoInput
            // 
            this.tbx_RecentMemoInput.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbx_RecentMemoInput.Location = new System.Drawing.Point(322, 30);
            this.tbx_RecentMemoInput.MaxLength = 255;
            this.tbx_RecentMemoInput.Name = "tbx_RecentMemoInput";
            this.tbx_RecentMemoInput.Size = new System.Drawing.Size(368, 20);
            this.tbx_RecentMemoInput.TabIndex = 8;
            this.tbx_RecentMemoInput.TabStop = false;
            this.tbx_RecentMemoInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_RecentMemoInput_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_info_MemoSum);
            this.panel1.Controls.Add(this.lbl_info_MemoSousu);
            this.panel1.Controls.Add(this.lblbtn_ctl_MemoSave);
            this.panel1.Controls.Add(this.lbl_info_RecentMemoTime);
            this.panel1.Controls.Add(this.lbl_info_RecentMemo);
            this.panel1.Controls.Add(this.lbl_info_MemoTime);
            this.panel1.Controls.Add(this.lbl_info_Memo);
            this.panel1.Controls.Add(this.lblbtn_ctl_RecentMemoRemove);
            this.panel1.Controls.Add(this.lblbtn_ctl_MemoAdd);
            this.panel1.Controls.Add(this.lblbtn_ctl_RecentMemoUpdate);
            this.panel1.Controls.Add(this.lblbtn_ctl_GetMemoTime);
            this.panel1.Controls.Add(this.lblbtn_ctl_MemoInputRemove);
            this.panel1.Controls.Add(this.tbx_MemoInput);
            this.panel1.Controls.Add(this.tbx_RecentMemoInput);
            this.panel1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel1.Location = new System.Drawing.Point(13, 624);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 84);
            this.panel1.TabIndex = 9;
            // 
            // lbl_info_MemoSum
            // 
            this.lbl_info_MemoSum.AutoSize = true;
            this.lbl_info_MemoSum.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_info_MemoSum.Location = new System.Drawing.Point(821, 6);
            this.lbl_info_MemoSum.Name = "lbl_info_MemoSum";
            this.lbl_info_MemoSum.Size = new System.Drawing.Size(35, 15);
            this.lbl_info_MemoSum.TabIndex = 17;
            this.lbl_info_MemoSum.Text = "0 件";
            this.lbl_info_MemoSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_info_MemoSousu
            // 
            this.lbl_info_MemoSousu.AutoSize = true;
            this.lbl_info_MemoSousu.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_info_MemoSousu.Location = new System.Drawing.Point(754, 6);
            this.lbl_info_MemoSousu.Name = "lbl_info_MemoSousu";
            this.lbl_info_MemoSousu.Size = new System.Drawing.Size(61, 15);
            this.lbl_info_MemoSousu.TabIndex = 16;
            this.lbl_info_MemoSousu.Text = "メモ総数:";
            // 
            // lblbtn_ctl_MemoSave
            // 
            this.lblbtn_ctl_MemoSave.BackColor = System.Drawing.Color.Silver;
            this.lblbtn_ctl_MemoSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblbtn_ctl_MemoSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblbtn_ctl_MemoSave.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_ctl_MemoSave.Location = new System.Drawing.Point(824, 32);
            this.lblbtn_ctl_MemoSave.Name = "lblbtn_ctl_MemoSave";
            this.lblbtn_ctl_MemoSave.Size = new System.Drawing.Size(68, 43);
            this.lblbtn_ctl_MemoSave.TabIndex = 15;
            this.lblbtn_ctl_MemoSave.Text = "メモ保存";
            this.lblbtn_ctl_MemoSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_MemoSave.Click += new System.EventHandler(this.lblbtn_ctl_MemoSave_Click);
            this.lblbtn_ctl_MemoSave.MouseEnter += new System.EventHandler(this.lblbtn_ctl_MemoSave_MouseEnter);
            this.lblbtn_ctl_MemoSave.MouseLeave += new System.EventHandler(this.lblbtn_ctl_MemoSave_MouseLeave);
            // 
            // lbl_info_RecentMemoTime
            // 
            this.lbl_info_RecentMemoTime.AutoSize = true;
            this.lbl_info_RecentMemoTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_info_RecentMemoTime.Location = new System.Drawing.Point(246, 32);
            this.lbl_info_RecentMemoTime.Name = "lbl_info_RecentMemoTime";
            this.lbl_info_RecentMemoTime.Size = new System.Drawing.Size(70, 16);
            this.lbl_info_RecentMemoTime.TabIndex = 14;
            this.lbl_info_RecentMemoTime.Text = "00:00:00";
            // 
            // lbl_info_RecentMemo
            // 
            this.lbl_info_RecentMemo.AutoSize = true;
            this.lbl_info_RecentMemo.Location = new System.Drawing.Point(227, 16);
            this.lbl_info_RecentMemo.Name = "lbl_info_RecentMemo";
            this.lbl_info_RecentMemo.Size = new System.Drawing.Size(85, 16);
            this.lbl_info_RecentMemo.TabIndex = 13;
            this.lbl_info_RecentMemo.Text = "直前のメモ:";
            // 
            // lbl_info_MemoTime
            // 
            this.lbl_info_MemoTime.AutoSize = true;
            this.lbl_info_MemoTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_info_MemoTime.Location = new System.Drawing.Point(154, 59);
            this.lbl_info_MemoTime.Name = "lbl_info_MemoTime";
            this.lbl_info_MemoTime.Size = new System.Drawing.Size(70, 16);
            this.lbl_info_MemoTime.TabIndex = 12;
            this.lbl_info_MemoTime.Text = "00:00:00";
            // 
            // lbl_info_Memo
            // 
            this.lbl_info_Memo.AutoSize = true;
            this.lbl_info_Memo.Location = new System.Drawing.Point(154, 43);
            this.lbl_info_Memo.Name = "lbl_info_Memo";
            this.lbl_info_Memo.Size = new System.Drawing.Size(37, 16);
            this.lbl_info_Memo.TabIndex = 11;
            this.lbl_info_Memo.Text = "メモ:";
            // 
            // lblbtn_ctl_RecentMemoRemove
            // 
            this.lblbtn_ctl_RecentMemoRemove.BackColor = System.Drawing.Color.Transparent;
            this.lblbtn_ctl_RecentMemoRemove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblbtn_ctl_RecentMemoRemove.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_ctl_RecentMemoRemove.Image = global::Inventory_System.Properties.Resources.button_off_144_red;
            this.lblbtn_ctl_RecentMemoRemove.Location = new System.Drawing.Point(774, 27);
            this.lblbtn_ctl_RecentMemoRemove.Name = "lblbtn_ctl_RecentMemoRemove";
            this.lblbtn_ctl_RecentMemoRemove.Size = new System.Drawing.Size(44, 23);
            this.lblbtn_ctl_RecentMemoRemove.TabIndex = 9;
            this.lblbtn_ctl_RecentMemoRemove.Text = "削除";
            this.lblbtn_ctl_RecentMemoRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_RecentMemoRemove.Click += new System.EventHandler(this.lblbtn_ctl_RecentMemoRemove_Click);
            this.lblbtn_ctl_RecentMemoRemove.MouseEnter += new System.EventHandler(this.lblbtn_ctl_RecentMemoRemove_MouseEnter);
            this.lblbtn_ctl_RecentMemoRemove.MouseLeave += new System.EventHandler(this.lblbtn_ctl_RecentMemoRemove_MouseLeave);
            // 
            // lblbtn_ctl_MemoAdd
            // 
            this.lblbtn_ctl_MemoAdd.BackColor = System.Drawing.Color.Transparent;
            this.lblbtn_ctl_MemoAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblbtn_ctl_MemoAdd.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_ctl_MemoAdd.Image = global::Inventory_System.Properties.Resources.button_off_144_blue;
            this.lblbtn_ctl_MemoAdd.Location = new System.Drawing.Point(696, 56);
            this.lblbtn_ctl_MemoAdd.Name = "lblbtn_ctl_MemoAdd";
            this.lblbtn_ctl_MemoAdd.Size = new System.Drawing.Size(38, 23);
            this.lblbtn_ctl_MemoAdd.TabIndex = 9;
            this.lblbtn_ctl_MemoAdd.Text = "確定";
            this.lblbtn_ctl_MemoAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_MemoAdd.Click += new System.EventHandler(this.lblbtn_ctl_MemoAdd_Click);
            this.lblbtn_ctl_MemoAdd.Enter += new System.EventHandler(this.lblbtn_ctl_MemoAdd_MouseEnter);
            this.lblbtn_ctl_MemoAdd.Leave += new System.EventHandler(this.lblbtn_ctl_MemoAdd_MouseLeave);
            this.lblbtn_ctl_MemoAdd.MouseEnter += new System.EventHandler(this.lblbtn_ctl_MemoAdd_MouseEnter);
            this.lblbtn_ctl_MemoAdd.MouseLeave += new System.EventHandler(this.lblbtn_ctl_MemoAdd_MouseLeave);
            this.lblbtn_ctl_MemoAdd.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lblbtn_ctl_MemoAdd_PreviewKeyDown);
            // 
            // lblbtn_ctl_RecentMemoUpdate
            // 
            this.lblbtn_ctl_RecentMemoUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lblbtn_ctl_RecentMemoUpdate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblbtn_ctl_RecentMemoUpdate.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_ctl_RecentMemoUpdate.Image = global::Inventory_System.Properties.Resources.button_off_144_blue;
            this.lblbtn_ctl_RecentMemoUpdate.Location = new System.Drawing.Point(695, 28);
            this.lblbtn_ctl_RecentMemoUpdate.Name = "lblbtn_ctl_RecentMemoUpdate";
            this.lblbtn_ctl_RecentMemoUpdate.Size = new System.Drawing.Size(74, 23);
            this.lblbtn_ctl_RecentMemoUpdate.TabIndex = 9;
            this.lblbtn_ctl_RecentMemoUpdate.Text = "入力更新";
            this.lblbtn_ctl_RecentMemoUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_RecentMemoUpdate.Click += new System.EventHandler(this.lblbtn_ctl_RecentMemoUpdate_Click);
            this.lblbtn_ctl_RecentMemoUpdate.Enter += new System.EventHandler(this.lblbtn_ctl_RecentMemoUpdate_MouseEnter);
            this.lblbtn_ctl_RecentMemoUpdate.Leave += new System.EventHandler(this.lblbtn_ctl_RecentMemoUpdate_MouseLeave);
            this.lblbtn_ctl_RecentMemoUpdate.MouseEnter += new System.EventHandler(this.lblbtn_ctl_RecentMemoUpdate_MouseEnter);
            this.lblbtn_ctl_RecentMemoUpdate.MouseLeave += new System.EventHandler(this.lblbtn_ctl_RecentMemoUpdate_MouseLeave);
            this.lblbtn_ctl_RecentMemoUpdate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lblbtn_ctl_RecentMemoUpdate_PreviewKeyDown);
            // 
            // lblbtn_ctl_GetMemoTime
            // 
            this.lblbtn_ctl_GetMemoTime.Image = global::Inventory_System.Properties.Resources.button_off_144_red;
            this.lblbtn_ctl_GetMemoTime.Location = new System.Drawing.Point(3, 6);
            this.lblbtn_ctl_GetMemoTime.Name = "lblbtn_ctl_GetMemoTime";
            this.lblbtn_ctl_GetMemoTime.Size = new System.Drawing.Size(144, 74);
            this.lblbtn_ctl_GetMemoTime.TabIndex = 10;
            this.lblbtn_ctl_GetMemoTime.Text = "ここでメモ";
            this.lblbtn_ctl_GetMemoTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_GetMemoTime.Click += new System.EventHandler(this.lblbtn_ctl_GetMemoTime_Click);
            this.lblbtn_ctl_GetMemoTime.Enter += new System.EventHandler(this.lblbtn_ctl_GetMemoTime_MouseEnter);
            this.lblbtn_ctl_GetMemoTime.Leave += new System.EventHandler(this.lblbtn_ctl_GetMemoTime_MouseLeave);
            this.lblbtn_ctl_GetMemoTime.MouseEnter += new System.EventHandler(this.lblbtn_ctl_GetMemoTime_MouseEnter);
            this.lblbtn_ctl_GetMemoTime.MouseLeave += new System.EventHandler(this.lblbtn_ctl_GetMemoTime_MouseLeave);
            this.lblbtn_ctl_GetMemoTime.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lblbtn_ctl_GetMemoTime_PreviewKeyDown);
            // 
            // lblbtn_ctl_MemoInputRemove
            // 
            this.lblbtn_ctl_MemoInputRemove.BackColor = System.Drawing.Color.Silver;
            this.lblbtn_ctl_MemoInputRemove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblbtn_ctl_MemoInputRemove.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_ctl_MemoInputRemove.Image = global::Inventory_System.Properties.Resources.button_off_144_red;
            this.lblbtn_ctl_MemoInputRemove.Location = new System.Drawing.Point(738, 56);
            this.lblbtn_ctl_MemoInputRemove.Name = "lblbtn_ctl_MemoInputRemove";
            this.lblbtn_ctl_MemoInputRemove.Size = new System.Drawing.Size(80, 23);
            this.lblbtn_ctl_MemoInputRemove.TabIndex = 9;
            this.lblbtn_ctl_MemoInputRemove.Text = "←入力取消";
            this.lblbtn_ctl_MemoInputRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_MemoInputRemove.Click += new System.EventHandler(this.lblbtn_ctl_MemoInputRemove_Click);
            this.lblbtn_ctl_MemoInputRemove.MouseEnter += new System.EventHandler(this.lblbtn_ctl_MemoInputRemove_MouseEnter);
            this.lblbtn_ctl_MemoInputRemove.MouseLeave += new System.EventHandler(this.lblbtn_ctl_MemoInputRemove_MouseLeave);
            // 
            // tbx_MemoInput
            // 
            this.tbx_MemoInput.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tbx_MemoInput.Location = new System.Drawing.Point(230, 56);
            this.tbx_MemoInput.MaxLength = 64;
            this.tbx_MemoInput.Name = "tbx_MemoInput";
            this.tbx_MemoInput.Size = new System.Drawing.Size(460, 23);
            this.tbx_MemoInput.TabIndex = 8;
            this.tbx_MemoInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_MemoInput_KeyPress);
            // 
            // panel_MediaSelect
            // 
            this.panel_MediaSelect.BackColor = System.Drawing.Color.Transparent;
            this.panel_MediaSelect.Controls.Add(this.panel_MediaSelect_MediaInfo);
            this.panel_MediaSelect.Controls.Add(this.lbl_TitleLogo);
            this.panel_MediaSelect.Location = new System.Drawing.Point(826, 93);
            this.panel_MediaSelect.Name = "panel_MediaSelect";
            this.panel_MediaSelect.Size = new System.Drawing.Size(421, 259);
            this.panel_MediaSelect.TabIndex = 10;
            // 
            // panel_MemoList
            // 
            this.panel_MemoList.BackColor = System.Drawing.Color.Transparent;
            this.panel_MemoList.Controls.Add(this.panel_MemoList_All);
            this.panel_MemoList.Controls.Add(this.label1);
            this.panel_MemoList.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel_MemoList.Location = new System.Drawing.Point(826, 73);
            this.panel_MemoList.Name = "panel_MemoList";
            this.panel_MemoList.Size = new System.Drawing.Size(421, 441);
            this.panel_MemoList.TabIndex = 11;
            // 
            // panel_MemoList_All
            // 
            this.panel_MemoList_All.BackColor = System.Drawing.Color.LightGray;
            this.panel_MemoList_All.Controls.Add(this.panel2);
            this.panel_MemoList_All.Controls.Add(this.panel_MemoList_Title_Time);
            this.panel_MemoList_All.Controls.Add(this.panel_MemoList_info);
            this.panel_MemoList_All.Location = new System.Drawing.Point(12, 39);
            this.panel_MemoList_All.Name = "panel_MemoList_All";
            this.panel_MemoList_All.Size = new System.Drawing.Size(410, 399);
            this.panel_MemoList_All.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblbtn_ctl_AllMemoRemove);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(70, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 40);
            this.panel2.TabIndex = 5;
            // 
            // lblbtn_ctl_AllMemoRemove
            // 
            this.lblbtn_ctl_AllMemoRemove.BackColor = System.Drawing.Color.Transparent;
            this.lblbtn_ctl_AllMemoRemove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblbtn_ctl_AllMemoRemove.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblbtn_ctl_AllMemoRemove.Image = global::Inventory_System.Properties.Resources.button_off_144_red;
            this.lblbtn_ctl_AllMemoRemove.Location = new System.Drawing.Point(240, 6);
            this.lblbtn_ctl_AllMemoRemove.Name = "lblbtn_ctl_AllMemoRemove";
            this.lblbtn_ctl_AllMemoRemove.Size = new System.Drawing.Size(92, 28);
            this.lblbtn_ctl_AllMemoRemove.TabIndex = 6;
            this.lblbtn_ctl_AllMemoRemove.Text = "入力全削除\r\n(ダブルクリック)";
            this.lblbtn_ctl_AllMemoRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblbtn_ctl_AllMemoRemove.DoubleClick += new System.EventHandler(this.lblbtn_ctl_AllMemoRemove_DoubleClick);
            this.lblbtn_ctl_AllMemoRemove.MouseEnter += new System.EventHandler(this.lblbtn_ctl_AllMemoRemove_MouseEnter);
            this.lblbtn_ctl_AllMemoRemove.MouseLeave += new System.EventHandler(this.lblbtn_ctl_AllMemoRemove_MouseLeave);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(1, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(330, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Memo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel_MemoList_Title_Time
            // 
            this.panel_MemoList_Title_Time.BackColor = System.Drawing.Color.Gainsboro;
            this.panel_MemoList_Title_Time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_MemoList_Title_Time.Controls.Add(this.label2);
            this.panel_MemoList_Title_Time.Location = new System.Drawing.Point(0, 0);
            this.panel_MemoList_Title_Time.Margin = new System.Windows.Forms.Padding(0);
            this.panel_MemoList_Title_Time.Name = "panel_MemoList_Title_Time";
            this.panel_MemoList_Title_Time.Size = new System.Drawing.Size(70, 40);
            this.panel_MemoList_Title_Time.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel_MemoList_info
            // 
            this.panel_MemoList_info.AutoScroll = true;
            this.panel_MemoList_info.BackColor = System.Drawing.Color.Azure;
            this.panel_MemoList_info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_MemoList_info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_MemoList_info.Controls.Add(this.lbl_ctl_MemoList_FakeLabel);
            this.panel_MemoList_info.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.panel_MemoList_info.Location = new System.Drawing.Point(0, 39);
            this.panel_MemoList_info.Name = "panel_MemoList_info";
            this.panel_MemoList_info.Size = new System.Drawing.Size(410, 360);
            this.panel_MemoList_info.TabIndex = 3;
            // 
            // lbl_ctl_MemoList_FakeLabel
            // 
            this.lbl_ctl_MemoList_FakeLabel.AutoSize = true;
            this.lbl_ctl_MemoList_FakeLabel.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ctl_MemoList_FakeLabel.Location = new System.Drawing.Point(0, 0);
            this.lbl_ctl_MemoList_FakeLabel.Name = "lbl_ctl_MemoList_FakeLabel";
            this.lbl_ctl_MemoList_FakeLabel.Size = new System.Drawing.Size(0, 13);
            this.lbl_ctl_MemoList_FakeLabel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "-メモ一覧-";
            // 
            // JukeBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.BackgroundImage = global::Inventory_System.Properties.Resources.background_jukebox_x_Gouka_Blue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.lblbtn_comeonbabyboss_fuckinfuckin);
            this.Controls.Add(this.panel_MemoList);
            this.Controls.Add(this.panel_MediaSelect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_MediaPlay);
            this.Controls.Add(this.panel_ControlWindow);
            this.Controls.Add(this.lbl_exc_I_am_seclet_application);
            this.Controls.Add(this.panel_SysControl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "JukeBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JukeBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.JukeBox_Load);
            this.panel_MediaSelect_MediaInfo.ResumeLayout(false);
            this.panel_MediaSelect_MediaInfo.PerformLayout();
            this.panel_SysControl.ResumeLayout(false);
            this.panel_MediaPlay_TimeBar.ResumeLayout(false);
            this.panel_MediaPlay_TimeBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MediaPlay_Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_MediaPlay_Volume)).EndInit();
            this.panel_ControlWindow.ResumeLayout(false);
            this.panel_MediaPlay.ResumeLayout(false);
            this.panel_MediaPlay_PlayWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.window_MediaPlayer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_MediaSelect.ResumeLayout(false);
            this.panel_MemoList.ResumeLayout(false);
            this.panel_MemoList.PerformLayout();
            this.panel_MemoList_All.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel_MemoList_Title_Time.ResumeLayout(false);
            this.panel_MemoList_info.ResumeLayout(false);
            this.panel_MemoList_info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblbtn_sys_BackPos;
        private System.Windows.Forms.Panel panel_MediaSelect_MediaInfo;
        private System.Windows.Forms.Panel panel_SysControl;
        private System.Windows.Forms.Label lbl_TitleLogo;
        private System.Windows.Forms.Label lblbtn_cnt_MediaSelect_Next;
        private System.Windows.Forms.Label lblbtn_cnt_MediaSelect_Back;
        private System.Windows.Forms.Label lbl_exc_I_am_seclet_application;
        private System.Windows.Forms.Panel panel_MediaPlay_TimeBar;
        private System.Windows.Forms.Panel panel_ControlWindow;
        private System.Windows.Forms.Label lblbtn_cnt_PlayAndPause;
        private System.Windows.Forms.Panel panel_MediaPlay;
        private System.Windows.Forms.Panel panel_MediaPlay_PlayWindow;
        private AxWMPLib.AxWindowsMediaPlayer window_MediaPlayer;
        private System.Windows.Forms.Label lbl_info_volume;
        private System.Windows.Forms.TrackBar trackBar_MediaPlay_Volume;
        private System.Windows.Forms.Label lbl_info_playtime;
        private System.Windows.Forms.TrackBar trackBar_MediaPlay_Time;
        private System.Windows.Forms.Timer timer_getMediaPlayTime_250;
        private System.Windows.Forms.Timer timer_changeMediaPlayTime_150;
        private System.Windows.Forms.Label lblbtn_ctl_FileOpen;
        private System.Windows.Forms.Label lblbtn_sys_HeyBoss;
        private System.Windows.Forms.Label lblbtn_comeonbabyboss_fuckinfuckin;
        private System.Windows.Forms.Timer timer_statusGetMediaPlayTime_50;
        private System.Windows.Forms.Label lblbtn_ctl_Reverse;
        private System.Windows.Forms.Label lblbtn_ctl_Forward;
        private System.Windows.Forms.TextBox tbx_RecentMemoInput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblbtn_ctl_MemoInputRemove;
        private System.Windows.Forms.Label lbl_info_RecentMemoTime;
        private System.Windows.Forms.Label lbl_info_RecentMemo;
        private System.Windows.Forms.Label lbl_info_MemoTime;
        private System.Windows.Forms.Label lbl_info_Memo;
        private System.Windows.Forms.Label lblbtn_ctl_RecentMemoRemove;
        private System.Windows.Forms.Label lblbtn_ctl_MemoAdd;
        private System.Windows.Forms.Label lblbtn_ctl_RecentMemoUpdate;
        private System.Windows.Forms.Label lblbtn_ctl_GetMemoTime;
        private System.Windows.Forms.TextBox tbx_MemoInput;
        private System.Windows.Forms.Label lblbtn_ctl_FolderSelect;
        private System.Windows.Forms.Label lblbtn_ctl_MemoSave;
        private System.Windows.Forms.Label lbl_info_MemoSum;
        private System.Windows.Forms.Label lbl_info_MemoSousu;
        private System.Windows.Forms.Panel panel_MediaSelect;
        private System.Windows.Forms.Panel panel_MemoList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_MemoList_info;
        private System.Windows.Forms.Label lbl_ctl_MemoList_FakeLabel;
        private System.Windows.Forms.Panel panel_MemoList_All;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_MemoList_Title_Time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblbtn_ctl_AllMemoRemove;
        private System.Windows.Forms.Label lblbtn_ctl_Stop;
    }
}