using AppMvc.Net.Models;

namespace AppMvc.Net.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new[]
            {
                new ProductModel() {Id = 1, Name = "Iphone A", Price = 22000},
                new ProductModel() {Id = 2, Name = "Iphone B", Price = 35000},
                new ProductModel() {Id = 3, Name = "Iphone C", Price = 13000},
                new ProductModel() {Id = 4, Name = "Iphone D", Price = 57000},
            });
        }

    }
}
