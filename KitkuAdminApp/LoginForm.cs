using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
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
            if (string.IsNullOrWhiteSpace(boxUser.Text) || string.IsNullOrWhiteSpace(boxPass.Text))
                MessageBox.Show("Mohon isi user dan/atau password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                // refer to BackgroundTask.cs for more detail
                //UserData userData = new UserData();
                /*string result = new UserData().execute(userBox.Text, passBox.Text);
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
                    */
                Datas datas = new Datas();
                datas.id_supplier = boxUser.Text;
                datas.password = boxPass.Text;
                var ser = datas.ToJson();

                // Specify requirement to POST
                //var stringData = await _httpClient.GetStringAsync();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://kitku.id/pelanggan/login");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                // write data
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    //string json = sr.ReadToEnd();
                    streamWriter.Write(ser);
                }

                // get response
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var res = Datas.FromJson(streamReader.ReadToEnd());
                    //Console.WriteLine(res.id_supplier);

                    // if data gotten
                    if (res.message != null)
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
                                MainForm.UserLogged = res.message;
                            }
                        }
                    }
                    else
                        MessageBox.Show("Tidak ditemukan supplier dengan nama ini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }

    public partial class Datas
    {
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
    }

    // instance for convert JSON
    /*[System.Runtime.Serialization.DataContract]
    class ProductData
    {
        [System.Runtime.Serialization.DataMember]
        //public string Username { get; set; }
        public string email { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string password { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string message { get; set; }
    }

    public class UserData
    {
        [System.Runtime.Serialization.DataContract]
        class UserDatas
        {
            //Username = userBox.Text,
            [System.Runtime.Serialization.DataMember]
            public string email { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string password { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string message { get; set; }
        }
        

        public string execute(string user, string pass)
        {
            UserDatas userData = new UserDatas()
            {
                email = user,
                password = pass
            };
            // convert to JSON
            var stream1 = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(UserDatas));
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

                String result = "..";
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
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var deserializedUser = new UserDatas();
                        var ms = new MemoryStream(Encoding.UTF8.GetBytes(streamReader.ReadToEnd()));
                        ser = new DataContractJsonSerializer(deserializedUser.GetType());
                        deserializedUser = ser.ReadObject(ms) as UserDatas;
                        result = deserializedUser.message;
                        ms.Close();
                    }
                    // compare response
                    /*if (result.Contains("PEL-"))
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
                catch (Exception e) { result = e.Message; }

                return result;
            }
        }
    }*/
}
