using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Core.IRepositories;
using StudentManagement.Core.IServices;
using StudentManagement.Resources.Repositories;
using StudentManagement.Services.Services;

namespace StudentManagement.Utilities
{
    public static class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Context accesor
            // this is for accessing the http context by interface in view level
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services

            services.AddScoped<IStudentServices,StudentServices>();

            #endregion
            #region Repository

            services.AddScoped<IStudentRepositories , StudentRepositories>();

            #endregion
        }

    }
    }
