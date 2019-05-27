using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using QuartzTypeLib;
using System.IO;


namespace menu
{
    public partial class JukeBox : Form
    {
        public JukeBox()
        {
            InitializeComponent();
        }

        //変数一覧
        private double playTime = 0;
        private bool playstatus = false;
        private int memo_New_Y_Location = 0;
        private int memo_Now_Number = -1;
        private string filePath = "";
        private string[] memoTime = new string[50000];
        private string[] memoInfo = new string[50000];
        private string[] memoMaster = new string[50001];
        private Label[,] lbl_ctl_MemoTime = new Label[50000,1];
        private Label[,] lbl_ctl_MemoInfo = new Label[50000,1];
        private OpenFileDialog ofd = new OpenFileDialog();
        private OpenFileDialog ofd_csv = new OpenFileDialog();
        private SaveFileDialog sfd_memo = new SaveFileDialog();

        //ぼくの描画系メソッド
        private void imageChange_Button_On_Blue(Label label)
        {
            label.Image = global::Inventory_System.Properties.Resources.button_on_144_blue;
        }
        private void imageChange_Button_On_Red(Label label)
        {
            label.Image = global::Inventory_System.Properties.Resources.button_on_144_red;
        }
        private void imageChange_Button_On_LGreen(Label label)
        {
            label.Image = global::Inventory_System.Properties.Resources.button_on_144_lgreen;
        }
        private void imageChange_Button_Off_Blue(Label label)
        {
            label.Image = global::Inventory_System.Properties.Resources.button_off_144_blue;
        }
        private void imageChange_Button_Off_Red(Label label)
        {
            label.Image = global::Inventory_System.Properties.Resources.button_off_144_red;
        }
        private void imageChange_Button_Off_LGreen(Label label)
        {
            label.Image = global::Inventory_System.Properties.Resources.button_off_144_lgreen;
        }

