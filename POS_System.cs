using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;
using Microsoft.VisualBasic;

namespace POS_System
{

    public partial class Form1 : Form
    {

        WMPLib.WindowsMediaPlayer mediaPlayer = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer pipipi = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer backgroundMediaPlayer = new WMPLib.WindowsMediaPlayer();
        private string strCn = ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        //private OleDbConnection cn;
        string strSQL = "";
        OleDbCommand cmd = null;
        OleDbDataReader dr = null;
        // OleDbCommand cmd2 = null;
        // OleDbDataReader dr2 = null;


        private Label[,] dispLabel = new Label[1000, 5];//dispLabel(上で数指定して宣言しないと毎回初期化されてNullる)
        private NumericUpDown[,] dispNumericUpDown = new NumericUpDown[1000, 1];//dispNumericUpDown(上で数指定して宣言しないと毎回初期化されてNullる)
        //private Label[,] dispPurchaseLabel = new Label[100, 2];//dispPurchaseLabel(上で数指定して宣言しないと毎回初期化されてNullる)
        //private Button [,] dispPurchaseButton = new Button [100, 1];//dispPurchaseButton(上で数指定して宣言しないと毎回初期化されてNullる)
        private int[] labels_XLocation = { 8, 114, 344, 694, 1068 };//各labelのX座標。ぶっちゃけもっと上階層で宣言していいけど見た目的にわかんなくなるからマスターアップまで置いとく
        private int[] numericUpDowns_XLocation = { 908 };//各labelのX座標。レジ
        private int productLoop = 0;//パネル1内の列表示回数
        private int changeY = 0;//Panelで次にlabelとか出すときのY座標
        //private int changeYpur = 0;//Panelで次にlabelとか出すときのY座標


        private string tax;//税率
        private string memberNumber = "";//会員番号
        private int memberPoint = 0;//会員ポイント
        private string inputNumber = "";//直前にテキストボックスに入っていた番号
        private int[] dispItemsPrice = new int[1000];//商品価格
        private int[] dispItemsTotalPrice = new int[1000];//商品価格*商品点数
        private int dispItemsTotalPiece = 0;//商品合計点数
        private int dispTotalPrice = 0;//商品小計
        private int dispTotalPricePlusTax = 0;//税込合計
        private int calc_Balance = 0;//必要入金残
        private int present_MemberPoint = 0;//獲得会員ポイント
        private int next_MemberPoint = 0;//決済完了時ポイント
        private int nextDealNo = 0;//会計時に紐づけられる購入番号(受注番号)
        private int change = 0;//お釣り
        private string[] purchaseNumber = new string[3];//発注番号
        private int purchaseloopnextflag = 1;//割り込み発注番号格納
        private int pointRate = 100;//1pt獲得レート(小計金額/pointRate)
        private int textboxfocusflag = 0;
        private int unicornflag = 0;
        private bool debug = false;

        private string paymented_SE = "SE\\madomagibb_getmagikarush.wav";//決済完了時SE
        private string enterLoad_SE = "SE\\Cash_Register-Beep01-1.mp3";//バーコード読み取り時SE
        private string numLoad_SE = "SE\\Cell_Phone-Beep01-1.mp3";//数字読み取り時SE
        private string seven = "SE\\seven.mp3";//例のアレ
        private string start_SE ="" ;//"SE\\UNICORN-CUTVer.wav";//例のアレ
        private Boolean loadflag = true;
        private Boolean backgroundmusicflag = false;
        OpenFileDialog ofd = new OpenFileDialog();




        public Form1()
        {
            InitializeComponent();
        }
        //----------------

