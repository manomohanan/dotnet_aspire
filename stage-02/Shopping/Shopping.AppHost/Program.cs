var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Cart_API>("cart-api");

builder.AddProject<Projects.Catalog_API>("catalog-api");

builder.Build().Run();
