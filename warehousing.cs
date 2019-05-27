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

namespace nyuko
{
    public partial class Warehousing : Form
    {
        private void kensaku()
        {
            if (textBox2.Text != "")
            {
                OleDbCommand cmd2 = null;
                OleDbCommand cmd3 = null;
                OleDbDataReader dr = null;
                OleDbDataReader dr2 = null;
                OleDbDataReader dr3 = null;

                try
                {
                    DataView dView = new DataView(dTbl);
                    dView.RowFilter = "入庫番号  ='" + textBox2.Text + "'";
                    dataGridView1.DataSource = dView;
                    dataGridView1.AutoResizeColumns();
                    dataGridView1.AutoResizeRows();


                }

                catch (Exception ex)
                {
                    label5.Text = "";
                    label20.Text = "";
                    MessageBox.Show(ex.Message);
                }




                using (OleDbConnection cn = new OleDbConnection(strCn))
                {
                    try
                    {
                        if (cn.State == ConnectionState.Closed) cn.Open();
                        {
                            strSQL2 = "SELECT * FROM RECEIVE WHERE RECID ='" + textBox2.Text + "'";
                            cmd2 = new OleDbCommand(strSQL2, cn);
                            dr2 = cmd2.ExecuteReader();
                            dr2.Read();
                            strSQL3 = "SELECT * FROM PURCHASE WHERE PURID ='" + dr2["PURID"] + "'";
                            cmd3 = new OleDbCommand(strSQL3, cn);
                            dr3 = cmd3.ExecuteReader();
                            dr3.Read();
                            DateTime date = DateTime.Parse(dr2["RECDAY"].ToString());

                            //表示させる
                            label5.Text = date.ToString("yyyy/MM/dd");
                            label20.Text = dr3["PURID"].ToString();

                            int i = dView.Count;
                            if (i >= 1)
                            {
                                label5.Text = "";
                                label20.Text = "";
                            }
                            i = 0;
                        }
                    }
                    catch (Exception)
                    {
                        label5.Text = "";
                        label20.Text = "";
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
        private OleDbDataAdapter da = new OleDbDataAdapter();
        private DataSet ds = new DataSet();
        private DataTable dTbl = null;
        private DataView dView = new DataView();
        private string strSQL = "";
        private string strSQL2 = "";
        private string strSQL3 = "";
        private menu.menu top;

        public Warehousing(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            kensaku();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //読み取り専用
            dataGridView1.ReadOnly = true;
        }

        private void Warehousing_Load(object sender, EventArgs e)
        {
            this.Text = "入庫検索";
            strSQL = "SELECT RECEIVE.RECID AS 入庫番号,PRODUCT.PROID AS 商品番号,PRODUCT.PRONAME AS 商品名, PRODUCT.PROCOST AS 入荷価格, STOCK.STOCK AS 在庫数 FROM (((( PRODUCT INNER JOIN PURCHASEDETAIL ON PURCHASEDETAIL.PROID = PRODUCT.PROID) INNER JOIN PURCHASE ON PURCHASEDETAIL.PURID = PURCHASE.PURID) INNER JOIN RECEIVE ON PURCHASE.PURID = RECEIVE.PURID) INNER JOIN STOCK ON PRODUCT.PROID = STOCK.PROID) ";
            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand(strSQL, cn);

                    da.SelectCommand = cmd;

                    da.Fill(ds, "PRODUCT");

                    dTbl = ds.Tables["PRODUCT"];

                    dataGridView1.DataSource = ds;

                    dataGridView1.DataMember = dTbl.TableName;

                    dataGridView1.AutoResizeColumns();

                    dataGridView1.AutoResizeRows();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
