using KPI5.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMemoryCache();
builder.Services.AddControllersWithViews()
    .ConfigureApiBehaviorOptions(options => options.SuppressMapClientErrors = true);

var connDb = builder.Configuration.GetConnectionString("PostgreConnectionString");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(connDb));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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