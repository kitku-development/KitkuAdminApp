using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace KitkuAdminApp
{
    public class BackgroundTask
    {
        private readonly HttpClient _httpClient = new HttpClient();

        //[HttpGet]
        //[Route("DotNetCount")]
        public async Task<String> GetDotNetCountAsync()
        {
            // Suspends GetDotNetCountAsync() to allow the caller (the web server)
            // to accept another request, rather than blocking on this one.
            var html = await _httpClient.GetStringAsync("https://kitku.id/pelanggan/data/PEL-1");

            //return Regex.Matches(html, @"\.NET").Count;
            return html;
        }
    }

    /*public class UploadImage
    {
        public static string HttpUploadFile(string url, string files, NameValueCollection formFields = null)
        {
            /*String lineEnd = "\r\n";
            String twoHyphens = "--";
            String boundary = "*****";
            //string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
           
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, file, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                //log.Debug(string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd()));
            }
            catch (Exception)
            {
                //log.Error("Error uploading file", ex);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }

            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;

            Stream memStream = new System.IO.MemoryStream();
            var boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            var endBoundaryBytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--");
            string formdataTemplate = "\r\n--" + boundary +
                                        "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";

            if (formFields != null)
            {
                foreach (string key in formFields.Keys)
                {
                    string formitem = string.Format(formdataTemplate, key, formFields[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    memStream.Write(formitembytes, 0, formitembytes.Length);
                }
            }

            string headerTemplate =
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                "Content-Type: application/octet-stream\r\n\r\n";

            for (int i = 0; i < files.Length; i++)
            {
                memStream.Write(boundarybytes, 0, boundarybytes.Length);
                var header = string.Format(headerTemplate, "uplTheFile", files[i]);
                var headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

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
            }

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
                return reader2.ReadToEnd();
            }

            /*
            // Convert each of the three inputs into HttpContent objects

            HttpContent stringContent = new StringContent(filename);
            // examples of converting both Stream and byte [] to HttpContent objects
            // representing input type file
            HttpContent fileStreamContent = new StreamContent(fileStream);
            HttpContent bytesContent = new ByteArrayContent(fileBytes);

            // Submit the form using HttpClient and 
            // create form data as Multipart (enctype="multipart/form-data")

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                // Add the HttpContent objects to the form data

                // <input type="text" name="filename" />
                formData.Add(stringContent, "filename", "filename");
                // <input type="file" name="file1" />
                formData.Add(fileStreamContent, "file1", "file1");
                // <input type="file" name="file2" />
                formData.Add(bytesContent, "file2", "file2");

                // Invoke the request to the server

                // equivalent to pressing the submit button on
                // a form with attributes (action="{url}" method="post")
                var response = await client.PostAsync(url, formData);

                // ensure the request was a success
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return await response.Content.ReadAsStreamAsync();
            }
        }
    }*/

    /*class GetProductInfo
    {
        [System.Runtime.Serialization.DataContract]
        class ProductInfo
        {
            [System.Runtime.Serialization.DataMember]
            public string kategori { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string id_barang { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string nama { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string mitra { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string desc { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string satuan { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string harga { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string jumlah { get; set; }
            [System.Runtime.Serialization.DataMember]
            public string url { get; set; }
        }

        private readonly HttpClient _httpClient = new HttpClient();
        static string url = "http://kitku.id/produk/detail/";
        

        public async void execute(string id_barang)
        {
            ProductInfo productInfo     = new ProductInfo();
            productInfo.id_barang       = id_barang;
            // convert to JSON
            var stream1                 = new MemoryStream();
            var ser                     = new DataContractJsonSerializer(typeof(ProductInfo));
            ser.WriteObject(stream1, productInfo);
            stream1.Position            = 0;

            //var html = await _httpClient.GetStringAsync(url + productInfo.id_barang);
            //Console.WriteLine(html);
            var httpWebRequest          = (HttpWebRequest)WebRequest.Create(url + productInfo.id_barang);
            // get response
            var httpResponse            = (HttpWebResponse)httpWebRequest.GetResponse();
            String result;
            using (var streamReader     = new StreamReader(httpResponse.GetResponseStream()))
            {
                var deserializedUser    = new ProductInfo();
                var ms                  = new MemoryStream(Encoding.UTF8.GetBytes(streamReader.ReadToEnd()));
                result                  = streamReader.ReadToEnd();
                Console.WriteLine(result);
                ser                     = new DataContractJsonSerializer(deserializedUser.GetType());
                deserializedUser        = ser.ReadObject(ms) as ProductInfo;
                productInfo.kategori    = deserializedUser.kategori;
                productInfo.nama        = deserializedUser.nama;
                productInfo.mitra       = deserializedUser.mitra;
                productInfo.desc        = deserializedUser.desc;
                productInfo.satuan      = deserializedUser.satuan;
                productInfo.harga       = deserializedUser.harga;
                productInfo.jumlah      = deserializedUser.jumlah;
                productInfo.url         = deserializedUser.url;

                Console.WriteLine(productInfo.url);
                ms.Close();
            }
        }

        // instance for convert JSON
        [System.Runtime.Serialization.DataContract]
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
    }*/

    /*public class UserData
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
