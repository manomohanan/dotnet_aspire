var builder = DistributedApplication.CreateBuilder(args);
var mongo = builder.AddMongoDB("mongodb") // Use "mongodb" as the identifier
    .WithMongoExpress()
    .AddDatabase("ProductDb");

builder.AddProject<Projects.Cart_API>("cart-api");

builder.AddProject<Projects.Catalog_API>("catalog-api").WithReference(mongo)
       .WaitFor(mongo); ;

builder.Build().Run();
