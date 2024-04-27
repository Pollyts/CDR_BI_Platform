using CDR_BI_Platform.Models;
using CDR_BI_Platform.Repositories.Interfaces;
using CDR_BI_Platform.Repositories;
using CDR_BI_Platform.Services.Implementation;
using CDR_BI_Platform.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TranslationManagement.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlite("Data Source=TranslationAppDatabase.db"));

var _entitiesModelsAssemblies =
    new Assembly[]
    {
                    Assembly.Load("TranslationManagement.Api")
    };

var entitiesTypes = _entitiesModelsAssemblies
    .SelectMany(x => x.GetTypes())
    .Where(x => typeof(IEntityDb).IsAssignableFrom(x) && x != typeof(IEntityDb));

foreach (var entityType in entitiesTypes)
{
    {
        services.AddScoped(typeof(IBaseRepository<>).MakeGenericType(entityType), typeof(BaseRepository<>).MakeGenericType(entityType));
    }
}


services.AddScoped<ITranslatorService, CallService>();
services.AddScoped<IBaseService<Translator>, CallService>();

services.AddScoped<ICallService, TranslationJobService>();
services.AddScoped<IBaseService<TranslationJob>, TranslationJobService>();

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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
