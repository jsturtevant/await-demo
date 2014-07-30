using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwaitDemo
{

    public partial class Form1 : Form
    {
        // may need to adjust this number for your processor speed
        private const int PRIME_TO_FIND = 599000;

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Should freeze the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void noAwaitClick(object sender, EventArgs e)
        {
            label1.Text = "starting...";
            long prime = this.FindPrimeNumber(PRIME_TO_FIND);
            label1.Text = prime.ToString();
        }

        /// <summary>
        /// Should freeze the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void async1Click(object sender, EventArgs e)
        {
            label2.Text = "starting...";
            var prime = await this.primenumberAsync();
            label2.Text = prime.ToString();
        }

        /// <summary>
        /// Window should be responsive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async Task<long> primenumberAsync()
        {
            long prime = this.FindPrimeNumber(PRIME_TO_FIND);
            return await Task.FromResult(prime);
        }

        private async void async2Click(object sender, EventArgs e)
        {
            label3.Text = "starting...";
            var prime = await this.primenumberAsync2();
            label3.Text = prime.ToString();
        }

        private async Task<long> primenumberAsync2()
        {
            var prime = await Task.Run(() => this.FindPrimeNumber(PRIME_TO_FIND));
            return prime;
        }

        // http://stackoverflow.com/questions/13001578/i-need-a-slow-c-sharp-function
        public long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;// to check if found a prime
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                    count++;
                a++;
            }
            return (--a);
        }
    }
}
