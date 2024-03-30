using Languamania.Data;
using Languamania.Server.AppStart.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using System.Security.Cryptography.X509Certificates;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder = RegisterServices(builder);

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.UseMiddleware<DataAccessMiddleware>();
        app.MapControllers();
        app.MapFallbackToFile("/index.html");

        app.Run();
    }

    private static WebApplicationBuilder RegisterServices(WebApplicationBuilder builder)
    {
        var httpsConnectionAdapterOptions = new HttpsConnectionAdapterOptions
        {
            SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
            ClientCertificateMode = ClientCertificateMode.AllowCertificate,
            ServerCertificate = new X509Certificate2("..\\.local\\certs\\lang-local-cert.pfx", "Password")

        };
        // configure https
        builder.Services.Configure<KestrelServerOptions>(options =>
        {
            options.ConfigureEndpointDefaults(listenOptions =>
                listenOptions.UseHttps(httpsConnectionAdapterOptions)
            );
        });
        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #region app services registration
        var connectionString = builder.Configuration.GetConnectionString("MainConnection") ?? throw new ArgumentNullException("connectionString");
        builder.Services.AddDataServices(connectionString);
        #endregion

        return builder;
    }
}