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

namespace teiryou
{
    public partial class Quantification_2 : Form
    {
        private string strCn =
        ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;

        private menu.menu top;
        public Quantification_2(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "定量管理";
            string strSQL = "";
            string strSQL2 = "";
            string strSQL3 = "";
            string strSQL4 = "";
            string strSQL5 = "";
            string strSQL6 = "";
            string strSQL7 = "";
            string strSQL8 = "";


            OleDbCommand cmd = null;
            OleDbCommand cmd2 = null;
            OleDbCommand cmd3 = null;
            OleDbCommand cmd4 = null;
            OleDbCommand cmd5 = null;
            OleDbCommand cmd6 = null;
            OleDbCommand cmd7 = null;
            OleDbCommand cmd8 = null;


            OleDbDataReader dr = null;
            OleDbDataReader dr2 = null;
            OleDbDataReader dr3 = null;
            OleDbDataReader dr4 = null;
            OleDbDataReader dr5 = null;
            OleDbDataReader dr6 = null;
            OleDbDataReader dr7 = null;
            OleDbDataReader dr8 = null;

            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    {
                        strSQL = "SELECT * FROM MASTER WHERE MASID = 1";
                        strSQL2 = "SELECT * FROM MASTER WHERE MASID = 3";
                        strSQL3 = "SELECT * FROM MASTER WHERE MASID = 4";
                        strSQL4 = "SELECT * FROM MASTER WHERE MASID = 5";
                        strSQL5 = "SELECT * FROM MASTER WHERE MASID = 6";
                        strSQL6 = "SELECT * FROM MASTER WHERE MASID = 7";
                        strSQL7 = "SELECT * FROM MASTER WHERE MASID = 2";
                        strSQL8 = "SELECT * FROM MASTER WHERE MASID = 8";


                        cmd = new OleDbCommand(strSQL, cn);
                        cmd2 = new OleDbCommand(strSQL2, cn);
                        cmd3 = new OleDbCommand(strSQL3, cn);
                        cmd4 = new OleDbCommand(strSQL4, cn);
                        cmd5 = new OleDbCommand(strSQL5, cn);
                        cmd6 = new OleDbCommand(strSQL6, cn);
                        cmd7 = new OleDbCommand(strSQL7, cn);
                        cmd8 = new OleDbCommand(strSQL8, cn);


                        dr = cmd.ExecuteReader();
                        dr2 = cmd2.ExecuteReader();
                        dr3 = cmd3.ExecuteReader();
                        dr4 = cmd4.ExecuteReader();
                        dr5 = cmd5.ExecuteReader();
                        dr6 = cmd6.ExecuteReader();
                        dr7 = cmd7.ExecuteReader();
                        dr8 = cmd8.ExecuteReader();


                        dr.Read();
                        dr2.Read();
                        dr3.Read();
                        dr4.Read();
                        dr5.Read();
                        dr6.Read();
                        dr7.Read();
                        dr8.Read();


                        textBox1.Text = dr["MASINFO1"].ToString();
                        textBox6.Text = dr2["MASINFO1"].ToString();
                        textBox7.Text = dr3["MASINFO1"].ToString();
                        textBox8.Text = dr4["MASINFO1"].ToString();
                        textBox9.Text = dr5["MASINFO1"].ToString();
                        textBox10.Text = dr6["MASINFO1"].ToString();
                        textBox11.Text = dr7["MASINFO1"].ToString();
                        textBox12.Text = dr8["MASINFO1"].ToString();


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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //更新ボタン
        private void button2_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            string strSQL2 = "";
            string strSQL3 = "";
            string strSQL4 = "";
            string strSQL5 = "";
            string strSQL6 = "";
            string strSQL7 = "";
            string strSQL8 = "";


            OleDbCommand cmd = null;
            OleDbCommand cmd2 = null;
            OleDbCommand cmd3 = null;
            OleDbCommand cmd4 = null;
            OleDbCommand cmd5 = null;
            OleDbCommand cmd6 = null;
            OleDbCommand cmd7 = null;
            OleDbCommand cmd8 = null;


            OleDbDataReader dr = null;
            OleDbDataReader dr2 = null;
            OleDbDataReader dr3 = null;
            OleDbDataReader dr4 = null;
            OleDbDataReader dr5 = null;
            OleDbDataReader dr6 = null;
            OleDbDataReader dr7 = null;
            OleDbDataReader dr8 = null;

            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    {
                        //データの更新
                        strSQL = "UPDATE MASTER SET MASINFO1 = '" + textBox1.Text + "' WHERE MASID = 1";
                        strSQL2 = "UPDATE MASTER SET MASINFO1 = '" + textBox6.Text + "' WHERE MASID = 3";
                        strSQL3 = "UPDATE MASTER SET MASINFO1 = '" + textBox7.Text + "' WHERE MASID = 4";
                        strSQL4 = "UPDATE MASTER SET MASINFO1 = '" + textBox8.Text + "' WHERE MASID = 5";
                        strSQL5 = "UPDATE MASTER SET MASINFO1 = '" + textBox9.Text + "' WHERE MASID = 6";
                        strSQL6 = "UPDATE MASTER SET MASINFO1 = '" + textBox10.Text + "' WHERE MASID = 7";
                        strSQL7 = "UPDATE MASTER SET MASINFO1 = '" + textBox11.Text + "' WHERE MASID = 2";
                        strSQL8 = "UPDATE MASTER SET MASINFO1 = '" + textBox12.Text + "' WHERE MASID = 8";


                        cmd = new OleDbCommand(strSQL, cn);
                        cmd2 = new OleDbCommand(strSQL2, cn);
                        cmd3 = new OleDbCommand(strSQL3, cn);
                        cmd4 = new OleDbCommand(strSQL4, cn);
                        cmd5 = new OleDbCommand(strSQL5, cn);
                        cmd6 = new OleDbCommand(strSQL6, cn);
                        cmd7 = new OleDbCommand(strSQL7, cn);
                        cmd8 = new OleDbCommand(strSQL8, cn);


                        dr = cmd.ExecuteReader();
                        dr2 = cmd2.ExecuteReader();
                        dr3 = cmd3.ExecuteReader();
                        dr4 = cmd4.ExecuteReader();
                        dr5 = cmd5.ExecuteReader();
                        dr6 = cmd6.ExecuteReader();
                        dr7 = cmd7.ExecuteReader();
                        dr8 = cmd8.ExecuteReader();


                        dr.Read();
                        dr2.Read();
                        dr3.Read();
                        dr4.Read();
                        dr5.Read();
                        dr6.Read();
                        dr7.Read();
                        dr8.Read();

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("");
                }
                finally
                {
                    if (dr != null) dr.Close();
                }
            }

            int nullCheck = 0;

            nullCheck += nullcheck(textBox1);
            nullCheck += nullcheck(textBox6);
            nullCheck += nullcheck(textBox7);
            nullCheck += nullcheck(textBox8);
            nullCheck += nullcheck(textBox9);
            nullCheck += nullcheck(textBox10);
            nullCheck += nullcheck(textBox11);
            nullCheck += nullcheck(textBox12);

            if (nullCheck != 0)
            {
                MessageBox.Show("値を入力してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("データを更新しました。",
                                "更新",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        //再読込みボタン
        private void button3_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            string strSQL2 = "";
            string strSQL3 = "";
            string strSQL4 = "";
            string strSQL5 = "";
            string strSQL6 = "";
            string strSQL7 = "";
            string strSQL8 = "";


            OleDbCommand cmd = null;
            OleDbCommand cmd2 = null;
            OleDbCommand cmd3 = null;
            OleDbCommand cmd4 = null;
            OleDbCommand cmd5 = null;
            OleDbCommand cmd6 = null;
            OleDbCommand cmd7 = null;
            OleDbCommand cmd8 = null;


            OleDbDataReader dr = null;
            OleDbDataReader dr2 = null;
            OleDbDataReader dr3 = null;
            OleDbDataReader dr4 = null;
            OleDbDataReader dr5 = null;
            OleDbDataReader dr6 = null;
            OleDbDataReader dr7 = null;
            OleDbDataReader dr8 = null;

            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    {
                        //データの再読込み
                        strSQL = "SELECT * FROM MASTER WHERE MASID = 1";
                        strSQL2 = "SELECT * FROM MASTER WHERE MASID = 3";
                        strSQL3 = "SELECT * FROM MASTER WHERE MASID = 4";
                        strSQL4 = "SELECT * FROM MASTER WHERE MASID = 5";
                        strSQL5 = "SELECT * FROM MASTER WHERE MASID = 6";
                        strSQL6 = "SELECT * FROM MASTER WHERE MASID = 7";
                        strSQL7 = "SELECT * FROM MASTER WHERE MASID = 2";
                        strSQL8 = "SELECT * FROM MASTER WHERE MASID = 8";


                        cmd = new OleDbCommand(strSQL, cn);
                        cmd2 = new OleDbCommand(strSQL2, cn);
                        cmd3 = new OleDbCommand(strSQL3, cn);
                        cmd4 = new OleDbCommand(strSQL4, cn);
                        cmd5 = new OleDbCommand(strSQL5, cn);
                        cmd6 = new OleDbCommand(strSQL6, cn);
                        cmd7 = new OleDbCommand(strSQL7, cn);
                        cmd8 = new OleDbCommand(strSQL8, cn);


                        dr = cmd.ExecuteReader();
                        dr2 = cmd2.ExecuteReader();
                        dr3 = cmd3.ExecuteReader();
                        dr4 = cmd4.ExecuteReader();
                        dr5 = cmd5.ExecuteReader();
                        dr6 = cmd6.ExecuteReader();
                        dr7 = cmd7.ExecuteReader();
                        dr8 = cmd8.ExecuteReader();


                        dr.Read();
                        dr2.Read();
                        dr3.Read();
                        dr4.Read();
                        dr5.Read();
                        dr6.Read();
                        dr7.Read();
                        dr8.Read();


                        textBox1.Text = dr["MASINFO1"].ToString();
                        textBox6.Text = dr2["MASINFO1"].ToString();
                        textBox7.Text = dr3["MASINFO1"].ToString();
                        textBox8.Text = dr4["MASINFO1"].ToString();
                        textBox9.Text = dr5["MASINFO1"].ToString();
                        textBox10.Text = dr6["MASINFO1"].ToString();
                        textBox11.Text = dr7["MASINFO1"].ToString();
                        textBox12.Text = dr8["MASINFO1"].ToString();


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("");
                }
                finally
                {
                    if (dr != null) dr.Close();
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private int nullcheck(TextBox textbox)
        {
            if (textbox.Text == "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
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
