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
    public partial class AutoBrewer : Form
    {
        public static int autoBrewerCount = 0;
        public static int ultraBrewerCount = 0;
        int autoBrewerPrice = 20;
        int ultraBrewerPrice = 200;
        public AutoBrewer()
        {
            Thread brew = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    if (autoBrewerCount != 0 && MainCount.coffeeBeans > 0)
                    {
                        Thread.Sleep(2500 / autoBrewerCount);
                        MainCount.coffeeCount++;
                        MainCount.coffeeBeans--;
                    }
                }
            });
            Thread superBrew = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    if (ultraBrewerCount != 0 && MainCount.coffeeBeans > 4)
                    {
                        Thread.Sleep(2500 / ultraBrewerCount);
                        MainCount.coffeeCount += 5;
                        MainCount.coffeeBeans -= 5;
                    }
                }
            });
            InitializeComponent();
            brew.Start();
            superBrew.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MainCount.coffeeCount >= autoBrewerPrice)
            {
                MainCount.coffeeCount -= autoBrewerPrice;
                autoBrewerCount++;
                autoBrewerPrice += 5;
                label1.Text = "AutoBrewer Count: " + autoBrewerCount.ToString();
                button1.Text = "Buy AutoBrewer (" + autoBrewerPrice.ToString() + ")";
                button1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MainCount.coffeeCount >= ultraBrewerPrice)
            {
                MainCount.coffeeCount -= ultraBrewerPrice;
                ultraBrewerCount++;
                ultraBrewerPrice += 50;
                label2.Text = "UltraBrewer Count: " + ultraBrewerCount.ToString();
                button2.Text = "Buy UltraBrewer (" + ultraBrewerPrice.ToString() + ")";
                button2.Refresh();
            }
        }
    }
}
