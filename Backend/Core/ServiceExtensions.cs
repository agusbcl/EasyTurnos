﻿using Core.Behaviors;
using Core.Services;
using Core.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCoreServiceCollection(this IServiceCollection services)
        {
            // FluentValidation configuration
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Professional
            services.AddScoped<IProfessionalService, ProfessionalService>();
            services.AddScoped<ISlotService, SlotService>();
            services.AddScoped<IClientService, ClientService>();
            //Appointment
            services.AddScoped<IAppointmentService, AppointmentService>();
            //Payment
            services.AddScoped<IPaymentService, PaymentService>();

            // Authentication
            services.AddScoped<IAuthenticationService, AuthenticationService>();
          
            // Validation Behavior
            services.AddTransient(typeof(IValidationBehavior<>), typeof(ValidationBehavior<>));

            return services;
        }
    }
}
