using Microsoft.AspNetCore.Mvc;
using NotesWebApi.Data;
using NotesWebApi.Data.Interfaces;
using NotesWebApi.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NotesWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //указываем, какой использовать sql-сервер, с помощью переменной, в которой хранятся настройки из файла 
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            /*---связываем интерфейс с классом, реализующим этот интерфейс---*/
            //для работы с БД используем repository
            services.AddTransient<IAllPerson, PersonRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
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
                app.UseHsts();
            }
            using (var scope = app.ApplicationServices.CreateScope())
            {
                //подключаем AppDBContent, чтобы на основе него подключаться к БД
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                //заполняем базу, если она пустая
                DBObjects.Initial(content);
            }
        }
    }
}
