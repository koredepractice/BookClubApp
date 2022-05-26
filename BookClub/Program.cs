using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Bookclub.Data;
using BookClubApp.Data.Repositories;
using Bookclub.Models;
using BookClubApp.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container (start).
builder.Services.AddDbContext<BookclubContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// for book table 
builder.Services.AddScoped<ICrudRepository<Book, int>, BooksRepository>();
builder.Services.AddScoped<ICrudService<Book, int>, BooksService>();
//for member table 
builder.Services.AddScoped<ICrudRepository<Member, int>, MembersRepository>();
builder.Services.AddScoped<ICrudService<Member, int>, MembersService>();
//for rating table
builder.Services.AddScoped<ICrudRepository<Rating, int>, RatingsRepository>();
builder.Services.AddScoped<ICrudService<Rating, int>, RatingsService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "BookClub",
//        Version =
//    "v1"
//    });
//});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);//To EnableCors - CrossOrigin

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseDefaultFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();