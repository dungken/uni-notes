using RestSharp;
using Source.Dtos.Category;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Repository
{
    public class CategoryRepository
    {
        private readonly RestClient _apiClient;

        public CategoryRepository()
        {
            _apiClient = new RestClient(new RestClientOptions {
                BaseUrl = new Uri (Utils.Config.BaseUrl),
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            });
        }

        //public async Task<Category> CreateCategoryAsync(CreateCategoryDto categoryDto)
        //{
        //    var request = new RestRequest("api/Category", Method.POST);
        //    return null;
        //}
        //public async Task<Category> GetCategoryByIdAsync(Guid id)
        //{
        //    var request = new RestRequest("api/Category", Method.Get);

        //}
    }
}
