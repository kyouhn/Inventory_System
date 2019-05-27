using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Configuration;

namespace Inventory_System
{
    public partial class autoPurchase : Form

        
    {
        private menu.menu top;

        public autoPurchase(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }

        private string filePath = "";
        private string[] logTime = new string[50000];
        private string[] logInfo = new string[50000];
        private string[] logMaster = new string[50001];
        private Label[,] lbl_ctl_LogTime = new Label[50000, 1];
        private Label[,] lbl_ctl_LogInfo = new Label[50000, 1];
        private int log_Now_Number = -1;
        private int log_New_Y_Location = 0;
        DateTime NowDate=DateTime.Now;

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
        private int logSave()
        {
            try
            {
                StreamWriter csvSave = new StreamWriter("log\\csv\\"+NowDate.ToString("yyyyMMddHHmmss")+".csv", false, Encoding.GetEncoding("UTF-8"));
                csvSave.Write("Time,Log");
                for (int i = 0; i <= log_Now_Number; i++)
                {
                    logMaster[i] = logTime[i] + "," + logInfo[i];
                    csvSave.Write(System.Environment.NewLine + logMaster[i]);
                }
                csvSave.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }//ログ保存
        private void LogsAdd(string log)
        {
            NowDate = DateTime.Now;
            lbl_SysDate.Text = "現在時刻:"+NowDate.ToString("yyyy/MM/dd hh:MM:ss");
            panel_LogTable_Log.AutoScroll = false;
            log_Now_Number++;
            //lbl_fake.Focus();
            int[] logTime_new_X_Location = { 6 };
            int[] logInfo_new_X_Location = { 146 };
            LabelsAdd(1, 1, log_New_Y_Location, 0, logTime_new_X_Location, lbl_ctl_LogTime, log_Now_Number, "lbl_ctl_LogTime", "MS UI Gothic", 10F);
            LabelsAdd(1, 1, log_New_Y_Location, 0, logInfo_new_X_Location, lbl_ctl_LogInfo, log_Now_Number, "lbl_ctl_LogInfo", "MS UI Gothic", 10F);
            lbl_ctl_LogTime[log_Now_Number, 0].Font = new System.Drawing.Font("MS UI Gothic", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            lbl_ctl_LogTime[log_Now_Number, 0].ForeColor = Color.Black;
            logTime[log_Now_Number] = lbl_ctl_LogTime[log_Now_Number, 0].Text = NowDate.ToString("yyyy/MM/dd HH:mm:ss");
            logInfo[log_Now_Number] = lbl_ctl_LogInfo[log_Now_Number, 0].Text = log;
            panel_LogTable_Log.Controls.Add(lbl_ctl_LogTime[log_Now_Number, 0]);
            panel_LogTable_Log.Controls.Add(lbl_ctl_LogInfo[log_Now_Number, 0]);
            lbl_ctl_LogInfo[log_Now_Number, 0].BringToFront();
            lbl_ctl_LogTime[log_Now_Number, 0].BringToFront();
            log_New_Y_Location += 20;
            panel_LogTable_Log.AutoScroll = true;
            lbl_ctl_LogTime[log_Now_Number, 0].Focus();
            panel_LogTable_Log.Focus();
            this.Refresh();
        }//メモ確定-追加
        public static string sql_Load(string sqlcode, string data)
        {

            OleDbDataReader dr = null;
            OleDbCommand cmd = null;

            using (OleDbConnection cn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    cmd = new OleDbCommand(sqlcode, cn);
                    dr = cmd.ExecuteReader();

                    dr.Read();
                    return dr[data].ToString();
                }
                catch
                {
                    //error
                    return "";
                }
                finally
                {
                    if (dr != null) dr.Close();

                }
            }
        }
        private static int sql_Load_2(string sqlcode, string data, string[] bukkomi)
        {
            int k = 0;
            OleDbDataReader dr = null;
            OleDbCommand cmd = null;
            using (OleDbConnection cn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    cmd = new OleDbCommand(sqlcode, cn);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bukkomi[k] = dr[data].ToString();

                        k++;
                    }
                    return k - 1;


                }
                catch (Exception ex)
                {
                    //error_Disp(ex.ToString());
                    return -1;
                }
                finally
                {
                    if (dr != null) dr.Close();

                }
            }

        }//sqlcodeに打ち込んだSQL文でdataの内容を返す
        private static int sql_Write(string sqlcode)
        {
            int cnt = 0;
            OleDbDataReader dr = null;
            OleDbCommand cmd = null;
            using (OleDbConnection cn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString))
            {
                try
                {
                    cmd = new OleDbCommand(sqlcode, cn);
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    cnt = cmd.ExecuteNonQuery();
                    return 0;
                }

                catch (Exception ex)
                {
                    return -1;
                    //error
                }
                finally
                {
                    if (dr != null) dr.Close();
                }
            }
        }
        private void pbarChange(string info, string blockInfo, int blockValue, int value)
        {
            lbl_Progress_Info.Text = info;
            lbl_Progress_Block_Info.Text = blockInfo;
            pbar_Percent_Block.Value = blockValue;
            pbar_Percent.Value = value;
            lbl_Progress_Percent_Block.Text = pbar_Percent_Block.Value.ToString() + "%";
            lbl_Progress_Percent.Text = pbar_Percent.Value.ToString() + "%";
            this.Refresh();
            Task.WaitAll();
        }
        private void pbarChange(int blockValue, int value)
        {
            pbar_Percent_Block.Value = blockValue;
            pbar_Percent.Value = value;
            lbl_Progress_Percent_Block.Text = pbar_Percent_Block.Value.ToString() + "%";
            lbl_Progress_Percent.Text = pbar_Percent.Value.ToString() + "%";
            this.Refresh();
            Task.WaitAll();
        }

        private void createPurchaseList()
        {
            try
            {
                try
                {

                    DateTime time = DateTime.Now;
                    DateTime time2 = time.AddDays(-7);
                    string day = time.ToString("yyyy/MM/dd");
                    short pur_threshold_num_first = 3;//ランキング用の順位MASID頭の数
                    short pur_threshold_num_last = 8;//ランキング用の順位MASID尻の数
                    int pur_threshold_num = (pur_threshold_num_last - pur_threshold_num_first) + 1;
                    string[] proid = new string[100000];
                    string[] stock = new string[100000];
                    int count_PROID = 0;//変更件数
                    int count_STOCK = 0;//変更件数
                    string[] temp = new string[256];
                    string[] temp2 = new string[256];
                    int[] pur_threshold = new int[pur_threshold_num];
                    int[] pur_threshold_2 = new int[pur_threshold_num];
                    pur_threshold[0] = 1000;
                    int purorder_num = 12;
                    int nextaddno = 0;
                    int parcent = 0;

                    //LogsAdd("AUTOMATIC  ORDERING  SYSTEM");
                    LogsAdd("自動発注処理を開始します");
                    pbarChange("自動発注処理を開始", "0/9", 50, 0);
                    Task.WaitAll();
                    //閾値読み込み
                    /*
                    Console.WriteLine("debug:dbを他アプリで開いてないのを確認後、続行時はEnter押下");
                    Console.ReadLine();
                    //*/

                    LogsAdd("[1/9]:閾値読込");
                    pbarChange("閾値読み込み", "1/9", 0, 0);
                    sql_Load_2("SELECT MASINFO1 FROM MASTER WHERE MASID>=" + pur_threshold_num_first + " AND MASID <=" + pur_threshold_num_last + "", "MASINFO1", temp);
                    sql_Load_2("SELECT MASINFO2 FROM MASTER WHERE MASID>=" + pur_threshold_num_first + " AND MASID <=" + pur_threshold_num_last + "", "MASINFO2", temp2);
                    LogsAdd("読み込み完了しました。");
                    pbarChange(40, 2);
                    LogsAdd("閾値一覧");
                    pbarChange(60, 3);
                    for (int i = 0; i <= pur_threshold_num - 1; i++)
                    {
                        this.Refresh();
                        pur_threshold[i] = int.Parse(temp[i]);
                        pur_threshold_2[i] = int.Parse(temp2[i]);
                        LogsAdd("閾値" + (i + 1).ToString() + ":" + temp[i] + "/" + temp2[i] + "  ");
                    }
                    pbarChange(100, 5);
                    //全体用閾値以下一括変更
                    LogsAdd("[2/9]:自動発注商品絞り込みを開始します");
                    pbarChange("自動発注商品の絞り込み", "2/9", 0, 5);
                    LogsAdd("在庫数がランキング外の閾値を下回っている商品を絞り込みます");
                    LogsAdd("-商品ID-                     -在庫数-");


                    count_PROID = sql_Load_2("SELECT PROID,STOCK FROM STOCK WHERE STOCK < " + pur_threshold[pur_threshold_num - 1].ToString() + " ORDER BY PROID,STOCK", "PROID", proid);
                    count_STOCK = sql_Load_2("SELECT PROID,STOCK FROM STOCK WHERE STOCK < " + pur_threshold[pur_threshold_num - 1].ToString() + " ORDER BY PROID,STOCK", "STOCK", stock);
                    pbarChange(50, 7);
                    try
                    {
                        for (int i = 0; i <= count_PROID; i++)
                        {
                            LogsAdd(proid[i] + " / " + stock[i]);
                            this.Refresh();
                        }
                    }
                    catch { }
                    finally { }
                    LogsAdd("計" + (count_PROID + 1).ToString() + "件ヒットしました");
                    pbarChange(100, 10);
                    int l = 0;
                    int j = 0;
                    int error = 0;
                    parcent = 0;
                    LogsAdd("[3/9]発注リストに追加します。");
                    pbarChange("発注リストに追加", "3/9", 0, 10);
                    try
                    {
                        while (count_PROID >= l)
                        {
                            this.Refresh();
                            error = sql_Write("INSERT INTO PURCHASE(PURID,PURDAY) VALUES ('" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "','" + day + "')");
                            parcent = (l * 100) / count_PROID;
                            if (error != 0)
                            {
                                LogsAdd("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "]:エラー");
                            }
                            else
                            {
                                LogsAdd("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "]:完了");
                            }
                            pbarChange(parcent, 10 + (parcent / 10));
                            /*ここからパーセンテージバー
                            Console.Write("[");
                            for (int i = 0; i < 100; i += 4)
                            {

                                if (parcent - i > 0)
                                {
                                    Console.Write("#");
                                }
                                else
                                {
                                    Console.Write("-");
                                }


                            }
                            Console.Write("]");
                            Console.Write(" 進行状況: " + parcent.ToString() + "%");
                            */
                            l++;
                        }

                    }
                    catch
                    {
                        LogsAdd("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                        "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。" +"ErrorCode:00001");
                    }
                    finally {
                        pbarChange(100,20);
                    }
                    l = 0;
                    j = 0;
                    error = 0;
                    this.Refresh();
                    
                    LogsAdd("[4/9]:発注明細リストに追加します。");
                    pbarChange("発注明細リストに追加", "4/9", 0, 20);
                    try
                    {
                        int k = 0;
                        while (count_PROID >= j)
                        {
                            this.Refresh();
                            k = int.Parse(sql_Load("SELECT MAX(PURDETID) AS PURDETID FROM PURCHASEDETAIL", "PURDETID"));
                            error = sql_Write("INSERT INTO PURCHASEDETAIL(PURDETID,PURID,PROID,PURPIECE) VALUES ('" + String.Format("{0:00000000}", k + 1) + "','" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (j + 1)) + "','" + proid[j] + "'," + purorder_num + ")");
                            parcent = (l * 100) / count_PROID;
                            if (error != 0)
                            {
                                LogsAdd("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "]:エラー");
                            }
                            else
                            {
                                LogsAdd("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (l + 1)) + "]:完了");
                            }
                            /*パーセンテージ
                            Console.Write("[");
                            for (int i = 0; i < 100; i += 4)
                            {

                                if (parcent - i > 0)
                                {
                                    Console.Write("#");
                                }
                                else
                                {
                                    Console.Write("-");
                                }


                            }
                            Console.Write("]");
                            Console.Write(" 進行状況: " + parcent.ToString() + "%");
                            */
                            j++;
                            k++;
                            l++;
                            pbarChange(parcent, 20 + (parcent / 10));
                        }


                    }
                    catch
                    {
                        LogsAdd("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                        "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。"+ "ErrorCode:00001");
                    }
                    finally {
                        pbarChange(100, 30);
                    }
                    l = 0;
                    j = 0;
                    error = 0;
                    LogsAdd("[5/9]:入庫確定リストに入庫予定を追加します。");
                    pbarChange("入庫予定追加", "5/9", 0, 30);
                    try
                    {
                        int k = 0;
                        while (count_PROID >= j)
                        {
                            this.Refresh();
                            k = int.Parse(sql_Load("SELECT MAX(RECID) AS RECID FROM RECEIVE", "RECID"));
                            error = sql_Write("INSERT INTO RECEIVE(RECID,PURID,RECDAY,RECDAYPLAN) VALUES ('" + String.Format("{0:0000000}", k + 1) + "','" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (j + 1)) + "',null,'" + time.ToString("yyyy/MM/dd") + "')");
                            parcent = (l * 100) / count_PROID;
                            if (error != 0)
                            {
                                LogsAdd("商品ID[" + proid[j] + "]:エラー");
                            }
                            else
                            {
                                LogsAdd("商品ID[" + proid[j] + "]:完了");
                            }
                            pbarChange(parcent, 30 + (parcent / 5));
                            /*
                            Console.Write("[");
                            for (int i = 0; i < 100; i += 4)
                            {

                                if (parcent - i > 0)
                                {
                                    Console.Write("#");
                                }
                                else
                                {
                                    Console.Write("-");
                                }


                            }
                            Console.Write("]");
                            Console.Write(" 進行状況: " + parcent.ToString() + "%");
                            */
                            j++;
                            k++;
                            l++;
                        }
                        nextaddno = j - 1;

                    }
                    catch
                    {
                        LogsAdd("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                        "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。" + "ErrorCode:00001");
                    }
                    finally {
                        pbarChange(100, 50);
                    }
                    //在庫が最低閾値以下の商品発注が完了
                    //次はランキングからproid引っ張ってきて格納
                    //それと上で一括変更したproid変数をそれぞれ比較
                    //一致するものがあったら除外して
                    //なかったら新しいproid配列に追加
                    //上の処理をもう一度繰り返して
                    //発注処理完了
                    //RECEIVEテーブルとかもろもろのPURIDは全部null非許可に変更しておく
                    string[] proid_Rankin_temp = new string[100000];
                    string[] stock_Rankin_temp = new string[100000];
                    string[] proid_Rankin = new string[100000];
                    string[] stock_Rankin = new string[100000];
                    string[] Rank_Rankin_string = new string[100000];
                    int count_PROID_Rankin = 0;//変更件数
                    int count_STOCK_Rankin = 0;//変更件数
                    int count_RANK_Rankin = 0;//変更件数
                    bool flag = false;
                    int mas = j+1;
                    //全体用閾値以下一括変更
                    //Console.WriteLine("(ランクイン商品)閾値以下の商品絞込＆変更" + System.Environment.NewLine + System.Environment.NewLine);
                    LogsAdd("[6/9]:(ランクイン商品)自動発注商品絞り込みを開始します");
                    pbarChange("ランクイン発注商品絞り込み", "6/9", 0, 50);
                    LogsAdd("在庫数がランキング外の閾値を下回っている商品を絞り込みます");
                    LogsAdd("-商品ID-                    -在庫数-");

                    //sql_Load2(%1,%2,%3)の%1に
                    //上から順番に
                    //ランキング上位10位絞り込みした
                    //1,商品コードPROID
                    //2.在庫数STOCK
                    //3.順位(%2には順位の列名)
                    //を入れる
                    //10位までを絞り込む所までがSQL文

                    //ランキング
                    string[] temp999 = new string[9999999];
                    string[] temp998 = new string[9999999];
                    string temp001 = "";
                    //8日前の年月日を取得
                    int[] temp100 = new int[3];
                    temp100[0] = int.Parse(time2.AddDays(-1).ToString("yyyy"));
                    temp100[1] = int.Parse(time2.AddDays(-1).ToString("MM"));
                    temp100[2] = int.Parse(time2.AddDays(-1).ToString("dd"));
                    pbarChange(10, 53);
                    //deal,deadayを全部上り順で取得
                    sql_Load_2("select deaday from deal order by deaday", "deaday", temp999);
                    int temp000 = sql_Load_2("select deaid from deal order by deaid", "deaid", temp998);
                    //取得した値の数だけ変数を作成
                    int[] temp101 = new int[temp000 + 1];
                    int[] temp102 = new int[temp000 + 1];
                    int[] temp103 = new int[temp000 + 1];
                    pbarChange(20, 56);
                    //時間を省略したものと年月日を分離したものを用意
                    for (int i = 0; i < temp000; i++)
                    {
                        temp999[i] = DateTime.Parse(temp999[i]).ToString("yyyy/MM/dd");
                        temp101[i] = int.Parse(DateTime.Parse(temp999[i]).ToString("yyyy"));
                        temp102[i] = int.Parse(DateTime.Parse(temp999[i]).ToString("MM"));
                        temp103[i] = int.Parse(DateTime.Parse(temp999[i]).ToString("dd"));
                    }
                    pbarChange(30, 59);
                    //7日前の一番若いdeaidを取得
                    try
                    {
                        bool loopflag2 = false;
                        for (int i = 0; loopflag2 != true; i++)
                        {
                            //日が8日前以上 もしくは 月が8日前より大きいか比較
                            if (temp103[i] >= temp100[2] || temp102[i] > temp100[1])
                            {
                                //月が8日前以上 もしくは 年が8日前より大きいか比較
                                if (temp102[i] >= temp100[1] || temp101[i] > temp100[0])
                                {
                                    //年が8日前以上か比較
                                    if (temp101[i] >= temp100[0])
                                    {
                                        temp001 = temp998[i + 1];
                                        loopflag2 = true;
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                    finally
                    {
                        pbarChange(40, 62);
                    }
                    //なんやかんやあってtemp001が7日前最小のdeaid

                    //一週間の商品とその売り上げ一覧（商品コードで並び替え）
                    string[] temp201 = new string[1000000];
                    int temp211 = 0;
                    string[] temp202 = new string[1000000];

                    temp211 = sql_Load_2("SELECT PROID,ORDPIECE FROM DETAIL WHERE PROID >= '0000047' ORDER BY PROID;", "PROID", temp201);
                    sql_Load_2("SELECT PROID,ORDPIECE FROM DETAIL WHERE PROID >= '0000047' ORDER BY PROID;", "ORDPIECE", temp202);

                    //商品ごとの売り上げにまとめる
                    string[] temp221 = new string[1000000];
                    int[] temp222 = new int[1000000];
                    int temp212 = -1;
                    string temptemptemp = "";
                    pbarChange(50, 65);
                    for (int i = 0; i < temp211; i++)
                    {
                        if (temptemptemp != temp201[i])
                        {//直前の商品コードと別の場合(新規変数にそれ追加)
                            temp212++;
                            temp221[temp212] = temptemptemp = temp201[i];
                            temp222[temp212] = int.Parse(temp202[i]);
                        }
                        else
                        {//直前の商品コードと同じ場合(既存変数に個数だけを追加)
                            temp222[temp212] += int.Parse(temp202[i]);
                        }
                    }
                    temp212++;
                    pbarChange(60, 68);
                    //完成したものを売上個数多い順に並び替える
                    string temp291 = "";
                    int temp292 = 0;

                    for (int i = 0; i < temp212 - 1; i++)
                    {
                        if (temp222[i] < temp222[i + 1])
                        {
                            temp292 = temp222[i];
                            temp291 = temp221[i];

                            temp222[i] = temp222[i + 1];
                            temp221[i] = temp221[i + 1];

                            temp222[i + 1] = temp292;
                            temp221[i + 1] = temp291;

                            i = -1;
                        }
                    }
                    pbarChange(70, 72);
                    //ランキングと比較して自動発注かけるやつをピックアップ
                    string[] temp231 = new string[100000];
                    int[] temp232 = new int[100000];
                    bool loopflag = false;
                    l = 0;//直近の個数
                    j = 0;//更新件数
                    int h = 0;//直近のランキング順位を一時格納
                    try
                    {
                        for (int i = 0; loopflag != true; i++)
                        {
                            if (temp222[i] != l)
                            {
                                switch (i)
                                {
                                    case 1 - 1:
                                        {
                                            if (temp222[i] <= pur_threshold[0])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                                h = i;
                                            }
                                            break;
                                        }
                                    case 2 - 1:
                                        if (temp222[i] != l)
                                        {//
                                            if (temp222[i] <= pur_threshold[1])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                                h = i;
                                            }
                                            else
                                            {
                                                if (temp222[i] <= pur_threshold[h])
                                                {
                                                    temp231[j] = temp221[i];
                                                    l = temp232[j] = temp222[i];
                                                    j++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    case 3 - 1:
                                        if (temp222[i] != l)
                                        {//
                                            if (temp222[i] <= pur_threshold[2])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                                h = i;
                                            }
                                            else
                                            {
                                                if (temp222[i] <= pur_threshold[h])
                                                {
                                                    temp231[j] = temp221[i];
                                                    l = temp232[j] = temp222[i];
                                                    j++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    case 4 - 1:
                                        if (temp222[i] != l)
                                        {//
                                            if (temp222[i] <= pur_threshold[3])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                                h = i;
                                            }
                                            else
                                            {
                                                if (temp222[i] <= pur_threshold[h])
                                                {
                                                    temp231[j] = temp221[i];
                                                    l = temp232[j] = temp222[i];
                                                    j++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    case 5 - 1:
                                        if (temp222[i] != l)
                                        {//
                                            if (temp222[i] <= pur_threshold[4])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                                h = 4;
                                            }
                                            else
                                            {
                                                if (temp222[i] <= pur_threshold[h])
                                                {
                                                    temp231[j] = temp221[i];
                                                    l = temp232[j] = temp222[i];
                                                    j++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    case 6 - 1:
                                        if (temp222[i] != l)
                                        {//
                                            if (temp222[i] <= pur_threshold[4])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                                h = 4;
                                            }
                                            else
                                            {
                                                if (temp222[i] <= pur_threshold[h])
                                                {
                                                    temp231[j] = temp221[i];
                                                    l = temp232[j] = temp222[i];
                                                    j++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    case 7 - 1:
                                        if (temp222[i] != l)
                                        {//
                                            if (temp222[i] <= pur_threshold[4])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                                h = 4;
                                            }
                                            else
                                            {
                                                if (temp222[i] <= pur_threshold[h])
                                                {
                                                    temp231[j] = temp221[i];
                                                    l = temp232[j] = temp222[i];
                                                    j++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    case 8 - 1:
                                        if (temp222[i] != l)
                                        {//
                                            if (temp222[i] <= pur_threshold[4])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                                h = 4;
                                            }
                                            else
                                            {
                                                if (temp222[i] <= pur_threshold[h])
                                                {
                                                    temp231[j] = temp221[i];
                                                    l = temp232[j] = temp222[i];
                                                    j++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    case 9 - 1:
                                        if (temp222[i] != l)
                                        {//
                                            if (temp222[i] <= pur_threshold[4])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                                h = 4;
                                            }
                                            else
                                            {
                                                if (temp222[i] <= pur_threshold[h])
                                                {
                                                    temp231[j] = temp221[i];
                                                    l = temp232[j] = temp222[i];
                                                    j++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    case 10 - 1:
                                        if (temp222[i] != l)
                                        {//
                                            if (temp222[i] <= pur_threshold[4])
                                            {
                                                temp231[j] = temp221[i];
                                                l = temp232[j] = temp222[i];
                                                j++;
                                                h = 4;
                                            }
                                            else
                                            {
                                                if (temp222[i] <= pur_threshold[h])
                                                {
                                                    temp231[j] = temp221[i];
                                                    l = temp232[j] = temp222[i];
                                                    j++;
                                                }
                                                else
                                                {
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        {
                                            if (temp222[i] == l)
                                            {//

                                                if (temp222[i] <= pur_threshold[h])
                                                {
                                                    temp231[j] = temp221[i];
                                                    l = temp232[j] = temp222[i];
                                                    j++;
                                                }
                                                else
                                                {
                                                    loopflag = true;
                                                    break;
                                                }
                                            }
                                        }
                                        break;
                                }

                            }
                        }
                    }
                    catch { }
                    finally {
                        pbarChange(90, 77);
                    }


                    //strSQL5 = "SELECT DETAIL.[PROID], Sum(DETAIL.[ORDPIECE]) AS ORDPIECE FROM DETAIL 'GROUP BY DETAIL.[PROID] order by Sum(DETAIL.[ORDPIECE]) desc ";
                    //10位までループ
                    //以降10位の在庫数と同じまでループ

                    for (int i = 0; i <= 1000; i++)
                    {
                        proid_Rankin[i] = temp231[i];
                        stock_Rankin[i] = temp232[i].ToString();
                    }


                    //count_PROID_Rankin = sql_Load_2("SELECT DETAIL.PROID AS PROID, Sum(DETAIL.ORDPIECE) AS SUM FROM DEAL INNER JOIN DETAIL ON DEAL.DEAID = DETAIL.DEAID WHERE(((DETAIL.DEAID) >= "+'"'+ temp001 + '"'+")) GROUP BY DETAIL.PROID ORDER BY Sum(DETAIL.ORDPIECE) DESC;", "SUM", proid_Rankin_temp);



                    //発注必要商品の表示
                    try
                    {
                        for (int i = 0; i <= count_PROID_Rankin; i++)
                        {
                            LogsAdd(proid_Rankin[i] + " / " + stock_Rankin[i]);
                        }
                    }
                    catch { }
                    finally {
                        pbarChange(100, 80);
                    }
                    LogsAdd("計" + (count_PROID_Rankin + 1).ToString() + "件ヒットしました");
                    l = 0;
                    j = 0;
                    error = 0;
                    LogsAdd("[7/9]:(ランクイン商品)発注リストに追加します。");
                    pbarChange("ランクイン発注リスト追加","7/9",0,80);
                    try
                    {
                        while (count_PROID_Rankin >= l)
                        {

                            error = sql_Write("INSERT INTO PURCHASE(PURID,PURDAY) VALUES ('" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (mas+l + 1 + nextaddno)) + "','" + day + "')");
                            parcent = (l * 100) / count_PROID;
                            /*
                            Console.Write("[");
                            for (int i = 0; i < 100; i += 4)
                            {

                                if (parcent - i > 0)
                                {
                                    Console.Write("#");
                                }
                                else
                                {
                                    Console.Write("-");
                                }


                            }
                            Console.Write("]");
                            Console.Write(" 進行状況: " + parcent.ToString() + "%");
                            */
                            if (error != 0)
                            {
                                LogsAdd("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (mas+l + 1)) + "]:エラー");
                            }
                            else
                            {
                                LogsAdd("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (mas+l + 1)) + "]:完了");
                            }
                            l++;
                            pbarChange(parcent, 80 + parcent / 20);
                        }

                    }
                    catch
                    {
                        LogsAdd("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                        "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。" +"ErrorCode:00001");
                    }
                    finally
                    {
                        /*
                        Console.CursorLeft = 0;
                        Console.Write("[");
                        for (int i = 0; i < 100; i += 4)
                        {

                            if (parcent - i > 0)
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write("#");
                            }


                        }
                        Console.Write("]");
                        Console.Write(" 進行状況: 100%");
                        */
                        pbarChange(100, 85);
                    }
                    
                    l = 0;
                    j = 0;
                    error = 0;
                    LogsAdd("[8/9]:(ランクイン商品)発注明細リストに追加します。");
                    pbarChange("ランクイン発注明細追加","8/9",0,85);
                    try
                    {
                        int k = 0;
                        while (count_PROID_Rankin >= j)
                        {
                            k = int.Parse(sql_Load("SELECT MAX(PURDETID) AS PURDETID FROM PURCHASEDETAIL", "PURDETID"));
                            error = sql_Write("INSERT INTO PURCHASEDETAIL(PURDETID,PURID,PROID,PURPIECE) VALUES ('" + String.Format("{0:00000000}", mas+k + 1) + "','" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (mas+j + 1 + nextaddno)) + "','" + proid_Rankin[j] + "'," + purorder_num + ")");
                            parcent = (l * 100) / count_PROID;

                            /*
                            Console.Write("[");
                            for (int i = 0; i < 100; i += 4)
                            {

                                if (parcent - i > 0)
                                {
                                    Console.Write("#");
                                }
                                else
                                {
                                    Console.Write("-");
                                }


                            }
                            Console.Write("]");
                            Console.Write(" 進行状況: " + parcent.ToString() + "%");
                            */
                            if (error != 0)
                            {
                                LogsAdd("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (mas+l + 1)) + "]:エラー");
                            }
                            else
                            {
                                LogsAdd("発注ID[" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (mas+l + 1)) + "]:完了");
                            }
                            l++;
                            j++;
                            k++;
                            pbarChange(parcent, 85 + parcent / 20);
                        }

                    }
                    catch
                    {
                        LogsAdd("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                        "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。" + "ErrorCode:00001");
                    }
                    finally
                    {
                        /*
                        Console.Write("[");
                        for (int i = 0; i < 100; i += 4)
                        {

                            if (parcent - i > 0)
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write("#");
                            }


                        }
                        Console.Write("]");
                        Console.Write(" 進行状況: 100%");
                        */
                        pbarChange(100, 90);
                    }
                    l = 0;
                    j = 0;
                    error = 0;
                    LogsAdd("[9/9]:(ランクイン商品)入庫確定リストに入庫予定を追加します。");
                    pbarChange("ランクイン入庫予定追加", "9/9", 0, 90);
                    try
                    {
                        int k = 0;
                        while (count_PROID_Rankin >= j)
                        {
                            k = int.Parse(sql_Load("SELECT MAX(RECID) AS RECID FROM RECEIVE", "RECID"));
                            error += sql_Write("INSERT INTO RECEIVE(RECID,PURID,RECDAY,RECDAYPLAN) VALUES ('" + String.Format("{0:0000000}", mas+k + 1) + "','" + time.ToString("yyyyMMdd") + String.Format("{0:000}", (j + 1 + nextaddno+mas)) + "',null,'" + time.ToString("yyyy/MM/dd") + "')");
                            parcent = (l * 100) / count_PROID;
                            if (error != 0)
                            {
                                LogsAdd("商品ID[" + proid[j] + "]:エラー");
                            }
                            else
                            {
                                LogsAdd("商品ID[" + proid[j] + "]:完了");
                            }
                            pbarChange(parcent, 90 + parcent / 10);
                            /*
                            Console.Write("[");
                            for (int i = 0; i < 100; i += 4)
                            {

                                if (parcent - i > 0)
                                {
                                    Console.Write("#");
                                }
                                else
                                {
                                    Console.Write("-");
                                }


                            }
                            Console.Write("]");
                            Console.Write(" 進行状況: " + parcent.ToString() + "%");
                            */
                            l++;
                            j++;
                            k++;
                        }

                    }
                    catch
                    {
                        LogsAdd("エラーが発生しました。すでに発注リスト作成が終わっていないか確認してください。" +
                                        "発注リスト作成が完了していない場合はこちらのエラー番号をメモしてお問い合わせください。"  + "ErrorCode:00001");
                    }
                    finally
                    {
                        /*
                        Console.CursorLeft = 0;
                        Console.Write("[");
                        for (int i = 0; i < 100; i += 4)
                        {

                            if (parcent - i > 0)
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write("#");
                            }


                        }
                        Console.Write("]");
                        Console.Write(" 進行状況: 100%");
                        */
                        pbarChange(100, 99);
                    }


                    System.Threading.Thread.Sleep(250);
                    LogsAdd("自動発注処理が完了しました。");
                    pbarChange("", "Completed.", 100, 100);
                    sql_Write("UPDATE MASTER SET MASINFO1='" + NowDate.ToString("yyyy/MM/dd") + "' WHERE MASID=9");
                    // ↓コメント化で画面が閉じて自動でreturn0を返す
                    //　↖の「//*」を「/*」みたいにスラッシュ一個つけたり
                    //   消したりするだけでコメント化するかどうか変更できるよ
                    // Console.ReadKey();
                    //
                }
                catch
                {
                }
                finally
                {

                }
            }
            catch
            {

            }

            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//自動発注アプリ強制終了

        
        private void btn_Save_Click(object sender, EventArgs e)
        {
            logSave();
        }

        private void autoPurchase_Load(object sender, EventArgs e)
        {
            Timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;
            createPurchaseList();
            lbl_SysDate.Text = "ログファイル保存中..";
            this.Refresh();
            logSave();
            LogsAdd("ログファイル保存完了");
            lbl_Progress_Block_Info.Text = "処理が完了しました。およそ10秒経つか右下閉じるボタンでメニュー画面に戻ります。";
            closeTimer.Start();
            btn_Close.Enabled = true;
            button1.Enabled = true;
            lbl_SysDate.Text = "完了日時:" + NowDate.ToString("yyyy/MM/dd hh:MM:ss");
        }

        private void btn_EmergencyStop_Click(object sender, EventArgs e)
        {
            lbl_SysDate.Text = "ログファイル保存中..";
            this.Refresh();
            logSave();
            lbl_SysDate.Text ="ログファイル保存完了";
            this.Dispose();
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql_Write("delete from RECEIVE where recdayplan like '"+NowDate.ToString("yyyy/MM/dd")+"%'");
            sql_Write("delete from PURCHASEDETAIL where purid like '"+NowDate.ToString("yyyyMMdd")+"%'");
            sql_Write("delete from PURCHASE where purid like '" + NowDate.ToString("yyyyMMdd") + "%'");
            MessageBox.Show("本日実行分の削除が完了しました。正常に動作します。" + Environment.NewLine + "[デモ用機能]");
        }

        private void panel_All_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
