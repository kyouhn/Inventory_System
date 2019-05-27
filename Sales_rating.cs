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
using menu;

namespace rating
{
    public partial class Rating : Form
    {
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
                catch (Exception)
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

        private string strCn =
        ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        private menu.menu top;


        string[] temp231 = new string[100000];//PROID
        int[] temp232 = new int[100000];//STOCK
        int[] temp233 = new int[100000];//RANK

        public Rating(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)  //日別

        {
            string strSQL = "";


            OleDbCommand cmd = null;


            OleDbDataReader dr = null;


            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    {
                        test(1);
                        textBox1.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[0] + "'", "PRONAME");
                        textBox2.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[0] + "'", "AUTFAMILYNAME");
                        textBox3.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[0] + "'", "AUTFIRSTNAME");
                        textBox4.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[0] + "'", "GENNAME");
                        textBox5.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[0] + "'", "PUBNAME");

                        textBox6.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[1] + "'", "PRONAME");
                        textBox7.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[1] + "'", "AUTFAMILYNAME");
                        textBox8.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[1] + "'", "AUTFIRSTNAME");
                        textBox9.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[1] + "'", "GENNAME");
                        textBox10.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[1] + "'", "PUBNAME");

                        textBox11.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[2] + "'", "PRONAME");
                        textBox12.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[2] + "'", "AUTFAMILYNAME");
                        textBox13.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[2] + "'", "AUTFIRSTNAME");
                        textBox14.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[2] + "'", "GENNAME");
                        textBox15.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[2] + "'", "PUBNAME");

                        textBox16.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[3] + "'", "PRONAME");
                        textBox17.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[3] + "'", "AUTFAMILYNAME");
                        textBox18.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[3] + "'", "AUTFIRSTNAME");
                        textBox19.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[3] + "'", "GENNAME");
                        textBox20.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[3] + "'", "PUBNAME");

                        textBox21.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[4] + "'", "PRONAME");
                        textBox22.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[4] + "'", "AUTFAMILYNAME");
                        textBox23.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[4] + "'", "AUTFIRSTNAME");
                        textBox24.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[4] + "'", "GENNAME");
                        textBox25.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[4] + "'", "PUBNAME");


                        //strSQL = @"SELECT DETAIL.[PROID], Sum(DETAIL.[ORDPIECE]) AS ORDPIECE FROM DETAIL  where PROID = 
                        //          '" + label2.Text + "' GROUP BY DETAIL.[PROID] order by Sum(DETAIL.[ORDPIECE]) desc ";

                        //int a = 0;
                        //a = int.Parse(dr["ORDPIECE"].ToString());

                        //label11.Text = a.ToString();

                        //strSQL2 = @"SELECT DETAIL.[PROID], Sum(DETAIL.[ORDPIECE]) AS ORDPIECE FROM DETAIL  
                        //            GROUP BY DETAIL.[PROID]  having Sum(DETAIL.[ORDPIECE]) > " + a + "";

                        //int count = 0;
                        //while (dr2.Read())
                        //{
                        //    count += 1;
                        //}
                        //count += 1;

                        //label11.Text = count.ToString();


                        //strSQL = @"SELECT DETAIL.PROID,SUM(DETAIL.ORDPIECE) FROM ((((DETAIL INNER JOIN PRODUCT ON DETAIL.PROID = PRODUCT.PROID) 
                        //           INNER JOIN DEAL ON DETAIL.DEAID = DEAL.DEAID)
                        //           INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID)
                        //           INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID)
                        //           INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID
                        //           GROUP BY DETAIL.PROID";


                        //strSQL2 = @"SELECT * FROM ((((DETAIL INNER JOIN PRODUCT ON DETAIL.PROID = PRODUCT.PROID) 
                        //        INNER JOIN DEAL ON DETAIL.DEAID = DEAL.DEAID)
                        //        INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID)
                        //        INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID)
                        //        INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID
                        //        WHERE DATE()";


                        //cmd = new OleDbCommand(strSQL, cn);
                        //cmd2 = new OleDbCommand(strSQL2, cn);


                        //dr = cmd.ExecuteReader();
                        //dr2 = cmd2.ExecuteReader();


                        //dr.Read();
                        //dr2.Read();


                        //label11.Text = dr2["PROID"].ToString();             //題名
                        //label12.Text = dr2["AUTFAMILYNAME"].ToString();    //著者名
                        //label13.Text = dr2["GENNAME"].ToString();          //ジャンル
                        //label14.Text = dr2["PUBNAME"].ToString();          //出版社
                        //label31.Text = dr2["AUTFIRSTNAME"].ToString();

                        //label15.Text = dr["PRONAME"].ToString();
                        //label16.Text = dr["AUTFAMILYNAME"].ToString();
                        //label17.Text = dr["GENNAME"].ToString();
                        //label18.Text = dr["PUBNAME"].ToString();
                        //label32.Text = dr["AUTFIRSTNAME"].ToString();

                        //label19.Text = dr["PRONAME"].ToString();
                        //label20.Text = dr["AUTFAMILYNAME"].ToString();
                        //label21.Text = dr["GENNAME"].ToString();
                        //label22.Text = dr["PUBNAME"].ToString();
                        //label33.Text = dr["AUTFIRSTNAME"].ToString();

                        //label23.Text = dr["PRONAME"].ToString();
                        //label24.Text = dr["AUTFAMILYNAME"].ToString();
                        //label25.Text = dr["GENNAME"].ToString();
                        //label26.Text = dr["PUBNAME"].ToString();
                        //label34.Text = dr["AUTFIRSTNAME"].ToString();

                        //label27.Text = dr["PRONAME"].ToString();
                        //label28.Text = dr["AUTFAMILYNAME"].ToString();
                        //label29.Text = dr["GENNAME"].ToString();
                        //label30.Text = dr["PUBNAME"].ToString();
                        //label35.Text = dr["AUTFIRSTNAME"].ToString();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("値が間違っています正しい値を入力してください。",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                finally
                {
                    if (dr != null) dr.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)  //週別

        {

            OleDbDataReader dr = null;


            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    {
                        test(2);
                        textBox1.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[0] + "'", "PRONAME");
                        textBox2.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[0] + "'", "AUTFAMILYNAME");
                        textBox3.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[0] + "'", "AUTFIRSTNAME");
                        textBox4.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[0] + "'", "GENNAME");
                        textBox5.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[0] + "'", "PUBNAME");

                        textBox6.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[1] + "'", "PRONAME");
                        textBox7.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[1] + "'", "AUTFAMILYNAME");
                        textBox8.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[1] + "'", "AUTFIRSTNAME");
                        textBox9.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[1] + "'", "GENNAME");
                        textBox10.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[1] + "'", "PUBNAME");

                        textBox11.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[2] + "'", "PRONAME");
                        textBox12.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[2] + "'", "AUTFAMILYNAME");
                        textBox13.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[2] + "'", "AUTFIRSTNAME");
                        textBox14.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[2] + "'", "GENNAME");
                        textBox15.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[2] + "'", "PUBNAME");

                        textBox16.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[3] + "'", "PRONAME");
                        textBox17.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[3] + "'", "AUTFAMILYNAME");
                        textBox18.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[3] + "'", "AUTFIRSTNAME");
                        textBox19.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[3] + "'", "GENNAME");
                        textBox20.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[3] + "'", "PUBNAME");

                        textBox21.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[4] + "'", "PRONAME");
                        textBox22.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[4] + "'", "AUTFAMILYNAME");
                        textBox23.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[4] + "'", "AUTFIRSTNAME");
                        textBox24.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[4] + "'", "GENNAME");
                        textBox25.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[4] + "'", "PUBNAME");

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("値が間違っています正しい値を入力してください。",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                finally
                {
                    if (dr != null) dr.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)　//月別

        {

            OleDbDataReader dr = null;


            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    {
                        test(3);
                        textBox1.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[0] + "'", "PRONAME");
                        textBox2.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[0] + "'", "AUTFAMILYNAME");
                        textBox3.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[0] + "'", "AUTFIRSTNAME");
                        textBox4.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[0] + "'", "GENNAME");
                        textBox5.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[0] + "'", "PUBNAME");

                        textBox6.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[1] + "'", "PRONAME");
                        textBox7.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[1] + "'", "AUTFAMILYNAME");
                        textBox8.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[1] + "'", "AUTFIRSTNAME");
                        textBox9.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[1] + "'", "GENNAME");
                        textBox10.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[1] + "'", "PUBNAME");

                        textBox11.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[2] + "'", "PRONAME");
                        textBox12.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[2] + "'", "AUTFAMILYNAME");
                        textBox13.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[2] + "'", "AUTFIRSTNAME");
                        textBox14.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[2] + "'", "GENNAME");
                        textBox15.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[2] + "'", "PUBNAME");

                        textBox16.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[3] + "'", "PRONAME");
                        textBox17.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[3] + "'", "AUTFAMILYNAME");
                        textBox18.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[3] + "'", "AUTFIRSTNAME");
                        textBox19.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[3] + "'", "GENNAME");
                        textBox20.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[3] + "'", "PUBNAME");

                        textBox21.Text = sql_Load("SELECT PROID ,PRONAME FROM PRODUCT WHERE PROID = '" + temp231[4] + "'", "PRONAME");
                        textBox22.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[4] + "'", "AUTFAMILYNAME");
                        textBox23.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID WHERE PROID = '" + temp231[4] + "'", "AUTFIRSTNAME");
                        textBox24.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID WHERE PROID = '" + temp231[4] + "'", "GENNAME");
                        textBox25.Text = sql_Load("SELECT * FROM PRODUCT INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID WHERE PROID = '" + temp231[4] + "'", "PUBNAME");


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("値が間違っています正しい値を入力してください。",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                finally
                {
                    if (dr != null) dr.Close();
                }
            }
        }

        void test(int a)
        {
            string[] proid_Rankin_temp = new string[100000];
            string[] stock_Rankin_temp = new string[100000];
            string[] proid_Rankin = new string[100000];
            string[] stock_Rankin = new string[100000];
            string[] Rank_Rankin_string = new string[100000];

            //全体用閾値以下一括変更
            //sql_Load2(%1,%2,%3)の%1に
            //上から順番に
            //ランキング上位10位絞り込みした
            //1,商品コードPROID
            //2.在庫数STOCK
            //3.順位(%2には順位の列名)
            //を入れる
            //10位までを絞り込む所までがSQL文

            //ランキン
            DateTime time = DateTime.Now;
            DateTime time2 = time;
            switch (a)
            {
                case 1:
                    {
                        time2 = time.AddDays(-1);
                        break;
                    }
                case 2:
                    {
                        time2 = time.AddDays(-7);
                        break;
                    }
                case 3:
                    {
                        time2 = time.AddMonths(-1);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            string[] temp999 = new string[9999999];
            string[] temp998 = new string[9999999];
            int h;
            int j;
            int l;
            h = j = l = 0;

            string temp001 = "";

            //8日前の年月日を取得
            int[] temp100 = new int[3];
            temp100[0] = int.Parse(time2.AddDays(-1).ToString("yyyy"));
            temp100[1] = int.Parse(time2.AddDays(-1).ToString("MM"));
            temp100[2] = int.Parse(time2.AddDays(-1).ToString("dd"));
            //deal,deadayを全部上り順で取得
            sql_Load_2("select deaday from deal order by deaday", "deaday", temp999);
            int temp000 = sql_Load_2("select deaid from deal order by deaid", "deaid", temp998);
            //取得した値の数だけ変数を作成
            int[] temp101 = new int[temp000 + 1];
            int[] temp102 = new int[temp000 + 1];
            int[] temp103 = new int[temp000 + 1];
            //時間を省略したものと年月日を分離したものを用意
            for (int i = 0; i <= temp000; i++)
            {
                temp999[i] = DateTime.Parse(temp999[i]).ToString("yyyy/MM/dd");
                temp101[i] = int.Parse(DateTime.Parse(temp999[i]).ToString("yyyy"));
                temp102[i] = int.Parse(DateTime.Parse(temp999[i]).ToString("MM"));
                temp103[i] = int.Parse(DateTime.Parse(temp999[i]).ToString("dd"));
            }
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
            finally { }
            //なんやかんやあってtemp001が7日前最小のdeaid

            //一週間の商品とその売り上げ一覧（商品コードで並び替え）
            string[] temp201 = new string[1000000];
            int temp211 = 0;
            string[] temp202 = new string[1000000];

            temp211 = sql_Load_2("SELECT PROID,ORDPIECE FROM DETAIL WHERE DEAID >= '" + temp001 + "' ORDER BY PROID;", "PROID", temp201);
            sql_Load_2("SELECT PROID,ORDPIECE FROM DETAIL WHERE DEAID >= '" + temp001 + "' ORDER BY PROID;", "ORDPIECE", temp202);

            //商品ごとの売り上げにまとめる
            string[] temp221 = new string[1000000];
            int[] temp222 = new int[1000000];
            int temp212 = -1;
            string temptemptemp = "";
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

            //ランキングと比較して自動発注かけるやつをピックアップ

            bool loopflag = false;
            l = 0;//直近の個数
            j = 0;//更新件数
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
                                    temp231[j] = temp221[i];
                                    l = temp232[j] = temp222[i];
                                    temp233[j] = i + 1;
                                    j++;
                                    h = i;
                                    break;
                                }
                            case 2 - 1:
                                {
                                    if (temp222[i] != l)
                                    {
                                        temp231[j] = temp221[i];
                                        l = temp232[j] = temp222[i];
                                        temp233[j] = i + 1;
                                        j++;
                                        h = i;
                                    }
                                    else
                                    {
                                        temp231[j] = temp221[i];
                                        l = temp232[j] = temp222[i];
                                        temp233[j] = h;
                                        j++;
                                    }
                                }
                                break;
                            case 3 - 1:
                                {
                                    if (temp222[i] != l)
                                    {
                                        temp231[j] = temp221[i];
                                        l = temp232[j] = temp222[i];
                                        temp233[j] = i + 1;
                                        j++;
                                        h = i;
                                    }
                                    else
                                    {
                                        temp231[j] = temp221[i];
                                        l = temp232[j] = temp222[i];
                                        temp233[j] = h;
                                        j++;
                                    }
                                }
                                break;
                            case 4 - 1:
                                {
                                    if (temp222[i] != l)
                                    {
                                        temp231[j] = temp221[i];
                                        l = temp232[j] = temp222[i];
                                        temp233[j] = i + 1;
                                        j++;
                                        h = i;
                                    }
                                    else
                                    {
                                        temp231[j] = temp221[i];
                                        l = temp232[j] = temp222[i];
                                        temp233[j] = h;
                                        j++;
                                    }
                                }
                                break;
                            case 5 - 1:
                                {
                                    if (temp222[i] != l)
                                    {
                                        temp231[j] = temp221[i];
                                        l = temp232[j] = temp222[i];
                                        temp233[j] = i + 1;
                                        j++;
                                        h = i;
                                    }
                                    else
                                    {
                                        temp231[j] = temp221[i];
                                        l = temp232[j] = temp222[i];
                                        temp233[j] = h;
                                        j++;
                                    }
                                }
                                break;

                            default:
                                {
                                    if (temp222[i] == l)
                                    {
                                        temp231[j] = temp221[i];
                                        l = temp232[j] = temp222[i];
                                        temp233[j] = h;
                                        j++;
                                    }
                                    else
                                    {
                                        loopflag = true;
                                        break;
                                    }
                                    break;
                                }
                        }
                    }

                }
            }
            catch { }
            finally { }
        }

        private void Rating_Load(object sender, EventArgs e)
        {

        }

        private void pbtn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbtn_Dispose_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }
    }
}
