using Newtonsoft.Json;

// dotnet add package
// dotnet remove package
// dotnet restore
// dotnet build => build lại khi chỉnh sủa file .csproj
// dotnet add currentProject.csproj reference libaryProject.csproj => EX: dotnet add .../ExtendsionMethod.csproj reference .../Utils/Utils.csproj


namespace CS_Extensions
{
    class Product
    {
        public string Name { get; set; }
        public DateTime Expiry { get; set; }
        public string[] Sizes { get; set; }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Product product = new Product();
            product.Name = "Apple";
            product.Expiry = new DateTime(2008, 12, 28);
            product.Sizes = new string[] { "Small" };

            string json = JsonConvert.SerializeObject(product);
            Product newProduct = JsonConvert.DeserializeObject<Product>(json);
            Console.WriteLine(newProduct.Name);
        }
    }
}

// KEY: asdfdasfsdafsdaf => tao ra trong web nuget
// dotnet pack => dong goi thanh file .nupkg
// dotnet nuget push ...nupkg --api-key KEY --source URL => KEY dc tao ra trong nuget