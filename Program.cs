using Microsoft.EntityFrameworkCore;
using PruebaDesempeno.Data;
using PruebaDesempeno.Services.Courses;
using PruebaDesempeno.Services.Emails;
using PruebaDesempeno.Services.Enrollments;
using PruebaDesempeno.Services.Students;
using PruebaDesempeno.Services.Teachers;

var builder = WebApplication.CreateBuilder(args);

//Controladores
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conexion a la bd
builder.Services.AddDbContext<SchoolContext>(
    opt => opt.UseMySql(
        builder.Configuration.GetConnectionString("MySql"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2")));

//Añadir interfaces
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IMailService, MailService>();


//peticiones HTTP
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
