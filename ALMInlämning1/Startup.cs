using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMInlämning1.WebUI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ALMInlämning1
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<BankRepository>();

            //var customers = new List<Customer>();
            //customers.Add(new Customer { CusomterId = 1, FirstName = "Hans", LastName = "Svensson", Address = "Ringvägen 3" });
            //customers.Add(new Customer { CusomterId = 2, FirstName = "Lars", LastName = "Lunden", Address = "Hamngatan 6" });
            //customers.Add(new Customer { CusomterId = 3, FirstName = "Greta", LastName = "Kvast", Address = "Solstigen 54" });

            //var accounts = new List<Account>();
            //accounts.Add(new Account { CusomterId = 1, AccountNumber = 12345, Balance = 900000 });
            //accounts.Add(new Account { CusomterId = 2, AccountNumber = 23456, Balance = 1000000 });
            //accounts.Add(new Account { CusomterId = 3, AccountNumber = 34567, Balance = 500000 });
            //accounts.Add(new Account { CusomterId = 1, AccountNumber = 45678, Balance = 4500000 });

            //var repo = new BankRepository(customers, accounts);
            
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
