using DependencyInjectionExample.Interface;
using DependencyInjectionExample.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Teacher nesnesini oluşturuyoruz ve ClassRoom'a inject ediyoruz
IOgretmen teacher = new Teacher("Ali", "Yılmaz");
ClassRoom classRoom = new ClassRoom(teacher);

// Öğretmen bilgilerini ekrana yazdırıyoruz
Console.WriteLine(classRoom.GetTeacherInfo());
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
