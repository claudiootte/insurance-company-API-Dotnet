using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using src.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
builder.Services.AddScoped<DatabaseContext, DatabaseContext>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Insurance Company API Dotnet",
        Description = "Uma API idealizada para seguradoras ou empresas demandem por controle sobre contratos de seus clientes.",
        Contact = new OpenApiContact
        {
            Name = "Contato com o Dev: Claudio Otte",
            Url = new Uri("https://claudiootte.com")
        },
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
