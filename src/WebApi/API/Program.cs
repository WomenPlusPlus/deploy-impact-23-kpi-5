using Api.Common;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<Supabase.Client>(_ => 
    new Supabase.Client(
        builder.Configuration["Supabase:ApiUrl"], 
        builder.Configuration["Supabase:ApiKey"],
        new SupabaseOptions
        {
            AutoRefreshToken = true,
        }));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
