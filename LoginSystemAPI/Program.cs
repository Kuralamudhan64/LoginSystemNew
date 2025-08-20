using System.Data;
using System.Data.SqlClient;
using LoginSystemAPI.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.RegisterApplicationServices();

builder.Services.AddScoped<IDbConnection>(connection => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

var allowOrigins = "_allowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigins,
        builder =>
        {
            builder.WithOrigins("https://localhost:7056")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
var app = builder.Build();
app.UseCors(allowOrigins);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
