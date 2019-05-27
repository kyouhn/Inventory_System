using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace syohin
{
    public partial class Add_menu : Form
    {
        private menu.menu top;
        public Add_menu(menu.menu top2)
        {
            InitializeComponent();
            top = top2;
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            Add_product frm = new Add_product(this);
            frm.Show(this);

            this.Hide();
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            Add_author atr = new Add_author(this);
            atr.Show(this);

            this.Hide();
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {/*
            Add_publiser pub = new Add_publiser(this);
            pub.Show(this);

            this.Hide();
            */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            top.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {/*
            kaiin_user.Member_user add_mem = new kaiin_user.Member_user(this);
            add_mem.Show(this);

            this.Hide();
            */
        }

        private void Add_menu_Load(object sender, EventArgs e)
        {
            this.Text = "メニュー";
        }
    }
}
