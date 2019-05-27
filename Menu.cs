using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menu
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private Button[,] autoButton = new Button[50000, 1];
        private int memo_New_Y_Location = 0;
        private int memo_Now_Number = -1;

        public int ButtonsAdd(string[] a ,int itemNumY, int itemNumX, int locationY, int locationYAdd, int[] locationX, Button[,] buttons, int defaultItemNumberY, string buttonsName, string font, Single fontSize)
        {
            int nowLocationY = locationY;
            int nowItemNumberY = defaultItemNumberY;
            for (int loopY = 0; loopY != itemNumY; loopY++)
            {
                for (int loopX = 0; loopX != itemNumX; loopX++)
                {
                    buttons[nowItemNumberY, loopX] = new Button();
                    buttons[nowItemNumberY, loopX].Name = buttonsName+ nowItemNumberY.ToString();
                    buttons[nowItemNumberY, loopX].Text = a[memo_Now_Number];//labelsName + loopY.ToString() + loopX.ToString();
                    buttons[nowItemNumberY, loopX].Font = new System.Drawing.Font(font, fontSize);
                    buttons[nowItemNumberY, loopX].Location = new System.Drawing.Point(locationX[loopX], nowLocationY);
                    buttons[nowItemNumberY, loopX].AutoSize = false;
                    buttons[nowItemNumberY, loopX].Width = 500;
                    buttons[nowItemNumberY, loopX].Height = 50;
                }
                nowLocationY += locationYAdd;
                nowItemNumberY++;
            }
            return nowLocationY;

        }//label生成するやーつ
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {

          
        }

        public void btn_Pos_Click(object sender, EventArgs e)
        {
            POS_System.Form1 pos = new POS_System.Form1();
            pos.ShowDialog(this);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {/*
            teiryou.Quantification_2 qua = new teiryou.Quantification_2();
            qua.ShowDialog(this);
            */
        }

        private void btn_Ranking_Click(object sender, EventArgs e)
        {
            rating.Rating ran = new rating.Rating(this);
            ran.Show(this);

            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //画面を閉じる
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            while (memo_Now_Number >= 0)
            {
                try
                {
                    memo_New_Y_Location -= 70;
                    autoButton[memo_Now_Number, 0].Dispose();
                    autoButton[memo_Now_Number, 0].Dispose();
                    memo_Now_Number--;
                }
                catch { }
            }
            memo_New_Y_Location = 40;
            int[] memoTime_new_X_Location = { 280 };
            int[] memoInfo_new_X_Location = { 280 };
            string[] test = { "商品", "著者", "出版社", "会員", "" };
            int i = 0;
            while (test[i] != "")
            {
                memo_Now_Number++;
                ButtonsAdd(test, 1, 1, memo_New_Y_Location, 0, memoTime_new_X_Location, autoButton, memo_Now_Number, "1", "MS UI Gothic", 10F);
                panel_Side_R.Controls.Add(autoButton[memo_Now_Number, 0]);
                autoButton[memo_Now_Number, 0].BringToFront();
                memo_New_Y_Location += 70;
                autoButton[memo_Now_Number, 0].Click += new EventHandler(Buttonsclick);
                i++;
            }

            //別フォームを生成するときに、自フォーム(スタートアップフォーム)を渡す
            //syohin.Add_menu add_menu = new syohin.Add_menu(this);
            //add_menu.Show();

            //スタートアップフォームを隠す
            //スタートアップフォームは閉じるとアプリケーションが終了するので注意
            //this.Hide();
        }
        private void Buttonsclick(object sender, EventArgs e)
        {
            try
            {
                switch(((Button)sender).Name)
                {
                    case "00":
                        //別フォームを生成するときに、自フォーム(スタートアップフォーム)を渡す
                        syohin.Product product = new syohin.Product(this);
                        product.Show(this);

                        //スタートアップフォームを隠す
                        //スタートアップフォームは閉じるとアプリケーションが終了するので注意
                        this.Hide();
                        break;

                    case "01":
                        //別フォームを生成するときに、自フォーム(スタートアップフォーム)を渡す
                        stock_2.stock_2 stock = new stock_2.stock_2(this);
                        stock.Show(this);

                        //スタートアップフォームを隠す
                        //スタートアップフォームは閉じるとアプリケーションが終了するので注意
                        this.Hide();
                        break;

                    case "02":
                        wassyoi.Order order = new wassyoi.Order(this);
                        order.Show(this);
                        this.Hide();
                        break;

                    case "03":
                        nyuko.Warehousing ware = new nyuko.Warehousing(this);
                        ware.Show(this);
                        this.Hide();
                        break;

                    case "04":
                        uriage.Sales sales = new uriage.Sales(this);
                        sales.Show(this);
                        this.Hide();
                        break;

                    case "05":
                        kaiin.Member_management member = new kaiin.Member_management(this);
                        member.Show(this);
                        this.Hide();
                        break;

                    case "06":
                        Purchase pur = new Purchase(this);
                        pur.Show(this);

                        this.Hide();
                        break;

                    case "10":
                        syohin.Add_product frm = new syohin.Add_product(this);
                        frm.Show(this);

                        this.Hide();
                        break;

                    case "11":
                        syohin.Add_author atr = new syohin.Add_author(this);
                        atr.Show(this);

                        this.Hide();
                        break;

                    case "12":
                        syohin.Add_publiser pub = new syohin.Add_publiser(this);
                        pub.Show(this);

                        this.Hide();
                        break;

                    case "13":
                        kaiin_user.Member_user add_mem = new kaiin_user.Member_user(this);
                        add_mem.Show(this);

                        this.Hide();
                        break;

                    case "20":
                        teiryou.Quantification_2 qua = new teiryou.Quantification_2(this);
                        qua.Show(this);
                        break;

                    case "21":
                        Inventory_System.autoPurchase auto = new Inventory_System.autoPurchase(this);
                        auto.Show(this);    
                        break;
                    default:
                        break;
                        
                }
            }
            catch
            {

            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            while (memo_Now_Number >= 0)
            {
                try
                {
                    memo_New_Y_Location -= 70;
                    autoButton[memo_Now_Number, 0].Dispose();
                    autoButton[memo_Now_Number, 0].Dispose();
                    memo_Now_Number--;
                }
                catch { }
            }
            memo_New_Y_Location =40;
            int[] memoTime_new_X_Location = { 280 };
            int[] memoInfo_new_X_Location = { 280 };
            string[] test = { "商品検索", "在庫検索", "販売記録","入庫検索","売上検索","会員検索","発注管理","" };
            int i = 0;
            while (test[i]!="")
            {
                memo_Now_Number++;
                ButtonsAdd(test, 1, 1, memo_New_Y_Location, 0, memoTime_new_X_Location, autoButton, memo_Now_Number, "0", "MS UI Gothic", 10F);
                panel_Side_R.Controls.Add(autoButton[memo_Now_Number, 0]);
                autoButton[memo_Now_Number, 0].BringToFront();
                memo_New_Y_Location += 70;
                autoButton[memo_Now_Number, 0].Click += new EventHandler(Buttonsclick);
                i++;
            }
            //別フォームを生成するときに、自フォーム(スタートアップフォーム)を渡す
            //Search search = new Search(this);
            //search.Show();

            //スタートアップフォームを隠す
            //スタートアップフォームは閉じるとアプリケーションが終了するので注意
            //this.Hide();


        }

        private void menu_Load(object sender, EventArgs e)
        {
            this.Text = "メニュー";

            
        }

        private void menu_Load_1(object sender, EventArgs e)
        {

        }

        private void btn_Esc_Click(object sender, EventArgs e)
        {
            while (memo_Now_Number >= 0)
            {
                try
                {
                    memo_New_Y_Location -= 70;
                    autoButton[memo_Now_Number, 0].Dispose();
                    autoButton[memo_Now_Number, 0].Dispose();
                    memo_Now_Number--;
                }
                catch { }
            }
            memo_New_Y_Location = 40;
            int[] memoTime_new_X_Location = { 280 };
            int[] memoInfo_new_X_Location = { 280 };
            string[] test = { "マスタ", "自動発注", "" };
            int i = 0;
            while (test[i] != "")
            {
                memo_Now_Number++;
                ButtonsAdd(test, 1, 1, memo_New_Y_Location, 0, memoTime_new_X_Location, autoButton, memo_Now_Number, "2", "MS UI Gothic", 10F);
                panel_Side_R.Controls.Add(autoButton[memo_Now_Number, 0]);
                autoButton[memo_Now_Number, 0].BringToFront();
                memo_New_Y_Location += 70;
                autoButton[memo_Now_Number, 0].Click += new EventHandler(Buttonsclick);
                i++;
            }
            
        }

        private void pbtn_Dispose_Click(object sender, EventArgs e)
        {
            //画面を閉じる
            this.Close();
        }

        private void pbtn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbtn_Minimize_MouseEnter(object sender, EventArgs e)
        {
            pbtn_Minimize.Image = Inventory_System.Properties.Resources.Syukusyo_v3_MouseEnter;
        }

        private void pbtn_Minimize_MouseLeave(object sender, EventArgs e)
        {
            pbtn_Minimize.Image = Inventory_System.Properties.Resources.Syukusyo_v3_fix1;
        }

        private void pbtn_Dispose_MouseEnter(object sender, EventArgs e)
        {
            pbtn_Dispose.Image = Inventory_System.Properties.Resources.batsu_MouseEnter;
        }

        private void pbtn_Dispose_MouseLeave(object sender, EventArgs e)
        {
            pbtn_Dispose.Image = Inventory_System.Properties.Resources.batsu;
        }

        private void btn_Search_MouseEnter(object sender, EventArgs e)
        {
            btn_Search.BackColor = Color.Blue;
        }

        private void btn_Search_MouseLeave(object sender, EventArgs e)
        {
            btn_Search.BackColor = Color.FromArgb(64, 64, 64); ;
        }

        private void btn_Add_MouseEnter(object sender, EventArgs e)
        {
            btn_Add.BackColor = Color.Blue;
        }

        private void btn_Add_MouseLeave(object sender, EventArgs e)
        {
            btn_Add.BackColor = Color.FromArgb(64, 64, 64); ;
        }

        private void btn_Ranking_MouseEnter(object sender, EventArgs e)
        {
            btn_Ranking.BackColor = Color.Blue;
        }

        private void btn_Ranking_MouseLeave(object sender, EventArgs e)
        {
            btn_Ranking.BackColor = Color.FromArgb(64, 64, 64); ;
        }

        private void btn_Pos_MouseEnter(object sender, EventArgs e)
        {
            btn_Pos.BackColor = Color.Blue;
        }

        private void btn_Pos_MouseLeave(object sender, EventArgs e)
        {
            btn_Pos.BackColor = Color.FromArgb(64, 64, 64); 
        }

        private void btn_Esc_MouseEnter(object sender, EventArgs e)
        {
            btn_Esc.BackColor = Color.Blue;
        }

        private void btn_Esc_MouseLeave(object sender, EventArgs e)
        {
            btn_Esc.BackColor = Color.FromArgb(64, 64, 64);
        }

    }
}
