using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DevWebsCourseProjectApp.Models;
using Microsoft.AspNetCore.Identity;
using DevWebsCourseProjectApp.Services;

namespace DevWebsCourseProjectApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();


            // ef to create the tables base on ProfileContext.cs
            services.AddDbContext<ProfileContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"])); // db connection in appsettings.json

            // register identity login config
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ProfileContext>()
                .AddDefaultTokenProviders();

            // register sendgrid
            services.AddTransient<IEmailSend, MessageSend>();

            // register api keys for user secrets
            services.Configure<MessageSenderOptions>(Configuration);

            // register twillio
            services.AddTransient<ISmsSend, MessageSend>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // for login stuff
            app.UseAuthentication();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
