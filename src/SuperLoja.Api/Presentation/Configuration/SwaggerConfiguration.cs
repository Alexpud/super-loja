using System.Reflection;

namespace SuperLoja.Api.Presentation.Configuration;

public static class SwaggerConfiguration
{
    public static IServiceCollection ConfigureSwagerServices(this IServiceCollection services)
    {
        return services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}
