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

namespace wassyoi
{
    public partial class Order : Form
    {
        private string strCn = 
        ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        private OleDbConnection cn;
        private menu.menu top;
        private OleDbDataAdapter da = new OleDbDataAdapter();
        private DataSet ds = new DataSet();
        private DataTable dTbl = null;



        public Order(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }

        private void kensaku()
        {
            //一回初期化
            ds.Clear();


            string strSQL = "select PRODUCT.PROID as 商品番号,PRODUCT.PRONAME as 商品名,DETAIL.ORDPIECE as 冊数,PRODUCT.PROCOST as 単価 from ((DEAL inner join DETAIL on DEAL.DEAID = DETAIL.DEAID) inner join PRODUCT on DETAIL.PROID = PRODUCT.PROID) where DEAL.DEAID = '" + textBox1.Text + "'";

            if (textBox1.Text == "")
            {
                MessageBox.Show("注文番号を入力してください。");
            }

            OleDbDataReader dr = null;
            OleDbCommand cmd2 = null;
            OleDbDataReader dr2 = null;


            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    OleDbCommand cmd0 = null;
                    cmd0 = new OleDbCommand(strSQL, cn);
                    da.SelectCommand = cmd0;
                    da.Fill(ds, "DEAL");
                    dTbl = ds.Tables["DEAL"];
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = dTbl.TableName;
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoResizeRows();


                    if (cn.State == ConnectionState.Closed) cn.Open();
                    {
                        //注文日、会員番号、会員名を出す。
                        //dr = cmd0.ExecuteReader();
                        cmd0.Parameters.Add("@DEAID", OleDbType.VarChar).Value = textBox1.Text;
                        dr = cmd0.ExecuteReader();
                        dr.Read();
                        string strSQL2 = "select * from  MEMBER inner join DEAL on (DEAL.MEMID = MEMBER.MEMID) where DEAID = '" + textBox1.Text + "'";
                        cmd2 = new OleDbCommand(strSQL2, cn);
                        dr2 = cmd2.ExecuteReader();
                        dr2.Read();


                        label7.Text = dr2["DEADAY"].ToString();
                        label9.Text = dr2["MEMBER.MEMID"].ToString();
                        label10.Text = dr2["MEMFAMILYNAME"].ToString() + dr2["MEMFIRSTNAME"].ToString();

                        int piece_sum = 0;   //個数合計を入れる
                        int sum_money = 0;   //金額合計を入れる

                        int sum = 0;         //全ての個数合計を入れる
                        int money = 0;       //全ての金額合計を入れる

                        //各合計をlabelに表示する
                        do
                        {
                            piece_sum = int.Parse(dr["冊数"].ToString());
                            sum_money = int.Parse(dr["冊数"].ToString()) * int.Parse(dr["単価"].ToString());
                            sum += piece_sum;
                            money += sum_money;
                        }

                        while (dr.Read());

                        label13.Text = sum.ToString();
                        label14.Text = money.ToString();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

                finally
                {
                    if (dr != null) dr.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kensaku();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //基本のデータベースアクセスのコード
            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();

                    //データベースの処理

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //読み取り専用
            dataGridView1.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void pbtn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            top.Show();
        }

        private void pbtn_Dispose_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }
    }
}
