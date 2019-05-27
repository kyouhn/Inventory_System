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
namespace menu
{
    public partial class Purchase : Form
    {
        private string strCn =
       ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        private OleDbDataAdapter da = new OleDbDataAdapter();
        private DataSet ds = new DataSet();
        private DataTable dTbl = null;
        private DataView dView = new DataView();

        int SUM_PURPIECE = 0;
        private menu top;

        public Purchase(menu top2)
        {
            InitializeComponent();
            top = top2;
        }
        private void search()
        {
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;
            OleDbCommand cmd2 = null;
            OleDbDataReader dr2 = null;

            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                //textBox1が空白でないなら
                if (textBox1.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "発注番号 like '" + textBox1.Text + "%'";
                        dView.Sort = "発注明細 asc";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("値が間違っています正しい値を入力してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                }
            }

            string strSQL2 = "";  //宣言
            strSQL2 = "SELECT * FROM ((((PURCHASEDETAIL INNER JOIN PURCHASE ON PURCHASEDETAIL.PURID = PURCHASE.PURID) INNER JOIN PRODUCT ON PURCHASEDETAIL.PROID = PRODUCT.PROID) INNER JOIN RECEIVE ON PURCHASE.PURID = RECEIVE.PURID) INNER JOIN STOCK ON PRODUCT.PROID = STOCK.PROID) where PURCHASEDETAIL.PURID like '%" + textBox1.Text + "%'";
            string strSQL3 = "";  //宣言
            strSQL3 = "SELECT * FROM ((((PURCHASEDETAIL INNER JOIN PURCHASE ON PURCHASEDETAIL.PURID = PURCHASE.PURID) INNER JOIN PRODUCT ON PURCHASEDETAIL.PROID = PRODUCT.PROID) INNER JOIN RECEIVE ON PURCHASE.PURID = RECEIVE.PURID) INNER JOIN STOCK ON PRODUCT.PROID = STOCK.PROID) where PURCHASEDETAIL.PURID like '%" + textBox1.Text + "%'";

            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    {

                        cmd = new OleDbCommand(strSQL2, cn);
                        dr = cmd.ExecuteReader();
                        cmd2 = new OleDbCommand(strSQL3, cn);
                        dr2 = cmd2.ExecuteReader();
                        dr2.Read();
                        int i = 0;

                        while (dr.Read())
                        {
                            SUM_PURPIECE += int.Parse(dr["PURPIECE"].ToString());
                            i++;
                        }

                        label7.Text = dr2["PURDAY"].ToString();
                        label9.Text = dr2["RECDAYPLAN"].ToString();
                        label6.Text = SUM_PURPIECE.ToString();

                        if (i != 1)
                        {
                            label7.Text = "";
                            label9.Text = "";
                            label6.Text = "";
                        }

                        SUM_PURPIECE = 0;
                    }
                }
                catch (Exception ex)
                {
                    label6.Text = "";
                    label7.Text = "";
                    label9.Text = "";

                    MessageBox.Show("値が間違っています正しい値を入力してください。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }

            if (textBox1.Text == "")
            {
                try
                {
                    

                }

                catch (Exception ex)
                {
                    MessageBox.Show("値が間違っています正しい値を入力してください。",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }

        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            search();
        }
        private void Purchase_Load(object sender, EventArgs e)
        {
            this.Text = "発注検索";
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.FormBorderStyle = FormBorderStyle.None;

            string strSQL = "";  //宣言
            string strSQL2 = "";  //宣言
            strSQL2 = "SELECT * FROM ((((PURCHASEDETAIL INNER JOIN PURCHASE ON PURCHASEDETAIL.PURID = PURCHASE.PURID) INNER JOIN PRODUCT ON PURCHASEDETAIL.PROID = PRODUCT.PROID) INNER JOIN RECEIVE ON PURCHASE.PURID = RECEIVE.PURID) INNER JOIN STOCK ON PRODUCT.PROID = STOCK.PROID)";
            OleDbCommand cmd2 = null;
            OleDbDataReader dr2 = null;

            //SQL文
            strSQL = "SELECT PURCHASEDETAIL.PURDETID AS 発注明細 , PURCHASE.PURID AS 発注番号, PURCHASEDETAIL.PROID AS 商品番号 , PRODUCT.PRONAME AS 商品名 , STOCK.STOCK AS 在庫数 , PURCHASEDETAIL.PURPIECE AS 発注数 FROM ((((PURCHASEDETAIL INNER JOIN PURCHASE ON PURCHASEDETAIL.PURID = PURCHASE.PURID) INNER JOIN PRODUCT ON PURCHASEDETAIL.PROID = PRODUCT.PROID) INNER JOIN RECEIVE ON PURCHASE.PURID = RECEIVE.PURID) INNER JOIN STOCK ON PRODUCT.PROID = STOCK.PROID) order by PURCHASEDETAIL.PURDETID desc";

            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand(strSQL, cn);

                    da.SelectCommand = cmd;

                    da.Fill(ds, "PURCHASEDETAIL");

                    dTbl = ds.Tables["PURCHASEDETAIL"];

                    dataGridView1.DataSource = ds;

                    dataGridView1.DataMember = dTbl.TableName;

                    dataGridView1.AutoResizeColumns();

                    dataGridView1.AutoResizeRows();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                using (OleDbConnection cn2 = new OleDbConnection(strCn))
                {
                    try
                    {
                        if (cn2.State == ConnectionState.Closed) cn2.Open();
                        {

                            cmd2 = new OleDbCommand(strSQL2, cn2);
                            dr2 = cmd2.ExecuteReader();

                            while (dr2.Read())
                            {
                                SUM_PURPIECE += int.Parse(dr2["PURPIECE"].ToString());
                            }
                        }
                        label6.Text = SUM_PURPIECE.ToString();
                        SUM_PURPIECE = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("値が間違っています正しい値を入力してください。",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                search();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //読み取り専用
            dataGridView1.ReadOnly = true;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strSQL2 = "";  //宣言
            strSQL2 = "SELECT * FROM ((((PURCHASEDETAIL INNER JOIN PURCHASE ON PURCHASEDETAIL.PURID = PURCHASE.PURID) INNER JOIN PRODUCT ON PURCHASEDETAIL.PROID = PRODUCT.PROID) INNER JOIN RECEIVE ON PURCHASE.PURID = RECEIVE.PURID) INNER JOIN STOCK ON PRODUCT.PROID = STOCK.PROID)";
            OleDbCommand cmd2 = null;
            OleDbDataReader dr2 = null;

            try
            {
                DataView dView = new DataView(dTbl);
                dView.Sort = "";
                dView.RowFilter = "";
                dataGridView1.DataSource = dView;
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();
                label6.Text = "";
                label7.Text = "";
                label9.Text = "";
                textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            using (OleDbConnection cn2 = new OleDbConnection(strCn))
            {
                try
                {
                    if (cn2.State == ConnectionState.Closed) cn2.Open();
                    {

                        cmd2 = new OleDbCommand(strSQL2, cn2);
                        dr2 = cmd2.ExecuteReader();

                        while (dr2.Read())
                        {
                            SUM_PURPIECE += int.Parse(dr2["PURPIECE"].ToString());
                        }
                    }
                    label6.Text = SUM_PURPIECE.ToString();
                    SUM_PURPIECE = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
