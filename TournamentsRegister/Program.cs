using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TournamentsRegister.DAL;
using TournamentsRegister.DAL.Repositories;
using TournamentsRegister.Models.MiddleModelsForDAL;
using TournamentsRegister.Models.Requests;
using TournamentsRegister.Services;
using TournamentsRegister.Validators.ForRequests;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TournamentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TournamentDemoProjectDB"))
);

builder.Services.AddScoped<IMapper, TournamentMapper>();

builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

builder.Services.AddScoped<TournamentService>();
builder.Services.AddScoped<TeamService>();

builder.Services.AddScoped<IValidator<TournamentInsert>, TournamentInsertValidator>();
builder.Services.AddScoped<IValidator<TournamentUpdate>, TournamentUpdateValidator>();

builder.Services.AddScoped<IValidator<TeamMiddleModelInsert>, TeamInsertValidator>();
builder.Services.AddScoped<IValidator<TeamUpdate>, TeamUpdateValidator>();

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