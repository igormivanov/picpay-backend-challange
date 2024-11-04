using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PicPayChallange.API.Data;
using PicPayChallange.API.Repositories;
using PicPayChallange.API.Services;
using PicPayChallange.API.Services.Autorization;
using PicPayChallange.API.Services.Notify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddHttpClient("Authorization", httpClient => {
    httpClient.BaseAddress = new Uri(builder.Configuration["HttpClients:AuthorizationAPI:BaseAddress"]!);
});

builder.Services.AddHttpClient("Notify", httpClient => {
    httpClient.BaseAddress = new Uri(builder.Configuration["HttpClients:NotifyAPI:BaseAddress"]!);
});
  
        

builder.Services.AddScoped<IUserModelService, UserModelService>();
builder.Services.AddScoped<IUserModelRepository, UserModelRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IAuthorizationApiService, AuthorizationApiService>();
builder.Services.AddScoped<INotifyApiService, NotifyApiService>();



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
