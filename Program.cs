var builder = WebApplication.CreateBuilder();
builder.Services
.AddFastEndpoints()
.SwaggerDocument();

var app = builder.Build();

await DB.InitAsync(app.Configuration["DbName"]!, "localhost");
// await DB.MigrateAsync();

app
.UseFastEndpoints()
.UseSwaggerGen();

app.Run();