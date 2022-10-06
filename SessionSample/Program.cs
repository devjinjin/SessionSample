var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//jylee 추가
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => { 
    options.IdleTimeout = TimeSpan.FromSeconds(10);
});
//jylee 추가

var app = builder.Build();

//jylee 추가
app.UseSession();
//jylee 추가

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
