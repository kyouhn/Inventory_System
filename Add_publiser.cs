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


namespace syohin
{
    public partial class Add_publiser : Form
    {
        private string strCn =
        ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        //private string strCn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sdatabase_v5.accdb";
        private OleDbConnection cn;
        DataTable dt = new DataTable();
        private string queryString = "select * from PUBLISER;";
        private double nextdealno = 0;
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        private menu.menu top;

        public Add_publiser(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }

        private string sql_Load(string sqlcode, string data)
        {
            string strSQL = sqlcode;
            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {

                    if (cn.State == ConnectionState.Closed)
                    {
                        cn.Open();
                    }
                    OleDbCommand cmd = new OleDbCommand(strSQL, cn);

                    OleDbDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    return dr[data].ToString();


                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();    //接続成功
                    OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, cn);
                    dt.Columns.Add("PUBID", typeof(string));
                    dt.Columns.Add("PUBNAME", typeof(string));
                    dt.Columns.Add("PUBPHONENAME", typeof(string));

                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("出版社の追加に失敗しました");           //接続失敗
                }

                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    if ((System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, @"^[ア-ン,ァ-ョ,ー,-]*$")))
                    {

                        //「はい」が選択された時                                              
                        try
                        {
                            using (OleDbConnection connection = new OleDbConnection(strCn))
                            {
                                string SQL1 = "select count(PUBNAME) as C from PUBLISER where PUBNAME = '" + textBox2.Text + "'";

                                OleDbCommand cmd1 = new OleDbCommand(SQL1, cn);
                                OleDbDataReader dr1 = cmd1.ExecuteReader();
                                dr1.Read();
                                int x = int.Parse(dr1["C"].ToString());


                                string SQL2 = "select count(PUBPHONENAME) as CO from PUBLISER where PUBPHONENAME = '" + textBox3.Text + "'";

                                OleDbCommand cmd2 = new OleDbCommand(SQL2, cn);
                                OleDbDataReader dr2 = cmd2.ExecuteReader();
                                dr2.Read();
                                int y = int.Parse(dr2["CO"].ToString());

                                if (x == 0 || y == 0)
                                {
                                    //データの追加
                                    DataRow nr = dt.NewRow();
                                    nextdealno = int.Parse(sql_Load("SELECT MAX(PUBID) AS PUBID FROM  PUBLISER;", "PUBID"));
                                    nr["PUBID"] = String.Format("{0:00000}", nextdealno + 1);
                                    nr["PUBNAME"] = textBox2.Text;
                                    nr["PUBPHONENAME"] = textBox3.Text;
                                    dt.Rows.Add(nr);

                                    connection.Open();

                                    OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, connection);
                                    OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                                    adapter.UpdateCommand = builder.GetUpdateCommand();

                                    adapter.Update(dt);

                                    MessageBox.Show("出版社の追加に成功しました。",
                                                    "",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Asterisk);

                                    textBox2.Clear();
                                    textBox3.Clear();
                                    connection.Close();
                                    cn.Close();
                                }

                                else
                                {
                                    MessageBox.Show("その出版社はすでに追加されています。",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                    textBox2.Clear();
                                    textBox3.Clear();
                                    connection.Close();
                                    cn.Close();

                                }
                            }
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }


                

                else
                {
                    MessageBox.Show("フリガナはカナ文字で入力してください",
                                    "エラー",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
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
        }
            
        
    

        private void button2_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void Publiser_Load(object sender, EventArgs e)
        {
            this.Text = "出版社追加";
            textBox2.MaxLength = 24;
            textBox3.MaxLength = 32;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                textBox3.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        string tbx3temp = "";
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "") tbx3temp = "";
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text,
            @"^[\p{IsKatakana}\u31F0-\u31FF\u3099-\u309C\uFF65-\uFF9F]+$"))
            {
                tbx3temp = textBox3.Text;
            }
            else
            {
                textBox3.Text = tbx3temp;
                textBox3.Focus();
            }
        }
    }
}
