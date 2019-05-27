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


namespace stock_2
{
    public partial class stock_2 : Form
    {
        private string strCn =
        ConfigurationManager.ConnectionStrings["MyOrder.Properties.Settings.Setting"].ConnectionString;
        private OleDbDataAdapter da = new OleDbDataAdapter();
        private DataSet ds = new DataSet();
        private DataTable dTbl = null;
        private DataView dView = new DataView();
        private menu.menu top;
        public stock_2(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }
        private void kensaku()
        {
            OleDbCommand cmd = null;
            OleDbDataReader dr = null;

            //textBox1.Text = "";




            using (OleDbConnection cn = new OleDbConnection(strCn))
            {
                //textBox1が空白でないなら
                if (textBox1.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 LIKE '" + textBox1.Text + "%'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                //textBox2が空白でないなら
                if (textBox2.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品名 LIKE '" + textBox2.Text + "%'";
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                //textBox3が空白でないなら
                if (textBox3.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "ジャンル LIKE '" + textBox3.Text + "%'";
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                //textBox4が空白でないなら
                if (textBox4.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "著者 LIKE '" + textBox4.Text + "%'";
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                //textBox5が空白でないなら
                if (textBox5.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "出版社 LIKE '" + textBox5.Text + "%'";
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                //textBox7とtextBox8が空白でないなら
                if (textBox7.Text != "" && textBox8.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "入荷価格" + "<=" + textBox8.Text + " AND " + textBox7.Text + " <= " + "入荷価格";
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox7.Text != "" && textBox8.Text == "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = textBox7.Text + " <= " + "入荷価格";
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox7.Text == "" && textBox8.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "入荷価格" + "<=" + textBox8.Text;
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                //textBox9とtextBox10が空白でないなら
                if (textBox9.Text != "" && textBox10.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "販売価格" + "<=" + textBox10.Text + " AND " + textBox9.Text + " <= " + "販売価格";
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox9.Text != "" && textBox10.Text == "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = textBox9.Text + " <= " + "販売価格";
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox9.Text == "" && textBox10.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "販売価格" + "<=" + textBox10.Text;
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                //textBox11とtextBox12が空白でないなら
                if (textBox11.Text != "" && textBox12.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "出版年" + "<=" + textBox12.Text + " AND " + textBox11.Text + " <= " + "出版年";
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                    /*
                    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "")
                    {


                    }*/
                    /*  textBox1.Text = "";
                      textBox2.Text = "";
                      textBox3.Text = "";
                      textBox4.Text = "";
                      textBox5.Text = "";
                      textBox7.Text = "";
                      textBox8.Text = "";
                      textBox9.Text = "";
                      textBox10.Text = "";
                      textBox11.Text = "";
                      textBox12.Text = "";*/

                }
                else if (textBox11.Text != "" && textBox12.Text == "")
                {
                    DateTime sydate = DateTime.Now;
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "出版年" + "<=" + sydate.ToString("yyyy") + " AND " + textBox11.Text + " <= " + "出版年";
                        dataGridView1.DataSource = dView;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.AutoResizeRows();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                //textBoxに2つ以上入力されたときの条件
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND 商品名 = '" + textBox2.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox1.Text != "" && textBox3.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND ジャンル = '" + textBox3.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                }
                else if (textBox1.Text != "" && textBox3.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND ジャンル = '" + textBox3.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                }
                else if (textBox1.Text != "" && textBox4.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND 著者 = '" + textBox4.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                }
                else if (textBox1.Text != "" && textBox5.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND 出版社 = '" + textBox5.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                }
                else if (textBox1.Text != "" && textBox7.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND 入荷価格 >= '" + textBox7.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                }
                else if (textBox1.Text != "" && textBox8.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND 入荷価格 <= '" + textBox8.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                }
                else if (textBox1.Text != "" && textBox9.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND 販売価格 >= '" + textBox9.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                }
                else if (textBox1.Text != "" && textBox10.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND 販売価格 <= '" + textBox10.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                }
                else if (textBox1.Text != "" && textBox11.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND 出版年 >= '" + textBox11.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                }
                else if (textBox1.Text != "" && textBox12.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品番号 = '" + textBox1.Text + "'" + "AND 出版年 <= '" + textBox12.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }

                }

                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品名 = '" + textBox2.Text + "'" + "AND ジャンル = '" + textBox3.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox2.Text != "" && textBox4.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品名 = '" + textBox2.Text + "'" + "AND 著者 = '" + textBox4.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox2.Text != "" && textBox5.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品名 = '" + textBox2.Text + "'" + "AND 出版社 = '" + textBox5.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox2.Text != "" && textBox7.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品名 = '" + textBox2.Text + "'" + "AND 入荷価格 >= '" + textBox7.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox2.Text != "" && textBox8.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品名 = '" + textBox2.Text + "'" + "AND 入荷価格 <= '" + textBox8.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox2.Text != "" && textBox9.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品名 = '" + textBox2.Text + "'" + "AND 販売価格 >= '" + textBox9.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox2.Text != "" && textBox10.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品名 = '" + textBox2.Text + "'" + "AND 販売価格 <= '" + textBox10.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox2.Text != "" && textBox11.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品名 = '" + textBox2.Text + "'" + "AND 出版年 >= '" + textBox11.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox2.Text != "" && textBox12.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "商品名 = '" + textBox2.Text + "'" + "AND 出版年 <= '" + textBox12.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                if (textBox3.Text != "" && textBox4.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "ジャンル = '" + textBox3.Text + "'" + "AND 著者 = '" + textBox4.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox3.Text != "" && textBox5.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "ジャンル = '" + textBox3.Text + "'" + "AND 出版社 = '" + textBox5.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox3.Text != "" && textBox7.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "ジャンル = '" + textBox3.Text + "'" + "AND 入荷価格 >= '" + textBox7.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox3.Text != "" && textBox8.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "ジャンル = '" + textBox3.Text + "'" + "AND 入荷価格 <= '" + textBox8.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox3.Text != "" && textBox9.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "ジャンル = '" + textBox3.Text + "'" + "AND 販売価格 >= '" + textBox9.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox3.Text != "" && textBox10.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "ジャンル = '" + textBox3.Text + "'" + "AND 販売価格 <= '" + textBox10.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox3.Text != "" && textBox11.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "ジャンル = '" + textBox3.Text + "'" + "AND 出版年 >= '" + textBox11.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox3.Text != "" && textBox12.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "ジャンル = '" + textBox3.Text + "'" + "AND 出版年 <= '" + textBox12.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                if (textBox4.Text != "" && textBox5.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "著者 = '" + textBox4.Text + "'" + "AND 出版社 = '" + textBox5.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox4.Text != "" && textBox7.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "著者 = '" + textBox4.Text + "'" + "AND 入荷価格 >= '" + textBox7.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox4.Text != "" && textBox8.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "著者 = '" + textBox4.Text + "'" + "AND 入荷価格 <= '" + textBox8.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox4.Text != "" && textBox9.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "著者 = '" + textBox4.Text + "'" + "AND 販売価格 >= '" + textBox9.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox4.Text != "" && textBox10.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "著者 = '" + textBox4.Text + "'" + "AND 販売価格 <= '" + textBox10.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox4.Text != "" && textBox11.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "著者 = '" + textBox4.Text + "'" + "AND 出版年 >= '" + textBox11.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox4.Text != "" && textBox12.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "著者 = '" + textBox4.Text + "'" + "AND 出版年 <= '" + textBox12.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                if (textBox5.Text != "" && textBox7.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "出版社 = '" + textBox5.Text + "'" + "AND 入荷価格 >= '" + textBox7.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox5.Text != "" && textBox8.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "出版社 = '" + textBox5.Text + "'" + "AND 入荷価格 <= '" + textBox8.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox5.Text != "" && textBox9.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "出版社 = '" + textBox5.Text + "'" + "AND 販売価格 >= '" + textBox9.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox5.Text != "" && textBox10.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "出版社 = '" + textBox5.Text + "'" + "AND 販売価格 <= '" + textBox10.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox5.Text != "" && textBox11.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "出版社 = '" + textBox5.Text + "'" + "AND 出版年 >= '" + textBox11.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox5.Text != "" && textBox12.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "出版社 = '" + textBox5.Text + "'" + "AND 出版年 <= '" + textBox12.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                if (textBox7.Text != "" && textBox9.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "入荷価格 >= '" + textBox7.Text + "'" + "AND 販売価格 >= '" + textBox9.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox7.Text != "" && textBox10.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "入荷価格 >= '" + textBox7.Text + "'" + "AND 販売価格 <= '" + textBox10.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox7.Text != "" && textBox11.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "入荷価格 >= '" + textBox7.Text + "'" + "AND 出版年 >= '" + textBox11.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox7.Text != "" && textBox12.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "入荷価格 >= '" + textBox7.Text + "'" + "AND 出版年 <= '" + textBox12.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                if (textBox8.Text != "" && textBox9.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "入荷価格 <= '" + textBox8.Text + "'" + "AND 販売価格 >= '" + textBox9.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox8.Text != "" && textBox10.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "入荷価格 <= '" + textBox8.Text + "'" + "AND 販売価格 <= '" + textBox10.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox8.Text != "" && textBox11.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "入荷価格 <= '" + textBox8.Text + "'" + "AND 出版年 >= '" + textBox11.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox8.Text != "" && textBox12.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "入荷価格 <= '" + textBox8.Text + "'" + "AND 出版年 <= '" + textBox12.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                if (textBox9.Text != "" && textBox11.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "販売価格 >= '" + textBox9.Text + "'" + "AND 出版年 >= '" + textBox11.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox9.Text != "" && textBox12.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "販売価格 >= '" + textBox9.Text + "'" + "AND 出版年 <= '" + textBox12.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                if (textBox10.Text != "" && textBox11.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "販売価格 <= '" + textBox10.Text + "'" + "AND 出版年 >= '" + textBox11.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }
                else if (textBox10.Text != "" && textBox12.Text != "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.RowFilter = "販売価格 <= '" + textBox10.Text + "'" + "AND 出版年 <= '" + textBox12.Text + "'";
                        dataGridView1.DataSource = dView;
                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        MessageBox.Show("値を入力してください。",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
                    }
                }

                if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox7.Text == "" && textBox8.Text == "" && textBox9.Text == "" && textBox10.Text == "" && textBox12.Text == "")
                {
                    try
                    {
                        DataView dView = new DataView(dTbl);
                        dView.Sort = "";
                        dView.RowFilter = "";
                        dataGridView1.DataSource = dView;

                        //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
                        dataGridView1.AutoResizeColumns();
                        //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
                        dataGridView1.AutoResizeRows();
                    }



                    catch (Exception)
                    {
                        
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kensaku();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void stock_2_Load(object sender, EventArgs e)
        {
            this.Text = "在庫管理";
            //string型SQLの宣言
            string strSQL = "";
            strSQL = "SELECT PRODUCT.PROID AS 商品番号,PRODUCT.PRONAME AS 商品名,STOCK.STOCK AS 在庫数,GENRE.GENNAME AS ジャンル,AUTHOR.AUTFAMILYNAME & AUTHOR.AUTFIRSTNAME AS 著者,PUBLISER.PUBNAME AS 出版社,PRODUCT.PROCOST AS 入荷価格,PRODUCT.PROPRICE AS 販売価格,PRODUCT.PROYEAR AS 出版年 FROM (((( PRODUCT INNER JOIN STOCK ON PRODUCT.PROID = STOCK.PROID ) INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID) INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID ) INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID )";
            //string strSQL2 = "SELECT * FROM (((( PRODUCT INNER JOIN STOCK ON PRODUCT.PROID = STOCK.PROID ) INNER JOIN GENRE ON PRODUCT.GENID = GENRE.GENID) INNER JOIN AUTHOR ON PRODUCT.AUTID = AUTHOR.AUTID ) INNER JOIN PUBLISER ON PRODUCT.PUBID = PUBLISER.PUBID )";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //読み取り専用
            dataGridView1.ReadOnly = true;
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
                    if (textBox1.Text.Length == 13)
                    {
                        textBox1.Focus();
                    }
                    else
                    {
                        kensaku();
                    }
                }
                

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dView = new DataView(dTbl);
                dView.Sort = "";
                dView.RowFilter = "";
                dataGridView1.DataSource = dView;
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
