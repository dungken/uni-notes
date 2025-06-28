using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Source.Views.Custommer;
using Newtonsoft.Json.Linq;
using RestSharp.Authenticators;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using static Google.Apis.Requests.BatchRequest;
namespace Source.DataAcess
{
    public class ApiClient
    {
        private readonly RestClient _client;
      
        public ApiClient(string baseUrl)
        {
            if(Utils.Config.token != "")
            {
                var authenticator = new JwtAuthenticator(Utils.Config.token);
                var options = new RestClientOptions(Utils.Config.BaseUrl)
                {
                    Authenticator = authenticator
                };
                _client = new RestClient(options);
            }
            else
            {
                _client = new RestClient(baseUrl);
            }     
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            request.AddHeader("Authorization", $"Bearer {Utils.Config.token}");

            var response = await _client.ExecuteAsync<T>(request);

            if (response.IsSuccessful)
            {
                // Format JSON response
                //var formattedJson = FormatJson(response.Content);
                //MessageBox.Show(response.StatusCode.ToString());
                
                //throw new Exception($"API Error: {response.ErrorMessage}");
                return response.Data;
            }
            //// Format JSON response
            //var formattedJson = FormatJson(response.Content);
            ////MessageBox.Show(response.StatusCode.ToString() + "\n" + formattedJson);

            throw new Exception($"API Error: {response.ErrorMessage}");
        }

        public async Task<T> PostAsync<T>(string endpoint, object? body = null)
        {
            var request = new RestRequest(endpoint, Method.Post);
            if(Utils.Config.token != null)
            {
                request.AddHeader("Authorization", $"Bearer {Utils.Config.token}");
            }      

            if (body != null)
            {
                request.AddJsonBody(body);
            }

            var response = await _client.ExecuteAsync<T>(request);

            //if (!response.IsSuccessful)
            //{
            //    // In chi tiết lỗi
            //    //MessageBox.Show($"API Error: {response.ErrorMessage}\nStatus: {response.StatusCode}\nResponse Content: {response.Content}");

            //    // Nếu có response nội dung, hiển thị nó để debug
            //    if (response.Content != null)
            //    {
            //        MessageBox.Show("API Error: " + response.ErrorMessage + "\nLỗi " + response.StatusCode.ToString() + "\nResponse Content: " + response.Content);
            //        //var formattedJson = FormatJson(response.Content);
            //        //MessageBox.Show(response.StatusCode.ToString() + "\n" + formattedJson);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Lỗi " + response.StatusCode.ToString() + "\nResponse Content: " + response.ErrorMessage);
            //    }
            //    //throw new Exception($"API Error: {response.ErrorMessage}");
            //}

            ////MessageBox.Show(response.StatusCode.ToString());
            return response.Data;
        }

        public async Task<T> PostImageAsync<T>(string endpoint, string filePath, string username)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddHeader("Authorization", $"Bearer {Utils.Config.token}");
            //request.Authenticator = new JwtAuthenticator(Utils.Config.token);
            if (filePath != null)
            {
                request.AddFile("file", filePath);
            }
            if (!string.IsNullOrEmpty(username))
            {
                request.AddParameter("username", username);
            }
            var response = await _client.ExecuteAsync<T>(request);
            if (!response.IsSuccessful)
            {
                //// Format JSON response
                //if (response.Content != null)
                //{
                //    var formattedJson = FormatJson(response.Content);
                //    //MessageBox.Show(response.StatusCode.ToString() + "\n" + formattedJson);
                //}
                //else
                //{
                //    ////MessageBox.Show(response.StatusCode.ToString());
                //}
                throw new Exception($"API Error: {response.ErrorMessage}");
            }
            ////MessageBox.Show(response.StatusCode.ToString());
            return response.Data;
        }

        public async Task<T> PostAsync<T>(string endpoint, IFormFile[] files, Guid productId, string altText)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddHeader("Authorization", $"Bearer {Utils.Config.token}");
            //request.Authenticator = new JwtAuthenticator(Utils.Config.token);
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await file.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();