        private string sql_Load(string sqlcode, string data)
        {

            strSQL = sqlcode;
            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    cmd = new OleDbCommand(strSQL, cn);

                    dr = cmd.ExecuteReader();
                    dr.Read();
                    return dr[data].ToString();
                }
                catch (Exception ex)
                {
                    //error_Disp(ex.ToString());
                    return "";
                }
                finally
                {
                    if (dr != null) dr.Close();

                }
            }

        }//sqlcodeに打ち込んだSQL文でdataの内容を返す
        private int sql_Load_2(string sqlcode, string data, string[] bukkomi)
        {
            int k = 0;
            strSQL = sqlcode;
            using (OleDbConnection cn = new OleDbConnection(strCn))
            {

                try
                {

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    cmd = new OleDbCommand(strSQL, cn);

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

        private void sql_Write(string sqlcode)
        {
            strSQL = sqlcode;
            int cnt = 0;

            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    cmd = new OleDbCommand(strSQL, cn);
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    cnt = cmd.ExecuteNonQuery();
                    label59.Text = ("登録完了:" + cnt.ToString() + "件更新されました");
                }

                catch (Exception ex)
                {
                    error_Disp(ex.ToString());
                }
                finally
                {
                    if (dr != null) dr.Close();

                }
            }
        }//sqlcodeに打ち込んだSQL文でテーブルに書き込む

        private void dealDataWrite()
        {
            DateTime sysdate = DateTime.Now;//変数sysdateに時刻を取得
            //ifで会員番号あるパターンとないパターンで分ける
            if (memberNumber == "")
            {
                sql_Write("INSERT INTO DEAL(DEAID,DEADAY,MEMID) VALUES('" + label58.Text + "', '" + sysdate.ToString("yyyy/MM/dd") + "','000000000');");
                //        sql_Write("UPDATE DEAL SET MEMID = null WHERE DEAID ='" + label58.Text + "'");

            }
            else
            {
                sql_Write("INSERT INTO DEAL(DEAID,DEADAY,MEMID) VALUES('" + label58.Text + "', '" + sysdate.ToString("yyyy/MM/dd") + "','" + memberNumber + "');");
                //会員ポイントもついでにアプデ
                sql_Write("UPDATE MEMBER SET MEMPOINT =" + next_MemberPoint + " WHERE MEMID='" + memberNumber + "';");
            }
            //あるパターン(一部入力)
            //sql_Write("INSERT INTO DEAL(DEAID,DEADAY,MEMID) VALUES('" + ::::::::::::: + "', '" + sysdate.ToString("yyyy/MM/dd") + "','" + ::::::::::::: + "');");

            //ないパターン(一部入力)
            //sql_Write("INSERT INTO DEAL(DEAID,DEADAY) VALUES('" + ::::::::::::: + "', '" + sysdate.ToString("yyyy/MM/dd") + "');");


        }//決済完了時にDEAL更新するやつ
        string te;
        private void detailDataWrite()
        {
            //sql_Write("INSERT INTO DETAIL(DEADETID,DEAID,PROID,ORDPIECE) VALUES('".........
            //DEADETIDはDEAID+連番3桁(labelの001とか002とか)を連結してやればいいだけ
            //注意点としてはNumericUpDownの値(Value)はToString()かけないとダメ
            //whileでproductloop有効活用してぶん回せばokな気がする
            //在庫もついでに減らします
            int i = 0;
            int stockpiece = 0;
            while (productLoop > i)
            {
                te = "INSERT INTO DETAIL(DEADETID, DEAID, PROID, ORDPIECE) VALUES('"
                    + label58.Text.ToString() + dispLabel[i, 0].Text.ToString() +
                    "','" + label58.Text.ToString() +
                    "','" + dispLabel[i, 1].Text.ToString() +
                    "'," + dispNumericUpDown[i, 0].Value.ToString() + ");";
                sql_Write("INSERT INTO DETAIL(DEADETID, DEAID, PROID, ORDPIECE) VALUES('"
                    + label58.Text.ToString() + dispLabel[i, 0].Text.ToString() +
                    "','" + label58.Text.ToString() +
                    "','" + dispLabel[i, 1].Text.ToString() +
                    "'," + dispNumericUpDown[i, 0].Value.ToString() + ");");

                stockpiece = int.Parse(sql_Load("SELECT STOCK FROM STOCK WHERE PROID = '" + dispLabel[i, 1].Text.ToString() + "';", "STOCK")) - int.Parse(dispNumericUpDown[i, 0].Value.ToString());

                if (stockpiece >= 0)
                {
                    sql_Write("UPDATE STOCK SET STOCK =" + stockpiece + " WHERE PROID = '" + dispLabel[i, 1].Text.ToString() + "'");
                }
                else
                {
                    sql_Write("UPDATE STOCK SET STOCK = 0 WHERE PROID = '" + dispLabel[i, 1].Text.ToString() + "'");

                }

                i++;
            }
        }//決済完了時にDETAIL更新するやつ

        private void error_Disp(string ex)
        {
            MessageBox.Show(ex.ToString(),
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            //*/    
        }//error出すやつ

        //----------------

        private int selectBranch(string M)
        {

            inputNumber = M;
            int branchTemp = -1;//読込数値の桁数でどこに飛んだかメモっとくやつ
            int len; //読込数値の桁数をぶっこんどくやつ
            try
            {
                len = M.Length; //桁数を求めlenに格納

                switch (len)
                {
                    case 0:
                        {
                            break;
                        }
                    case 7://DEAL-購入(追加実装の可能性あり)
                        {
                            branchTemp = -1;
                            break;
                        }
                    case 9://MEMBER-会員(2を返す)//気持ち悪いから時間あったらあとで治す
                        {
                            //会員確認済みの場合の分岐（上書き確認）を実装
                            if (memberNumber == M
                                || memberNumber != ""
                                && MessageBox.Show("会員情報は既に入力されています。会員スキャンを解除し置き換えますか？", "確認", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                            {
                                label59.Text = "会員番号取得は重複していたためキャンセルされました。";
                                textBox3.Text = "";
                                break;
                            }

                            if (sql_Load("SELECT MEMID FROM MEMBER WHERE MEMID ='" + M + "';", "MEMID") != "")
                            {
                                memberNumber = label26.Text = sql_Load("SELECT MEMID FROM MEMBER WHERE MEMID ='" + M + "';", "MEMID");//会員番号を取得、表示
                                memberPoint = int.Parse(sql_Load("SELECT MEMPOINT FROM MEMBER WHERE MEMID ='" + M + "';", "MEMPOINT"));//会員ポイントを取得
                                label28.Text = String.Format("{0:#,0} P", memberPoint);//会員ポイントを表示
                                label59.Text = "会員取得成功:" + label26.Text;
                                point_calc();
                            }
                            else
                            {
                                memberNumber = label26.Text = "";
                                label28.Text = "0 P";
                                label59.Text = "正しい会員番号を取得してください。会員情報を再度スキャンしてください。";

                            }

                            textBox3.Text = "";
                            break;

                        }
                    case 11://PURCHASE-発注(3を返す)
                        {
                            branchTemp = 3;
                            if (sql_Load("SELECT RECDAY FROM RECEIVE WHERE PURID='" + M + "';", "RECDAY") == "")
                            {
                                if (sql_Load("SELECT PURID FROM PURCHASE WHERE PURID ='" + M + "';", "PURID") != "")
                                {
                                    if (purchaseloopnextflag == 1)//追加していた入庫番号を消去したときに割り込む
                                    {
                                        purchaseloopnextflag = -1;
                                        for (int i = 2; i >= 0; i--)
                                        {
                                            if (purchaseNumber[i] == "")
                                                purchaseloopnextflag = i;
                                        }
                                        if (purchaseloopnextflag != -1)
                                        {
                                            if (purchaseNumber[0] != M && purchaseNumber[1] != M && purchaseNumber[2] != M)
                                            {
                                                purchaseNumber[purchaseloopnextflag] = M;

                                                label56.Text = purchaseNumber[0];
                                                label11.Text = purchaseNumber[1];
                                                label13.Text = purchaseNumber[2];

                                                purchaseloopnextflag = 0;
                                                for (int i = 2; i >= 0; i--)
                                                {
                                                    if (purchaseNumber[i] == "")
                                                        purchaseloopnextflag = 1;
                                                }
                                                label59.Text = "発注番号取得成功 : " + M.ToString() + "";
                                            }
                                            else
                                            {
                                                for (int i = 2; i >= 0; i--)
                                                {
                                                    if (purchaseNumber[i] == "")
                                                        purchaseloopnextflag = 1;
                                                }
                                                MessageBox.Show("この入庫番号はすでに入力されています。");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("一度入庫を確定またはキャンセルして再度発注番号を入力してください。");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("一度に入庫処理をかけられるのは3つまでです。" + System.Environment.NewLine + "一度入庫を確定して再度発注番号を入力してください。");
                                    }


                                }
                                else
                                {
                                    label59.Text = "正しい発注番号を取得してください";
                                }
                            }
                            else
                            {
                                MessageBox.Show("発注番号 " + M + " の入庫は" + System.Environment.NewLine + "確定されています。");
                            }
                            textBox3.Text = "";
                            break;

                        }
                    case 13://PRODUCT-商品(0を返す)
                        {
                            branchTemp = 0;
                            label59.Text = "2つ目のバーコードをスキャンしてください";
                            textBox3.Text = M;
                            break;
                        }
                    case 26://PRODUCT-商品(26桁全入力)(1を返す)
                        {
                            branchTemp = 1;
                            if (sql_Load("SELECT PROID FROM PRODUCT WHERE PROID ='" + M + "';", "PROID") != "")
                            {
                                if (productLoop != 0 && M == dispLabel[productLoop - 1, 1].Text.ToString() && dispNumericUpDown[productLoop - 1, 0].Value < 100)//直前に吸ったやつと同じかどうか
                                {
                                    dispNumericUpDown[productLoop - 1, 0].Value += 1;//NumericUpDown++
                                    label22.Text = String.Format("{0:#,0} 個", dispItemsTotalPiece);//商品合計個数の表示
                                    dispTotalPrice += dispItemsPrice[productLoop - 1];//商品合計金額を計算
                                    label32.Text = label23.Text = String.Format("\\ {0:#,0}", dispTotalPrice);//商品合計の小計の表示
                                    dispTotalPricePlusTax = ((dispTotalPrice * (int.Parse(tax) + 100)) / 100);//税込合計の計算
                                    label34.Text = String.Format("\\ {0:#,0}", dispTotalPricePlusTax);//税込合計の表示

                                    calc_Balance = 0;
                                    if (textBox1.Text != "") { calc_Balance -= int.Parse(textBox1.Text); }
                                    if (textBox2.Text != "") { calc_Balance -= int.Parse(textBox2.Text); }
                                    calc_Balance += dispTotalPricePlusTax;
                                    label49.Text = String.Format("\\ {0:#,0}", calc_Balance);

                                    label59.Text = "商品取得成功 : " + dispLabel[productLoop - 1, 2].Text + "(" + dispLabel[productLoop - 1, 3].Text + ")";
                                }
                                else
                                {
                                    addProductDisp();//panelにlabelとか追加するメソッド

                                    //自動生成ラベルとか、ぬーめりっくあっぷだうんに適切な数値や情報を埋め込んでいく
                                    dispItemsPrice[productLoop] = int.Parse(sql_Load("SELECT PROPRICE FROM PRODUCT WHERE PROID ='" + M + "';", "PROPRICE"));
                                    dispLabel[productLoop, 0].Text = String.Format("{0:000}", productLoop + 1);
                                    dispLabel[productLoop, 1].Text = sql_Load("SELECT PROID FROM PRODUCT WHERE PROID ='" + M + "';", "PROID");
                                    dispLabel[productLoop, 2].Text = sql_Load("SELECT PRONAME FROM PRODUCT WHERE PROID ='" + M + "';", "PRONAME");
                                    dispLabel[productLoop, 3].Text = String.Format("\\ {0:#,0}", dispItemsPrice[productLoop]);

                                    dispNumericUpDown[productLoop, 0].Value = 1;//NumericUpDownに初期値の1を代入
                                    dispLabel[productLoop, 4].Text = String.Format("\\ {0:#,0}", dispItemsPrice[productLoop]);//商品*個数の単品小計

                                    dispItemsTotalPiece++;//商品合計個数を1追加

                                    label22.Text = String.Format("{0:#,0} 個", dispItemsTotalPiece);//商品合計個数の表示
                                    dispTotalPrice += dispItemsPrice[productLoop];//商品合計金額を計算
                                    label32.Text = label23.Text = String.Format("\\ {0:#,0}", dispTotalPrice);//商品合計の小計の表示
                                    dispTotalPricePlusTax = ((dispTotalPrice * (int.Parse(tax) + 100)) / 100);//税込合計の計算
                                    label34.Text = String.Format("\\ {0:#,0}", dispTotalPricePlusTax);//税込合計の表示

                                    calc_Balance = 0;
                                    if (textBox1.Text != "") { calc_Balance -= int.Parse(textBox1.Text); }
                                    if (textBox2.Text != "") { calc_Balance -= int.Parse(textBox2.Text); }
                                    calc_Balance += dispTotalPricePlusTax;
                                    label49.Text = String.Format("\\ {0:#,0}", calc_Balance);

                                    label59.Text = "商品取得成功 : " + dispLabel[productLoop, 2].Text + "(" + dispLabel[productLoop, 3].Text + ")";
                                    productLoop++;
                                }
                            }
                            else
                            {
                                label59.Text = "正しい商品番号を取得してください";
                            }
                            textBox3.Text = "";
                            break;
                        }
                    case 5://なんか隠しコマンド立てるやつ
                        {
                            branchTemp = 1024;
                            switch (int.Parse(M))
                            {

                                case 77777://
                                    {
                                        this.TopMost = false;
                                        if (memberNumber != "")
                                        {
                                            try
                                            {
                                                sql_Write("UPDATE MEMBER SET MEMPOINT =" + int.Parse(Interaction.InputBox("変更後のポイントを入力してください。(-32768～32767)")) + " WHERE MEMID='" + memberNumber + "';");
                                                label59.Text = "Command<77777>:ポイント変更が実行されました。00000で会計取消を実行してください。";
                                            }
                                            catch
                                            {
                                                label59.Text = "Command<77777>:ポイント変更エラーです。数値を確認の上もう一度やり直してください。";
                                            }
                                            finally
                                            {

                                            }
                                        }
                                        this.TopMost = true;
                                        mediaPlayer.URL = seven;
                                        mediaPlayer.controls.play();
                                        textBox3.Text = "";
                                        break;
                                    }
                                case 00774://
                                    {
                                        if (memberNumber != "")
                                        {
                                            sql_Write("UPDATE MEMBER SET MEMPOINT =" + 0 + " WHERE MEMID='" + memberNumber + "';");
                                            label59.Text = "Command<00774>:ポイント消去が実行されました。00000で会計取消を実行してください。";
                                        }
                                        textBox3.Text = "";
                                        break;
                                    }

                                case 00000://強制的にpaymentCompleted処理をかける(事実上の一括取消)
                                    {
                                        loadflag = true;//決済完了音回避
                                        paymentCompleted();
                                        label59.Text = "Command<00000>:会計一括取消が実行されました。";
                                        textBox3.Text = "";
                                        break;
                                    }
                                case 88888://
                                    {
                                        textBox2.Focus();
                                        label59.Text = "Command<99999>:決済処理へ移行します。";
                                        textBox3.Text = "";
                                        break;
                                    }
                                case 99999:
                                    {
                                        this.Hide();
                                        break;
                                    }
                                case 12345:
                                    {
                                        if (backgroundmusicflag == false)
                                        {
                                            ofd.FileName = "";
                                            ofd.InitialDirectory = "";
                                            ofd.Filter = "音楽ファイル(*.mp3;*.wav)|*.mp3;*.wav";
                                            ofd.FilterIndex = 1;
                                            ofd.Title = "BGM再生-音楽ファイルを選択してください(ファイル名に直リンク打ち込んでもおｋ)";
                                            ofd.RestoreDirectory = true;
                                            if (ofd.ShowDialog() == DialogResult.OK)
                                            {
                                                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                                                backgroundMediaPlayer.settings.setMode("loop", true);
                                                backgroundMediaPlayer.URL = ofd.FileName;
                                                backgroundMediaPlayer.controls.play();
                                                backgroundmusicflag = true;
                                                label59.Text = "Command<12345>:BGMを再生しました。停止する場合は再度12345を入力してください。";
                                            }
                                        }
                                        else
                                        {
                                            backgroundMediaPlayer.settings.setMode("loop", false);
                                            backgroundMediaPlayer.controls.stop();
                                            backgroundmusicflag = false;
                                            label59.Text = "Command<12345>:BGMを停止しました。";
                                        }
                                        textBox3.Text = "";
                                        break;
                                    }

                                case 00001:
                                    {
                                        mediaPlayer.URL = paymented_SE;
                                        mediaPlayer.controls.play();
                                        textBox3.Text = "";
                                        break;
                                    }
                                case 11111:
                                    {
                                        if (this.TopMost == false)
                                        {
                                            this.TopMost = true;
                                            label59.Text = "最前面に設定しました。";
                                        }
                                        else
                                        {
                                            this.TopMost = false;
                                            label59.Text = "最前面設定を解除しました。";
                                        }
                                        textboxfocusflag = 0;
                                        textBox3.Text = "";
                                        break;
                                    }
                                case 32767:
                                    {
                                        if (textBox1.Text == "") { textBox1.Text = "0"; }
                                        if (textBox2.Text == "") { textBox2.Text = "0"; }
                                        dealDataWrite();
                                        detailDataWrite();
                                        paymentCompleted();
                                        label45.Text = String.Format("\\ {0:#,0}", change);
                                        change = 0;
                                        label59.Text = "Command<32767>:強制決済 ";
                                        label59.Text += "決済完了 (お釣り : " + label45.Text + " )";
                                        textBox3.Text = "";
                                        break;
                                    }

                                case 66666:
                                    {
                                        autopurchase_at_ranking.autorun.Run();
                                        break;
                                    }

                                case 54321:
                                    {
                                        menu.JukeBox jukebox = new menu.JukeBox();
                                        jukebox.Show();
                                        this.Dispose();
                                        break;
                                    }

                                default:
                                    MessageBox.Show("指定された数値は正しく認識されませんでした");
                                    textBox3.Text = "";
                                    break;
                            }
                            break;
                        }
                    default://当てはまらないとき(エラー -1を返す)
                        {
                            branchTemp = -1;
                            MessageBox.Show("指定された数値は正しく認識されませんでした。桁数を確認してください。");
                            textBox3.Text = "";
                            break;
                        }
                }

            }
            finally
            {

            }
            return branchTemp;
        }//バーコードリーダーとかで打った桁数認識させて実際いろいろやるやつ


        private void addProductDisp()//panelにlabelとか追加するやーつ(999まで)
        {

            if (productLoop < 999)
            {

                this.label8.Focus();//panelの(X:0,Y:0)に配置してるこいつに一旦スクロールバー移動して描画バグ的なやつを避ける。コメントにして動かしたら意味わかるかも

                int X_LabelsNumber = 5;//X座標(一列)のLabelの数
                int X_NumericUpDownsNumber = 1;// X座標(一列)のNumericUpDownの数
                int changeYTemp = changeY;//addLabels/addNumericUpDowns共にchangeYを上書きする仕様だから元の数値を退避させておく
                changeY = addLabels(1, X_LabelsNumber, changeY, 0, labels_XLocation, this.dispLabel, productLoop, "dispLabel", "MS UI Gothic", 12F);//labelを1行生成して次回Y座標は変更しない
                changeY = addNumericUpDowns(1, X_NumericUpDownsNumber, changeY, 39, numericUpDowns_XLocation, this.dispNumericUpDown, productLoop, "dispNumericUpDown", "MS UI Gothic", 12F);//NumericUpDownを1行生成して次回Y座標を変更

                for (int i = 0; i != X_LabelsNumber; i++)
                {
                    this.panel1.Controls.Add(dispLabel[productLoop, i]);
                    dispLabel[productLoop, i].BringToFront();
                }//作ったlabelをpanelに表示
                for (int i = 0; i != X_NumericUpDownsNumber; i++)
                {
                    this.panel1.Controls.Add(dispNumericUpDown[productLoop, i]);
                    dispNumericUpDown[productLoop, i].BringToFront();
                }//作ったNumericUpDownをpanelに表示
                this.dispNumericUpDown[productLoop, X_NumericUpDownsNumber - 1].Focus();
                this.textBox3.Focus();
            }//ほぼこっち

            else
            {
                MessageBox.Show("同時会計できる最大商品数を超過しています。");
            }//商品種合計が999以上の時
            //*/
        }

        //↓作成する行数,作成する列数,生成する行数の初期座標Y,生成する行数の間隔[ない場合は0],生成する列数の座標(個数分),Labelの変数名,label[YYY,0]のY部初期値(連番),labelのName,フォント名,フォントサイズ
        //最後に生成したもののY座標を返す
        //おーばーろーどでいろいろ仕様豊富にしても。。。
        //正直速度ぶっ飛ばしで作ったから改善の余地はあちこちにあるけどまぁ動く。
        private int addLabels(int itemNumY, int itemNumX, int locationY, int locationYAdd, int[] locationX, Label[,] labels, int defaultItemNumberY, string labelsName, string font, Single fontSize)
        {
            int nowLocationY = locationY;
            int nowItemNumberY = defaultItemNumberY;
            for (int loopY = 0; loopY != itemNumY; loopY++)
            {
                for (int loopX = 0; loopX != itemNumX; loopX++)
                {
                    labels[nowItemNumberY, loopX] = new Label();
                    labels[nowItemNumberY, loopX].Name = labelsName + loopY.ToString() + loopX.ToString();
                    labels[nowItemNumberY, loopX].Text = labelsName + loopY.ToString() + loopX.ToString();
                    labels[nowItemNumberY, loopX].Font = new System.Drawing.Font(font, fontSize);
                    labels[nowItemNumberY, loopX].Location = new System.Drawing.Point(locationX[loopX], nowLocationY);
                    labels[nowItemNumberY, loopX].AutoSize = true;
                }
                nowLocationY += locationYAdd;
                nowItemNumberY++;
            }
            return nowLocationY;

        }//label生成するやーつ

        //addLabelsのNumericUpDown版
        private int addNumericUpDowns(int itemNumY, int itemNumX, int locationY, int locationYAdd, int[] locationX, NumericUpDown[,] NumericUpDowns, int defaultItemNumberY, string numericUpDownsName, string font, Single fontSize)
        {
            int nowLocationY = locationY;
            int nowItemNumberY = defaultItemNumberY;
            for (int loopY = 0; loopY != itemNumY; loopY++)
            {
                for (int loopX = 0; loopX != itemNumX; loopX++)
                {
                    NumericUpDowns[nowItemNumberY, loopX] = new NumericUpDown();
                    NumericUpDowns[nowItemNumberY, loopX].Name = numericUpDownsName + loopY.ToString() + loopX.ToString();
                    NumericUpDowns[nowItemNumberY, loopX].Value = 1;
                    NumericUpDowns[nowItemNumberY, loopX].Font = new System.Drawing.Font(font, fontSize);
                    NumericUpDowns[nowItemNumberY, loopX].Location = new System.Drawing.Point(locationX[loopX], nowLocationY);
                    NumericUpDowns[nowItemNumberY, loopX].ValueChanged += new System.EventHandler(this.productNumericUpDown_ValueChanged);
                }
                nowLocationY += locationYAdd;
                nowItemNumberY++;
            }
            return nowLocationY;

        }//numericupdown生成するやーつ

        //----------------

        private void paymentCompleted()//全決済処理完了したときにやるやつ(部分的に初期化する)
        {
            //*
            int resetloop = 0;
            while (resetloop != productLoop)
            {

                for (int loopX = 0; loopX != 5; loopX++)
                {
                    Control control = dispLabel[resetloop, loopX];
                    this.Controls.Remove(control);
                    control.Dispose();
                }
                for (int loopX = 0; loopX != 1; loopX++)
                {
                    Control control = dispNumericUpDown[resetloop, loopX];
                    this.Controls.Remove(control);
                    control.Dispose();
                }

                resetloop++;
            }//labelとか消す

            if (textBox1.Text != "") { change += int.Parse(textBox1.Text); }
            if (textBox2.Text != "") { change += int.Parse(textBox2.Text); }
            change -= dispTotalPricePlusTax;
            //label45.Text = String.Format($"\\ {change}");
            label49.Text = " \\ 0";


            memberNumber = "";//会員番号
            memberPoint = 0;//会員ポイント
            textboxfocusflag = 0;//会計移行フラグ
            label26.Text = "";//会員番号ラベル
            label28.Text = "0 P";//会員ポイントラベル
            inputNumber = "";//テキストボックスに直前に入力されていた番号

            try
            {
                nextDealNo = int.Parse(sql_Load("SELECT MAX(DEAID) AS DEAID FROM DEAL;", "DEAID")) + 1;//購入No再取得
            }
            catch
            {
                nextDealNo = 0;
            }
            label58.Text = String.Format("{0:00000000}", nextDealNo);//購入No表示
            productLoop = 0;//パネル1内の列表示回数
            changeY = 0;//Panelで次にlabelとか出すときのY座標
            dispItemsTotalPiece = 0;//商品合計点数
            dispTotalPrice = 0;//商品小計
            dispTotalPricePlusTax = 0;//税込合計
            nextDealNo = 0;//会計時に紐づけられる購入番号(受注番号)
            label22.Text = "0 個";
            label23.Text = label32.Text = label34.Text = "\\ 0";
            textBox1.Text = textBox2.Text = "";
            calc_Balance = 0;
            if (textBox1.Text != "") { calc_Balance -= int.Parse(textBox1.Text); }
            if (textBox2.Text != "") { calc_Balance -= int.Parse(textBox2.Text); }
            calc_Balance += dispTotalPricePlusTax;
            present_MemberPoint = 0;//獲得会員ポイント
            label37.Text = label39.Text = "0 P";//獲得会員ポイント表示
            purchaseloopnextflag = 1;//発注番号
            label56.Text = label11.Text = label13.Text = "";
            purchaseNumber[0] = purchaseNumber[1] = purchaseNumber[2] = "";

            if (loadflag == true)
            {
                //mediaPlayer.URL = "SE\\UNICORN-CUTVer.wav";
                //mediaPlayer.controls.stop();
                loadflag = false;
            }
            else
            {
                mediaPlayer.URL = paymented_SE;
                mediaPlayer.controls.play();
                paymented_SE = "SE\\madomagibb_getmagikarush.wav";//決済完了時SE
                enterLoad_SE = "SE\\Cash_Register-Beep01-1.mp3";//バーコード読み取り時SE
                numLoad_SE = "SE\\Cell_Phone-Beep01-1.mp3";//数字読み取り時SE
            }



            //*
            label29.Text = label30.Text = label31.Text = label43.Text = label42.Text = "";//ミニゲーム実装時ポイント表示用
            label36.Text = "決済後ポイント残高:";
            textBox3.Focus();
            //*/
        }

        //-----------------------------------------------------

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }//使わないと思われ

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime systime = DateTime.Now;
            if (label3.Text != systime.ToString("yyyy年MM月dd日 HH:mm:ss"))
            {
                label3.Text = systime.ToString("yyyy年MM月dd日 HH:mm:ss");
            }


        }//システム時刻

        private void Form1_Load(object sender, EventArgs e)
        {
            if (debug == true)
            {
                paymented_SE = "";
                start_SE = "";
            }
            mediaPlayer.URL = start_SE;
            //label60.Text = "DebugMode";
            //時刻初期化
            loadflag = true;
            label3.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");

            //税率初期化
            try
            {
                tax = sql_Load("SELECT MASINFO1 FROM MASTER WHERE MASID=1", "MASINFO1");
                label24.Text = tax + " %";

            }
            catch (Exception ex)
            {
                error_Disp(ex.ToString());
            }
            pipipi.URL = enterLoad_SE;
            pipipi.controls.stop();
            paymentCompleted();
            timer2.Start();
            this.TopMost = false;
            //button6.Dispose();
            //下記参照コード




        }//初期化用

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Back)//BackSpace時の処理
            {
                textboxfocusflag = 0;
            }
            else
            if (e.KeyChar == (char)Keys.Enter)//Enter時の処理
            {
                textboxfocusflag++;
                if (textboxfocusflag > 1)
                {
                    textBox2.Focus();
                    textboxfocusflag = 0;
                }
                pipipi.controls.play();
                int DoSelect = 0;
                inputNumber = textBox3.Text;
                //textBox3.Text = "";
                DoSelect = selectBranch(inputNumber);//桁数判断に掛け、入力内容はinput Numberへ
                //label59.Text = DoSelect.ToString();

                e.Handled = true;
            }
            else
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
                textboxfocusflag = 0;
            }
            else
            {
                mediaPlayer.URL = numLoad_SE;
                mediaPlayer.controls.play();
                textboxfocusflag = 0;
            }
        }//番号入力用テキストボックス


        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {

        }//使わないと思われ

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                try
                {
                    double.Parse(textBox3.Text);
                }
                catch
                {
                    label59.Text = "入力は半角数字のみ読み込むことができます。数字で入力してください。";
                    textBox3.Text = "";
                }
                finally
                {

                }
            }

        }//使わないと思われ

        private void productNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //*
            int numericLoop = 0;
            int numericSum = 0;
            int priceSum = 0;
            while (productLoop != numericLoop)
            {
                dispItemsTotalPrice[numericLoop] = dispItemsPrice[numericLoop] * int.Parse(dispNumericUpDown[numericLoop, 0].Value.ToString());
                dispLabel[numericLoop, 4].Text = String.Format("\\ {0:#,0}", dispItemsTotalPrice[numericLoop]);
                numericSum += int.Parse(dispNumericUpDown[numericLoop, 0].Value.ToString());
                priceSum += dispItemsTotalPrice[numericLoop];
                numericLoop++;
            }
            dispItemsTotalPiece = numericSum;
            dispTotalPrice = priceSum;
            label22.Text = String.Format("{0:#,0} 個", dispItemsTotalPiece);
            label32.Text = label23.Text = String.Format("\\ {0:#,0}", dispTotalPrice);
            dispTotalPricePlusTax = ((dispTotalPrice * (int.Parse(tax) + 100)) / 100);
            label34.Text = String.Format("\\ {0:#,0}", dispTotalPricePlusTax);

            calc_Balance = 0;
            if (textBox1.Text != "") { calc_Balance -= int.Parse(textBox1.Text); }
            if (textBox2.Text != "") { calc_Balance -= int.Parse(textBox2.Text); }
            calc_Balance += dispTotalPricePlusTax;
            label49.Text = String.Format("\\ {0:#,0}", calc_Balance);
            // */

        }//自動生成されたNumericUpDownの値のいずれかを変更したときに発動するやーつ(合計数、金額とか再計算したーい)

        private void calculation_Balance(object sender, EventArgs e)

        {
            if (textBox1.Text != "")
            {
                try
                {
                    double.Parse(textBox1.Text);
                    if(int.Parse(textBox1.Text)<0)
                    {
                        textBox1.Text = "0";
                    }

                    
                }
                catch
                {
                    label59.Text = "入力は半角数字のみ読み込むことができます。数字で入力してください。";
                    textBox1.Text = "";
                }
                finally { }
            }
            if (textBox2.Text != "")
            {
                try
                {
                    double.Parse(textBox2.Text);
                    if (int.Parse(textBox2.Text) < 0)
                    {
                        textBox2.Text = "0";
                    }
                }
                catch
                {
                    label59.Text = "入力は半角数字のみ読み込むことができます。数字で入力してください。";
                    textBox2.Text = "";
                }
                finally { }
            }
            calc_Balance = 0;
            if (textBox1.Text != "") { calc_Balance -= int.Parse(textBox1.Text); }
            if (textBox2.Text != "") { calc_Balance -= int.Parse(textBox2.Text); }
            calc_Balance += dispTotalPricePlusTax;
            label49.Text = String.Format("\\ {0:#,0}", calc_Balance);

            //
            point_calc();
            /*
            if (textBox1.Text == "") { present_MemberPoint = dispTotalPrice / pointRate; }
            else { present_MemberPoint = (dispTotalPrice - int.Parse(textBox1.Text)) / pointRate; }
            label39.Text = String.Format("{0:#,0} P", present_MemberPoint);
            next_MemberPoint = 0;
            if (textBox1.Text != "") { next_MemberPoint -= int.Parse(textBox1.Text); }
            next_MemberPoint += present_MemberPoint + memberPoint;
            label37.Text = String.Format("{0:#,0} P", next_MemberPoint);
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { textBox1.Text = "0"; }
            if (textBox2.Text == "") { textBox2.Text = "0"; }

            if (dispTotalPricePlusTax == 0) { MessageBox.Show("購入商品を登録してください。" + System.Environment.NewLine + "入力番号に00000と入力すると決済取消ができます。"); textBox3.Focus(); }
            else if (int.Parse(textBox1.Text) > memberPoint) { MessageBox.Show("決済利用ポイントが、所有ポイントを超えています。"); textBox2.Focus(); }
            else if (dispTotalPricePlusTax < int.Parse(textBox1.Text)) { MessageBox.Show("利用ポイントは決済金額範囲内に指定してください。" + System.Environment.NewLine + "ポイントのみの決済でお釣りの排出はできません。"); textBox2.Focus(); }
            else if ((int.Parse(textBox1.Text) + int.Parse(textBox2.Text)) < dispTotalPricePlusTax) { MessageBox.Show("決済金額が不足しています。"); textBox2.Focus(); }
            else
            {
                dealDataWrite();
                detailDataWrite();
                paymentCompleted();
                label45.Text = String.Format("\\ {0:#,0}", change);
                change = 0;
                label59.Text = "決済完了 (お釣り : " + label45.Text + " )";
            }

        }//決済確定ボタン

        private void label49_TextChanged(object sender, EventArgs e)
        {
            if (calc_Balance <= 0)
            {
                label49.ForeColor = Color.DarkSlateBlue;
            }
            else
            {
                label49.ForeColor = Color.Red;
            }
            label45.Text = "\\ ---";
        }//必要入金残計算&お釣り初期化

        private void label32_TextChanged(object sender, EventArgs e)
        {
            if (memberNumber != "")
            {
                if (textBox1.Text == "") { present_MemberPoint = dispTotalPrice / pointRate; }
                else { present_MemberPoint = (dispTotalPrice - int.Parse(textBox1.Text)) / pointRate; }
                label39.Text = String.Format("{0:#,0} P", present_MemberPoint);
                next_MemberPoint = 0;
                if (textBox1.Text != "") { next_MemberPoint -= int.Parse(textBox1.Text); }
                next_MemberPoint += present_MemberPoint + memberPoint;
                label37.Text = String.Format("{0:#,0} P", next_MemberPoint);
            }
            else
            {
                label37.Text = label39.Text = "0 P";
            }
        }//ポイント計算

        private void point_calc()
        {
            if (memberNumber != "")
            {
                if (textBox1.Text == "") { present_MemberPoint = dispTotalPrice / pointRate; }
                else { present_MemberPoint = (dispTotalPrice - int.Parse(textBox1.Text)) / pointRate; }
                label39.Text = String.Format("{0:#,0} P", present_MemberPoint);
                next_MemberPoint = 0;
                if (textBox1.Text != "") { next_MemberPoint -= int.Parse(textBox1.Text); }
                next_MemberPoint += present_MemberPoint + memberPoint;
                label37.Text = String.Format("{0:#,0} P", next_MemberPoint);
            }
            else
            {
                label37.Text = label39.Text = "0 P";
            }
        }

        private void label23_TextChanged(object sender, EventArgs e)
        {
            point_calc();
        }//ポイント計算

        private void label37_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (memberPoint - int.Parse(textBox1.Text) < 0)
                {
                    label59.Text = "ポイント利用は、会員取得をした上で所有ポイント以下に設定してください";

                }
            }
        }//利用ポイントが所有ポイント上回った時に警告を出すやつ

        private void button3_Click(object sender, EventArgs e)
        {
            if (purchaseNumber[0] != "")
            {
                purchaseNumber[0] = label56.Text = "";
                label59.Text = "入庫番号01を取消しました。";
                purchaseloopnextflag = 1;
            }
            else
            {
                label59.Text = "この入庫番号は入力されていません。";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (purchaseNumber[1] != "")
            {
                purchaseNumber[1] = label11.Text = "";
                label59.Text = "入庫番号02を取消しました。";
                purchaseloopnextflag = 1;
            }
            else
            {
                label59.Text = "この入庫番号は入力されていません。";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (purchaseNumber[2] != "")
            {
                purchaseNumber[2] = label13.Text = "";
                label59.Text = "入庫番号03を取消しました。";
                purchaseloopnextflag = 1;
            }
            else
            {
                label59.Text = "この入庫番号は入力されていません。";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            purchaseloopnextflag = 1;
            int loop = 0;
            int nextstock = 0;
            string[] proids = new string[1000];
            string[] purpieces = new string[1000];
            DateTime receivetime = DateTime.Now;

            for (int i = 0; i < 3; i++)
            {
                if (purchaseNumber[i] != "")
                {
                    if (sql_Load("SELECT RECDAY FROM RECEIVE WHERE PURID='" + purchaseNumber[i] + "';", "RECDAY") == "")
                    {
                        sql_Write("UPDATE RECEIVE SET RECDAY ='" + receivetime.ToString("yyyy/MM/dd") + "' WHERE PURID='" + purchaseNumber[i] + "';");

                        loop = sql_Load_2("SELECT PROID FROM PURCHASEDETAIL WHERE PURID = '" + purchaseNumber[i] + "'; ", "PROID", proids);
                        sql_Load_2("SELECT PURPIECE FROM PURCHASEDETAIL WHERE PURID = '" + purchaseNumber[i] + "'; ", "PURPIECE", purpieces);
                        for (int j = 0; loop >= j; j++)
                        {

                            nextstock = int.Parse(sql_Load("SELECT STOCK FROM STOCK WHERE PROID='" + proids[j] + "';", "STOCK"));
                            nextstock += int.Parse(purpieces[j]);
                            sql_Write("UPDATE STOCK SET STOCK =" + nextstock.ToString() + " WHERE PROID = '" + proids[j] + "';");

                        }

                    }
                    else
                    {
                        MessageBox.Show("発注番号 " + purchaseNumber[i] + " の入庫は" + System.Environment.NewLine + "確定されています。");
                    }
                }

                label56.Text = label11.Text = label13.Text = "";
                purchaseNumber[0] = purchaseNumber[1] = purchaseNumber[2] = "";
                textBox3.Focus();
            }

        }//入庫確ボタン

        private void textBox2_Numcheck(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)//BackSpace時の処理
            {

            }
            else
            if (e.KeyChar == (char)Keys.Enter)//Enter時の処理
            {
                pipipi.controls.play();
                textBox1.Focus();

                e.Handled = true;
            }
            else
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
            else
            {
                mediaPlayer.URL = numLoad_SE;
                mediaPlayer.controls.play();
            }
        }

        private void textBox3_Numcheck(object sender, KeyPressEventArgs e)//だけどtextbox1
        {
            if (e.KeyChar == (char)Keys.Back)//BackSpace時の処理
            {

            }
            else
            if (e.KeyChar == (char)Keys.Enter)//Enter時の処理
            {
                pipipi.controls.play();
                button1.Focus();
                e.Handled = true;
            }
            else
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;

            }
            else
            {
                mediaPlayer.URL = numLoad_SE;
                mediaPlayer.controls.play();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (unicornflag < 10)
            {
                unicornflag++;
            }
            else if (unicornflag < 25)
            {
                unicornflag++;
                label59.Text = "ん？";
            }
            else if (unicornflag <= 50)
            {
                unicornflag++;
                label59.Text += " ";
            }
            else if (unicornflag > 50)
            {
                mediaPlayer.URL = "SE\\UNICORN-CUTVer.wav";
                unicornflag = 0;
                label59.Text = "<POS>:流れ変わったな";
            }


        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox3.Focus();
            timer2.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
             kaiin.Member_management member = new kaiin.Member_management();
             member.Show(this);
             member.import_POS(memberNumber);
             

        }
    }
}
