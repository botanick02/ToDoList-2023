using AutoMapper;
using GraphQL;
using Microsoft.AspNetCore.Hosting;
using ToDoList;
using ToDoList.DAL;
using ToDoList.Server.GraphQL;
using ToDoList.Server.GraphQL.Tasks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQL(b => b
    .AddSchema<TasksSchema>()
    .AddAutoClrMappings()
    .AddSystemTextJson());

// Add services to the container.
builder.Services.AddControllersWithViews();

var config = AutoMapperConfig.Configure();
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);

DALConfiguration.ConfigureDALServices(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseGraphQL("/graphql");
app.UseGraphQLAltair();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
