namespace Shopping_CartApp
{
    public enum ProductCategory
    {
        Clothing,
        Electronics,
        Home,
        Beauty,
        Groceries
    }

    public class Product
    {
        private string name;
        private double price;
        private ProductCategory category;

        public string Name => name;
        public double Price => price;
        public ProductCategory Category => category;

        public Product(string name, double price, ProductCategory category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {name}, Price: {price}, Category: {category}");
        }
    }

    public class ClothingProduct : Product
    {
        private readonly string size;
        private readonly string color;

        public string Size => size;
        public string Color => color;

        public ClothingProduct(string name, double price, ProductCategory category, string size, string color)
            : base(name, price, category)
        {
            this.size = size;
            this.color = color;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Size: {size}, Color: {color}");
        }
    }

    public class ElectronicsProduct : Product
    {
        private readonly string brand;
        private readonly string model;

        public string Brand => brand;
        public string Model => model;

        public ElectronicsProduct(string name, double price, ProductCategory category, string brand, string model)
            : base(name, price, category)
        {
            this.brand = brand;
            this.model = model;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Brand: {brand}, Model: {model}");
        }
    }

    public class ShoppingCart
    {
        private readonly Product[] products;
        private int itemCount;

        public Product[] Products => products;
        public int ItemCount => itemCount;

        public ShoppingCart(int capacity)
        {
            products = new Product[capacity];
            itemCount = 0;
        }

        public void AddProduct(Product product)
        {
            if (itemCount < products.Length)
            {
                products[itemCount] = product;
                itemCount++;
            }
            else
            {
                Console.WriteLine("Shopping cart is full.");
            }
        }

        public void RemoveProduct(Product product)
        {
            bool found = false;
            for (int i = 0; i < itemCount; i++)
            {
                if (products[i] == product)
                {
                    // Shift remaining elements to the left
                    for (int j = i; j < itemCount - 1; j++)
                    {
                        products[j] = products[j + 1];
                    }
                    itemCount--;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Product not found in the shopping cart.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate products
            Product shirt = new ClothingProduct("Shirt", 25.99, ProductCategory.Clothing, "M", "Blue");
            Product phone = new ElectronicsProduct("Phone", 599.99, ProductCategory.Electronics, "Samsung", "Galaxy S21");

            // Instantiate shopping cart
            ShoppingCart cart = new ShoppingCart(10);

            // Add products to the shopping cart
            cart.AddProduct(shirt);
            cart.AddProduct(phone);

            // Display the contents of the shopping cart
            Console.WriteLine("Contents of the shopping cart:");
            foreach (Product product in cart.Products)
            {
                if (product != null)
                {
                    product.GetInfo();
                }
            }

            // Remove a product from the shopping cart
            cart.RemoveProduct(shirt);

            // Display the updated contents of the shopping cart
            Console.WriteLine("\nUpdated contents of the shopping cart:");
            foreach (Product product in cart.Products)
            {
                if (product != null)
                {
                    product.GetInfo();
                }
            }
        }
    }
}
