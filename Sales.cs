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

namespace uriage
{
    public partial class Sales : Form
    {
        private void kensaku()
        {
            DateTime sysdate = DateTime.Now;
            strSQL2 = "SELECT * FROM (((( PRODUCT INNER JOIN STOCK ON PRODUCT.PROID = STOCK.PROID ) INNER JOIN GENRE on PRODUCT.GENID = GENRE.GENID )  INNER JOIN PUBLISER on PRODUCT.PUBID = PUBLISER.PUBID ) INNER JOIN AUTHOR on PRODUCT.AUTID = AUTHOR.AUTID )  where PRODUCT.PROID ='" + textBox2.Text + "' or PRODUCT.PRONAME = '" + textBox1.Text + "' or PRODUCT.PROID = '" + textBox2.Text + "' and PRODUCT.PRONAME = '" + textBox1.Text + "'";
            strSQL3 = "SELECT * FROM ((DEAL INNER JOIN DETAIL ON DEAL.DEAID = DETAIL.DEAID )INNER JOIN PRODUCT ON PRODUCT.PROID = DETAIL.PROID)";


            switch (comboBox2.SelectedIndex)
            {
                case 0:

                    date = sysdate.ToString("yyyy/MM/dd");

                    if (textBox2.Text == "" && textBox1.Text == "") //商品名と商品番号が未入力の時、エラーメッセージを返す
                    {
                        MessageBox.Show("値を入力してください。",
                                        "エラー",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else if (textBox1.Text == "") //商品名が未入力の場合でも商品番号が入力されていれば商品名も含めて検索結果を返す
                    {
                        strSQL3 += " where DETAIL.PROID ='" + textBox2.Text + "' AND DEAL.DEADAY = '" + date + "'";

                    }
                    else if (textBox2.Text == "") //商品番号が未入力の場合でも商品名が入力されていれば商品番号も含めて検索結果を返す。
                    {
                        strSQL3 += " where PRODUCT.PRONAME ='" + textBox1.Text + "' AND DEAL.DEADAY = '" + date + "'";
                    }
                    else  //商品名、商品番号ともに入力されている時、検索結果を返す
                    {
                        strSQL3 += " where PRODUCT.PRONAME ='" + textBox1.Text + "' AND DETAIL.PROID = '" + textBox2.Text + "' AND DEAL.DEADAY = '" + date + "'";
                    }

                    break;

                case 1:
                    DateTime dt = DateTime.Now;
                    dt = sysdate.AddDays(-7);          //1週間前のsysdate

                    if (textBox2.Text == "" && textBox1.Text == "") //商品名と商品番号が未入力の時、エラーメッセージを返す
                    {
                        MessageBox.Show("値を入力してください。",
                                        "エラー",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else if (textBox1.Text == "") //商品名が未入力の場合でも商品番号が入力されていれば商品名も含めて検索結果を返す
                    {
                        strSQL3 += " where DETAIL.PROID ='" + textBox2.Text + "' AND DEAL.DEADAY >= '" + dt + "'";

                    }
                    else if (textBox2.Text == "") //商品番号が未入力の場合でも商品名が入力されていれば商品番号も含めて検索結果を返す。
                    {
                        strSQL3 += " where PRODUCT.PRONAME ='" + textBox1.Text + "' AND DEAL.DEADAY >= '" + dt + "'";
                    }
                    else  //商品名、商品番号ともに入力されている時、検索結果を返す
                    {
                        strSQL3 += " where PRODUCT.PRONAME ='" + textBox1.Text + "' AND DETAIL.PROID = '" + textBox2.Text + "' AND DEAL.DEADAY >= '" + dt + "'";
                    }

                    break;
                case 2:
                    DateTime dt2 = DateTime.Now;
                    dt2 = sysdate.AddDays(-30);                 //1か月前のsysdate

                    if (textBox2.Text == "" && textBox1.Text == "") //商品名と商品番号が未入力の時、エラーメッセージを返す
                    {
                        MessageBox.Show("値を入力してください。",
                                        "エラー",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else if (textBox1.Text == "") //商品名が未入力の場合でも商品番号が入力されていれば商品名も含めて検索結果を返す
                    {
                        strSQL3 += " where DETAIL.PROID ='" + textBox2.Text + "' AND DEAL.DEADAY >= '" + dt2 + "'";

                    }
                    else if (textBox2.Text == "") //商品番号が未入力の場合でも商品名が入力されていれば商品番号も含めて検索結果を返す。
                    {
                        strSQL3 += " where PRODUCT.PRONAME ='" + textBox1.Text + "' AND DEAL.DEADAY >= '" + dt2 + "'";
                    }
                    else  //商品名、商品番号ともに入力されている時、検索結果を返す
                    {
                        strSQL3 += " where PRODUCT.PRONAME ='" + textBox1.Text + "' AND DETAIL.PROID = '" + textBox2.Text + "' AND DEAL.DEADAY >= '" + dt2 + "'";
                    }
                    break;
            }



            if (textBox2.Text == "" && textBox1.Text == "") //商品名と商品番号が未入力の時、エラーメッセージを返す
            {
                MessageBox.Show("値を入力してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else if (textBox1.Text == "") //商品名が未入力の場合でも商品番号が入力されていれば商品名も含めて検索結果を返す
            {
                strSQL = "SELECT * FROM PRODUCT WHERE PROID = '" + textBox2.Text + "'";

            }
            else if (textBox2.Text == "") //商品番号が未入力の場合でも商品名が入力されていれば商品番号も含めて検索結果を返す。
            {
                strSQL = "SELECT * FROM PRODUCT WHERE PRONAME = '" + textBox1.Text + "'";
            }
            else  //商品名、商品番号ともに入力されている時、検索結果を返す
            {
                strSQL = "SELECT * FROM PRODUCT WHERE PRONAME = '" + textBox1.Text + "' AND PROID = '" + textBox2.Text + "'";
            }

            if (strSQL != "")
            {
                OleDbCommand cmd = null;
                OleDbCommand cmd2 = null;
                OleDbCommand cmd3 = null;
                OleDbCommand cmd4 = null;
                OleDbCommand cmd5 = null;

                OleDbDataReader dr = null;
                OleDbDataReader dr2 = null;
                OleDbDataReader dr3 = null;
                OleDbDataReader dr4 = null;
                OleDbDataReader dr5 = null;

                using (OleDbConnection cn = new OleDbConnection(strCn))
                {
                    try
                    {
                        if (cn.State == ConnectionState.Closed) cn.Open();
                        {
                            cmd = new OleDbCommand(strSQL, cn);
                            dr = cmd.ExecuteReader();
                            dr.Read();


                            cmd2 = new OleDbCommand(strSQL2, cn);
                            dr2 = cmd2.ExecuteReader();
                            dr2.Read();


                            cmd3 = new OleDbCommand(strSQL3, cn);
                            dr3 = cmd3.ExecuteReader();
                            int SUM_ORDPIECE = 0;


                            /* if (comboBox2.SelectedIndex == 0)
                             {

                             }
                             */

                            strSQL4 = "SELECT DETAIL.[PROID], Sum(DETAIL.[ORDPIECE]) AS ORDPIECE FROM DETAIL  where PROID = '" + textBox2.Text + "'GROUP BY DETAIL.[PROID] order by Sum(DETAIL.[ORDPIECE]) desc ";

                            cmd4 = new OleDbCommand(strSQL4, cn);
                            dr4 = cmd4.ExecuteReader();
                            dr4.Read();
                            int a = 0;
                            a = int.Parse(dr4["ORDPIECE"].ToString());


                            strSQL5 = "SELECT DETAIL.[PROID], Sum(DETAIL.[ORDPIECE]) AS ORDPIECE FROM DETAIL  GROUP BY DETAIL.[PROID]  having Sum(DETAIL.[ORDPIECE]) > " + a + "";
                            cmd5 = new OleDbCommand(strSQL5, cn);
                            dr5 = cmd5.ExecuteReader();

                            int count = 0;
                            while (dr5.Read())
                            {
                                count += 1;

                            }

                            count += 1;



                            while (dr3.Read())
                            {

                                SUM_ORDPIECE += int.Parse(dr3["ORDPIECE"].ToString());

                            }




                            textBox1.Text = dr["PRONAME"].ToString(); //PRONAME = 商品名
                            textBox2.Text = dr["PROID"].ToString();   //PROID = 商品番号
                            label7.Text = dr2["GENNAME"].ToString();  //GENNAME = ジャンル
                            label19.Text = dr2["PUBNAME"].ToString(); //PUBNAME = 出版社
                            label20.Text = dr2["AUTFAMILYNAME"].ToString() + dr2["AUTFIRSTNAME"].ToString(); //AUTFAMILYNAME = 著者名(性) + AUTFIRSTNAME = 著者名(名)
                            label22.Text = dr["PROYEAR"].ToString();  //PROYEAR = 出版年


                            label15.Text = SUM_ORDPIECE.ToString();
                            string sum = SUM_ORDPIECE.ToString();
                            string sum1 = dr["PROPRICE"].ToString();
                            label17.Text = (int.Parse(sum) * int.Parse(sum1)).ToString();

                            if ((int.Parse(sum) * int.Parse(sum1)).ToString() == 0.ToString())
                            {
                                label15.Text = "売上数なし";
                                label17.Text = "売上金額なし";
                                label11.Text = "ランキング情報なし";
                            }
                            else
                            {
                                label11.Text = count.ToString();
                            }
                        }
                        //入力した値がどこかしら間違っている時
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("値が間違っています正しい値を入力してください",
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
        }

        string strSQL = "";
        string strSQL2 = "";
        string strSQL3 = "";
        string strSQL4 = "";
        string strSQL5 = "";
        //string strSQL4 = "SELECT DETAIL.PROID, Sum(DETAIL.ORDPIECE) AS ORDPIECE, DCount('ORDPIECE', 'RANKDETAIL', 'ORDPIECE > ' & [ORDPIECE])+1 AS RANK FROM DETAIL GROUP BY DETAIL.PROID;";
        
        string date = "";
        //private int rank = 0;

        private string strCn =
        ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        private menu.menu top;

        public Sales(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "売上検索";
            //comboBoxの設定
            comboBox2.Items.Add("当日");
            comboBox2.Items.Add("7日前");
            comboBox2.Items.Add("30日前");

            //初期値として0を設定
            comboBox2.SelectedIndex = 0;

            //string型SQLの宣言



        }



        private void button1_Click(object sender, EventArgs e)
        {
            kensaku();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                /*
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;

            }
            if (e.KeyChar == (char)Keys.Back)//BackSpace時の処理
            {

            }
            else
            */
                if (e.KeyChar == (char)Keys.Enter)
                {
                    kensaku();
                }

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;

            }
            if (e.KeyChar == (char)Keys.Back)//BackSpace時の処理
            {

            }
            else if (textBox2.Text.Length != 13)
                {
                    if (e.KeyChar == (char)Keys.Enter)
                    {
                        kensaku();
                    }
                }


            }
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
