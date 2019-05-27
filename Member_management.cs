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

namespace kaiin
{
    public partial class Member_management : Form
    {
        int flag = 0;
        public void import_POS(string str)
        {
            textBox1.Text = str;
            kensaku();
            flag = 1;
        }
        private void kensaku()
        {
            string strSQL = "";
            string strSQL2 = "";

            if (textBox1.Text == "" && textBox9.Text == "") //商品名と商品番号が未入力の時、エラーメッセージを返す
            {
                MessageBox.Show("値を入力してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else if (textBox9.Text == "") //メールアドレスが未入力の場合でも会員番号が入力されていればメールアドレスも含めて検索結果を返す
            {
                strSQL = "SELECT * FROM MEMBER INNER JOIN POSTAL ON MEMBER.POSTALCODE = POSTAL.POSTALCODE WHERE MEMID = '" + textBox1.Text + "'";
            }
            else if (textBox1.Text == "") //会員番号が未入力の場合でもメールアドレスが入力されていれば会員番号も含めて検索結果を返す。
            {
                strSQL = "SELECT * FROM MEMBER INNER JOIN POSTAL ON MEMBER.POSTALCODE = POSTAL.POSTALCODE WHERE MEMMAIL = '" + textBox9.Text + "'";
            }
            else  //商品名、商品番号ともに入力されている時、検索結果を返す
            {
                strSQL = "SELECT * FROM MEMBER INNER JOIN POSTAL ON MEMBER.POSTALCODE = POSTAL.POSTALCODE  WHERE MEMID = '" + textBox1.Text + "' AND MEMMAIL = '" + textBox9.Text + "'";

            }



            if (strSQL != "")
            {
                OleDbCommand cmd = null;
                OleDbCommand cmd2 = null;
                //OleDbCommand cmd3 = null;
                OleDbDataReader dr = null;
                OleDbDataReader dr2 = null;
                //OleDbDataReader dr3 = null;
                using (OleDbConnection cn = new OleDbConnection(strCn))
                {
                    try
                    {
                        if (cn.State == ConnectionState.Closed) cn.Open();
                        {
                            cmd = new OleDbCommand(strSQL, cn);
                            dr = cmd.ExecuteReader();
                            dr.Read();



                            strSQL2 = "SELECT * FROM MEMBER INNER JOIN POSTAL ON MEMBER.POSTALCODE = POSTAL.POSTALCODE where MEMBER.MEMID ='" + textBox1.Text + "' and MEMBER.MEMMAIL = '" + textBox9.Text + "'";

                            cmd2 = new OleDbCommand(strSQL2, cn);
                            dr2 = cmd2.ExecuteReader();
                            dr2.Read();


                            textBox1.Text = dr["MEMID"].ToString();
                            textBox9.Text = dr["MEMMAIL"].ToString();
                            label7.Text = dr["MEMPOINT"].ToString();
                            label28.Text = dr["MEMPHONEFAMILYNAME"].ToString();
                            label29.Text = dr["MEMPHONEFIRSTNAME"].ToString();
                            label27.Text = dr["MEMTEL"].ToString();
                            label17.Text = dr["MEMFAMILYNAME"].ToString();
                            label20.Text = dr["MEMFIRSTNAME"].ToString();
                            label19.Text = dr["MEMBIRTHDAY"].ToString();

                            string temp = "";
                            string temp2 = "";

                            label24.Text = dr["MEMBER.POSTALCODE"].ToString();
                            temp = (int.Parse(label24.Text) % 10000).ToString();
                            temp = string.Format("{0:0000}", int.Parse(temp));
                            label24.Text = temp;
                            label21.Text = dr["MEMBER.POSTALCODE"].ToString();
                            temp2 = ((int.Parse(label21.Text) - int.Parse(label24.Text)) / 10000).ToString();
                            temp2 = string.Format("{0:000}", int.Parse(temp2));
                            label21.Text = temp2;

                            label22.Text = dr["MEMTEL2"].ToString();


                            label18.Text = dr["MEMADMISSIONDAY"].ToString();


                            //label23.Text = dr["POSTALCODE"].ToString();
                            //string strSQL3 = "SELECT * FROM POSTAL WHERE POSTALCODE=" + dr["MEMBER.POSTALCODE"] + ";";
                            // cmd3 = new OleDbCommand(strSQL3, cn);
                            // dr3 = cmd3.ExecuteReader();
                            // dr3.Read();

                            label23.Text = dr["POSADDRESS"].ToString() + "  " + dr["MEMADDRESS"];



                        }
                    }

                    catch (Exception ex)
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
        }

        private string strCn =
        ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;

        private menu.menu top;


        
        public Member_management(menu.menu top2)
        {
            InitializeComponent();
            top = top2;

        }

        public Member_management()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "会員（管理者）";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kensaku();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); //会員の画面を閉じる
            if (flag == 0)
            {
                top.Show();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
            else
            
                if (e.KeyChar == (char)Keys.Enter)
                {
                    kensaku();
                }

            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
