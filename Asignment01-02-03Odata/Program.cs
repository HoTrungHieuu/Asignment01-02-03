using BussinessObject.ViewModel;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using Asignment01_02_03Odata;
using DataAccessObject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddOData(options =>
    {
        options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100)
               .AddRouteComponents("odata", GetEdmModel());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OData API", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OData API v1");
    c.RoutePrefix = "swagger";
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<NewsArticleView>("NewsArticles");
    return builder.GetEdmModel();
}