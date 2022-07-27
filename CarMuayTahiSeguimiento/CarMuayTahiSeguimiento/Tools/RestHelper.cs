using CarMuayTahiSeguimiento.Tools.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarMuayTahiSeguimiento.Tools
{
    public class RestHelper
    {

        #region Request params
        public string ApiUrl { get; set; }
        public string ContollerName { get; set; }
        public string MethodName { get; set; }
        public HttpMethodsEnum _HttpMethod { get; set; }
        public object Params { get; set; }
        public object Body { get; set; }
        #endregion
        #region Result params
        public object Response { get; set; }
        public bool Error { get; set; }
        public string Message { get; set; }
        #endregion
        public RestHelper(string apiUrl, string contollerName, HttpMethodsEnum httpMethod, string methodName = null, object _params = null, object body = null)
        {
            ApiUrl = apiUrl;
            ContollerName = contollerName;
            MethodName = methodName;
            _HttpMethod = httpMethod;
            Params = _params;
            Body = body;
        }
        public async void RestRequest()
        {
            try
            {
                var uri = $"{this.ApiUrl.Trim()}/{this.ContollerName.Trim()}";
                if (!string.IsNullOrEmpty(this.MethodName?.Trim() ?? null))
                    uri += $"/{this.MethodName.Trim()}";
                //falta implementar parametros en la ruta de la uri ejemplo ?id=3&valor="Hola"
                var client = new HttpClient();
                switch (this._HttpMethod)
                {
                    case HttpMethodsEnum.Get:
                        var request = new HttpRequestMessage();
                        request.RequestUri = new Uri(uri);
                        request.Method = HttpMethod.Get;
                        request.Headers.Add("Accept", "aplication/json");
                        HttpResponseMessage responseGet = await client.SendAsync(request);
                        if (responseGet.StatusCode == HttpStatusCode.OK)
                        {
                            string content = await responseGet.Content.ReadAsStringAsync();
                            var resultado = JsonConvert.DeserializeObject<object>(content);
                            this.Response = resultado;
                        }
                        else { 
                            this.Error = true;
                            this.Message = responseGet.Content.ReadAsStringAsync().Result;
                        }
                        break;
                    case HttpMethodsEnum.Post:
                        var RequestUri = new Uri(uri);
                        var json = JsonConvert.SerializeObject(this.Body);
                        var contentJson = new StringContent(json,Encoding.UTF8,"application/json");
                        var responsePost = await client.PostAsync(RequestUri,contentJson);
                        if (responsePost.StatusCode == HttpStatusCode.OK)
                        {
                            string content = await responsePost.Content.ReadAsStringAsync();
                            var resultado = JsonConvert.DeserializeObject<object>(content);
                            this.Response = resultado;
                        }
                        else
                        {
                            this.Error = true;
                            this.Message = responsePost.Content.ReadAsStringAsync().Result;

                        }
                        break;
                    case HttpMethodsEnum.Put:
                        break;
                    case HttpMethodsEnum.Delete:
                        break;
                    default:
                        this.Error = true;
                        this.Message = "La petición HTTP no está configurada";
                        break;
                }

            }
            catch (Exception ex)
            {
                this.Error = true;
                this.Message = ex.Message;
                if (ex.InnerException != null)
                    this.Message += $"\n{ex.InnerException.Message}";
            }

        }
    }
}
