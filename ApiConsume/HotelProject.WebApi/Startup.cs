using HotelProject.BusinnessLayer.Abstract;
using HotelProject.BusinnessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi
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
            services.AddDbContext<Context>();

            services.AddScoped<IStaffDal, EFStaffDal>();
            services.AddScoped<IStaffService, StaffManager>();

            services.AddScoped<IServicesDal, EFServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<IRoomDal, EFRoomDal>();
            services.AddScoped<IRoomService, RoomManager>();

            services.AddScoped<ITestimonialDal, EFTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<ISubscribeDal, EFSubscribeDal>();
            services.AddScoped<ISubscribeService, SubscribeManager>();

            services.AddScoped<IAboutDal, EFAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IBookingDal, EFBookingDal>();
            services.AddScoped<IBookingService, BookingManager>();

            services.AddScoped<IContactDal, EFContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IGuestDal, EFGuestDal>();
            services.AddScoped<IGuestService, GuestManager>();

            services.AddScoped<ISendMessageDal, EFSendMessageDal>();
            services.AddScoped<ISendMessageService, SendMessageManager>();

            services.AddScoped<IMessageCategoryDal, EFMessageCategoryDal>();
            services.AddScoped<IMessageCategoryService, MessageCategoryManager>();

            services.AddScoped<IWorkLocationDal, EFWorkLocationDal>();
            services.AddScoped<IWorkLocationService, WorkLocationManager>();

            services.AddScoped<IAppUserDal, EFAppUserDal>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddAutoMapper(typeof(Startup));

            //services.AddScoped<>();


            services.AddCors(opt =>
            {
                opt.AddPolicy("OtelApiCors", opts =>
                {
                    opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelProject.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelProject.WebApi v1"));
            }

            app.UseRouting();
            app.UseCors("OtelApiCors");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
