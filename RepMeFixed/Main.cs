using RepMeFixed.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace RepMeFixed
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void WindowSelector_Tick(object sender, EventArgs e)
        {
            if (RepMeFixed.Properties.Settings.Default.Public_Tick >= 4000)
            {
                switch (RepMeFixed.Properties.Settings.Default.Window)
                {
                    case 1:
                        bunifuTransition1.HideSync(login1);
                        bunifuTransition1.ShowSync(dashboard1);
                        break;
                    case 2:
                        bunifuTransition1.HideSync(login1);
                        bunifuTransition1.ShowSync(dashboard1);
                        break;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (RepMeFixed.Properties.Settings.Default.login == true)
            {
                bunifuTransition1.HideSync(newLogin1);
                bunifuTransition1.ShowSync(newDashboard1);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Windows_Message(string title, string message)
        {
            // Create a NotifyIcon instance
            var notifyIcon = new NotifyIcon();

            // Set the icon for the notification
            notifyIcon.Icon = SystemIcons.Information;

            // Set the title and text for the notification
            notifyIcon.BalloonTipTitle = title.ToString();
            notifyIcon.BalloonTipText = message.ToString();

            // Show the notification
            notifyIcon.Visible = true;

            // Display the notification for 5 seconds
            notifyIcon.ShowBalloonTip(5000);

            // Cleanup and close the application
            notifyIcon.Dispose();
        }



        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

        }
    }
}
