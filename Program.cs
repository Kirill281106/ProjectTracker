using Microsoft.EntityFrameworkCore;
using ProjectTracker.Data;
using ProjectTracker.Middleware;
using ProjectTracker.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProjectService,ProjectService>();//Эта строка говорит DI-контейнеру:
                                                             //«Когда кто-то запросит IProjectService — создай экземпляр ProjectService и отдай его».

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();