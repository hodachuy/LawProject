using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace LawProject.Application.Utilities
{
    public class AccentVietNamese
    {
        private readonly IConfiguration _config;
        private readonly string urlAccentAPI;
        public AccentVietNamese(IConfiguration config)
        {
            _config = config;
            urlAccentAPI = _config["APISettings:UrlAccentVN"];
        }
        /// <summary>
        /// Chuyển đổi Tiếng Việt không dấu tới có dấu
        /// </summary>
        public string GetAccentVN(string text)
        {
            string result = "";
            if (String.IsNullOrEmpty(text))
                return result;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAccentAPI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    text = System.Web.HttpUtility.UrlEncode(text);
                    string requestUri = "AccentVN/ConvertVN?text=" + text;
                    response = client.GetAsync(requestUri).Result;
                }
                catch (Exception ex)
                {
                    return result;
                }
                if (response.IsSuccessStatusCode)
                {
                    string resultConvert = response.Content.ReadAsStringAsync().Result;
                    return resultConvert;
                }
            }
            return result;
        }
    }
}
