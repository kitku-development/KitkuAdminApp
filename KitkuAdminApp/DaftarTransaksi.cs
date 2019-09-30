using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace KitkuAdminApp
{
    public partial class DaftarTransaksi : UserControl
    {
        /*String[] 
            id_pemesanan,
            id_pelanggan, nama_pelanggan,
            id_barang, nama_barang, id_supplier, nama_supplier, jumlah,
            diskon_id, diskon, harga,ongkir,
            waktu_pemesanan, waktu_pengiriman, catatan, koor,
            status, info, last_update;*/
        public DaftarTransaksi()
        {
            InitializeComponent();
        }

        public HttpClient HttpClient { get; } = new HttpClient();

        public async Task<String> GetData(String date)
        {
            // Suspends GetDotNetCountAsync() to allow the caller (the web server)
            // to accept another request, rather than blocking on this one.
            var html = await HttpClient.GetStringAsync("https://kitku.id/invoice/date/" + date);
            //result.ToString();
            //deserializeData(s);
            //return Regex.Matches(html, @"\.NET").Count;
            Console.WriteLine(html);
            PostExecute(html);
            return html;
        }

        public void ExecuteTask(object sender, EventArgs e)
        {
            String date =
                pilihanTanggal.Value.Year.ToString() + "-";
            if (pilihanTanggal.Value.Month < 10)
                date += "0";
            date = date +
                pilihanTanggal.Value.Month.ToString() + "-" +
                pilihanTanggal.Value.Day.ToString();
            //Console.WriteLine(date);
            if (!string.IsNullOrWhiteSpace(pilihanUrut.Text))
                _ = GetData(date);
            //if (pilihanUrut.Text == "Pelanggan")
        }

        public void PostExecute(String json)
        {
            var result = Datas.FromJson(json);
            //Console.WriteLine(result.Pemesanans[0].IdPemesanan);
            tabelRingkasanPemesanan.ColumnCount = 19;
            tabelRingkasanPemesanan.Columns[0].Name = "id_pemesanan";
            tabelRingkasanPemesanan.Columns[1].Name = "id_pelanggan";
            tabelRingkasanPemesanan.Columns[2].Name = "nama_pelanggan";
            tabelRingkasanPemesanan.Columns[3].Name = "id_barang";
            tabelRingkasanPemesanan.Columns[4].Name = "nama_barang";
            tabelRingkasanPemesanan.Columns[5].Name = "id_supplier";
            tabelRingkasanPemesanan.Columns[6].Name = "nama_supplier";
            tabelRingkasanPemesanan.Columns[7].Name = "jumlah";
            tabelRingkasanPemesanan.Columns[8].Name = "diskon_id";
            tabelRingkasanPemesanan.Columns[9].Name = "diskon";
            tabelRingkasanPemesanan.Columns[10].Name = "harga";
            tabelRingkasanPemesanan.Columns[11].Name = "ongkir";
            tabelRingkasanPemesanan.Columns[12].Name = "waktu_pemesanan";
            tabelRingkasanPemesanan.Columns[13].Name = "waktu_pengiriman";
            tabelRingkasanPemesanan.Columns[14].Name = "catatan";
            tabelRingkasanPemesanan.Columns[15].Name = "koor";
            tabelRingkasanPemesanan.Columns[16].Name = "status";
            tabelRingkasanPemesanan.Columns[17].Name = "info";
            tabelRingkasanPemesanan.Columns[18].Name = "last_update";
            //if (pilihanUrut.Text == "Pelanggan")
            for(int i = 0; i < result.Pemesanans.Length; i++)
            {
                string[] row = new string[] 
                {
                    result.Pemesanans[i].IdPemesanan,
                    result.Pemesanans[i].IdPelanggan,
                    result.Pemesanans[i].NamaPelanggan,
                    result.Pemesanans[i].IdBarang,
                    result.Pemesanans[i].NamaBarang,
                    result.Pemesanans[i].IdSupplier,
                    result.Pemesanans[i].NamaSupplier,
                    result.Pemesanans[i].Jumlah,
                    result.Pemesanans[i].DiskonId,
                    result.Pemesanans[i].Diskon,
                    result.Pemesanans[i].Harga,
                    result.Pemesanans[i].Ongkir,
                    result.Pemesanans[i].WaktuPemesanan,
                    result.Pemesanans[i].WaktuPengiriman,
                    result.Pemesanans[i].Catatan,
                    result.Pemesanans[i].Koor,
                    result.Pemesanans[i].Status,
                    result.Pemesanans[i].Info,
                    result.Pemesanans[i].LastUpdate
                };
                tabelRingkasanPemesanan.Rows.Add(row);
            }
                
        }

        /*public class RootObject
        {
            public List<Pemesanan> Pemesanans { get; set; }
        }

        private void deserializeData(Stream ms)
        {
            var deserializedData = new Pemesanan();
            var ser = new DataContractJsonSerializer(typeof(Pemesanan));
            ser = new DataContractJsonSerializer(deserializedData.GetType());
            deserializedData = ser.ReadObject(ms) as Pemesanan;
            //result = deserializedUser.message;
            Console.WriteLine(deserializedData);
        }*/
    }

    
    // instance for convert JSON
    public partial class Pemesanan
    {
        [JsonProperty("id_pemesanan")]
        public string IdPemesanan { get; set; }

        [JsonProperty("id_pelanggan")]
        public string IdPelanggan { get; set; }

        [JsonProperty("nama_pelanggan")]
        public string NamaPelanggan { get; set; }

        [JsonProperty("id_barang")]
        public string IdBarang { get; set; }

        [JsonProperty("nama_barang")]
        public string NamaBarang { get; set; }

        [JsonProperty("id_supplier")]
        public string IdSupplier { get; set; }

        [JsonProperty("nama_supplier")]
        public string NamaSupplier { get; set; }

        [JsonProperty("jumlah")]
        public string Jumlah { get; set; }

        [JsonProperty("diskon_id")]
        public string DiskonId { get; set; }

        [JsonProperty("diskon")]
        public string Diskon { get; set; }

        [JsonProperty("harga")]
        public string Harga { get; set; }

        [JsonProperty("ongkir")]
        public string Ongkir { get; set; }

        [JsonProperty("waktu_pemesanan")]
        public string WaktuPemesanan { get; set; }

        [JsonProperty("waktu_pengiriman")]
        public string WaktuPengiriman { get; set; }

        [JsonProperty("catatan")]
        public string Catatan { get; set; }

        [JsonProperty("koor")]
        public string Koor { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("last_update")]
        public string LastUpdate { get; set; }
    }

    public partial class Datas
    {
        [JsonProperty("Pemesanans")]
        public Pemesanan[] Pemesanans { get; set; }
        public static Datas FromJson(string json) => JsonConvert.DeserializeObject<Datas>(json, KitkuAdminApp.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Datas self) => JsonConvert.SerializeObject(self, KitkuAdminApp.Converter.Settings);
    }

    internal static class Converter
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
    }

    internal class ParseStringConverter : JsonConverter
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
    }
    //
}
