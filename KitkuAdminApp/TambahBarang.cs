using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace KitkuAdminApp
{
    public partial class TambahBarang : UserControl
    {
        string id_supplier;
        OpenFileDialog fileDialog;
        public TambahBarang()
        {
            InitializeComponent();
        }

        private void ButtonCekMitra_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(boxMitra.Text))
            {
                buttonCekMitra.Enabled = false;
                Datas datas = new Datas();
                var stream1 = new MemoryStream();
                datas.nama_supplier = boxMitra.Text;
                var ser = datas.ToJson();

                // Specify requirement to POST
                //var stringData = await _httpClient.GetStringAsync();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://kitku.id/supplier/byname");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                //String result = "..";
                // POST data
                try
                {
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(ser);
                    }

                    // get response
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var res = Datas.FromJson(streamReader.ReadToEnd());
                        //Console.WriteLine(res.id_supplier);

                        // if data gotten
                        if (res.id_supplier != null)
                        {
                            id_supplier = res.id_supplier;
                            boxIDSupplier.Text = id_supplier;
                        }
                        else
                            MessageBox.Show("Tidak ditemukan supplier dengan nama ini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception) { }
                buttonCekMitra.Enabled = true;
            }
        }
        public void RemoveFocus(object sender, EventArgs e)
        {
            boxMitra.Focus();
        }

        private void ButtonSimpan_Click(object sender, EventArgs e)
        {
            buttonSimpan.Enabled = false;
            if (string.IsNullOrEmpty(boxIDSupplier.Text))
                MessageBox.Show("Silakan dapatkan kode mitra terlebih dahulu dengan mengecek nama mitra", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (
                !string.IsNullOrEmpty(boxKategori.Text) ||
                !string.IsNullOrEmpty(boxKodeBarang.Text) ||
                !string.IsNullOrEmpty(boxNamaBarang.Text) ||
                !string.IsNullOrEmpty(boxSatuanInt.Text) ||
                !string.IsNullOrEmpty(boxHarga.Text) ||
                !string.IsNullOrEmpty(boxDeskripsi.Text) ||
                fileDialog != null
                )
            {
                // convert to json
                Datas datas = new Datas();
                datas.kategori = boxKategori.Text;
                datas.id_barang = boxKodeBarang.Text;
                datas.id_supplier = id_supplier;
                datas.nama = boxNamaBarang.Text;
                datas.deskripsi = boxDeskripsi.Text;
                datas.satuan = boxSatuanInt.Text;
                datas.harga = boxHarga.Text;
                var ser = datas.ToJson();
                Console.WriteLine(ser);

                bool dbSuccess = false, imageSuccess = false;

                // Specify requirement to POST
                //var stringData = await _httpClient.GetStringAsync();
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://kitku.id/produk/add");
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
                        dbSuccess = true;
                        boxIDBarang.Text = res.id_barang;
                    }
                }

                string imageUploadMessage = UploadImage.HttpUploadFile("https://kitku.id/produk/updatepic/" + datas.nama.Replace(" ","") , fileDialog.FileName, null);
                if (imageUploadMessage.Contains("Success"))
                    imageSuccess = true;

                if (dbSuccess && imageSuccess)
                    MessageBox.Show("Produk berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    if (!dbSuccess)
                        MessageBox.Show("Produk gagal ditambahkan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!imageSuccess)
                        MessageBox.Show("Gambar gagal diupload!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Silakan lengkapi data dan gambar untuk menambah produk.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            buttonSimpan.Enabled = true;
        }

        private void ButtonIDBarangInfo_Click(object sender, EventArgs e)
        {
            string message = "Kode barang ditentukan sesuai dengan nama barang tersebut. " +
                "\nKode barang yang dimasukkan terdiri atas tiga huruf yang merujuk pada nama barang." +
                "\nAdapun kode barang yang sudah ditentukan yaitu : " +
                "\n1. AYM = Ayam" +
                "\n2. BRS = Beras" +
                "\n3. DAG = Daging" +
                "\n4. IKN = Ikan" +
                "\n5. SYR = Sayur" +
                "\n6. TLR = Telur";
            MessageBox.Show(message, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonPilihGambar_Click(object sender, EventArgs e)
        {
            fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            fileDialog.Title = "Pilih Gambar";
            fileDialog.DefaultExt = "jpg";
            fileDialog.Filter = "Image (*.jpg;*.jpeg;)|*.jpg;*.jpeg;";
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            
            DialogResult dr = fileDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in fileDialog.FileNames)
                {
                    if (fileDialog.OpenFile().Length < 500 * 1024)
                    {
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
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
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
    }

    // for json
    public partial class Datas
    {
        // supplier data
        [JsonProperty("nama")]
        public string nama_supplier { get; set; }
        [JsonProperty("id_supplier")]
        public string id_supplier { get; set; }

        // product data
        [JsonProperty("kategori")]
        public string kategori { get; set; }
        [JsonProperty("id_barang")]
        public string id_barang { get; set; }
        [JsonProperty("nama_barang")]
        public string nama { get; set; }
        [JsonProperty("mitra")]
        public string mitra { get; set; }
        [JsonProperty("deskripsi")]
        public string deskripsi { get; set; }
        [JsonProperty("satuan")]
        public string satuan { get; set; }
        [JsonProperty("harga")]
        public string harga { get; set; }
    }
}
