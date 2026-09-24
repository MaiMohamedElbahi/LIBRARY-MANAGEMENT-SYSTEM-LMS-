using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Data;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.Mappings;
using LIBRARY_MANAGEMENT_SYSTEM__LMS_.REPOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryManagementAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True"));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
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
