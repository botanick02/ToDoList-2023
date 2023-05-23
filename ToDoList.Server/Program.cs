using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.Extensions.Options;
using ToDoList.BLL;
using ToDoList.DAL;
using ToDoList.Server;
using ToDoList.Server.GraphQL;
using ToDoList.Server.GraphQL.Categories;
using ToDoList.Server.HttpContextHelpers;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.RegisterDALDependencies(builder.Configuration);
builder.Services.RegisterBLLDependencies();
builder.Services.AddSingleton<HeaderSourceProviderParser>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .WithMethods("POST", "OPTIONS")
               .WithOrigins("http://localhost:3000")
               .AllowCredentials();
    });
});



builder.Services.AddGraphQL(b => b
    .AddSchema<ToDoListSchema>()
    .AddGraphTypes(typeof(ToDoListSchema).Assembly)
    .AddAutoClrMappings()
    .AddSystemTextJson());


builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

app.UseCors("DefaultPolicy");
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
