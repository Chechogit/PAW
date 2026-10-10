using System.Net.Http.Json;
using PAW.Web.Models;

namespace PAW.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/products");
        return products ?? Enumerable.Empty<Product>();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/products/{id}");
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<Product>();
    }

    public async Task<Product?> CreateAsync(Product product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/products", product);
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<Product>();
    }

    public async Task<bool> UpdateAsync(int id, Product product)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/products/{id}", product);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/products/{id}");
        return response.IsSuccessStatusCode;
    }
}
