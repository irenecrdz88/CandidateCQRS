using Application.Contracts.Persistence;
using Application.Features.Candidates.Commands.CreateCandidate;
using Application.Features.Candidates.Commands.DeleteCandidate;
using Application.Features.Candidates.Commands.UpdateCandidate;
using Application.Features.Candidates.Queries;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());


            //services.AddAutoMapper(typeof(Candidate), typeof(CandidatesVm));

            return services;
        }
    }
}
