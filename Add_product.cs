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

    public partial class Add_product : Form
    {
        private string strCn =
        ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        //private string strCn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sdatabase_v5.accdb";
        private OleDbConnection cn;
        private OleDbConnection cn3;
        private OleDbConnection cn4;
        private OleDbConnection cn5;
        DataTable dt = new DataTable();
        private string queryString = "select * from PRODUCT";
        private string queryString2 = "select * from STOCK";
        string strSQL = "";
        OleDbCommand cmd = null;
        OleDbDataReader dr = null;

        private menu.menu top;
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
                    
                }

                catch (Exception ex)
                {
                    //error_Disp(ex.ToString());
                }
                finally
                {
                    if (dr != null) dr.Close();

                }
            }
        }

        public void kensaku()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                using (OleDbConnection cn = new OleDbConnection(strCn))
                
                {
                    try
                    {
                        if (cn.State == ConnectionState.Closed) cn.Open();    //接続成功
                        OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, cn);
                        //OleDbDataAdapter adapter2 = new OleDbDataAdapter(queryString2, cn);

                        dt.Columns.Add("AUTID", typeof(string));
                        dt.Columns.Add("PROID", typeof(string));
                        dt.Columns.Add("PRONAME", typeof(string));
                        dt.Columns.Add("PROPRICE", typeof(string));
                        dt.Columns.Add("GENID", typeof(string));
                        dt.Columns.Add("PUBID", typeof(string));
                        dt.Columns.Add("PROCOST", typeof(string));
                        adapter.Fill(dt);
                        // adapter2.Fill(dt);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("追加に失敗しました。",
                                        "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);       //接続失敗
                    }
                    string SQL1 = "select count(PROID) as A from PRODUCT where PROID = '" + textBox2.Text + "'";


                    OleDbCommand cmd1 = new OleDbCommand(SQL1, cn);

                    OleDbDataReader dr1 = cmd1.ExecuteReader();

                    dr1.Read();

                    int x = int.Parse(dr1["A"].ToString());





                    if (x == 0)
                    {
                        //try
                        //{
                            using (OleDbConnection cn3 = new OleDbConnection(strCn))
                            using (OleDbConnection cn4 = new OleDbConnection(strCn))
                            using (OleDbConnection cn5 = new OleDbConnection(strCn))
                            
                            {
                            if (cn3.State == ConnectionState.Closed) cn3.Open();    //接続成功
                                                                                    //OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, cn3);
                            if (cn4.State == ConnectionState.Closed) cn4.Open();    //接続成功
                                                                                    //OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, cn4);
                            if (cn5.State == ConnectionState.Closed) cn5.Open();    //接続成功
                                                                                    //OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, cn4);

                            string SQL3 = "select AUTID from AUTHOR where (AUTFAMILYNAME + AUTFIRSTNAME) = '" + textBox5.Text + "' OR (AUTPHONEFAMILYNAME + AUTPHONEFIRSTNAME) = '" + textBox5.Text + "'";
                            string SQL4 = "select PUBID,PUBNAME from PUBLISER WHERE PUBNAME = '" + textBox3.Text + "' OR PUBPHONENAME = '" + textBox3.Text + "'";
                            string SQL5 = "select GENID from GENRE where GENNAME='" + comboBox1.Text + "'";
                            OleDbCommand cmd3 = new OleDbCommand(SQL3, cn3);
                            OleDbCommand cmd4 = new OleDbCommand(SQL4, cn4);
                            OleDbCommand cmd5 = new OleDbCommand(SQL5, cn5);

                            OleDbDataReader dr3 = cmd3.ExecuteReader();
                            OleDbDataReader dr4 = cmd4.ExecuteReader();
                            OleDbDataReader dr5 = cmd5.ExecuteReader();

                            dr3.Read();
                            dr4.Read();
                            dr5.Read();

                            string AUT = dr3["AUTID"].ToString();
                            string PUB = dr4["PUBID"].ToString();
                            string GEN = dr5["GENID"].ToString();
                            //データの追加
                            DataRow nr = dt.NewRow();
                            nr["PROID"] = textBox2.Text;
                            nr["PRONAME"] = textBox1.Text;
                            nr["PROPRICE"] = int.Parse(textBox8.Text);
                            nr["AUTID"] = AUT;
                            nr["GENID"] = GEN;
                            nr["PUBID"] = PUB;
                            nr["PROCOST"] = int.Parse(textBox9.Text);
                            nr["PROYEAR"] = textBox4.Text;

                            

                            dt.Rows.Add(nr);

                        }

                        try
                        {
                            using (OleDbConnection connection = new OleDbConnection(strCn))
                            {
                                connection.Open();
                                sql_Write("INSERT INTO STOCK(PROID,STOCK) VALUES('" + textBox2.Text + "',0)");
                                OleDbDataAdapter adapter = new OleDbDataAdapter(queryString, connection);
                                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                                adapter.UpdateCommand = builder.GetUpdateCommand();

                                adapter.Update(dt);

                                MessageBox.Show("商品の追加に成功しました",
                                                "",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Asterisk);

                                textBox1.Clear();
                                textBox2.Clear();
                                textBox3.Clear();
                                textBox4.Clear();
                                textBox5.Clear();
                                textBox8.Clear();
                                textBox9.Clear();
                                

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("その商品はすでに追加されています。",
                                           "エラー",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
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

        public Add_product(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "商品追加";
            textBox1.MaxLength = 100;
            textBox2.MaxLength = 26;
            textBox3.MaxLength = 5;
            textBox4.MaxLength = 4;
            textBox5.MaxLength = 6;
            textBox8.MaxLength = 6;
            textBox9.MaxLength = 6;
            comboBox1.MaxLength = 10;

            string strSQL2 = "select * from GENRE";
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;

            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    {
                        cmd = new OleDbCommand(strSQL2, cn);
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            comboBox1.Items.Add(dr["GENNAME"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            kensaku();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                
            }
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;

            }
            else

            if (e.KeyChar == (char)Keys.Enter)
            {
                kensaku();

            }

        }

        private string tbx2temp = "";
        private string tbx4temp = "";
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(int.Parse(textBox2.Text)<0)
                {
                    textBox2.Text = tbx2temp;
                }
                else
                {
                    tbx2temp = textBox2.Text;
                }
            }
            catch
            {
                textBox2.Text = "";
                tbx2temp = "";
            }
        }

        bool bookyearflag = false;
        bool priceflag = false;
        bool orderpriceflag = false;
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "")
                {
                    label1.Text = "";
                }
                if (int.Parse(textBox4.Text)>-1000)
                {
                    tbx4temp=textBox4.Text;
                    if(int.Parse(textBox4.Text) < 1900|| int.Parse(textBox4.Text)>int.Parse(DateTime.Now.AddYears(2).ToString("yyyy")))
                    {
                        textBox4.ForeColor = Color.DarkRed;
                        bookyearflag = true;
                        warnflag();
                    }
                    else
                    {
                        textBox4.ForeColor = Color.Black;
                        bookyearflag = false;
                        warnflag();
                    }
                }
                else
                {
                    tbx4temp = textBox4.Text;
                    bookyearflag = false;
                        label1.Text = "入力形式を確認後、再度入力してください。";

                }
                
            }
            catch
            {
                textBox4.Text = "";
                tbx4temp = "";
            }
        }
        private void warnflag()
        {
            label1.ForeColor = Color.DarkRed;
            if (bookyearflag==true||priceflag==true||orderpriceflag==true)
            {
                label1.Text = "赤字の箇所(";
                if (bookyearflag == true) label1.Text += " 出版年 ";
                if (priceflag == true) label1.Text += " 価格 ";
                if (orderpriceflag == true) label1.Text += " 卸値 ";


                label1.Text += ")に入力ミスがないか確認後、商品を追加してください。"+Environment.NewLine+"入力ミスでない場合、登録可能になってますので全入力後商品追加を押してください。";
            }
            else
            {
                label1.Text = "";
            }
        }

        private void pbtn_Dispose_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void pbtn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

