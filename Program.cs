using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(config.GetConnectionString("localServer"), options =>
        options.CommandTimeout(50)));

builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<SalesService>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();
app.UseCors("AllowAll");

// Person
app.MapGet("/person/GetAll", async (PersonService personService) =>
{
    var persons = await personService.GetAll();
    return Results.Ok(persons);
});

app.MapGet("/person/GetByName", async (PersonService personService, [FromQuery] string name) =>
{
    var person = await personService.GetPersonByName(name);
    return Results.Ok(person);
});

app.MapGet("/person/GetByEmpType", async (PersonService personService, [FromQuery] string emplType) =>
{
    var persons = await personService.GetPersonByPersonType(emplType);
    return Results.Ok(persons);
});

app.MapGet("/person/GetByNameAndType", async (PersonService personService, [FromQuery] string name, string emplType) =>
{
    var person = await personService.GetPersonByNameAndPersonType(name, emplType);
    return Results.Ok(person);
});


// Product
app.MapGet("/product/GetAll", async (ProductService productService) =>
{
    var products = await productService.GetAll();
    return Results.Ok(products);
});

app.MapGet("/product/GetByName", async (ProductService productService, [FromQuery] string name) =>
{
    var product = await productService.GetProductByName(name);
    return Results.Ok(product);
});

app.MapGet("/product/GetByCategoryType", async (ProductService productService, [FromQuery] string category) =>
{
    var products = await productService.GetProductsByCategoryType(category);
    return Results.Ok(products);
});

//Sales
app.MapGet("/sales/GetAll", async (SalesService salesService) =>
{
    var sales = await salesService.GetAll();
    return Results.Ok(sales);
});

app.MapGet("/sales/GetByName", async (SalesService salesService, [FromQuery] string name) =>
{
    var person = await salesService.GetByName(name);
    return Results.Ok(person);
});

app.Run();