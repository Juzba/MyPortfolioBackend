using MyPortfolioBackend;
using MyPortfolioBackend.Services;
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.AspNetCore.Builder;  

var builder = WebApplication.CreateBuilder(args);



// Registrace služby EmailService  
builder.Services.AddSingleton<EmailService>();



//////////////

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors //
builder.Services.AddCors(options =>
options.AddPolicy("AllowAll", builder =>
builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);

var app = builder.Build();

// Cors //
app.UseCors("AllowAll");


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
