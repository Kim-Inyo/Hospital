using Database;
using Database.Repository;
using Domain.Logic;
using Domain.Models;
using Domain.UseCase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql($"Host=localhost;Port=5432;Database=user_db;Username=user1;Password=user1"));
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.EnableSensitiveDataLogging(true));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IScheduleRepository, ScheduleRepository>();
builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<ISpecRepository, SpecRepository>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<DoctorService>();
builder.Services.AddTransient<ScheduleService>();
builder.Services.AddTransient<AppointmentService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
