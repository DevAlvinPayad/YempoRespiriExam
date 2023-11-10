using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using YempoRespiriExam.Data;
using YempoRespiriExam.Services;

namespace YempoRespiriExam
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseForwardedHeaders();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "api");
                c.RoutePrefix = string.Empty;
            });

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors();

            // seed data
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

                dataSeeder.Seed();
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .Build());
            });

            services.AddHttpContextAccessor();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "TestDB"));

            services.AddScoped<DataSeeder>();
            services.AddScoped<IPersonServices, PersonServices>();

            services.AddControllers();
        }
    }
}
