using Microsoft.EntityFrameworkCore;
using My_API.Connection;

var builder = WebApplication.CreateBuilder(args);

#region Connection Database
var ConfigConnectionStringValue = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(ConfigConnectionStringValue));
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
