using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Media;

namespace Cash_Register
{
    public partial class Form1 : Form
    {

        double grossTotal;
        double tax;
        double discount = 1.0;
        double discountTotal = 0;
        double Total = 0;

        int canprompt = 0;
        int flashlight = 0;
        int hazSuit = 0;
        int shield = 0;
        int reinforcedShield = 0;
        int handGun = 0;
        int firstAid = 0;
        int proFlashlight = 0;
        int platedSuit = 0;
        int eBatton = 0;
        int toolKit = 0;

    void update()
        {
            reclabel.Text = "-------------- RECEIPT --------------\r\n\r\n       - HAZMART incorperated -\r\n\r\n";

            Refresh();
            Thread.Sleep(10);

            try
            {
                if (canprompt >= 2)
                {
                    SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources._351304__deleted_user_96253__cha_ching);
                    soundPlayer.Play();
                }
                else
                {
                    SoundPlayer soundPlayer = new SoundPlayer(Properties.Resources._16942__cognito_perceptu__receipt_printer);
                    soundPlayer.Play();
                }

                if (firstAid != 0)
                {
                    Refresh();
                    Thread.Sleep(10);
                    reclabel.Text += $" First-Aid Kit (x{firstAid}) ... ${firstAid * 25} \r\n";
                }
                if (flashlight != 0)
                {
                    Refresh();
                    Thread.Sleep(10);
                    reclabel.Text += $" Flashlight (x{flashlight}) ... ${flashlight * 10} \r\n";
                }
                if (hazSuit != 0)
                {
                    Refresh();
                    Thread.Sleep(10);
                    reclabel.Text += $" HAZMAT Suit (x{hazSuit}) ... ${hazSuit * 35} \r\n";
                }
                if (shield != 0)
                {
                    Refresh();
                    Thread.Sleep(10);
                    reclabel.Text += $" Shield (x{shield}) ... ${shield * 20} \r\n";
                }
                if (reinforcedShield != 0)
                {
                    Refresh();
                    Thread.Sleep(10);
                    reclabel.Text += $" Reinforced Shield (x{reinforcedShield}) ... ${reinforcedShield * 50} \r\n";
                }
                if (handGun != 0)
                {
                    Refresh();
                    Thread.Sleep(10);
                    reclabel.Text += $" HandGun (x{handGun}) ... ${handGun * 150} \r\n";
                }
                if (proFlashlight != 0)
                {
                    Refresh();
                    Thread.Sleep(10);
                    reclabel.Text += $" Pro Flashlight (x{proFlashlight}) ... ${proFlashlight * 25} \r\n";
                }
                if (platedSuit != 0)
                {
                    Refresh();
                    Thread.Sleep(10);
                    reclabel.Text += $" Plated HAZMAT Suit (x{platedSuit}) ... ${platedSuit * 50} \r\n";
                }
                if (eBatton != 0)
                {
                    Refresh();
                    Thread.Sleep(10);
                    reclabel.Text += $" E-Batton (x{eBatton}) ... ${eBatton * 30} \r\n";
                }
                if (toolKit != 0)
                {
                    Refresh();
                    Thread.Sleep(10);
                    reclabel.Text += $" Toolkit (x{toolKit}) ... ${toolKit * 75} \r\n";
                }
            }
            catch
            {
                reclabel.Text += $"ERROR! \r\n";
            }

            Refresh();
            Thread.Sleep(10);

            if (Total == 0)
            {
                purchaseButton.Enabled = false;

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
            }
            else
            {
                if (discount != 1 && canprompt == 1)
                {
                    discountButton.Enabled = false;
                    discountTotal = Total * discount;
                    reclabel.Text += $"\r\n ADDED DISCOUNT .......... -${Math.Round(discountTotal, 3)} \r\n\r\n";

                    Total -= discountTotal;
                }
                if(canprompt >= 2)
                {
                    purchaseButton.Enabled = false;
                    discountButton.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                    button10.Enabled = false;
                }
                else
                {
                    purchaseButton.Enabled = true;
                    purchaseButton.AllowDrop = true;
                }
                Refresh();
                Thread.Sleep(100);

                tax = (Total * 0.13);
                grossTotal = Total + tax;

                reclabel.Text += $"\r\n Total .......... ${Math.Round(Total, 3)} \r\n\r\n Tax .......... ${Math.Round(tax, 3)} \r\n\r\n Gross Total .......... ${Math.Round(grossTotal, 3)} \r\n\r\n";


            }

        }

