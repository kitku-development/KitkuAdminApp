using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Net.Http;

namespace KitkuAdminApp
{
    public partial class EditBarang : UserControl
    {
        LoadingDialog loadingDialog;// = new LoadingDialog();
        public EditBarang()
        {
            InitializeComponent();
            buttonPilihGambar.Enabled = false;
        }

        private void Button_UbahGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "Pilih Gambar";
            openFileDialog.DefaultExt = "jpg";
            openFileDialog.Filter = "Image (*.jpg;*.jpeg;)|*.jpg;*.jpeg;";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            //openFileDialog.ShowDialog();

            /*this.openFileDialog1.Multiselect = true;
            foreach (String file in openFileDialog1.FileNames)
            {
                MessageBox.Show(file);
            }*/
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    if (openFileDialog.OpenFile().Length < 500 * 1024)
                    {
                        //Console.WriteLine(openFileDialog.FileName);
                        loadingDialog = new LoadingDialog();
                        loadingDialog.Show();
                        try
                        {
                            PictureBox imageControl = productPicture;

                            Image.GetThumbnailImageAbort myCallback =
                                    new Image.GetThumbnailImageAbort(ThumbnailCallback);
                            Bitmap myBitmap = new Bitmap(file);
                            Image myThumbnail = myBitmap.GetThumbnailImage(300, 300,
                                myCallback, IntPtr.Zero);
                            imageControl.Image = myThumbnail;
                            myBitmap.Dispose();
                            //
                            /*NameValueCollection nvc = new NameValueCollection
                            {
                                { "id", "TTR" },
                                { "btn-submit-photo", "Upload" }
                            };*/
                            string result = UploadImage.HttpUploadFile("https://kitku.id/produk/updatepic/" + filename,
                                 openFileDialog.FileName, null);
                            if (result.Contains("Success"))
                                MessageBox.Show("Gambar berhasil diupload!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Gambar gagal diupload!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //Console.WriteLine("https://kitku.id/produk/updatepic/" + filename);
                            //
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                        loadingDialog.dismiss();
                    }
                    else MessageBox.Show("Gambar hanya boleh berukuran 500kb atau kurang!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        public HttpClient HttpClient { get; } = new HttpClient();
        static string url = "https://kitku.id/produk/detail/";
        string filename;
        private async void Button_Cari_Click(object sender, EventArgs e)
        {
            buttonCari.Enabled = false;
            if (!string.IsNullOrEmpty(boxIDBarang.Text) && buttonCari.Text == "Cari")
            {
                loadingDialog = new LoadingDialog();
                loadingDialog.Show();
                //loadingDialog.Focus();
                loadingDialog.Activate();
                var html = await HttpClient.GetStringAsync(url + boxIDBarang.Text);
                var result = Datas.FromJson(html);

                boxNamaBarang.Text = result.Products[0].nama;
                boxMitra.Text = result.Products[0].mitra;
                boxKategori.Text = result.Products[0].kategori;
                boxSatuanInt.Text = result.Products[0].satuan;
                boxHarga.Text = result.Products[0].harga;
                boxDeskripsi.Text = result.Products[0].desc;
                boxJumlah.Text = result.Products[0].jumlah;
                filename = result.Products[0].url.Replace("https://kitku.id/productpic/", "").Replace(".jpeg", "");
                //Console.WriteLine(filename);

                // download image
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(result.Products[0].url);
                Bitmap bitmap; bitmap = new Bitmap(stream);

                if (bitmap != null)
                {
                    productPicture.Image = bitmap;
                }

                stream.Flush();
                stream.Close();
                client.Dispose();

                loadingDialog.dismiss();
                buttonPilihGambar.Enabled = true;
                buttonCari.Text = "Reset";
                boxIDBarang.ReadOnly = true;
            }
            else
            {
                boxIDBarang.Text = "";
                boxIDBarang.ReadOnly = false;
                boxNamaBarang.Text = "";
                boxMitra.Text = "";
                boxKategori.Text = "";
                boxJumlah.Text = "";
                boxSatuanInt.Text = "";
                boxHarga.Text = "";
                boxDeskripsi.Text = "";
                productPicture.Image = null;
                buttonCari.Text = "Cari";
            }
            buttonCari.Enabled = true;
        }

        private void ButtonSimpan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(boxIDBarang.Text))
            {
                Datas products = new Datas();
                products.id_barang = boxIDBarang.Text;
                products.nama = boxNamaBarang.Text;
                products.kategori = boxKategori.Text;
                products.satuan = boxSatuanInt.Text;
                products.harga = boxHarga.Text;
                products.jumlah = boxJumlah.Text;
                products.deskripsi = boxDeskripsi.Text;
                var ser = products.ToJson();
                Console.WriteLine(ser);

                // Specify requirement to POST
                //var stringData = await _httpClient.GetStringAsync();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://kitku.id/produk/update");
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
                    if (res.message.Contains("updated"))
                    {
                        MessageBox.Show("Berhasil mengupdate data barang!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Gagal mengupdate data barang!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else MessageBox.Show("Silakan masukan ID barang dan lakukan pengeditan pada bagian yang ingin dirubah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // instance for convert JSON
    public partial class Products
    {
        [JsonProperty("kategori")]
        public string kategori { get; set; }
        [JsonProperty("id_barang")]
        public string id_barang { get; set; }
        [JsonProperty("nama")]
        public string nama { get; set; }
        [JsonProperty("mitra")]
        public string mitra { get; set; }
        [JsonProperty("desc")]
        public string desc { get; set; }
        [JsonProperty("satuan")]
        public string satuan { get; set; }
        [JsonProperty("harga")]
        public string harga { get; set; }
        [JsonProperty("jumlah")]
        public string jumlah { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
    }

    public partial class Datas
    {
        [JsonProperty("Products")]
        public Products[] Products { get; set; }

        [JsonProperty("jumlah")]
        public string jumlah { get; set; }
        //public static Datas FromJson(string json) => JsonConvert.DeserializeObject<Datas>(json, KitkuAdminApp.Converter.Settings);
    }

    /*public static class Serialize
    {
        public static string ToJson(this Datas self) => JsonConvert.SerializeObject(self, KitkuAdminApp.Converter.Settings);
    }*/

    /*internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }*/

    /*internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (long.TryParse(value, out long l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }*/

    //
    public class UploadImage
    {
        public static string HttpUploadFile(string url, string files, NameValueCollection formFields = null)
        {
            string lineEnd = "\r\n";
            string twoHyphens = "--";
            string boundary = "*****";
            //string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;

            Stream memStream = new MemoryStream();
            var boundarybytes = System.Text.Encoding.ASCII.GetBytes(lineEnd + twoHyphens + boundary + lineEnd);
            var endBoundaryBytes = System.Text.Encoding.ASCII.GetBytes(lineEnd + twoHyphens + boundary + twoHyphens);
            //string formdataTemplate = "\r\n--" + boundary +
            //string formdataTemplate = twoHyphens + boundary + lineEnd +
            //                            "\r\nContent-Disposition: form-data; name=\"image\";\r\n\r\n";// + url.Replace("https://kitku.id/produk/updatepic/","");
            //Console.WriteLine(formdataTemplate);

            /*if (formFields != null)
            {
                foreach (string key in formFields.Keys)
                {
                    string formitem = string.Format(formdataTemplate, key, formFields[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    memStream.Write(formitembytes, 0, formitembytes.Length);
                    //Console.WriteLine(formitembytes.ToString());
                }
            }*/

            string headerTemplate =
                twoHyphens + boundary + lineEnd +
                "Content-Disposition: form-data; name=\"image\"; filename=\"" +files+"\"" + lineEnd +
                "Content-Type: application/json" + lineEnd + lineEnd;
            //Console.WriteLine(headerTemplate);
            //for (int i = 0; i < files.Length; i++)
            //{
                memStream.Write(boundarybytes, 0, boundarybytes.Length);
                var header = string.Format(headerTemplate, "uplTheFile", files);
                var headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                //Console.WriteLine(headerbytes.ToString());
                memStream.Write(headerbytes, 0, headerbytes.Length);

                using (var fileStream = new FileStream(files, FileMode.Open, FileAccess.Read))
                {
                    var buffer = new byte[1024];
                    var bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        memStream.Write(buffer, 0, bytesRead);
                    }
                }
            //}

            memStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            request.ContentLength = memStream.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            }

            using (var response = request.GetResponse())
            {
                Stream stream2 = response.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                string res = reader2.ReadToEnd();
                //Console.WriteLine("From post: " + res);
                reader2.Dispose();
                stream2.Close();
                return res;
            }
        }
    }
}
