
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
using System.Net.WebSockets;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Trumpet",
        Price = 1500.99M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Trombone",
        Price = 3000.50M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "French Horn",
        Price = 2500.50M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "The Green, Green Grass",
        Price = 22.99M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "The Blue, Blue Bay",
        Price = 50.50M,
        ProductTypeId = 2
    }
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Brass Instrument",
        Id = 1
    },
    new ProductType()
    {
        Title = "Poem",
        Id = 2
    }
};
//put your greeting here
string greeting = @"Welcome to Brass and Poem
The one stop Brass and Poem Shop";

Console.WriteLine(greeting);
//implement your loop here
bool isRunning = true;

while (isRunning)
{
    DisplayMenu();
    Console.WriteLine("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "0":
            Console.WriteLine("Closing application, bye!");
            isRunning = false;
            break;
        case "1":
            DisplayAllProducts(products, productTypes);
            break;
        case "2":
            DeleteProduct(products, productTypes);
            break;
        case "3":
            AddProduct(products, productTypes);
            break;
        case "4":
            UpdateProduct(products, productTypes);
            break;
        default:
            Console.WriteLine("Invalid option. Please select a number from 0 to 5");
            break;
    }
}

void DisplayMenu()
{
    Console.WriteLine("\nPlease choose an option:");
    Console.WriteLine("0. Exit");
    Console.WriteLine("1. Display all product");
    Console.WriteLine("2. Delete a product");
    Console.WriteLine("3. Add a new product");
    Console.WriteLine("4. Update product properties");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    if (products.Count == 0)
    {
        Console.WriteLine("No products available.");
        return;
    }

    Console.WriteLine("Available Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
        Console.WriteLine($"{i + 1}. {product.Name} - ${product.Price} ({productType?.Title ?? "Unknown"})");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("All products:");

    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
        Console.WriteLine($"{i + 1}. {product.Name} - ${product.Price} ({productType?.Title ?? "Unknown"})");
    }

    Console.WriteLine("Please enter the number of the item you wish to delete:");
    int productChoice; 
    while (!int.TryParse(Console.ReadLine(), out productChoice) || productChoice < 1 || productChoice > products.Count)
    {
        Console.WriteLine("Please enter a valid number corresponding to the product you wish to remove.");
    }
    products.RemoveAt(productChoice - 1);
    Console.WriteLine("This product has been deleted from the inventory");
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Add a product to the inventory:");

    Console.WriteLine("Enter product name:");
    string name = Console.ReadLine();
    
    Console.WriteLine("Enter the products price:");
    decimal price;
    while(!decimal.TryParse(Console.ReadLine(), out price)  || price < 0)
    {
        Console.WriteLine("Please enter a valid price.");
    }

    Console.WriteLine(@"Please choose the option that best describes your product
    1. Brass Instrument
    2. Poem");
    int productTypeId;
    while(!int.TryParse(Console.ReadLine(), out productTypeId) || productTypeId < 1 || productTypeId > 2)
    {
        Console.WriteLine("Please enter a valid number for product type.");
    }
    
    Product newProduct = new Product()
    {
        Name = name,
        Price = price,
        ProductTypeId = productTypeId
    };

    products.Add(newProduct);
    Console.WriteLine($"The {name} has been added to the store inventory.");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Select a product to update: ");

    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
        Console.WriteLine($"{i + 1}. {product.Name} - ${product.Price} ({productType?.Title ?? "Unknown"})");
    }

    int productChoice;
    while (!int.TryParse(Console.ReadLine(), out productChoice) || productChoice < 1 || productChoice > products.Count)
    {
        Console.WriteLine("Please enter a valid number corresponding to the product you wish to update.");
    }
    Product selectedProduct = products[productChoice - 1];

    Console.WriteLine("Enter a new name or press Enter to keep the current name");
    string name = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(name))
    {
        selectedProduct.Name = name;
    }

    Console.WriteLine("Please enter a new price or press Enter to keep the current price");
    string priceInput = Console.ReadLine();
    if (decimal.TryParse(priceInput, out decimal price) && price >= 0)
    {
        selectedProduct.Price = price;
    }

    Console.WriteLine("Choose the product type or press Enter to keep the current type:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{productTypes[i].Id}. {productTypes[i].Title}");
    }

    string productTypeIdInput = Console.ReadLine();
    if (int.TryParse(productTypeIdInput, out int productTypeId) && productTypeId >= 1 && productTypeId <= productTypes.Count)
    {
        selectedProduct.ProductTypeId = productTypeId;
    }

    Console.WriteLine("Product details updated successfully.");
}

// don't move or change this!
public partial class Program { }