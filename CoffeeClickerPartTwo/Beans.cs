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
    public partial class Beans : Form
    {
        public static bool autoEnabled = false;
        public Beans()
        {
            InitializeComponent();
            Thread thready = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    label1.Text = MainCount.coffeeBeans.ToString();
                    label1.Refresh();
                }
            });
            thready.Start();
            Thread autoBuy = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while(true)
                {
                    if(MainCount.coffeeBeans <= 0 && MainCount.coffeeCount >= 50 && autoEnabled == true)
                    {
                        MainCount.coffeeCount -= 50;
                        MainCount.coffeeBeans += 100;
                    }
                }
            });
            autoBuy.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(MainCount.coffeeCount >= 50)
            {
                MainCount.coffeeBeans += 100;
                MainCount.coffeeCount -= 50;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(MainCount.coffeeCount >= 500)
            {
                MainCount.coffeeCount -= 500;
                button2.Enabled = false;
                autoEnabled = true;
            }
        }
    }
}
