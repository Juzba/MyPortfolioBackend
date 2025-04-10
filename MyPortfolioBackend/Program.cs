
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.AspNetCore.Builder;  

var builder = WebApplication.CreateBuilder(args);


//////////////
///
// P�id�n� CORS slu�by  
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // P�idejte zde va�e adresy  
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


// Cors //
//builder.Services.AddCors(options =>
//options.AddPolicy("AllowAllOrigins", builder =>
//builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
//);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Cors //
app.UseCors("AllowSpecificOrigins");








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
