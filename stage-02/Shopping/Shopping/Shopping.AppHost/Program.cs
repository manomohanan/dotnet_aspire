var builder = DistributedApplication.CreateBuilder(args);

var productDbPort = builder.AddParameter("productDb-port", false);
var productDbUsername = builder.AddParameter("productDb-uname", true);
var productDbPassword = builder.AddParameter("productDb-password", true);

var mongo = builder.AddMongoDB("catalogdb", Convert.ToInt32(productDbPort.Resource.Value), productDbUsername, productDbPassword)
    .WithMongoExpress();
var productsDb = mongo.AddDatabase("ProductsDb");

builder.AddProject<Projects.Catalog_API>("catalog-api")
    .WithEnvironment("DatabaseSettings_DatabaseName", builder.Configuration["DatabaseSettings:DatabaseName"])
    .WithEnvironment("DatabaseSettings_CollectionName", builder.Configuration["DatabaseSettings:CollectionName"])
    .WithEnvironment("DatabaseSettings_BrandsCollection", builder.Configuration["DatabaseSettings:BrandsCollection"])
    .WithEnvironment("DatabaseSettings_TypesCollection", builder.Configuration["DatabaseSettings:TypesCollection"])
    .WithReference(productsDb)
    .WaitFor(productsDb);

var cartDbPort = builder.AddParameter("cartDb-port", false);
var cartDbUsername = builder.AddParameter("cartDb-uname", true);
var cartDbPassword = builder.AddParameter("cartDb-password", true);
var sqlServer = builder.AddSqlServer("cartdbserver", cartDbPassword, Convert.ToInt32(cartDbPort.Resource.Value))
    .WithDataVolume();
var cartDatabase = sqlServer.AddDatabase("CartDb");

builder.AddProject<Projects.Cart_API>("cart-api").WithReference(cartDatabase)
    .WaitFor(cartDatabase);

builder.Build().Run();