using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_System;

namespace menu
{
    public partial class Search : Form
    {
        private menu top;
        public Search(menu top2)
        {
            InitializeComponent();
            top = top2;
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            //別フォームを生成するときに、自フォーム(スタートアップフォーム)を渡す
            //syohin.Product product = new syohin.Product(this);
            //product.Show(this);

            //スタートアップフォームを隠す
            //スタートアップフォームは閉じるとアプリケーションが終了するので注意
            //this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //別フォームを生成するときに、自フォーム(スタートアップフォーム)を渡す
            //stock_2.stock_2 stock = new stock_2.stock_2(this);
            //stock.Show(this);

            //スタートアップフォームを隠す
            //スタートアップフォームは閉じるとアプリケーションが終了するので注意
            //this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        { /*
         wassyoi.Order order = new wassyoi.Order(this);
         order.Show(this);

         this.Hide();     
         */
        }

        private void button4_Click_1(object sender, EventArgs e)
        {/*
        nyuko.Warehousing ware = new nyuko.Warehousing(this);
        ware.Show(this);
        this.Hide();
        */
    }

        private void button5_Click_1(object sender, EventArgs e)
        {/*
            uriage.Sales sales = new uriage.Sales(this);
            sales.Show(this);

            this.Hide();
            */
        }

        public string memnum = "";
        private void button6_Click_1(object sender, EventArgs e)
        {
            //kaiin.Member_management member = new kaiin.Member_management(/*this*/);
            //member.ShowDialog(/*this*/);
            //this.Hide();
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*
            Purchase pur = new Purchase(this);
            pur.Show(this);

            this.Hide();
            */
        }

        private void Search_Load(object sender, EventArgs e)
        {
            this.Text = "メニュー";
        }

        public static implicit operator Search(Form1 v)
        {
            throw new NotImplementedException();
        }
    }
}
