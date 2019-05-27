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
    public partial class Product : Form
    {
        private void kensaku()
        {
            string strSQL = "";
            string strSQL2 = "";

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
                OleDbDataReader dr = null;
                OleDbDataReader dr2 = null;
                using (OleDbConnection cn = new OleDbConnection(strCn))
                {
                    try
                    {
                        if (cn.State == ConnectionState.Closed) cn.Open();
                        {
                            cmd = new OleDbCommand(strSQL, cn);
                            dr = cmd.ExecuteReader();
                            dr.Read();


                            strSQL2 = "SELECT * FROM (((( PRODUCT INNER JOIN STOCK ON PRODUCT.PROID = STOCK.PROID ) INNER JOIN GENRE on PRODUCT.GENID = GENRE.GENID )  INNER JOIN PUBLISER on PRODUCT.PUBID = PUBLISER.PUBID ) INNER JOIN AUTHOR on PRODUCT.AUTID = AUTHOR.AUTID )  where PRODUCT.PROID ='" + textBox2.Text + "' or PRODUCT.PRONAME = '" + textBox1.Text + "' or PRODUCT.PROID = '" + textBox2.Text + "' and PRODUCT.PRONAME = '" + textBox1.Text + "'";

                            cmd2 = new OleDbCommand(strSQL2, cn);
                            dr2 = cmd2.ExecuteReader();
                            dr2.Read();




                            textBox1.Text = dr["PRONAME"].ToString();
                            textBox2.Text = dr["PROID"].ToString();
                            label8.Text = dr2["PUBNAME"].ToString();
                            label9.Text = dr2["AUTFAMILYNAME"].ToString() + dr2["AUTFIRSTNAME"].ToString();
                            label10.Text = dr2["GENNAME"].ToString();
                            label14.Text = dr2["STOCK"].ToString();
                            label15.Text = dr["PROPRICE"].ToString();
                            label18.Text = dr["PROYEAR"].ToString();
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

        public Product(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }

        private void button3_Click(object sender, EventArgs e)
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
            this.Text = "商品検索";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                kensaku();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;

            }
            else
            if (textBox2.Text.Length != 13)
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    kensaku();
                }
            }
            if (e.KeyChar == (char)Keys.Back)//BackSpace時の処理
            {
                e.Handled = false;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
