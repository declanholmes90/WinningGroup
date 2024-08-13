using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using LeapActivityTracker.Core.Common.Behaviours;
using MediatR;
using WinningGroup.Core.Activity.Queries;
using WinningGroup.Infrastructure;
using WinningGroup.Infrastructure.Repositories;
using WinningGroupAPI.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((container) =>
    {
        container.RegisterType<ProductsRepository>().As<IProductsRepository>().InstancePerLifetimeScope();
        container.RegisterType<ProductsDBConnection>().As<IProductsDBConnection>().InstancePerLifetimeScope();
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(new[] { typeof(AutoMapperProfile), typeof(GetSummaryOfProductsProfile) });
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetSummaryOfProductsQueryHandler).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<GetSummaryOfProductsQuery>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
