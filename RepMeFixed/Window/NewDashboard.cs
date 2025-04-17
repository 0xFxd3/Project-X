using RepMeFixed.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace RepMeFixed.Window
{
    public partial class NewDashboard : UserControl
    {
        public NewDashboard()
        {
            InitializeComponent();

            string broker = "abc99b064c47455f930ed9e2a66efd13.s1.eu.hivemq.cloud";
            int port = 8883;
            string username = "admin";
            string password = "CoolAdminPassword123409";
            string clientId = Guid.NewGuid().ToString();

            try
            {
                client = new MqttClient(broker, port, true, null, null, MqttSslProtocols.TLSv1_2, ValidateServerCertificate);
                client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;

                client.Connect(clientId, username, password);
                Windows_Message("Project x", "✅ Connected to HiveMQ Cloud");

                // Subscribe to 4 topics so that we can listen in on what is going on :))))
                client.Subscribe(new string[]
                {
                    "sensor/temperature",
                    "sensor/oxygen",
                    "sensor/bpm",
                    "sensor/name"
                },
                new byte[]
                {
                    MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,
                    MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,
                    MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,
                    MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE
                });

                Windows_Message("Project x", "📡 Subscribed to sensor topics");
            }
            catch (Exception ex)
            {
                Windows_Message("Project x", "❌ Connection failed: " + ex.Message);
            }
        }

        private void selection()
        {

        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            RepMeFixed.Properties.Settings.Default.doctor_id = 3;
            selection();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            RepMeFixed.Properties.Settings.Default.doctor_id = 2;
            selection();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            RepMeFixed.Properties.Settings.Default.doctor_id = 1;
            selection();
        }

        private void dopeSwitch()
        {
        }
 
        private void label1_Click(object sender, EventArgs e)
        {
            RepMeFixed.Properties.Settings.Default.doctor_ratings = 1;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            RepMeFixed.Properties.Settings.Default.doctor_ratings = 2;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            RepMeFixed.Properties.Settings.Default.doctor_ratings = 3;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            RepMeFixed.Properties.Settings.Default.doctor_ratings = 4;
        }

        private void label13_Click(object sender, EventArgs e)
        {
            RepMeFixed.Properties.Settings.Default.doctor_ratings = 5;
        }

        private void ratings_Tick(object sender, EventArgs e)
        {
            dopeSwitch();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

            private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void adminPanel1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // Allow trusted certs
            return sslPolicyErrors == SslPolicyErrors.None;
        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string topic = e.Topic;
            string message = Encoding.UTF8.GetString(e.Message);

            BeginInvoke((MethodInvoker)delegate
            {
                switch (topic)
                {
                    case "sensor/temperature":
                        label1.Text = $"🌡 Temp: {message}";
                        break;
                    case "sensor/oxygen":
                        label4.Text = $"📈 Oxygen: {message}";
                        break;
                    case "sensor/bpm":
                        label6.Text = $"📈 BPM: {message}";
                        break;
                    case "sensor/name":
                        label9.Text = $"🔄 Name: {message}";
                        break;
                    default:
                        Windows_Message("project x",$"📨 [{topic}]: {message}");
                        break;
                }
            });
        }


        private void SendMqttMessage(string topic, string message)
        {
            if (client == null || !client.IsConnected)
            {
                Windows_Message("project x", "❌ Not connected to broker.");
                return;
            }

            if (string.IsNullOrWhiteSpace(topic) || string.IsNullOrWhiteSpace(message))
            {
                Windows_Message("project x", "⚠️ Topic or message is empty.");
                return;
            }

            try
            {
                client.Publish(topic, Encoding.UTF8.GetBytes(message));
                Windows_Message("project x", $"📤 Sent to [{topic}]: {message}");
            }
            catch (Exception ex)
            {
                Windows_Message("project x", "❌ Failed to send: " + ex.Message);
            }
        }
        private void Windows_Message(string title, string message)
        {
            var notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.BalloonTipTitle = title.ToString();
            notifyIcon.BalloonTipText = message.ToString();
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(5000);
            notifyIcon.Dispose();
        }
        private MqttClient client;
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SendMqttMessage("sensor/temperature", "100");
            SendMqttMessage("sensor/oxygen", "50");
            SendMqttMessage("sensor/bpm", "68");
            SendMqttMessage("sensor/name", "Jeffrey");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            SendMqttMessage("sensor/temperature", "75");
            SendMqttMessage("sensor/oxygen", "90");
            SendMqttMessage("sensor/bpm", "98");
            SendMqttMessage("sensor/name", "Michael");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SendMqttMessage("sensor/temperature", "48");
            SendMqttMessage("sensor/oxygen", "80");
            SendMqttMessage("sensor/bpm", "38");
            SendMqttMessage("sensor/name", "Karen");
        }
    }
}
