using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace KitkuAdminApp
{
    class BackgroundTask
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
}
