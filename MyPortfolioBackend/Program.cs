var builder = WebApplication.CreateBuilder(args);


// Pøidání CORS služby  
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        // Zde specifikujte konkrétní domény  
        builder.WithOrigins("https://gentle-stone-053662403.6.azurestaticapps.net", "http://localhost:5173") // Pøidejte konkrétní adresy  
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials(); // Umožòuje cookies a autentizaèní hlavièky  
    });
});


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
