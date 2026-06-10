var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        // Ponto crucial: No .NET 10, o JSON padrão é gerado em /openapi/v1.json
        options.SwaggerEndpoint("/openapi/v1.json", "Minha API .NET 10 v1");

        // Opcional: Se quiser que o Swagger abra direto na raiz (ex: localhost:5000/)
        // em vez de localhost:5000/swagger, descomente a linha abaixo:
        // options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
