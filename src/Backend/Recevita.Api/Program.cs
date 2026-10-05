using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Recevita.Api.Converters;
using Recevita.Api.Filters;
using Recevita.Application;
using Recevita.Infrastructure;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new StringConverter()));
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultes = new List<CultureInfo> { new CultureInfo("pt-BR") };

    options.DefaultRequestCulture = new RequestCulture("pt-BR");

    options.SupportedCultures = supportedCultes;
    options.SupportedUICultures = supportedCultes;

    options.RequestCultureProviders = [new AcceptLanguageHeaderRequestCultureProvider()];
});

builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(localizationOptions.Value);


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