        void send(object button, int item, double price)
        {
            if (button.GetType() == typeof(Button))
            {
                try
                {
                    item += 1;

                    Refresh();
                    Thread.Sleep(100);

                    Total += price;

                    update();
                }
                catch
                {
                    clearRefresh();
                    return;
                }
            }

        }

        void purchaseCheck()
        {
            try
            {
                Refresh();
                Thread.Sleep(100);
                if (canprompt >= 2)
                {
                    purchaseButton.Text = "PURCHASE";
                    purchaseButton.Enabled = false;
                }
                if (canprompt == 1)
                {
                    purchaseButton.Text = "CONFIRM ORDER";

                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                    button10.Enabled = false;

                }
            }
            catch
            {
                reclabel.Text = "ERROR!";
            }


            update();
        }

        void clearRefresh()
        {
            clearbutton.BackColor = SystemColors.ControlDark;

            Refresh();
            Thread.Sleep(100);

            clearbutton.BackColor = Color.Red;
            Total = 0;
            tax = 0;
            grossTotal = 0;

            discount = 1.00;
            canprompt = 0;
            discountButton.Enabled = false;
            purchaseButton.Enabled = false;
            purchaseButton.Text = "PURCHASE";

            flashlight = 0;
            proFlashlight = 0;
            shield = 0;
            reinforcedShield = 0;
            handGun = 0;
            firstAid = 0;
            hazSuit = 0;
            platedSuit = 0;
            eBatton = 0;
            toolKit = 0;

            Refresh();
            Thread.Sleep(100);

            update();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(100);
            flashlight++;
            button1.BackColor = SystemColors.ActiveCaptionText;
            send(button1, flashlight, 10);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(100);
            hazSuit++;
            button2.BackColor = SystemColors.ActiveCaptionText;
            send(button2, hazSuit, 35);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(100);
            shield++;
            button3.BackColor = SystemColors.ActiveCaptionText;
            send(button3, shield, 20);
        }
        
        private void Button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(100);
            proFlashlight++;
            button4.BackColor = SystemColors.ActiveCaptionText;
            send(button4, proFlashlight, 25);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(100);
            platedSuit++;
            button5.BackColor = SystemColors.ActiveCaptionText;
            send(button5, platedSuit, 50);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(100);
            eBatton++;
            button6.BackColor = SystemColors.ActiveCaptionText;
            send(button6, eBatton, 30);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            button7.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(100);
            reinforcedShield++;
            button7.BackColor = SystemColors.ActiveCaptionText;
            send(button7, reinforcedShield, 50);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            button8.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(100);
            handGun++;
            button8.BackColor = SystemColors.ActiveCaptionText;
            send(button8, handGun, 150);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            button9.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(100);
            toolKit++;
            button9.BackColor = SystemColors.ActiveCaptionText;
            send(button9, toolKit, 75);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            button10.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(100);
            firstAid++;
            button10.BackColor = SystemColors.ActiveCaptionText;
            send(button10, firstAid, 25);
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            clearRefresh();
        }

        private void Discountbutton_Click(object sender, EventArgs e)
        {
            discountButton.Enabled = false;
            discount = 0.5;

            Refresh();
            Thread.Sleep(100);

            update();
        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            canprompt ++;

            discountButton.Enabled = true;

            Refresh();
            Thread.Sleep(100);

            purchaseButton.Enabled = false;

            purchaseCheck();
        }
    }
}
