using Blackjack_Dealer.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack_Dealer
{
    public partial class Form1 : Form
    {
        Shoe shoe = new Shoe();
        Dealer dealer = Dealer.GetInstance("carlos");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var card = dealer.DrawCard(shoe);
            pictureBox1.Image = card.Img;
        }
    }
}
