namespace RoyalLibrary.WebApplicationUtils;

public class ApplicationConfiguration
{
    public void Configure(IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseRouting();

        app.UseAuthentication();
        app.UseCors("AllowAll");
        app.UseStaticFiles();
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(configuration["Swagger:Path"], "API V1");
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}