        //ぼくのアプリ制御系メソッド
        private int mediaStart()
        {
            try
            {
                memoClear();
                window_MediaPlayer.close();
                trackBar_MediaPlay_Time.Value = 0;
                window_MediaPlayer.Ctlcontrols.currentPosition = 0;
                playTime = 0;
                mediaPlay();
                trackBar_MediaPlay_Time.Enabled = false;
                timer_getMediaPlayTime_250.Start();
                lblbtn_ctl_FolderSelect.Visible = true;
                lblbtn_ctl_FolderSelect.Enabled = true;
                tbx_MemoInput.Enabled = tbx_MemoInput.Visible = true;
                tbx_RecentMemoInput.Enabled = tbx_RecentMemoInput.Visible = true;
                lblbtn_ctl_Stop.Enabled = true;
                lblbtn_ctl_MemoSave.Enabled = true;
                lblbtn_ctl_RecentMemoRemove.Enabled = true;
                lblbtn_ctl_MemoAdd.Enabled = true;
                lblbtn_ctl_MemoSave.BackColor = Color.LightSkyBlue;
                return 0;
            }
            catch
            {
                return -1;
            }

        }//入ってるリンク先の動画新規で開く
        private int mediaPause()
        {
            try
            {
                window_MediaPlayer.Ctlcontrols.pause();
                playstatus = false;
                lblbtn_cnt_PlayAndPause.Text = "▶ 再生";
                return 0;
            }
            catch
            {
                return -1;
            }
        }//一時停止
        private int mediaPlay()
        {
            try
            {
                window_MediaPlayer.Ctlcontrols.play();
                playstatus = true;
                lblbtn_cnt_PlayAndPause.Text = "|| 一時停止";
                return 0;
            }
            catch
            {
                return -1;
            }
        }//再生
        private int mediaStop()
        {
            try
            {
                window_MediaPlayer.close();
                playstatus = false;
                timer_statusGetMediaPlayTime_50.Stop();
                lblbtn_cnt_PlayAndPause.Text = "▶ 再生";
                playTime = 0;
                trackBar_MediaPlay_Time.Value = 0;
                trackBar_MediaPlay_Time.Minimum = 0;
                trackBar_MediaPlay_Time.Maximum = 2;
                tbx_MemoInput.Enabled =false;
                tbx_RecentMemoInput.Enabled =false;
                lblbtn_ctl_FolderSelect.Enabled = false;
                trackBar_MediaPlay_Time.Enabled = false;
                lblbtn_ctl_Stop.Enabled = false;
                lblbtn_ctl_RecentMemoRemove.Enabled = false;
                lblbtn_ctl_MemoAdd.Enabled = false;
                lbl_info_playtime.Text = "0:00:00/0:00:00";
                lbl_info_MemoTime.Text = "00:00:00";
                if(memo_Now_Number!=-1)
                {
                    lblbtn_ctl_MemoSave.Enabled = true;
                }
                else
                {
                    lblbtn_ctl_MemoSave.Enabled = false;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }//停止
        private int memoClear()
        {
            try
            {
                while (memo_Now_Number >= 0)
                {
                    lbl_ctl_MemoTime[memo_Now_Number, 0].Text = "";
                    lbl_ctl_MemoTime[memo_Now_Number, 0].Dispose();
                    lbl_ctl_MemoInfo[memo_Now_Number, 0].Text = "";
                    lbl_ctl_MemoInfo[memo_Now_Number, 0].Dispose();
                    lbl_info_RecentMemoTime.Text = "";
                    tbx_RecentMemoInput.Text = "";
                    memoTime[memo_Now_Number] = memoInfo[memo_Now_Number] = "";
                    memo_Now_Number--;
                }
                memo_Now_Number = -1;
                memo_New_Y_Location = 0;
                lbl_info_MemoSum.Text = String.Format("{0:#,0} 件", memo_Now_Number + 1);
                if(lblbtn_ctl_Stop.Enabled==false)
                {
                    lblbtn_ctl_MemoSave.Enabled = false;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }//メモ初期化
        private int memoSave()
        {
            try
            {
                StreamWriter csvSave = new StreamWriter(filePath, false, Encoding.GetEncoding("UTF-8"));
                csvSave.Write("Time,Memo");
                for (int i = 0; i <= memo_Now_Number; i++)
                {
                    memoMaster[i] = memoTime[i] + "," + memoInfo[i];
                    csvSave.Write(System.Environment.NewLine+memoMaster[i]);
                }
                csvSave.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }//メモ保存
        private int memoLoad()
        {
            try
            {
                StreamReader load_CsvData = new StreamReader(ofd_csv.FileName, Encoding.GetEncoding("UTF-8"));
                try
                {
                    if (load_CsvData.ReadLine() == "Time,Memo")
                    {
                        int i = 0;
                        while (load_CsvData.Peek() != -1)
                        {
                            try
                            {
                                memoMaster[i] = load_CsvData.ReadLine();
                                string[] splitArray = memoMaster[i].Split(',');
                                lbl_info_MemoTime.Text = splitArray[0];
                                tbx_MemoInput.Text = splitArray[1];
                                lblbtn_ctl_MemoAdd_Click(null, null);
                                i++;
                            }
                            catch { }
                        }

                    }
                    else
                    {
                        MessageBox.Show("本アプリで生成したファイルのみ開くことができます。" + System.Environment.NewLine + "また、作成したファイルを他アプリで編集しないでください。" + System.Environment.NewLine + "ファイル1行目が[Time,Memo]のファイルのみ読み込み試行します。");
                    }
                    load_CsvData.Close();
                }
                catch
                {
                    load_CsvData.Close();
                    return -1;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }//メモ読込



        //ぼくのその他メソッド
        private void Labelsclick(object sender, EventArgs e)
        {
            try
            {
                int currentPositionTemp = 0;
                currentPositionTemp += (int.Parse(DateTime.ParseExact(((Label)sender).Text, "HH:mm:ss", null).ToString("ss")));
                currentPositionTemp += (int.Parse(DateTime.ParseExact(((Label)sender).Text, "HH:mm:ss", null).ToString("mm")) * 60);
                currentPositionTemp += (int.Parse(DateTime.ParseExact(((Label)sender).Text, "HH:mm:ss", null).ToString("HH")) * 3600);
                window_MediaPlayer.Ctlcontrols.currentPosition = (double)currentPositionTemp;
            }
            catch
            {
                MessageBox.Show("時刻の入力形式が正確か確認してください。");
            }
        }
        public int LabelsAdd(int itemNumY, int itemNumX, int locationY, int locationYAdd, int[] locationX, Label[,] labels, int defaultItemNumberY, string labelsName, string font, Single fontSize)
        {
            int nowLocationY = locationY;
            int nowItemNumberY = defaultItemNumberY;
            for (int loopY = 0; loopY != itemNumY; loopY++)
            {
                for (int loopX = 0; loopX != itemNumX; loopX++)
                {
                    labels[nowItemNumberY, loopX] = new Label();
                    labels[nowItemNumberY, loopX].Name = labelsName + loopY.ToString() + loopX.ToString();
                    labels[nowItemNumberY, loopX].Text = "00:00:00";//labelsName + loopY.ToString() + loopX.ToString();
                    labels[nowItemNumberY, loopX].Font = new System.Drawing.Font(font, fontSize);
                    labels[nowItemNumberY, loopX].Location = new System.Drawing.Point(locationX[loopX], nowLocationY);
                    labels[nowItemNumberY, loopX].AutoSize = true;
                }
                nowLocationY += locationYAdd;
                nowItemNumberY++;
            }
            return nowLocationY;

        }//label生成するやーつ
        
        //ボタン描画制御[追加機能つけるときに便利そうだから(Label)[object].Imageから引っ張らず敢えて分離]
        private void lblbtn_sys_BackPos_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Blue(lblbtn_sys_BackPos);
        }
        private void lblbtn_sys_BackPos_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_Blue(lblbtn_sys_BackPos);

        }
        private void lblbtn_sys_HeyBoss_MouseEnter(object sender, EventArgs e)
        {
            lblbtn_sys_HeyBoss.BackColor = Color.Gray;
        }
        private void lblbtn_sys_HeyBoss_MouseLeave(object sender, EventArgs e)
        {
            lblbtn_sys_HeyBoss.BackColor = Color.Silver;
        }
        private void lblbtn_cnt_PlayAndPause_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Blue(lblbtn_cnt_PlayAndPause);
        }
        private void lblbtn_cnt_PlayAndPause_MouseLeave(object sender, EventArgs e)
        {
           imageChange_Button_Off_Blue(lblbtn_cnt_PlayAndPause);
        }
        private void lblbtn_cnt_FileOpen_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Red(lblbtn_ctl_FileOpen);
        }
        private void lblbtn_cnt_FileOpen_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_Red(lblbtn_ctl_FileOpen);
        }
        private void lblbtn_ctl_Forward_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_LGreen(lblbtn_ctl_Forward);
        }
        private void lblbtn_ctl_Forward_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_LGreen(lblbtn_ctl_Forward);
        }
        private void lblbtn_ctl_Reverse_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_LGreen(lblbtn_ctl_Reverse);
        }
        private void lblbtn_ctl_Reverse_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_LGreen(lblbtn_ctl_Reverse);
        }
        private void lblbtn_ctl_FolderSelect_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Red(lblbtn_ctl_FolderSelect);
        }
        private void lblbtn_ctl_FolderSelect_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_Red(lblbtn_ctl_FolderSelect);
        }
        private void lblbtn_ctl_GetMemoTime_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Red(lblbtn_ctl_GetMemoTime);
        }
        private void lblbtn_ctl_GetMemoTime_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_Red(lblbtn_ctl_GetMemoTime);
        }
        private void lblbtn_ctl_RecentMemoRemove_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Red(lblbtn_ctl_RecentMemoRemove);
        }
        private void lblbtn_ctl_RecentMemoRemove_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_Red(lblbtn_ctl_RecentMemoRemove);
        }
        private void lblbtn_ctl_MemoInputRemove_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Red(lblbtn_ctl_MemoInputRemove);
        }
        private void lblbtn_ctl_MemoInputRemove_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_Red(lblbtn_ctl_MemoInputRemove);
        }
        private void lblbtn_ctl_RecentMemoUpdate_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Blue(lblbtn_ctl_RecentMemoUpdate);
        }
        private void lblbtn_ctl_RecentMemoUpdate_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_Blue(lblbtn_ctl_RecentMemoUpdate);
        }
        private void lblbtn_ctl_MemoAdd_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Blue(lblbtn_ctl_MemoAdd);
        }
        private void lblbtn_ctl_MemoAdd_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_Blue(lblbtn_ctl_MemoAdd);
        }
        private void lblbtn_ctl_MemoSave_MouseEnter(object sender, EventArgs e)
        {
            lblbtn_ctl_MemoSave.BackColor = Color.DeepSkyBlue;
        }
        private void lblbtn_ctl_MemoSave_MouseLeave(object sender, EventArgs e)
        {
            lblbtn_ctl_MemoSave.BackColor = Color.LightSkyBlue;
        }
        private void lblbtn_ctl_AllMemoRemove_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Red(lblbtn_ctl_AllMemoRemove);
        }
        private void lblbtn_ctl_AllMemoRemove_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_Red(lblbtn_ctl_AllMemoRemove);
        }
        private void lblbtn_ctl_Stop_MouseEnter(object sender, EventArgs e)
        {
            imageChange_Button_On_Red(lblbtn_ctl_Stop);
        }
        private void lblbtn_ctl_Stop_MouseLeave(object sender, EventArgs e)
        {
            imageChange_Button_Off_Red(lblbtn_ctl_Stop);
        }

        //タイマー制御
        private void timer_getMediaPlayTime_250_Tick(object sender, EventArgs e)
        {
            try
            {
                playTime = window_MediaPlayer.currentMedia.duration;
                if (playTime != 0)
                {
                    timer_getMediaPlayTime_250.Stop();
                    trackBar_MediaPlay_Time.TickFrequency = trackBar_MediaPlay_Time.Maximum = (int)playTime + 1;
                    trackBar_MediaPlay_Time.Enabled = true;
                    timer_statusGetMediaPlayTime_50.Start();
                }
            }
            catch
            { }
        }
        private void timer_changeMediaPlayTime_150_Tick(object sender, EventArgs e)
        {
            timer_changeMediaPlayTime_150.Stop();
            window_MediaPlayer.Ctlcontrols.pause();
            window_MediaPlayer.Ctlcontrols.currentPosition = trackBar_MediaPlay_Time.Value;
            if(playstatus==true)
            {
                window_MediaPlayer.Ctlcontrols.play();
            }

        }
        private void timer_statusGetMediaPlayTime_50_Tick(object sender, EventArgs e)
        {
            try
            {
                if(timer_changeMediaPlayTime_150.Enabled!=true)
                {
                    trackBar_MediaPlay_Time.Value = (int)window_MediaPlayer.Ctlcontrols.currentPosition;
                }
                if(trackBar_MediaPlay_Time.Value>=trackBar_MediaPlay_Time.Maximum-1)
                {
                    mediaPause();
                    window_MediaPlayer.Ctlcontrols.currentPosition = 0;
                }
                lbl_info_playtime.Text = String.Format("{0:00}", (int)window_MediaPlayer.Ctlcontrols.currentPosition / 3600) + ":" + String.Format("{0:00}", ((int)window_MediaPlayer.Ctlcontrols.currentPosition / 60) % 60) + ":" + String.Format("{0:00}", (int)window_MediaPlayer.Ctlcontrols.currentPosition % 60)+"/";
                lbl_info_playtime.Text += String.Format("{0:00}", (int)playTime / 3600) + ":" + String.Format("{0:00}", ((int)playTime / 60) % 60) + ":" + String.Format("{0:00}", (int)playTime % 60) ;

            }
            catch
            { }
            
        }

        //ロード時
        private void JukeBox_Load(object sender, EventArgs e)
        {
            window_MediaPlayer.uiMode = "none";
            ofd.FileName = "";
            ofd.InitialDirectory = "";
            ofd.Filter = "動画ファイル(*.mp4;*wmv;*.avi)|*.mp4;*.avi;*wmv";
            ofd.Filter += "|音楽ファイル(*.mp4;*wav;*.mp3;*.aac;*.flac;*.wma)|*.mp4;*.wav;*mp3;*.aac;*.flac;*.wma";
            ofd.Filter += "|メディアファイル(*.mp4;*wmv;*.avi;*wav;*.mp3;*.aac;*.flac;*.wma)|*.mp4;*wmv;*.avi;*wav;*.mp3;*.aac;*.flac;*.wma";
            ofd.Filter += "|全てのファイル(*.*)|*.*";
            ofd.FilterIndex = 3;
            ofd.Title = "メディア再生-動画/音楽ファイルを選択してください";
            ofd_csv.FileName = "";
            ofd_csv.InitialDirectory = "";
            ofd_csv.Filter = "CSVファイル(*.csv)|*.csv";
            ofd_csv.Filter += "|テキストファイル(*.txt;*.csv)|*.txt;*.csv";
            ofd_csv.FilterIndex = 1;
            ofd_csv.Title = "メモ読込-CSVファイルを選択してください";
            sfd_memo.FileName = "";
            sfd_memo.InitialDirectory = "";
            sfd_memo.Filter = "CSVファイル(*.csv)|*csv";
            sfd_memo.Title = "メモ保存-保存先とファイル名を選択してください";
            sfd_memo.FilterIndex = 1;
            sfd_memo.RestoreDirectory = true;
            memoMaster[0] = "Time,Comment";
            mediaStop();
        }//フォームロード

        //ボタン動作&他制御
        private void back_POS(object sender, EventArgs e)
        {
            //*/
            POS_System.Form1 pos_system = new POS_System.Form1();
            pos_system.Show();
            System.Threading.Thread.Sleep(200);
            //*/
            this.Dispose();
        }//新規POSを開く
        private void lblbtn_cnt_PlayAndPause_Click(object sender, EventArgs e)
        {
            if (playTime != 0)
            {
                if (playstatus == true)
                {
                    mediaPause();
                }
                else
                {
                    mediaPlay();
                }
            }
        }//再生・一時停止ボタン処理
        private void lblbtn_cnt_FileOpen_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //window_MediaPlayer.settings.autoStart = false;
                window_MediaPlayer.URL = ofd.FileName;
                mediaStart();
                lblbtn_ctl_GetMemoTime.Focus();
            }
            else
            {}
            /*
            FilgraphManager filgraphManager = new FilgraphManager();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filgraphManager.RenderFile(ofd.FileName);
                IBasicVideo bv = (IBasicVideo)filgraphManager;
                IVideoWindow vw = (IVideoWindow)filgraphManager;
                IMediaEventEx mevent = (IMediaEventEx)filgraphManager;
                int vx, vy;
                bv.GetVideoSize(out vx, out vy);
                vw.Owner = (int)this.panel_MediaPlay_PlayWindow.Handle;
                vw.WindowStyle = 0x40000000 | 0x4000000;
                vw.SetWindowPosition(0, 0, vx, vy);
                this.panel_MediaPlay_PlayWindow.Width = vx + 2;
                this.panel_MediaPlay_PlayWindow.Height = vy + 55;
                lblbtn_cnt_PlayAndPause.Location = new Point(0,0);
                mevent.SetNotifyWindow((int)this.panel_MediaPlay_PlayWindow.Handle, 0x8000, 0);
                filgraphManager.Run();
            }//*/

        }//メディアファイル選択読込
        private void lblbtn_ctl_FolderSelect_Click(object sender, EventArgs e)
        {
            if (ofd_csv.ShowDialog() == DialogResult.OK)
            {
                memoLoad();
            }
            else { }

        }//CSV読込
        private void lblbtn_ctl_MemoSave_Click(object sender, EventArgs e)
        {
            sfd_memo.FileName = Path.GetFileNameWithoutExtension(ofd.FileName) + "_Memo";
            if (sfd_memo.ShowDialog() == DialogResult.OK)
            {
                filePath = sfd_memo.FileName+".csv";
                memoSave();
            }
        }//CSV保存
        private void lblbtn_sys_HeyBoss_Click(object sender, EventArgs e)
        {
            mediaPause();
            lblbtn_comeonbabyboss_fuckinfuckin.Height = 720;
            lblbtn_comeonbabyboss_fuckinfuckin.Width = 1280;
        }//ボスが来た
        private void lblbtn_comeonbabyboss_fuckinfuckin_Click(object sender, EventArgs e)
        {
            lblbtn_comeonbabyboss_fuckinfuckin.Height = 0;
            lblbtn_comeonbabyboss_fuckinfuckin.Width = 0;
        }//ボスが来た解除
        private void lbl_exc_I_am_seclet_application_DoubleClick(object sender, EventArgs e)
        {
            lbl_exc_I_am_seclet_application.Text = "";
        }//上の邪魔な奴消す
        private void trackBar_MediaPlay_Volume_Scroll(object sender, EventArgs e)
        {
            window_MediaPlayer.settings.volume = trackBar_MediaPlay_Volume.Value;
        }//ボリュームバー
        private void trackBar_MediaPlay_Time_Scroll(object sender, EventArgs e)
        {
            //label1.Text=playTime.ToString();
            timer_changeMediaPlayTime_150.Stop();
            timer_changeMediaPlayTime_150.Start();
        }//再生箇所のバー
        private void lblbtn_ctl_Reverse_Click(object sender, EventArgs e)
        {
            mediaPause();
            window_MediaPlayer.Ctlcontrols.fastReverse();
        }//巻き戻し
        private void lblbtn_ctl_Forward_Click(object sender, EventArgs e)
        {
            mediaPause();
            window_MediaPlayer.Ctlcontrols.fastForward();
        }//早送り
        private void lblbtn_ctl_Stop_DoubleClick(object sender, EventArgs e)
        {
            mediaStop();
        }//停止
        private void lblbtn_ctl_GetMemoTime_Click(object sender, EventArgs e)
        {
            lbl_info_MemoTime.Text = String.Format("{0:00}", (int)window_MediaPlayer.Ctlcontrols.currentPosition / 3600) + ":" + String.Format("{0:00}", ((int)window_MediaPlayer.Ctlcontrols.currentPosition / 60) % 60) + ":" + String.Format("{0:00}", (int)window_MediaPlayer.Ctlcontrols.currentPosition % 60);
            tbx_MemoInput.Focus();
        }//メモ時間取得
        private void lblbtn_ctl_MemoInputRemove_Click(object sender, EventArgs e)
        {
            tbx_MemoInput.Text = "";

        }//メモ取消-テキストボックス削除
        private void tbx_MemoInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Enter時の処理
            {
                lblbtn_ctl_MemoAdd.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == (char)',')
            {
                e.Handled = true;
            }

        }//メモテキストボックス-移動
        private void tbx_RecentMemoInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Enter時の処理
            {
                lblbtn_ctl_RecentMemoUpdate.Focus();
                e.Handled = true;
            }
            if (e.KeyChar == (char)',')
            {
                e.Handled = true;
            }
        }//直近メモテキストボックス-移動
        private void lblbtn_ctl_RecentMemoUpdate_Click(object sender, EventArgs e)
        {
            if (memo_Now_Number >= 0)
            {
                lbl_ctl_MemoList_FakeLabel.Focus();
                memoTime[memo_Now_Number]=lbl_ctl_MemoTime[memo_Now_Number, 0].Text = lbl_info_RecentMemoTime.Text;
                memoInfo[memo_Now_Number]=lbl_ctl_MemoInfo[memo_Now_Number, 0].Text = tbx_RecentMemoInput.Text;
                lbl_info_MemoSum.Text = String.Format("{0:#,0} 件", memo_Now_Number+1);
                lbl_ctl_MemoTime[memo_Now_Number, 0].Focus();
                lbl_info_RecentMemoTime.Text = lbl_ctl_MemoTime[memo_Now_Number, 0].Text;
                tbx_RecentMemoInput.Text = lbl_ctl_MemoInfo[memo_Now_Number, 0].Text;
            }
            lblbtn_ctl_GetMemoTime.Focus();
        }//直近メモ更新
        private void lblbtn_ctl_RecentMemoRemove_Click(object sender, EventArgs e)
        {
            if (memo_Now_Number >= 0)
            {
                try
                {
                    lbl_ctl_MemoList_FakeLabel.Focus();
                    lbl_ctl_MemoTime[memo_Now_Number, 0].Focus();
                    memo_New_Y_Location -= 20;
                    lbl_ctl_MemoTime[memo_Now_Number, 0].Dispose();
                    lbl_ctl_MemoInfo[memo_Now_Number, 0].Dispose();
                    memoTime[memo_Now_Number] = memoInfo[memo_Now_Number] = "";
                    memo_Now_Number--;
                    lbl_info_MemoSum.Text = String.Format("{0:#,0} 件", memo_Now_Number + 1);
                    lbl_info_RecentMemoTime.Text = lbl_ctl_MemoTime[memo_Now_Number, 0].Text;
                    tbx_RecentMemoInput.Text = lbl_ctl_MemoInfo[memo_Now_Number, 0].Text;
                }
                catch { }
            }
            lblbtn_ctl_GetMemoTime.Focus();
        }//直近メモ削除
        private void lblbtn_ctl_MemoAdd_Click(object sender, EventArgs e)
        {
            panel_MemoList_info.AutoScroll = false;
            memo_Now_Number++;
            lbl_ctl_MemoList_FakeLabel.Focus();
            int[] memoTime_new_X_Location = { 10 };
            int[] memoInfo_new_X_Location = { 72 };
            LabelsAdd(1, 1, memo_New_Y_Location, 0, memoTime_new_X_Location, lbl_ctl_MemoTime, memo_Now_Number, "lbl_ctl_MemoTime", "MS UI Gothic", 10F);
            LabelsAdd(1, 1, memo_New_Y_Location, 0, memoInfo_new_X_Location, lbl_ctl_MemoInfo, memo_Now_Number, "lbl_ctl_MemoInfo", "MS UI Gothic", 10F);
            lbl_ctl_MemoTime[memo_Now_Number, 0].Font = new System.Drawing.Font("MS UI Gothic", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lbl_ctl_MemoTime[memo_Now_Number, 0].ForeColor = Color.Blue;
            lbl_ctl_MemoTime[memo_Now_Number, 0].Click += new EventHandler(Labelsclick);
            memoTime[memo_Now_Number] = lbl_ctl_MemoTime[memo_Now_Number, 0].Text = lbl_info_MemoTime.Text;
            memoInfo[memo_Now_Number] = lbl_ctl_MemoInfo[memo_Now_Number, 0].Text = tbx_MemoInput.Text;
            panel_MemoList_info.Controls.Add(lbl_ctl_MemoTime[memo_Now_Number, 0]);
            panel_MemoList_info.Controls.Add(lbl_ctl_MemoInfo[memo_Now_Number, 0]);
            lbl_ctl_MemoInfo[memo_Now_Number, 0].BringToFront();
            lbl_ctl_MemoTime[memo_Now_Number, 0].BringToFront();
            lblbtn_comeonbabyboss_fuckinfuckin.BringToFront();
            memo_New_Y_Location += 20;
            lbl_info_RecentMemoTime.Text = lbl_ctl_MemoTime[memo_Now_Number, 0].Text;
            tbx_RecentMemoInput.Text = lbl_ctl_MemoInfo[memo_Now_Number, 0].Text;
            panel_MemoList_info.AutoScroll = true;
            lbl_ctl_MemoTime[memo_Now_Number, 0].Focus();
            tbx_MemoInput.Text = "";
            lbl_info_MemoSum.Text = String.Format("{0:#,0} 件", memo_Now_Number+1);
            lblbtn_ctl_GetMemoTime.Focus();
        }//メモ確定-追加
        private void lblbtn_ctl_AllMemoRemove_DoubleClick(object sender, EventArgs e)
        {
            lbl_info_MemoSum.Text = "削除処理中...";
            memoClear();
        }//メモ全消ボタン

        //ラベルボタンのキーボード操作(ボタンクリックに飛ばすだけ)
        private void lblbtn_ctl_GetMemoTime_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lblbtn_ctl_GetMemoTime_Click(sender, (EventArgs)e);
        }//メモ時間取得(キー押下)
        private void lblbtn_ctl_MemoAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lblbtn_ctl_MemoAdd_Click(sender, (EventArgs)e);
        }//メモ確定-追加(キー押下)
        private void lblbtn_ctl_RecentMemoUpdate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            lblbtn_ctl_RecentMemoUpdate_Click(sender,(EventArgs)e);
        }//メモ更新(キー押下)
    }
}