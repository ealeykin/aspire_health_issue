var builder = DistributedApplication.CreateBuilder(args);

// var db = builder
//     .AddSqlServer("sql-server")
//     .AddDatabase("db")
//     //.WithHealthCheck("Postgres")
//     ;

var db = builder.AddPostgres("postgres");

var host1 = builder
    .AddProject<Projects.WebApplication1>("Host1")
    .WithReference(db)
    .WaitFor(db);

var host2 = builder
    .AddProject<Projects.WebApplication2>("Host2")
    .WithReference(db)
    .WaitFor(db)
    .WaitForCompletion(host1);

builder.Build().Run();