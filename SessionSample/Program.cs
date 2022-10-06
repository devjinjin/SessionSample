var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//jylee �߰�
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => { 
    options.IdleTimeout = TimeSpan.FromSeconds(10);
});
//jylee �߰�

var app = builder.Build();

//jylee �߰�
app.UseSession();
//jylee �߰�

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
