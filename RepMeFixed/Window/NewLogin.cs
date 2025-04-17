using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace RepMeFixed.Window
{
    public partial class NewLogin : UserControl
    {
        public NewLogin()
        {
            InitializeComponent();
        }


  
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Some information may not be available, we recommend logging in!");
            RepMeFixed.Properties.Settings.Default.Window = 2;
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }
        char star = '*';
        char notStar;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
        private void button3_Click(object sender, EventArgs e)
        {
            Windows_Message("RepMe", "Test");
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammar(new DictationGrammar());

            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

        }

        int time = 0;

        private void button1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            RepMeFixed.Properties.Settings.Default.Public_Tick += 100;
            if (RepMeFixed.Properties.Settings.Default.Public_Tick >= 4000)
            { 
                timer1.Enabled = false;
                bunifuTransition1.HideSync(this);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (username.Text == "doctor")
            {
                if (password.Text == "doctorpassword")
                {
                    Windows_Message("Project X", "Sucessfull login!");
                    RepMeFixed.Properties.Settings.Default.login = true;
                }
                else
                {
                    Windows_Message("Project X", "Failed Login!");
                    Application.Exit();
                }
            }
            else
            {
                Windows_Message("Project X", "Failed Login!");
                Application.Exit();
            }
        }
    }
}
