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
    public partial class Add_author : Form
    {
        //private string strCn =
        //ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        private string strCn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sdatabase_final.accdb";
        private OleDbConnection cn;
        DataTable dt = new DataTable();
        private string queryString = "select * from AUTHOR";
        private double nextdealno = 0;
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        private menu.menu top;


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
                finally
                {

                }
            }
        }          

        public Add_author(menu.menu top2)
        {
            InitializeComponent();
            top = top2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                   
                        if (cn.State == ConnectionState.Closed) cn.Open();    //接続成功
                        OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, cn);
                        dt.Columns.Add("AUTID", typeof(string));
                        dt.Columns.Add("AUTFAMILYNAME", typeof(string));
                        dt.Columns.Add("AUTFIRSTNAME", typeof(string));
                        dt.Columns.Add("AUTPHONEFAMILYNAME", typeof(string));
                        dt.Columns.Add("AUTPHONEFIRSTNAME", typeof(string));                       
                        adapter.Fill(dt);
                    
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message);          //接続失敗
                }
              
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    if ((System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, @"^[ア-ン,ァ-ョ,ー,-]*$")))
                    {
                        if ((System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, @"^[ア-ン,ァ-ョ,ー,-]*$")))
                        {
                            try
                            {


                                using (OleDbConnection connection = new OleDbConnection(strCn))
                                {

                                    string SQL1 = "select count(AUTFAMILYNAME) as A from AUTHOR where AUTFAMILYNAME = '" + textBox2.Text + "'";

                                    OleDbCommand cmd1 = new OleDbCommand(SQL1, cn);
                                    OleDbDataReader dr1 = cmd1.ExecuteReader();
                                    dr1.Read();
                                    int x = int.Parse(dr1["A"].ToString());

                                    string SQL2 = "select count(AUTFIRSTNAME) as B from AUTHOR where AUTFIRSTNAME = '" + textBox3.Text + "'";

                                    OleDbCommand cmd2 = new OleDbCommand(SQL2, cn);
                                    OleDbDataReader dr2 = cmd2.ExecuteReader();
                                    dr2.Read();
                                    int y = int.Parse(dr2["B"].ToString());

                                    string SQL3 = "select count(AUTPHONEFAMILYNAME) as C from AUTHOR where AUTPHONEFAMILYNAME = '" + textBox4.Text + "'";

                                    OleDbCommand cmd3 = new OleDbCommand(SQL3, cn);
                                    OleDbDataReader dr3 = cmd3.ExecuteReader();
                                    dr3.Read();
                                    int z = int.Parse(dr3["C"].ToString());

                                    string SQL4 = "select count(AUTPHONEFIRSTNAME) as D from AUTHOR where AUTPHONEFIRSTNAME = '" + textBox5.Text + "'";

                                    OleDbCommand cmd4 = new OleDbCommand(SQL4, cn);
                                    OleDbDataReader dr4 = cmd4.ExecuteReader();
                                    dr4.Read();
                                    int p = int.Parse(dr4["D"].ToString());

                                    if (x == 0 || y == 0 || z == 0 || p == 0)
                                    {

                                        //テーブルの追加
                                        DataRow nr = dt.NewRow();
                                        nextdealno = int.Parse(sql_Load("SELECT MAX(AUTID) AS AUTID FROM AUTHOR;", "AUTID"));
                                        nr["AUTID"] = String.Format("{0:000000}", nextdealno + 1);
                                        nr["AUTFAMILYNAME"] = textBox2.Text;
                                        nr["AUTFIRSTNAME"] = textBox3.Text;
                                        nr["AUTPHONEFAMILYNAME"] = textBox4.Text;
                                        nr["AUTPHONEFIRSTNAME"] = textBox5.Text;
                                        dt.Rows.Add(nr);

                                        connection.Open();

                                        OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, connection);
                                        OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                                        adapter.UpdateCommand = builder.GetUpdateCommand();

                                        adapter.Update(dt);

                                        MessageBox.Show("著者の追加に成功しました。",
                                                        "",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Asterisk);


                                        textBox2.Clear();
                                        textBox3.Clear();
                                        textBox4.Clear();
                                        textBox5.Clear();
                                        cn.Close();
                                        connection.Close();
                                    }


                                    else
                                    {
                                        MessageBox.Show("その著者はすでに追加されています。",
                                        "エラー",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);

                                        textBox2.Clear();
                                        textBox3.Clear();
                                        textBox4.Clear();
                                        textBox5.Clear();
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
                                     MessageBoxIcon.Error);
                }
            }
        }

        private void Author_Load(object sender, EventArgs e)
        {
            this.Text = "著者追加";
            textBox2.MaxLength = 32;
            textBox3.MaxLength = 32;
            textBox4.MaxLength = 64;
            textBox5.MaxLength = 64;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
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
                textBox4.Focus();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                textBox5.Focus();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void lbl_Menu_Click(object sender, EventArgs e)
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

        private void panel_Top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        string tbx4tmp = "";
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") tbx4tmp = "";
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text,
            @"^[\p{IsKatakana}\u31F0-\u31FF\u3099-\u309C\uFF65-\uFF9F]+$"))
            {
                tbx4tmp = textBox4.Text;
            }
            else
            {
                textBox4.Text = tbx4tmp;
            }
        }

        string tbx5tmp = "";
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "") tbx5tmp = "";
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5 .Text,
                @"^[\p{IsKatakana}\u31F0-\u31FF\u3099-\u309C\uFF65-\uFF9F]+$"))
            {
                tbx5tmp = textBox5.Text;
            }
            else
            {
                textBox5.Text = tbx5tmp;
            }
        }
    }
}

