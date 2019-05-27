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

namespace kaiin_user
{
    public partial class Member_user : Form
    {
        //private string strCn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sdatabase_v5.accdb";
        private string strCn =
        ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        //ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        string strSQL = "";
        OleDbCommand cmd = null;
        OleDbDataReader dr = null;
        private int nextDealNo = 0;
        private string MEM;
        private menu.menu top;

        public Member_user(menu.menu top2)
        {
            InitializeComponent();
            top = top2;

        }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime sysdate = DateTime.Now;
            nextDealNo = int.Parse(sql_Load("SELECT MAX(MEMID) AS MEMID FROM MEMBER;", "MEMID")) + 1;//購入No再取得
            MEM = String.Format("{0:000000000}", nextDealNo);

            if (textBox1.Text == textBox2.Text)
            {
                sql_Write("INSERT INTO MEMBER VALUES('" + MEM + "','" + textBox1.Text + "','" + textBox7.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox10.Text + "','" + textBox11.Text + "',null,0, '" + sysdate.ToString("yyyy/MM/dd") + "','" + textBox9.Text + "')");
            }

            ;//購入No表示
        }

        private void sql_Write(string sqlcode)
        {
            strSQL = sqlcode;
            int cnt = 0;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "")
            {
                using (OleDbConnection cn = new OleDbConnection(strCn))
                {
                    try
                    {
                        if (cn.State == ConnectionState.Closed) cn.Open();

                        string SQL1 = "select count(MEMMAIL) as M from MEMBER where MEMMAIL = '" + textBox1.Text + "'";
                        OleDbCommand cmd1 = new OleDbCommand(SQL1, cn);
                        OleDbDataReader dr1 = cmd1.ExecuteReader();
                        dr1.Read();
                        int x = int.Parse(dr1["M"].ToString());

                        if (x == 0)
                        {
                            cmd = new OleDbCommand(strSQL, cn);
                            //if (cn.State == ConnectionState.Closed) cn.Open();
                            cnt = cmd.ExecuteNonQuery();
                            MessageBox.Show(cnt.ToString() + "件追加完了しました",
                                                            "",
                                                            MessageBoxButtons.OK,
                                                            MessageBoxIcon.Asterisk);
                            cn.Close();
                        }
                        else
                        {
                            MessageBox.Show("そのメールアドレスはすでに登録されています。",
                                            "エラー",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            cn.Close();
                        }

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
            }
            else
            {
                MessageBox.Show("空白の欄があります。値を入力してください。",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
        }
        //sqlcodeに打ち込んだSQL文でテーブルに書き込む
        private void error_Disp(string ex)
        {
            MessageBox.Show(ex.ToString(),
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            //*/    
        }//error出すやつ

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label14.Text = sql_Load("SELECT POSADDRESS FROM POSTAL WHERE POSTALCODE='" + textBox10.Text + "'", "POSADDRESS");
        }

        private void Member_user_Load(object sender, EventArgs e)
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