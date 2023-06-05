using NewsAPI.Extensions;
using NewsAPI.Infrastructure.Extensions;
using NewsAPI.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructureServices();
builder.Services.AddCustomServices();
builder.Services.AddSwaggerDocumentation();
builder.Services.ConfigureAuthentication();

var app = builder.Build();

// Configure middleware
app.UseCustomSwaggerDocumentation(app.Environment);
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Configure endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
