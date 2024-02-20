


using Services.Experiment;
using Services.Lab;
using Services.Lesson;
using Services.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IExperimentService, ExperimentService>();
builder.Services.AddTransient<ILessonService, LessonService>();
builder.Services.AddTransient<ILabService, LabService>();

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
