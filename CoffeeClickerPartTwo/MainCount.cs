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
    public partial class MainCount : Form
    {
        public static int coffeeCount = 0;
        public static int coffeeBeans = 100;
        Form coffeeMake = new CoffeeMaker();
        Form autoBrew = new AutoBrewer();
        Form beanie = new Beans();
        Form bitcoin = new CoffeeCoin();
        public MainCount()
        {
            InitializeComponent();
            Thread thready = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    label2.Text = coffeeCount.ToString();
                    label2.Refresh();
                }
            });
            this.FormClosing += delegate { thready.Abort(); autoBrew.Hide(); beanie.Hide(); coffeeMake.Hide(); bitcoin.Hide(); };
            thready.Start();
            autoBrew.Show();
            beanie.Show();
            coffeeMake.Show();
            bitcoin.Show();
        }
    }
}
