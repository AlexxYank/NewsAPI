namespace NewsAPI.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseCustomSwaggerDocumentation(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewsAPI v1");
            });
        }
    }
}

