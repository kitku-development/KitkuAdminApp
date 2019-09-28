using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitkuAdminApp
{
    public partial class LoginForm : Form
    {
        public MainForm MainForm { get; set; }

        public LoginForm()
        {
            InitializeComponent();
            /*
            this.Hide();
            using (mainForm = new MainForm())
            {
                mainForm.FormClosing += MainForm_Closing;
                //mainForm.ShowDialog();
                if (mainForm.ShowDialog() == DialogResult.OK)
                {
                    //Console.WriteLine("user " + result);
                    //mainForm.userLogged = result;
                }
            }
            */
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            loginButton.Enabled = false;
            // This line will yield control to the UI as the request
            // from the web service is happening.
            //
            // The UI thread is now free to perform other work.
            if (string.IsNullOrWhiteSpace(userBox.Text) || string.IsNullOrWhiteSpace(passBox.Text))
                MessageBox.Show("Mohon isi user dan/atau password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {

                UserData userData = new UserData
                {
                    //Username = userBox.Text,
                    email = userBox.Text,
                    password = passBox.Text
                };

                // convert to JSON
                var stream1 = new MemoryStream();
                var ser = new DataContractJsonSerializer(typeof(UserData));
                ser.WriteObject(stream1, userData);
                stream1.Position = 0;
                using (var sr = new StreamReader(stream1))
                {
                    //stream1.Close();
                    //Console.Write("JSON form: ");
                    //Console.WriteLine(sr.ReadToEnd());

                    // Specify requirement to POST
                    //var stringData = await _httpClient.GetStringAsync();
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://kitku.id/pelanggan/login");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    // POST data
                    try
                    {
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = sr.ReadToEnd();
                            streamWriter.Write(json);
                        }

                        // get response
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        String result;
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var deserializedUser = new UserData();
                            var ms = new MemoryStream(Encoding.UTF8.GetBytes(streamReader.ReadToEnd()));
                            ser = new DataContractJsonSerializer(deserializedUser.GetType());
                            deserializedUser = ser.ReadObject(ms) as UserData;
                            result = deserializedUser.message;
                            ms.Close();
                        }

                        // compare response
                        if (result.Contains("PEL-"))
                        {
                            // initialize MainForm
                            //mainForm = new MainForm();
                            this.Hide();
                            using (MainForm = new MainForm())
                            {
                                MainForm.FormClosing += MainForm_Closing;
                                //mainForm.ShowDialog();
                                if (MainForm.ShowDialog() == DialogResult.OK)
                                {
                                    //Console.WriteLine("user " + result);
                                    MainForm.UserLogged = result;
                                }
                            }
                        }
                        else
                            MessageBox.Show("Login gagal! Silakan periksa kembali data anda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception) { MessageBox.Show("Gagal login! Periksa kembali koneksi internet anda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
            }
            loginButton.Enabled = true;
        }

        // apply on enter
        private void UserBox_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginButton_Click(sender, null);
        }

        // apply on enter
        private void PassBox_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoginButton_Click(sender, null);
        }

        // to show back Login window
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        // instance for convert JSON
        [System.Runtime.Serialization.DataContract]
        class UserData
        {
            [System.Runtime.Serialization.DataMember]
            //public string Username { get; set; }
            public string email { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string password { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string message { get; set; }
        }
    }
}
