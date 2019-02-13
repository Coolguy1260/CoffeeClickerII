using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace CoffeeClickerPartTwo
{
    public partial class CoffeeCoin : Form
    {
        public static int value = 500;
        public static int coins = 0;
        public CoffeeCoin()
        {
            InitializeComponent();
            Thread refreshValue = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(5000);
                    Random r = new Random();
                    value += r.Next(-25, 25);
                    label2.Text = "Current Value: " + value.ToString();
                }
            });
            refreshValue.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MainCount.coffeeCount >= value)
            {
                coins++;
                MainCount.coffeeCount -= value;
                label3.Text = "CoffeeCoin Balance: " + coins.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(coins > 0)
            {
                coins--;
                MainCount.coffeeCount += value;
                label3.Text = "CoffeeCoin Balance: " + coins.ToString();
            }
        }
    }
}