                    // Tên trường phải là "files"
                    request.AddFile("files", fileBytes, file.FileName, file.ContentType);
                }
            }

            request.AddParameter("productId", productId);
            request.AddParameter("altText", altText);

            var response = await _client.ExecuteAsync<T>(request);
            if (!response.IsSuccessful)
            {
                //// Format JSON response
                //if (response.Content != null)
                //{
                //    var formattedJson = FormatJson(response.Content);
                //    //MessageBox.Show(response.StatusCode.ToString() + "\n" + formattedJson);
                //}
                //else
                //{
                //    ////MessageBox.Show(response.StatusCode.ToString());
                //}
                throw new Exception($"API Error: {response.ErrorMessage}");
            }
            ////MessageBox.Show(response.StatusCode.ToString());
            return response.Data;
        }

      


        public async Task<T> PutAsync<T>(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddHeader("Authorization", $"Bearer {Utils.Config.token}");
            request.AddJsonBody(body);
            var response = await _client.ExecuteAsync<T>(request);
            if (!response.IsSuccessful)
            {
                // Format JSON response
                //var formattedJson = FormatJson(response.Content);
                ////MessageBox.Show(response.StatusCode.ToString() + "\n" + formattedJson);
                throw new Exception($"API Error: {response.ErrorMessage}");
            }
            return response.Data;
        }
        public async Task<T> PutAsync<T>(string endpoint, Guid productId, IFormFile[] newFiles,  IEnumerable<Guid> imageIdsToDelete, string altText)
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddHeader("Authorization", $"Bearer {Utils.Config.token}");
           
            // Thêm các tệp mới vào form-data
            if (newFiles != null && newFiles.Length > 0)
            {
                foreach (var file in newFiles)
                {
                    if (file != null && file.Length > 0)
                    {
                        using var memoryStream = new MemoryStream();
                        await file.CopyToAsync(memoryStream);
                        var fileBytes = memoryStream.ToArray();

                        // Thêm từng file với field name là "newFiles"
                        request.AddFile("newFiles", fileBytes, file.FileName, file.ContentType);
                    }
                }
            }

            // Thêm danh sách imageIdsToDelete vào form-data
            if (imageIdsToDelete != null && imageIdsToDelete.Any())
            {
               
                foreach (var id in imageIdsToDelete)
                {
                    request.AddParameter("imageIdsToDelete", id);
                }
               
               
            }
          
            // Thêm các tham số khác
            request.AddParameter("productId", productId);
            request.AddParameter("altText", altText);

            var response = await _client.ExecuteAsync<T>(request);
            if (!response.IsSuccessful)
            {
                //// Format JSON response
                //var formattedJson = FormatJson(response.Content);
                ////MessageBox.Show(response.StatusCode.ToString() + "\n" + formattedJson);
                throw new Exception($"API Error: {response.ErrorMessage}");
            }
            return response.Data;
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Delete);
           
            var response = await _client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                //Format JSON response
                var formattedJson = FormatJson(response.Content);
                MessageBox.Show(response.StatusCode.ToString() + "\n" + formattedJson);
                throw new Exception($"API Error: {response.ErrorMessage}");
            }
            return true;
        }

   
        public async Task<T> PatchAsync<T>(string endpoint, object body)
        {
            var request = new RestRequest(endpoint, Method.Patch);
          
            request.AddJsonBody(body);
            var response = await _client.ExecuteAsync<T>(request);
            if (!response.IsSuccessful)
            {
                // Format JSON response
                //var formattedJson = FormatJson(response.Content);
                ////MessageBox.Show(response.StatusCode.ToString() + "\n" + formattedJson);
                throw new Exception($"API Error: {response.ErrorMessage}");
            }
            return response.Data;
        }
        private string FormatJson(string json)
        {
            try
            {
                var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
                return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions { WriteIndented = true });
            }
            catch
            {
                return json; // Trả về JSON gốc nếu không thể định dạng
            }
        }
    }
}
