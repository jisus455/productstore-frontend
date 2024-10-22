using BlazorApp.Models;

namespace BlazorApp.Services
{
    public class ProductService
    {
        private string URL = "http://localhost:5046/api/products";

        public List<Product> GetProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                var products = client.GetFromJsonAsync<List<Product>>(URL).Result;
                return products;
            }
        }

        public bool CreateProduct(Product createProduct)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsJsonAsync(URL, createProduct).Result;
                return response.IsSuccessStatusCode;
            }
        }

        public bool ModifyProduct(Product modifyProduct)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PutAsJsonAsync(URL, modifyProduct).Result;
                return response.IsSuccessStatusCode;
            }
        }

        public bool DeleteProduct(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync($"{URL}?id={id}").Result;
                return response.IsSuccessStatusCode;
            }
        }
    }
}
