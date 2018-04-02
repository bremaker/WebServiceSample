using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
   public class ProductManager
    {
        public Dictionary<int, Product> products { get; set; }
        public int index { get; set; }
        private delegate int del(int i); // example lambda expression

        public ProductManager(int size)
        {
            this.products = new Dictionary<int, Product>();
            this.products.Add(1, new Product { Id = 1, Name = "Sopa", Category = "Primero", Price = 10 });
            this.products.Add(2, new Product { Id = 2, Name = "Ensalada", Category = "Primero", Price = 12 });
            this.products.Add(3, new Product { Id = 3, Name = "Entremeses", Category = "Primero", Price = 15 });
            this.products.Add(4, new Product { Id = 4, Name = "Hamburguesa", Category = "Segundo", Price = 18 });
            this.products.Add(5, new Product { Id = 5, Name = "Steak", Category = "Segundo", Price = 20 });

            this.index = 6;
        }

        public Product GetProduct(int id)
        {
            del func = x => x * x; // example lambda expression

            Product product;
            bool finded = products.TryGetValue(id, out product);

            return finded ? product : null;
        }

        public Product[] GetAll()
        {
            return products.Values.ToArray();
        }

        public bool DeleteProduct(int id)
        {
            return products.Remove(id);
        }

        public int AddProduct(Product p)
        {
            p.Id = this.index;
            products.Add(this.index, p);
            this.index++;

            return p.Id;
        }
    }
}
