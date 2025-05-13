using Gambit.Domain.Exceptions;
using Gambit.Domain.Models;
using Gambit.Domain.Repositories;

namespace Gambit.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static int _productId = 1;
        private static int GenerateId() { return _productId++; }

        #region FakeData
        private static List<Product> Products = new List<Product>()
        {
            new Product
            {
                Id = GenerateId(),
                Name = "Ordinateur Portable",
                Price = "1200.00",
                Tags = new List<string> { "électronique", "informatique", "portable" },
                Desc = "Un puissant ordinateur portable pour le travail et les loisirs.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddDays(-30),
                UpdatedAt = DateTime.Now,
                Quantity = 15
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Livre de Cuisine",
                Price = "25.50",
                Tags = new List<string> { "livre", "cuisine", "recettes" },
                Desc = "Un livre rempli de délicieuses recettes du monde entier.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddMonths(-2),
                UpdatedAt = null,
                Quantity = 50
            },
            new Product
            {
                Id = GenerateId(),
                Name = "T-Shirt en Coton Bio",
                Price = "19.99",
                Tags = new List<string> { "vêtements", "t-shirt", "bio" },
                Desc = null,
                IsAvailable = false,
                CreatedAt = DateTime.Now.AddYears(-1),
                UpdatedAt = DateTime.Now.AddDays(-5),
                Quantity = 0
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Cafetière Électrique",
                Price = "79.95",
                Tags = new List<string> { "électroménager", "cuisine", "café" },
                Desc = "Une cafetière rapide et efficace pour préparer votre café du matin.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = null,
                Quantity = 25
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Jeu de Société",
                Price = "35.00",
                Tags = new List<string> { "jeux", "famille", "divertissement" },
                Desc = "Un jeu de société amusant pour toute la famille.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddMonths(-6),
                UpdatedAt = DateTime.Now.AddDays(-1),
                Quantity = 10
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Smartphone Android",
                Price = "650.00",
                Tags = new List<string> { "électronique", "mobile", "android" },
                Desc = "Un smartphone puissant avec un excellent appareil photo.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddDays(-20),
                UpdatedAt = DateTime.Now,
                Quantity = 22
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Chaussures de Running",
                Price = "89.99",
                Tags = new List<string> { "sport", "chaussures", "course" },
                Desc = "Des chaussures confortables pour vos entraînements de course.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddMonths(-1),
                UpdatedAt = null,
                Quantity = 35
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Sac à Dos de Randonnée",
                Price = "55.75",
                Tags = new List<string> { "aventure", "extérieur", "randonnée" },
                Desc = "Un sac à dos robuste et spacieux pour vos excursions.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddYears(-2),
                UpdatedAt = DateTime.Now.AddDays(-15),
                Quantity = 18
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Théière en Fonte",
                Price = "42.50",
                Tags = new List<string> { "cuisine", "thé", "ustensiles" },
                Desc = "Une élégante théière en fonte pour une infusion parfaite.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = null,
                Quantity = 12
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Plantes d'Intérieur (Lot de 3)",
                Price = "30.00",
                Tags = new List<string> { "maison", "décoration", "plantes" },
                Desc = "Un ensemble de trois plantes d'intérieur faciles à entretenir.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddMonths(-4),
                UpdatedAt = DateTime.Now.AddDays(-2),
                Quantity = 40
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Casque Audio Bluetooth",
                Price = "110.00",
                Tags = new List<string> { "électronique", "audio", "sans-fil" },
                Desc = "Un casque audio confortable avec une excellente qualité sonore.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddDays(-12),
                UpdatedAt = null,
                Quantity = 28
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Huile d'Olive Extra Vierge (1L)",
                Price = "15.99",
                Tags = new List<string> { "alimentation", "huile", "cuisine" },
                Desc = "Une huile d'olive de première qualité pour vos plats.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddMonths(-3),
                UpdatedAt = DateTime.Now.AddDays(-7),
                Quantity = 60
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Puzzle 1000 Pièces",
                Price = "22.00",
                Tags = new List<string> { "jeux", "loisirs", "puzzle" },
                Desc = "Un puzzle stimulant de 1000 pièces pour les amateurs.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddDays(-8),
                UpdatedAt = null,
                Quantity = 30
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Lampe de Bureau LED",
                Price = "39.90",
                Tags = new List<string> { "maison", "bureau", "éclairage" },
                Desc = "Une lampe de bureau à LED avec intensité réglable.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddMonths(-5),
                UpdatedAt = DateTime.Now.AddDays(-3),
                Quantity = 20
            },
            new Product
            {
                Id = GenerateId(),
                Name = "Serviettes de Bain en Coton (Lot de 2)",
                Price = "28.50",
                Tags = new List<string> { "maison", "salle de bain", "textile" },
                Desc = "Un ensemble de deux serviettes de bain douces et absorbantes.",
                IsAvailable = true,
                CreatedAt = DateTime.Now.AddDays(-18),
                UpdatedAt = null,
                Quantity = 45
            }
        };
        #endregion

        public Product Create(Product product)
        {
            if (Products.Any(p => string.Equals(p.Name, product.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ProductAlreadyExisteException();
            }

            Product productDB = new Product()
            {
                Id = GenerateId(),
                Name = product.Name,
                Price = product.Price,
                Tags = product.Tags.Select(t => t).ToList(),
                IsAvailable = product.IsAvailable,
                Desc = product.Desc,
                Quantity = product.Quantity,
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            };

            Products.Add(productDB);
            return productDB;
        }

        public bool Delete(int id)
        {
            int nbRow = Products.RemoveAll(p => p.Id == id);    
            return nbRow > 0;
        }

        public Product? Get(int id)
        {
            Product? product = Products.SingleOrDefault(p => p.Id == id);            
            return product;
        }

        public IEnumerable<Product> GetAll(int offset, int limit)
        {
            return Products.Skip(offset).Take(limit);
        }

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
