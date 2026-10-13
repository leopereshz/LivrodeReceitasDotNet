using System.Globalization;
using LivroDeReceitas.API.Converters;
using LivroDeReceitas.API.Filters;
using LivroDeReceitas.Application;
using LivroDeReceitas.Infrastructure;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new StringConverter()));
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddOpenApi();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "pt", "en", "es" };

    options.SetDefaultCulture("pt")
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});

builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseRequestLocalization();

app.UseAuthorization();

app.MapControllers();

app.Run();
